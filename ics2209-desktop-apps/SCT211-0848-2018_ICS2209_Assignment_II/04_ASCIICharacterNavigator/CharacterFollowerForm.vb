' SCT211-O848/2018
' Jany Muong
' 04_CharacterFollower project: Return the character following the input character according to the ASCII table

Imports System.Windows.Forms

Public Class CharacterFollowerForm
    Inherits Form

    ' function procedure to return the character following the input character
    Private Function GetNextCharacter(inputChar As Char) As Char
        ' convert the input character to its ASCII value and add 1
        Dim nextCharAscii As Integer = Asc(inputChar) + 1
        ' convert the ASCII value back to a character for output
        Return ChrW(nextCharAscii)
    End Function

    Private Sub GetNextCharacterButton_Click(sender As Object, e As EventArgs) Handles GetNextCharacterButton.Click
        ' input dialog for char
        Dim userInput As String = InputBox("Enter an ASCII character:", "Input Character", "").Trim()

        ' check if user input is not empty and contains only one character
        If userInput.Length = 1 Then
            ' get the next character 
            Dim nextChar As Char = GetNextCharacter(userInput(0))
            MessageBox.Show("The character following " & userInput & " is " & nextChar)
        Else
            ' error message if user input is invalid
            MessageBox.Show("Please enter a single character.")
        End If
    End Sub
End Class
