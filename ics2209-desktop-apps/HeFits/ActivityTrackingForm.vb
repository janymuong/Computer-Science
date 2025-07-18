Imports Npgsql

Public Class ActivityTrackingForm
    Private ReadOnly loggedInUserID As Integer
    Private connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserID = userId
    End Sub

    ' Method to calculate calories based on the input values and update CaloriesTextBox
    Private Sub CalculateCalories()
        Dim duration As Integer
        Dim met As Double

        If Not Integer.TryParse(DurationComboBox.SelectedItem?.ToString(), duration) Then
            Return
        End If

        If Not Double.TryParse(METTextBox.Text, met) Then
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' Fetch the weight of the logged-in user from the database
                Dim query As String = "SELECT bodyweight FROM bodymeasurements WHERE userid = @userid"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    Dim weight As Double = Convert.ToDouble(cmd.ExecuteScalar())

                    ' Calculate calories using the formula calories = MET * weight * duration
                    Dim calories As Double = met * weight * duration
                    CaloriesTextBox.Text = calories.ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user weight: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Event handlers for ComboBox and TextBox text changed events to calculate calories
    Private Sub DurationComboBox_TextChanged(sender As Object, e As EventArgs) Handles DurationComboBox.TextChanged
        CalculateCalories()
    End Sub

    Private Sub METTextBox_TextChanged(sender As Object, e As EventArgs) Handles METTextBox.TextChanged
        CalculateCalories()
    End Sub

    Private Sub ActivitytypeComboBox_TextChanged(sender As Object, e As EventArgs) Handles ActivitytypeComboBox.TextChanged
        CalculateCalories()
    End Sub

    ' Submit button click event to insert data into the database
    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' Get the activity type from the ComboBox
                Dim activityType As String = ActivitytypeComboBox.SelectedItem?.ToString()

                ' Parse the duration value to ensure it is an integer
                Dim duration As Integer
                If Not Integer.TryParse(DurationComboBox.SelectedItem?.ToString(), duration) Then
                    MessageBox.Show("Invalid duration value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Parse the MET value to ensure it is a double
                Dim met As Double
                If Not Double.TryParse(METTextBox.Text, met) Then
                    MessageBox.Show("Invalid MET value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Parse the calories value to ensure it is a double
                Dim calories As Double
                If Not Double.TryParse(CaloriesTextBox.Text, calories) Then
                    MessageBox.Show("Invalid calories value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Insert the activity log into the database
                Dim query As String = "INSERT INTO activitylog (userid, activitytype, duration, met, calories) VALUES (@userid, @activitytype, @duration, @met, @calories)"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    cmd.Parameters.AddWithValue("@activitytype", activityType)
                    cmd.Parameters.AddWithValue("@duration", duration)
                    cmd.Parameters.AddWithValue("@met", met)
                    cmd.Parameters.AddWithValue("@calories", calories)
                    cmd.ExecuteNonQuery()

                    ' Notify the user about the successful submission
                    MessageBox.Show("Activity logged successfully!", "HeFits", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Clear the form fields after submission
                    DurationComboBox.SelectedIndex = -1
                    METTextBox.Clear()
                    CaloriesTextBox.Clear()
                    ActivitytypeComboBox.SelectedIndex = -1
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding activity: " & ex.Message, "HeFits - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackToDashboardButton_Click(sender As Object, e As EventArgs) Handles BackToDashboardButton.Click
        ' Return to the dashboard form
        Dim dashboardForm As New HeFitsDashBoardForm(loggedInUserID)
        dashboardForm.Show()
        Me.Close()
    End Sub

    Private Sub ActivityTrackingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load the image
            Dim imagePath As String = System.IO.Path.Combine(Application.StartupPath, "img\activitypage.jpg")
            Dim image As Image = Image.FromFile(imagePath)

            ' Set the PictureBox properties
            ActivityTypePictureBox.SizeMode = PictureBoxSizeMode.Zoom
            ActivityTypePictureBox.Image = image
        Catch ex As Exception
            ' Handle any exceptions
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
