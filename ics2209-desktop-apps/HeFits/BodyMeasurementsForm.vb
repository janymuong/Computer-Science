Imports Npgsql

Public Class BodyMeasurementsForm
    Private ReadOnly loggedInUserID As Integer
    Private ReadOnly connectionString As String = "Host=localhost;Username=postgres;Password=pseudo-xkcdpg;Database=hefits;"

    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserID = userId
    End Sub

    Private Sub HeightTextBox_TextChanged(sender As Object, e As EventArgs) Handles HeightTextBox.TextChanged, BodyWeightTextBox.TextChanged
        CalculateAndDisplayBMI()
    End Sub

    Private Sub CalculateAndDisplayBMI()
        ' Check if height and body weight are valid numeric values
        If Double.TryParse(HeightTextBox.Text, Nothing) AndAlso Double.TryParse(BodyWeightTextBox.Text, Nothing) Then
            ' Get the height and body weight values
            Dim height As Double = Double.Parse(HeightTextBox.Text)
            Dim bodyWeight As Double = Double.Parse(BodyWeightTextBox.Text)

            ' Calculate BMI using the formula BMI = weight (kg) / (height (m))^2
            Dim bmi As Double = bodyWeight / ((height / 100) ^ 2)

            ' Display BMI with 2 decimal places in the BMITextBox
            BMITextBox.Text = bmi.ToString("F2")
        Else
            ' Clear the BMI TextBox if height or body weight are not valid numeric values
            BMITextBox.Clear()
        End If
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        ' Check if height and body weight are valid numeric values
        If Double.TryParse(HeightTextBox.Text, Nothing) AndAlso Double.TryParse(BodyWeightTextBox.Text, Nothing) Then
            ' Get the height and body weight values
            Dim height As Double = Double.Parse(HeightTextBox.Text)
            Dim bodyWeight As Double = Double.Parse(BodyWeightTextBox.Text)

            ' Calculate BMI using the formula BMI = weight (kg) / (height (m))^2
            Dim bmi As Double = bodyWeight / ((height / 100) ^ 2)

            Try
                Using conn As New NpgsqlConnection(connectionString)
                    conn.Open()

                    ' Insert body measurements into the database
                    Dim query As String = "INSERT INTO bodymeasurements (userid, height, bodyweight, bmi) VALUES (@userid, @height, @bodyweight, @bmi)"
                    Using cmd As New NpgsqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@userid", loggedInUserID)
                        cmd.Parameters.AddWithValue("@height", height)
                        cmd.Parameters.AddWithValue("@bodyweight", bodyWeight)
                        cmd.Parameters.AddWithValue("@bmi", bmi)
                        cmd.ExecuteNonQuery()

                        ' Notify the user about the successful submission
                        MessageBox.Show("Body measurements saved successfully!", "HeFits", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Clear the textboxes after submission
                        HeightTextBox.Clear()
                        BodyWeightTextBox.Clear()
                        BMITextBox.Clear()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please enter valid numeric values for height and body weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BackToDashboardButton_Click(sender As Object, e As EventArgs) Handles BackToDashboardButton.Click
        ' Return to the dashboard form
        Dim dashboardForm As New HeFitsDashBoardForm(loggedInUserID)
        dashboardForm.Show()
        Me.Close()
    End Sub

    Private Sub BodyMeasurementsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load the image
            Dim imagePath As String = System.IO.Path.Combine(Application.StartupPath, "img\bmietcpage.jpg")
            Dim image As Image = Image.FromFile(imagePath)

            ' Set the PictureBox properties
            BMIetcPictureBox.SizeMode = PictureBoxSizeMode.Zoom
            BMIetcPictureBox.Image = image
        Catch ex As Exception
            ' Handle any exceptions
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
