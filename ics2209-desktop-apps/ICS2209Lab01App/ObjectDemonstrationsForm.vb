' SCT211-0848/2018
' Jany Muong

' Form Two
' ICS 2209: Design and Implementation Computer Apps
' Computer Scinece

Public Class ObjectDemonstrationsForm
    Private Sub ObjectDemonstrationsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExitButton.Text = "E&xit"
    End Sub

    Private Sub ObjectDemoHeaderLabel_Click(sender As Object, e As EventArgs) Handles ObjectDemoHeaderLabel.Click

    End Sub

    Private Sub DisplayTestTextBox_TextChanged(sender As Object, e As EventArgs) Handles DisplayTestTextBox.TextChanged
        ' DisplayTestTextBox.Text = DisplayTestTextBox.Text
    End Sub

    Private Sub GaramondRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles GaramondRadioButton.CheckedChanged
        If GaramondRadioButton.Checked Then
            DisplayTestTextBox.Font = New Font("Garamond", DisplayTestTextBox.Font.Size)
        End If
    End Sub

    Private Sub MagnetoRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MagnetoRadioButton.CheckedChanged
        If MagnetoRadioButton.Checked Then
            DisplayTestTextBox.Font = New Font("Magneto", DisplayTestTextBox.Font.Size)
        End If
    End Sub

    Private Sub TahomaRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles TahomaRadioButton.CheckedChanged
        If TahomaRadioButton.Checked Then
            DisplayTestTextBox.Font = New Font("Tahoma", DisplayTestTextBox.Font.Size)
        End If
    End Sub

    Private Sub GreenRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles GreenRadioButton.CheckedChanged
        If GreenRadioButton.Checked Then
            DisplayTestTextBox.ForeColor = Color.Green
        End If
    End Sub

    Private Sub BlueRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles BlueRadioButton.CheckedChanged
        If BlueRadioButton.Checked Then
            DisplayTestTextBox.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub RedRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RedRadioButton.CheckedChanged
        If RedRadioButton.Checked Then
            DisplayTestTextBox.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ItalicCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ItalicCheckBox.CheckedChanged
        Dim fontStyle As FontStyle = FontStyle.Regular

        If ItalicCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Italic
        End If

        If BoldCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Bold
        End If

        If BoldItalicCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Bold Or FontStyle.Italic
        End If

        DisplayTestTextBox.Font = New Font(DisplayTestTextBox.Font, fontStyle)
    End Sub

    Private Sub BoldCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BoldCheckBox.CheckedChanged
        Dim fontStyle As FontStyle = FontStyle.Regular

        If ItalicCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Italic
        End If

        If BoldCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Bold
        End If

        If BoldItalicCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Bold Or FontStyle.Italic
        End If

        DisplayTestTextBox.Font = New Font(DisplayTestTextBox.Font, fontStyle)
    End Sub

    Private Sub BoldItalicCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BoldItalicCheckBox.CheckedChanged
        Dim fontStyle As FontStyle = FontStyle.Regular

        If ItalicCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Italic
        End If

        If BoldCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Bold
        End If

        If BoldItalicCheckBox.Checked Then
            fontStyle = fontStyle Or FontStyle.Bold Or FontStyle.Italic
        End If

        DisplayTestTextBox.Font = New Font(DisplayTestTextBox.Font, fontStyle)
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        ' used to unload the Form back to the welcoming for when the button is clicked
        Me.Close()
    End Sub

    Private Sub LoadPictureButton_Click(sender As Object, e As EventArgs) Handles LoadPictureButton.Click
        ' Button, used to load a picture from the hard disk of the computer
        ' and display it in the picture box control of the form when it is clicked.
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedImage As Image = Image.FromFile(openFileDialog.FileName)
            ImagePictureBox.Image = selectedImage
        End If
    End Sub

    Private Sub ImagePictureBox_Click(sender As Object, e As EventArgs) Handles ImagePictureBox.Click

    End Sub
End Class