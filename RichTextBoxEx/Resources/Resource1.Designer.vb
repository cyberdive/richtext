﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Resource1
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("RichTextBoxEx.Resource1", GetType(Resource1).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to First Line Indent.
        '''</summary>
        Friend Shared ReadOnly Property First_Line_Indent() As String
            Get
                Return ResourceManager.GetString("First_Line_Indent", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Hanging Indent.
        '''</summary>
        Friend Shared ReadOnly Property Hanging_Indent() As String
            Get
                Return ResourceManager.GetString("Hanging_Indent", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Left Indents.
        '''</summary>
        Friend Shared ReadOnly Property Left_Indents() As String
            Get
                Return ResourceManager.GetString("Left_Indents", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Left Margin.
        '''</summary>
        Friend Shared ReadOnly Property Left_Margin() As String
            Get
                Return ResourceManager.GetString("Left_Margin", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Right Indent.
        '''</summary>
        Friend Shared ReadOnly Property Right_Indent() As String
            Get
                Return ResourceManager.GetString("Right_Indent", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Right Margin.
        '''</summary>
        Friend Shared ReadOnly Property Right_Margin() As String
            Get
                Return ResourceManager.GetString("Right_Margin", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Tab.
        '''</summary>
        Friend Shared ReadOnly Property Tab() As String
            Get
                Return ResourceManager.GetString("Tab", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
