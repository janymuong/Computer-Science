Imports Npgsql

Public Class LoginForm
    ' Shared property to store the logged-in user's ID
    Public Shared LoggedInUserID As Integer = -1 ' Initialize with a default value

    Private connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    ' Login button click event
    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim identifier As String = LoginIdentifierTextBox.Text
        Dim password As String = LoginPasswordMaskedTextBox.Text

        ' Validate input fields
        If String.IsNullOrWhiteSpace(identifier) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter your username/email and password.", "HeFits - Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' Check if the identifier is a username or an email
                Dim identifierType As String = "username"
                If identifier.Contains("@"c) Then
                    identifierType = "email"
                End If

                ' Query to check credentials and retrieve user ID
                Dim query As String = $"SELECT UserID FROM users WHERE {identifierType} = @identifier AND password = @password"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@identifier", identifier)
                    cmd.Parameters.AddWithValue("@password", password)
                    Dim userId As Object = cmd.ExecuteScalar()

                    If userId IsNot Nothing Then
                        ' Store the user ID in the shared property
                        LoginForm.LoggedInUserID = Convert.ToInt32(userId)

                        ' Open the dashboard form or perform actions after successful login
                        Dim dashboardForm As New HeFitsDashBoardForm(LoginForm.LoggedInUserID)
                        dashboardForm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Invalid username/email or password.", "HeFits - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoginPagePictureBox_Click(sender As Object, e As EventArgs) Handles LoginPagePictureBox.Click
        ' Handle click event for login page picture box if needed
    End Sub

    Private Sub SignupLinkLabel_Click(sender As Object, e As EventArgs) Handles SignupLinkLabel.Click
        ' Open the signup form when the signup link is clicked
        Dim signupForm As New SignupForm()
        signupForm.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        ' Handle enter event for group box if needed
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load the image
            Dim imagePath As String = System.IO.Path.Combine(Application.StartupPath, "img\login-img0.png")
            Dim image As Image = Image.FromFile(imagePath)

            ' Set the PictureBox properties
            LoginPictureBox.SizeMode = PictureBoxSizeMode.Zoom
            LoginPictureBox.Image = image
        Catch ex As Exception
            ' Handle any exceptions
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExitLoginButton_Click(sender As Object, e As EventArgs) Handles ExitLoginButton.Click
        ' log off system;
        Me.Close()

        Dim startupForm As New StartupForm()
        startupForm.Show()
    End Sub

End Class
