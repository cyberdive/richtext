Imports RichTextBoxEx

Imports System.Drawing.Printing
Imports System.ComponentModel

Public Class Form1

	'   font-size change options
	Private Enum SelectionOption
		NoAction
		Add1
		Subtract1
		MultiplyBy2
		DivideBy2
	End Enum

	'    private variables
	Private PageSettings As PageSettings, PrinterSettings As PrinterSettings
	Private KeyPressed As Keys

	'    Set up events for underlying rich-text box
	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
	'   uncomment following line to start with continuous spell-check DISabled
	'CheckBox15.Checked = False
	'   catch certain events of underlying rich-text box
	With RichTextBoxEx1.rtb
		AddHandler .DoubleClick, AddressOf RTB_DoubleClick
		AddHandler .SelectionChanged, AddressOf RTB_SelectionChanged
		AddHandler .TextChanged, AddressOf RTB_SelectionChanged
		AddHandler .HScroll, AddressOf RTB_SelectionChanged
		AddHandler .VScroll, AddressOf RTB_SelectionChanged
		.EnableAutoDragDrop = True : .AllowDrop = True
	End With
	'   prepare for print setup
	With PageSetupDialog1
		'   prepare set-up dialog
		.PageSettings = New System.Drawing.Printing.PageSettings()
		.PrinterSettings = New System.Drawing.Printing.PrinterSettings()
		If .ShowDialog() = Windows.Forms.DialogResult.OK Then
			'    set page/printer settings
			PageSettings = .PageSettings : PrinterSettings = .PrinterSettings
		End If
		'   set right-margin of extended rich-text box
		RichTextBoxEx1.rtb.SetRightMarginToPrinterWidth(.PageSettings)
		'   reset printer width in case of approximation error
		RichTextBoxEx1.rtb.SetPrinterWidthToRightMargin(.PageSettings)
		'   set file path
		RichTextBoxEx1.FilePath = Application.CommonAppDataPath
	End With
	End Sub

	'   Size extended rich-text box to form
	Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
	RichTextBoxEx1.SetBounds( _
		0, 0, Me.ClientSize.Width, _
			Me.ClientSize.Height - CheckBox1.Height _
				- CheckBox15.Height - CheckBox2.Height -TextBox2.Height)
	CheckBox1.SetBounds( _
		(Me.ClientSize.Width - CheckBox1.Width) \ 2, RichTextBoxEx1.Bottom, _
			CheckBox1.Width, CheckBox1.Height)
	CheckBox15.SetBounds( _
		(Me.ClientSize.Width - CheckBox15.Width) \ 2, CheckBox1.Bottom, _
			CheckBox15.Width, CheckBox15.Height)
	CheckBox2.SetBounds( _
		(Me.ClientSize.Width - CheckBox2.Width) \ 2, CheckBox15.Bottom, _
			CheckBox2.Width, CheckBox2.Height)
	TextBox2.SetBounds( _
		(Me.ClientSize.Width - TextBox2.Width) \ 2, CheckBox2.Bottom, _
			TextBox2.Width, TextBox2.Height)
	RichTextBoxEx1.rtb.ShowSelectionMargin = True
	RichTextBoxEx1.rtb.WordWrap = False
	RichTextBoxEx1.IsTextChanged = False
	End Sub

	'   Enable/disable spell-check
	Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) _
		Handles CheckBox1.CheckedChanged
	RichTextBoxEx1.AllowSpellCheck = DirectCast(sender, CheckBox).Checked
	End Sub

	'   Enable/disable continuous spell-check
	Private Sub CheckBox15_CheckedChanged(sender As System.Object, e As System.EventArgs) _
		Handles CheckBox15.CheckedChanged
	RichTextBoxEx1.IsSpellCheckContinuous = DirectCast(sender, CheckBox).Checked
	End Sub

	'   Enable/disable custom links
	Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) _
		Handles CheckBox2.CheckedChanged
	RichTextBoxEx1.DoCustomLinks = DirectCast(sender, CheckBox).Checked
	End Sub

	'   Catch events from the underlying rich-text box

	Private Sub RTB_DoubleClick(sender As Object, e As System.EventArgs)
	'   print text
	Dim PrintDocument As PrintDocument = New PrintDocument()
	With PrintDialog1
		'   invoke print dialog
		.AllowPrintToFile = True : .AllowSomePages = True
		.AllowCurrentPage = True : .AllowSelection = True
		With .PrinterSettings
			.MinimumPage = 1 : .MaximumPage = Integer.MaxValue
			.FromPage = 1 : .ToPage = Integer.MaxValue
		End With
		If .ShowDialog() = Windows.Forms.DialogResult.OK Then
			'   prepare to print
			If .PrinterSettings.PrintToFile Then
				'   handle printing to file (get file name)
				Dim FileDialog As New SaveFileDialog()
				FileDialog.AddExtension = True : FileDialog.DefaultExt = "prn"
				FileDialog.OverwritePrompt = True : FileDialog.RestoreDirectory = True
				FileDialog.InitialDirectory = Application.StartupPath
				If FileDialog.ShowDialog() <> Windows.Forms.DialogResult.OK Then
					Exit Sub 'don't print
				 Else
					.PrinterSettings.PrintFileName = FileDialog.FileName
				End If
			End If
			'  adjust to new settings
			PrinterSettings = .PrinterSettings : PrintDocument.PrinterSettings = PrinterSettings
			RichTextBoxEx1.rtb.SetRightMarginToPrinterWidth(PageSettings)
			'   preview
			PrintPreviewDialog1.Document = PrintDocument
			Dim PrintPreviewResult As DialogResult = _
				RichTextBoxEx1.rtb.PrintPreview(PrintPreviewDialog1)
			If PrintPreviewResult = Windows.Forms.DialogResult.OK Then
				'   print
				RichTextBoxEx1.rtb.Print(PrintDocument)
			End If
		End If
	End With
	End Sub

	Private Sub RTB_SelectionChanged(sender As Object, e As System.EventArgs)
	'   display character codes of selected text and scroll position
	With RichTextBoxEx1.rtb
		Dim s As String = .SelectedText
		Dim ss As Integer = .SelectionStart, sl As Integer = .SelectionLength
		Dim c As String = "Maximum Text Width: " & .GetMaximumWidth() _
			& ControlChars.CrLf & "Scroll Position: " _
			& .GetScrollPosition.X & ", " & .GetScrollPosition.Y
		c &= ControlChars.CrLf & "Codes for SELECTED characters: "
		For Index As Integer = 0 To sl - 1
			c &= Char.ConvertToUtf32(s, Index) & " "
		Next
		c = c.Trim(): TextBox2.Text = c
	End With
	End Sub

	'   Events for extended rich-text box

	Private Sub RichTextBoxEx1_InsertRtfText(sender As Object, _
		e As RichTextBoxEx.InsertRtfTextEventArgs)  
	'   take care of allowing fractions and printing
	If e.KeyEventArgs.Control Then
		Select Case e.KeyEventArgs.KeyCode
			Case Keys.D2, Keys.NumPad2
				'   [Ctrl] + [2] = 1/2 ("½")
				e.RtfText = "½"
			Case Keys.D3, Keys.NumPad3
				'   [Ctrl] + [3] = 3/4 ("¾")
				e.RtfText = "¾"
			Case Keys.D4, Keys.NumPad4
				'   [Ctrl] + [4] = 1/4 ("¼")
				e.RtfText = "¼"
			Case Keys.Enter
				If e.KeyEventArgs.Shift Then
					'   [Ctrl] + [Shift] + [Enter] = page break
					e.RtfText = "\page"
				End If
			Case Keys.P
				'   [Ctrl] + [P] = print text
				RTB_DoubleClick(RichTextBoxEx1.rtb, New EventArgs())
				e.RtfText = "" : e.KeyEventArgs.SuppressKeyPress = True
			Case Keys.S
				'   [Ctrl] + [P] = save text
				RichTextBoxEx1.SaveFile()
				e.RtfText = "" : e.KeyEventArgs.SuppressKeyPress = True
			Case Keys.O
				'   [Ctrol] + [O] = load text
				Dim cea As CancelEventArgs = New CancelEventArgs()
				Form1_Closing(Me, cea) 'see if we must save existing text
				If Not cea.Cancel Then
					RichTextBoxEx1.LoadFile()
				End If
				e.RtfText = "" : e.KeyEventArgs.SuppressKeyPress = True
			Case Keys.Oemcomma, Keys.OemPeriod
				'   [Ctrl] + [.] = add 1 point to font size,
				'   [Ctrl] + [Shift] + [>] = double font size
				'   [Ctrl] + [,] = subtract 1 point from font size,
				'   [Ctrl] + [Shift] + [<] = halve font size
				Dim Action As SelectionOption = SelectionOption.NoAction
				If e.KeyEventArgs.KeyCode = Keys.Oemcomma Then
					'   smaller font
					If e.KeyEventArgs.Shift Then
						Action = SelectionOption.DivideBy2
					 Else
						Action = SelectionOption.Subtract1
					End If 
				 Else
					'   bigger font
					If e.KeyEventArgs.Shift Then
						Action = SelectionOption.MultiplyBy2
					 Else
						Action = SelectionOption.Add1
					End If
				End If
				'   change font size
				RichTextBoxEx1.EditWithLinksUnprotected(Action)
				If Action = SelectionOption.NoAction Then
					Beep() : MessageBox.Show("Font size can't go any further!")
				End If
				KeyPressed = 0 : e.RtfText = "" : e.KeyEventArgs.SuppressKeyPress = True
		End Select
	End If
	End Sub

	Private Sub RichTextBoxEx1_SmartRtfText(sender As Object, e As SmartRtfTextEventArgs) _
		
	With RichTextBoxEx1
		'   get preceding text
		Dim PrecedingText As String = ""
		If .rtb.SelectionStart > 1 Then
			PrecedingText = .Text.Substring(.rtb.SelectionStart - 2, 2)
		End If
		'   see if we're to make a fraction
		Select Case e.KeyPressEventArgs.KeyChar
			Case "2"c
				If PrecedingText = "1/" Then
					'   "1/2" = "½"
					e.RtfText = "½" : e.PrecedingCharacterCount = 2
				End If
			Case "4"c
				If PrecedingText = "1/"
					'   "1/4" = "¼"
					e.RtfText = "¼" : e.PrecedingCharacterCount = 2
				 ElseIf PrecedingText = "3/"
					'   "3/4" = "¾"
					e.RtfText = "¾" : e.PrecedingCharacterCount = 2
				End If
		End Select
	End With
	End Sub

	Private Sub RichTextBoxEx1_HyperlinkClicked(sender As Object, _
		e As CustomLinkInfoEventArgs) 
	'   see if user wants to follow link
	If e.CustomLinkInfo IsNot Nothing Then
		Dim Result As DialogResult = _
			MessageBox.Show("This link goes to """ & e.CustomLinkInfo.Hyperlink & """." _
					& ControlChars.CrLf & "Follow it?", _
				"Link Clicked", MessageBoxButtons.YesNo)
		If Result = DialogResult.Yes Then
			Process.Start(e.CustomLinkInfo.Hyperlink)
		End If
	End If
	End Sub

	Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
	If RichTextBoxEx1.IsTextChanged Then
		'   if recent changes were made, should we save them?
		Dim IsTextSaved As Boolean = False
		Dim Result As DialogResult = _
			MessageBox.Show("The text has been modified. Save it?", _
				"Text Changed!", MessageBoxButtons.YesNoCancel)
		Select Case Result
		  Case DialogResult.Cancel
			  '   don't quit program
			  e.Cancel = True : Exit Sub
		  Case DialogResult.Yes
			  '   exit--save text
			  IsTextSaved = RichTextBoxEx1.SaveFile()
		  Case DialogResult.No
			  '   exit--don't save text
		End Select
		'   have changes been saved?
		If IsTextSaved Then
			MessageBox.Show("Changes saved.")
		 Else
			MessageBox.Show("Changes discarded.")
		End If
	End If
	End Sub

	Private Sub RichTextBoxEx1_EditingWithLinksUnprotected( _
		sender As Object, e As ParameterEventArgs) _
			
	'   change size of highlighted text
	'      [Ctrl] + [,] = subtract 1 point, [Ctrl] + [.] = add 1 point,
	'      [Ctrl] + [Shift] + [<] = divdide by 2, [Ctrl] + [Shift] + [>] = multiply by 2
	With RichTextBoxEx1.rtb
		'   get font
		'.SelectedText = "ME" : Exit Sub
		Dim font As Font = .SelectionFont
		If font Is Nothing Then
			'   mixed font--get font at beginning of selection
			.SetRedrawMode(False)
			Dim length As Integer = .SelectionLength
			.SelectionLength = 0 : font = .SelectionFont
			.SelectionLength = length
			.SetRedrawMode(True)
		End If
		'   change font size
		Try
			Select Case DirectCast(e.Parameters, SelectionOption)
			    Case SelectionOption.Add1
					.SelectionFont = New Font(font.Name, font.SizeInPoints + 1D, font.Style)
			    Case SelectionOption.Subtract1
					.SelectionFont = New Font(font.Name, font.SizeInPoints - 1D, font.Style)
			    Case SelectionOption.MultiplyBy2
					.SelectionFont = New Font(font.Name, font.SizeInPoints * 2D, font.Style)
			    Case SelectionOption.DivideBy2
					.SelectionFont = New Font(font.Name, font.SizeInPoints / 2D, font.Style)
			End Select
		 Catch ex As Exception
			'   can't go further
			e.Parameters = SelectionOption.NoAction
		End Try
	End With
	End Sub

	Private Sub RichTextBoxEx1_DragDrop(sender As Object, e As DragEventArgs) _
		
	With RichTextBoxEx1
		Dim x = 0
		Dim y = 1 \ x
		If .AutoDragDropInProgress Then
			Beep()
			Exit Sub 'internal text-box drop--don't handle this
		End If
		If e.Data.GetDataPresent(GetType(String)) Then
			.rtb.SelectedText = e.Data.GetData(GetType(String)).ToString
		End If
		e.Effect = DragDropEffects.None 'indicate no further handling necessary
	End With
	End Sub

	Private Sub TextBox2_MouseMove(sender As Object, e As MouseEventArgs) _
		Handles TextBox2.MouseMove
	If e.Button <> MouseButtons.None _
			AndAlso Not TextBox2.DisplayRectangle.Contains(e.X, e.Y) Then
		TextBox2.DoDragDrop(RichTextBoxEx1.rtb.EscapedRTFText(TextBox2.Text), _
			DragDropEffects.Move)
	End If
	End Sub

	Private Sub RichTextBoxEx1_DragOver(sender As Object, e As DragEventArgs) _
		
	Const CtrlKeyPressed As Integer = 8
	If e.KeyState And CtrlKeyPressed Then
		e.Effect = DragDropEffects.Copy
	 Else
		e.Effect = DragDropEffects.Move
	End If
	End Sub
End Class
