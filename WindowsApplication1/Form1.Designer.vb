<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	 Inherits System.Windows.Forms.Form

	 'Form overrides dispose to clean up the component list.
	 <System.Diagnostics.DebuggerNonUserCode()> _
	 Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		  Try
				If disposing AndAlso components IsNot Nothing Then
					 components.Dispose()
				End If
		  Finally
				MyBase.Dispose(disposing)
		  End Try
	 End Sub

	 'Required by the Windows Form Designer
	 Private components As System.ComponentModel.IContainer

	 'NOTE: The following procedure is required by the Windows Form Designer
	 'It can be modified using the Windows Form Designer.  
	 'Do not modify it using the code editor.
	 <System.Diagnostics.DebuggerStepThrough()> _
	 Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
		Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
		Me.CheckBox1 = New System.Windows.Forms.CheckBox()
		Me.CheckBox2 = New System.Windows.Forms.CheckBox()
		Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.CheckBox15 = New System.Windows.Forms.CheckBox()
		Me.RichTextBoxEx1 = New RichTextBoxEx.RichTextBoxEx()
		Me.SuspendLayout
		'
		'PrintDialog1
		'
		Me.PrintDialog1.UseEXDialog = true
		'
		'PrintPreviewDialog1
		'
		Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
		Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
		Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
		Me.PrintPreviewDialog1.Enabled = true
		Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"),System.Drawing.Icon)
		Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
		Me.PrintPreviewDialog1.Visible = false
		'
		'CheckBox1
		'
		Me.CheckBox1.AutoSize = true
		Me.CheckBox1.Checked = true
		Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBox1.Location = New System.Drawing.Point(226, 192)
		Me.CheckBox1.Name = "CheckBox1"
		Me.CheckBox1.Size = New System.Drawing.Size(119, 17)
		Me.CheckBox1.TabIndex = 2
		Me.CheckBox1.Text = "Enable &Spell Check"
		Me.CheckBox1.UseVisualStyleBackColor = true
		'
		'CheckBox2
		'
		Me.CheckBox2.AutoSize = true
		Me.CheckBox2.Checked = true
		Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBox2.Location = New System.Drawing.Point(226, 233)
		Me.CheckBox2.Name = "CheckBox2"
		Me.CheckBox2.Size = New System.Drawing.Size(125, 17)
		Me.CheckBox2.TabIndex = 1
		Me.CheckBox2.Text = "Enable &Custom Links"
		Me.CheckBox2.UseVisualStyleBackColor = true
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(104, 256)
		Me.TextBox2.Multiline = true
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.TextBox2.Size = New System.Drawing.Size(400, 54)
		Me.TextBox2.TabIndex = 4
		'
		'CheckBox15
		'
		Me.CheckBox15.AutoSize = true
		Me.CheckBox15.Checked = true
		Me.CheckBox15.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBox15.Location = New System.Drawing.Point(226, 214)
		Me.CheckBox15.Name = "CheckBox15"
		Me.CheckBox15.Size = New System.Drawing.Size(133, 17)
		Me.CheckBox15.TabIndex = 5
		Me.CheckBox15.Text = "Continous Spell Check"
		Me.CheckBox15.UseVisualStyleBackColor = true
		'
		'RichTextBoxEx1
		'
		Me.RichTextBoxEx1.AllowDefaultInsertText = true
		Me.RichTextBoxEx1.AllowDefaultSmartText = true
		Me.RichTextBoxEx1.AllowHyphenation = true
		Me.RichTextBoxEx1.AllowLists = true
		Me.RichTextBoxEx1.AllowPictures = true
		Me.RichTextBoxEx1.AllowSpellCheck = true
		Me.RichTextBoxEx1.AllowSymbols = true
		Me.RichTextBoxEx1.AllowTabs = true
		Me.RichTextBoxEx1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
		Me.RichTextBoxEx1.DoCustomLinks = true
		Me.RichTextBoxEx1.FilePath = ""
		Me.RichTextBoxEx1.IsSpellCheckContinuous = true
		Me.RichTextBoxEx1.IsTextChanged = true
		Me.RichTextBoxEx1.KeepHypertextOnRemove = false
		Me.RichTextBoxEx1.Location = New System.Drawing.Point(0, 0)
		Me.RichTextBoxEx1.MaintainSelection = false
		Me.RichTextBoxEx1.Name = "RichTextBoxEx1"
		Me.RichTextBoxEx1.RightMargin = 739
		Me.RichTextBoxEx1.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"\"& _ 
    "viewkind4\uc1\pard\fs20\par"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
		Me.RichTextBoxEx1.SetColorWithFont = true
		Me.RichTextBoxEx1.ShowRuler = true
		Me.RichTextBoxEx1.ShowToolStrip = true
		Me.RichTextBoxEx1.Size = New System.Drawing.Size(650, 186)
		Me.RichTextBoxEx1.SkipLinksOnReplace = true
		Me.RichTextBoxEx1.TabIndex = 6
		Me.RichTextBoxEx1.UnitsForRuler = RichTextBoxEx.TextRuler.UnitType.Inches
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(662, 312)
		Me.Controls.Add(Me.RichTextBoxEx1)
		Me.Controls.Add(Me.CheckBox15)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.CheckBox2)
		Me.Controls.Add(Me.CheckBox1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	 Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
	 Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
	 Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
	Friend WithEvents CheckBox15 As CheckBox
	Friend WithEvents RichTextBoxEx1 As RichTextBoxEx.RichTextBoxEx
End Class
