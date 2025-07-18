Imports Npgsql

Public Class GoalsProgressForm
    Private ReadOnly loggedInUserID As Integer
    Private ReadOnly connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserID = userId
        LoadUserData()
        LoadWeightProgress()
    End Sub

    Private Sub LoadUserData()
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' Fetch user's name
                Dim query As String = "SELECT username FROM users WHERE userid = @userid"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    Dim reader As NpgsqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim username As String = reader.GetString(0)
                        UserNameLabel.Text = username
                    End If

                    ' Close the reader after fetching data
                    reader.Close()
                End Using

                ' Fetch actual weight from bodymeasurements table
                query = "SELECT bodyweight FROM bodymeasurements WHERE userid = @userid ORDER BY id DESC LIMIT 1"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    Dim reader As NpgsqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim actualWeight As Double = reader.GetDouble(0)
                        ActualWeightLabel.Text = "Actual Weight: " & actualWeight.ToString() & " kg"
                    End If

                    ' Close the reader after fetching data
                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadWeightProgress()
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT goaldescription, goalstatus FROM goalsprogress WHERE userid = @userid"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    Dim reader As NpgsqlDataReader = cmd.ExecuteReader()

                    ' Clear existing data in the list box
                    GoalsListBox.Items.Clear()

                    While reader.Read()
                        Dim goalDescription As String = reader.GetString(0)
                        Dim goalStatus As String = reader.GetString(1)

                        ' Add goal information to the list box
                        GoalsListBox.Items.Add(goalDescription & " - " & goalStatus)
                    End While

                    ' Close the reader after fetching data
                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading weight progress: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateGoalButton_Click(sender As Object, e As EventArgs) Handles CreateGoalButton.Click
        Dim goalDescription As String = GoalDescriptionTextBox.Text
        Dim goalStatus As String = GoalStatusComboBox.SelectedItem.ToString()

        If String.IsNullOrWhiteSpace(goalDescription) Then
            MessageBox.Show("Please enter a goal description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query = "INSERT INTO goalsprogress (userid, goaldescription, goalstatus) VALUES (@userid, @goaldescription, @goalstatus)"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    cmd.Parameters.AddWithValue("@goaldescription", goalDescription)
                    cmd.Parameters.AddWithValue("@goalstatus", goalStatus)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("New goal created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Reload the weight progress data
                    LoadWeightProgress()

                    ' Clear the goal description textbox
                    GoalDescriptionTextBox.Clear()
                    GoalStatusComboBox.SelectedIndex = -1 ' Reset the selected index
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating new goal: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProgressSubmitButton_Click(sender As Object, e As EventArgs) Handles ProgressSubmitButton.Click
        Dim goalWeight As Double
        If Not Double.TryParse(ProgressWeightGoalTextBox.Text, goalWeight) Then
            MessageBox.Show("Please enter a valid goal weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim actualWeight As Double
        If Not Double.TryParse(ActualWeightLabel.Text.Replace("Actual Weight: ", "").Replace(" kg", ""), actualWeight) Then
            MessageBox.Show("Error retrieving actual weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform calculations or set progress bar value based on your logic
        ' For example, you can calculate the percentage completion and set the progress bar value
        WeightProgressBar.Value = CInt((WeightProgressBar.Maximum / 100) * (actualWeight / goalWeight))
    End Sub

    Private Sub BackToDashboardButton_Click(sender As Object, e As EventArgs) Handles BackToDashboardButton.Click
        Dim dashboardForm As New HeFitsDashBoardForm(loggedInUserID)
        dashboardForm.Show()
        Me.Close()
    End Sub

    Private Sub GoalsProgressForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load user data and weight progress when the form loads
        LoadUserData()
        LoadWeightProgress()
    End Sub
End Class
