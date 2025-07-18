Imports Npgsql
Public Class SignupForm
    Private connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    Private Sub SignupButton_Click(sender As Object, e As EventArgs) Handles SignupButton.Click
        Dim username As String = SignupUsernameTextBox.Text
        Dim password As String = SignupPasswordMaskedTextBox.Text
        Dim email As String = SignupEmailTextBox.Text

        ' Validate input fields
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) OrElse String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' Check if the username already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
                Using checkCmd As New NpgsqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@username", username)
                    Dim userCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If userCount > 0 Then
                        MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' Insert new user into the database
                Dim insertQuery As String = "INSERT INTO users (username, password, email) VALUES (@username, @password, @email)"
                Using insertCmd As New NpgsqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@username", username)
                    insertCmd.Parameters.AddWithValue("@password", password)
                    insertCmd.Parameters.AddWithValue("@email", email)
                    insertCmd.ExecuteNonQuery()

                    MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Clear input fields
                    ClearFields()

                    ' Close the SignupForm
                    Me.Close()

                    ' Create an instance of the LoginForm
                    Dim loginForm As New LoginForm()

                    ' Show the LoginForm
                    loginForm.Show()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        SignupUsernameTextBox.Text = ""
        SignupPasswordMaskedTextBox.Text = ""
        SignupEmailTextBox.Text = ""
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class


'Public Class SignupForm
'    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

'    End Sub

'    Private Sub SignupButton_Click(sender As Object, e As EventArgs) Handles SignupButton.Click
'        ' Create an instance of the LoginForm
'        Dim loginForm As New LoginForm()

'        ' Show the LoginForm
'        loginForm.Show()

'        ' Optionally, hide the current form
'        ' Me.Hide()
'    End Sub

'    Private Sub SignupPasswordMaskedTextBox_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles SignupPasswordMaskedTextBox.MaskInputRejected

'    End Sub

'    Private Sub SignupEmailTextBox_TextChanged(sender As Object, e As EventArgs) Handles SignupEmailTextBox.TextChanged

'    End Sub
'End Class


