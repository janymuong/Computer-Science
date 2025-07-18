Public Class DetermineGradeForm
    Private Sub CheckgradeButton_Click(sender As Object, e As EventArgs) Handles CheckgradeButton.Click
        ' check if all TextBoxes for marks are filled in
        If SCTextBox.Text.Trim() = "" OrElse CATextBox.Text.Trim() = "" _
    OrElse DBTextBox.Text.Trim() = "" OrElse LATextBox.Text.Trim() = "" Then
            MessageBox.Show("Please enter marks for all subjects.", "SnugGrades - Missing Marks", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ' exit the sub if marks are missing
        End If


        Dim mark1, mark2, mark3, mark4 As Integer

        ' parse input from TextBox controls into integer variables
        Dim success1 As Boolean = Integer.TryParse(SCTextBox.Text, mark1)
        Dim success2 As Boolean = Integer.TryParse(CATextBox.Text, mark2)
        Dim success3 As Boolean = Integer.TryParse(DBTextBox.Text, mark3)
        Dim success4 As Boolean = Integer.TryParse(LATextBox.Text, mark4)

        ' check if all conversions were successful
        If Not (success1 AndAlso success2 AndAlso success3 AndAlso success4) Then
            MessageBox.Show("Please enter valid integer marks for all subjects.", "SnugGrades - Invalid Marks", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim averageMark As Double = (mark1 + mark2 + mark3 + mark4) / 4

        Dim grade As String
        If averageMark >= 75 Then
            grade = "A"
        ElseIf averageMark >= 65 Then
            grade = "B"
        ElseIf averageMark >= 50 Then
            grade = "C"
        Else
            grade = "Fail"
        End If

        ' display results in a message box
        MessageBox.Show($"Average Mark: {averageMark:N2}%{Environment.NewLine}Grade: {grade}", "Your Grade", MessageBoxButtons.OK, MessageBoxIcon.Information)

        SCTextBox.Clear()
        CATextBox.Clear()
        DBTextBox.Clear()
        LATextBox.Clear()
    End Sub

    Private Sub LogOffButton_Click(sender As Object, e As EventArgs) Handles LogOffButton.Click
        Application.Exit()
    End Sub

End Class
