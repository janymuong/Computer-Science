' SCT211-O848/2018
' Jany Muong
' 02_MultiplicationTableGenerator project: Generate and display a multiplication table without using arrays

Imports System.Windows.Forms

Public Class MultiplicationTableForm
    Inherits Form

    Private Sub GenerateMultiplicationTable()

        Dim tableString As String = ""

        ' define the maximum number of digits for consistent formatting
        Dim maxDigits As Integer = 4

        ' compute total table width based on max digits and number of columns
        Dim tableWidth As Integer = (maxDigits + 4) * (8)  ' 8 columns with padding

        ' generate the title row with padding and centering
        Dim titlePadding As Integer = (tableWidth - "Multiplication Table".Length) \ 4
        tableString &= New String(" ", titlePadding) & "Multiplication Table" & vbCrLf & vbCrLf

        ' generate column headers with padding
        tableString &= PadNumber("*", maxDigits) & "  "
        For i As Integer = 1 To 7
            tableString &= PadNumber(i.ToString(), maxDigits) & "  "
        Next
        tableString &= vbCrLf

        ' generate the multiplication table with padding
        For i As Integer = 1 To 7
            tableString &= PadNumber(i.ToString(), maxDigits) & "  "
            For j As Integer = 1 To 7
                tableString &= PadNumber((i * j).ToString(), maxDigits) & "  "
            Next
            tableString &= vbCrLf
        Next

        ' make textbox read-only;
        MultiplicationTableRichTextBox.Text = tableString
        MultiplicationTableRichTextBox.ReadOnly = True
    End Sub

    Private Function PadNumber(number As String, width As Integer) As String
        Dim paddingLength As Integer = width - number.Length
        Dim padding As String = New String(" ", paddingLength)
        Return padding & number
    End Function

    Public Sub New()
        InitializeComponent()
        GenerateMultiplicationTable()
    End Sub

End Class
