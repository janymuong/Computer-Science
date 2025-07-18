Imports System.Drawing.Drawing2D

Public Class StartupForm
    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load the image
            Dim imagePath As String = System.IO.Path.Combine(Application.StartupPath, "img\HeFitsLogo.jpg")
            Dim image As Image = Image.FromFile(imagePath)

            ' Set the PictureBox properties
            LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
            LogoPictureBox.Image = image
        Catch ex As Exception
            ' Handle any exceptions
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StartupButton_Click(sender As Object, e As EventArgs) Handles StartupButton.Click
        ' Open the login form directly
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Hide() ' Optionally hide the startup form
    End Sub

    Private Sub ExitHeFitsButton_Click(sender As Object, e As EventArgs) Handles ExitHeFitsButton.Click
        ' Terminate the application/welcome form
        Me.Close()
    End Sub

    Private Sub StartupForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Define the gradient colors
        Dim startColor As Color = Color.FromArgb(255, 0, 102, 204) ' Dark blue or green
        Dim endColor As Color = Color.FromArgb(255, 255, 153, 51) ' Orange or vibrant green

        ' Create a LinearGradientBrush for the background
        Dim gradientBrush As New LinearGradientBrush(Me.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical)

        ' Fill the form background with the gradient
        e.Graphics.FillRectangle(gradientBrush, Me.ClientRectangle)
    End Sub
    Public Sub New()
        InitializeComponent()

        ' Disable the control box (close, maximize, minimize buttons)
        Me.ControlBox = False
    End Sub

End Class
