' SCT211-O848/2018
' Jany Muong
' 01_FormSizeSetter project: sub procedure that sets the vertical and horizontal sizes

Imports System.Windows.Forms

Public Class DemoForm
    Inherits Form

    Private Sub SetFormSize()
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width

        ' set vertical size of DemoForm to half the screen height
        Me.Height = screenHeight \ 2

        ' set horizontal size of DemoForm to three-quarters the screen width
        Me.Width = screenWidth * 0.75
    End Sub

    ' constructor - call the SetFormSize method
    ' when the form is initialized
    ' on load
    Public Sub New()
        InitializeComponent()
        SetFormSize()
    End Sub

End Class
