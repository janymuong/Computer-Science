Imports Npgsql

Public Class HeFitsDashBoardForm
    Private ReadOnly loggedInUserID As Integer
    Private ReadOnly connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    ' Constructor with parameter to accept the logged-in user's ID
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserID = userId
        LoadNotStartedGoals()
    End Sub

    ' Button click event for activity tracking
    Private Sub ActivityTrackingButton_Click(sender As Object, e As EventArgs) Handles ActivityTrackingButton.Click
        ' Create an instance of the ActivityTrackingForm and pass the user ID
        Dim activityForm As New ActivityTrackingForm(loggedInUserID)

        activityForm.Show()

        ' Close the dashboard form
        Me.Close()
    End Sub

    ' Button click event for body measurements
    Private Sub BodyMeasurementsButton_Click(sender As Object, e As EventArgs) Handles BodyMeasurementsButton.Click
        ' Create an instance of the BodyMeasurementsForm and pass the user ID
        Dim bodyMeasurementsForm As New BodyMeasurementsForm(loggedInUserID)
        bodyMeasurementsForm.Show()

        ' Close the dashboard form
        Me.Close()
    End Sub

    ' Button click event for goals progress
    Private Sub GoalsProgressButton_Click(sender As Object, e As EventArgs) Handles GoalsProgressButton.Click
        ' Create an instance of the GoalsProgressForm and pass the user ID
        Dim goalsProgressForm As New GoalsProgressForm(loggedInUserID)
        goalsProgressForm.Show()

        ' Close the dashboard form
        Me.Close()
    End Sub

    ' Button click event for settings
    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        ' Create an instance of the SettingsForm and pass the user ID
        Dim settingsForm As New SettingsForm(loggedInUserID)
        settingsForm.Show()

        ' Close the dashboard form
        Me.Close()
    End Sub

    ' Method to load and display "Not Started" goals
    Private Sub LoadNotStartedGoals()
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT goaldescription FROM goalsprogress WHERE userid = @userid AND goalstatus = 'Not Started'"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                    Dim reader As NpgsqlDataReader = cmd.ExecuteReader()

                    ' Clear existing data in the list box
                    NotStartedGoalsListBox.Items.Clear()

                    While reader.Read()
                        Dim goalDescription As String = reader.GetString(0)
                        ' Add goal information to the list box
                        NotStartedGoalsListBox.Items.Add(goalDescription)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading 'Not Started' goals: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
