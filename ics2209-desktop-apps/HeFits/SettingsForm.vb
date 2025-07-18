Imports Npgsql
Imports System.IO

Public Class SettingsForm
    Private ReadOnly loggedInUserID As Integer
    Private ReadOnly connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserID = userId
        LoadUserData()
    End Sub

    ' Load user data such as name and profile picture
    Private Sub LoadUserData()
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT username FROM users WHERE userid = @userid"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    Dim reader As NpgsqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim username As String = reader.GetString(0)

                        ' Display the user's name
                        UserNameLabel.Text = username
                    End If
                End Using
            End Using

            ' Load the generic profile picture
            Dim imagePath As String = Path.Combine(Application.StartupPath, "img\profilepicture.jpg")
            Dim image As Image = Image.FromFile(imagePath)

            ' Set the PictureBox properties
            ProfilePictureBox.SizeMode = PictureBoxSizeMode.Zoom
            ProfilePictureBox.Image = image

        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "HeFits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Logout button click event
    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        ' Implement logout functionality (e.g., close current form and show login form)
        Dim loginForm As New LoginForm
        loginForm.Show()
        Close()
    End Sub

    ' Submit Feedback button click event
    Private Sub SubmitFeedbackButton_Click(sender As Object, e As EventArgs) Handles SubmitFeedbackButton.Click
        ' Get the feedback text from the feedback textbox
        Dim feedbackText = FeedbackTextBox.Text

        ' Insert the feedback into the database
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query = "INSERT INTO feedback (userid, feedback_text) VALUES (@userid, @feedback)"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    cmd.Parameters.AddWithValue("@feedback", feedbackText)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Feedback submitted successfully!", "HeFits - Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Clear the feedback textbox after submission
                    FeedbackTextBox.Clear()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error submitting feedback: " & ex.Message, "HeFits - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackToDashboardButton_Click(sender As Object, e As EventArgs) Handles BackToDashboardButton.Click
        Dim dashboardForm As New HeFitsDashBoardForm(loggedInUserID)
        dashboardForm.Show()

        ' get out of Settings form;
        Me.Close()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load the image
            Dim imagePath As String = System.IO.Path.Combine(Application.StartupPath, "img\hefits-settings.jpg")
            Dim image As Image = Image.FromFile(imagePath)

            ' Set the PictureBox properties
            HeFitsSettingsPictureBox.SizeMode = PictureBoxSizeMode.Zoom
            HeFitsSettingsPictureBox.Image = image
        Catch ex As Exception
            ' Handle any exceptions
            MessageBox.Show("Error loading image: " & ex.Message, "HeFits - file Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FeedbackTextBox_TextChanged(sender As Object, e As EventArgs) Handles FeedbackTextBox.TextChanged

    End Sub
End Class
