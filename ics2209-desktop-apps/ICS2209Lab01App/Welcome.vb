' SCT211-0848/2018
' Jany Muong

' Form One
' ICS 2209: Design and Implementation Computer Apps
' Computer Scinece

Imports System.Windows.Forms

Public Class Welcome

    ' set proper tool tips;
    Private ToolTipWelcome As New ToolTip()
    Private Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set tooltips for controls
        ToolTipWelcome.SetToolTip(Me, "Click to maximize form and change background color")
        ToolTipWelcome.SetToolTip(LoadObjectDemoButtton, "Click to load Object Demonstrations form")
        ToolTipWelcome.SetToolTip(ExitButton, "Click to exit the application")
    End Sub

    Private Sub Welcome_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        ' maximize the form and change background color to red when clicked
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.Red
    End Sub

    Private Sub LoadObjectDemoButtton_Click(sender As Object, e As EventArgs) Handles LoadObjectDemoButtton.Click
        Dim objectDemoForm As New ObjectDemonstrationsForm()
        objectDemoForm.Show()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        ' terminate the application/welcome form
        Me.Close()
    End Sub
End Class
