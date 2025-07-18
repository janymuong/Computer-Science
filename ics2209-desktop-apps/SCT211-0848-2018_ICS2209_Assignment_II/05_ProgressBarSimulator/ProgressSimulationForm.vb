' SCT211-O848/2018
' Jany Muong
' 05_ProgressSimulation project: Simulate a lengthy process using a progress bar and a timer control

Imports System.Windows.Forms

Public Class ProgressSimulationForm
    Inherits Form

    ' Initialize controls
    Private WithEvents MyProgressBar As New ProgressBar()
    Private WithEvents ProgressLabel As New Label()
    Private WithEvents ProgressTimer As New Timer()

    ' Constructor
    Public Sub New()
        ' Set up MainForm - with properties
        Me.Text = "Progress Simulation"
        Me.Size = New Size(480, 270)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' ProgressBar - with properties lisetd
        MyProgressBar.Name = "MyProgressBar"
        MyProgressBar.Location = New Point(20, 20)
        MyProgressBar.Size = New Size(260, 20)
        MyProgressBar.Minimum = 0
        MyProgressBar.Maximum = 100
        MyProgressBar.Value = 0

        ' Label with props:
        ProgressLabel.Name = "ProgressLabel"
        ProgressLabel.Location = New Point(20, 50)
        ProgressLabel.Size = New Size(260, 20)
        ProgressLabel.Text = "Progress: 0%"

        ' Set up Timer
        ProgressTimer.Enabled = True
        ProgressTimer.Interval = 1000 ' 1 second

        ' Add controls to MainForm
        Me.Controls.Add(MyProgressBar)
        Me.Controls.Add(ProgressLabel)

        ' Start progress simulation
        ProgressTimer.Start()
    End Sub

    ' Event handler for progressTimer tick
    Private Sub ProgressTimer_Tick(sender As Object, e As EventArgs) Handles ProgressTimer.Tick
        ' Increase progress value by 10 until it reaches 100
        If MyProgressBar.Value < MyProgressBar.Maximum Then
            MyProgressBar.Value += 10
            ProgressLabel.Text = "Progress: " & MyProgressBar.Value & "%"
        Else
            ' Stop the timer when progress reaches 100%
            ProgressTimer.Stop()
        End If
    End Sub

End Class
