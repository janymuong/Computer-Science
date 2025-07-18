' SCT211-O848/2018
' Jany Muong
' 06_SalesCommissionCalculator project: Calculate weekly sales and commission for salespersons using arrays

Imports System.Windows.Forms

Public Class SalesCommissionForm
    Inherits Form

    ' Constants
    Private Const WEEKLY_BASE_PAY As Decimal = 2500
    Private Const QUOTA As Decimal = 1000
    Private Const COMMISSION_RATE As Single = 0.15

    ' Variables
    Private SalespersonNames() As String = New String(10) {}  ' Array to store salesperson names (10 elements)
    Private DailySales() As Decimal = New Decimal(10) {}     ' Array to store daily sales (10 elements)

    Private Sub SalesButton_Click(sender As Object, e As EventArgs) Handles SalesButton.Click
        ' Clear listbox before populating with new data
        SalesListBox.Items.Clear()

        For i As Integer = 0 To 9
            ' Input validation (can be improved)
            Dim NameInput As String = InputBox("Enter salesperson name for salesperson " & (i + 1).ToString(), "Salesperson Details")
            If NameInput.Trim() = "" Then
                MsgBox("Please enter a name.", MsgBoxStyle.Exclamation)
                Exit Sub ' Exit the loop if no name is entered
            End If

            SalespersonNames(i) = NameInput

            Dim DailySaleInput As String = InputBox("Enter daily sales for salesperson " & (i + 1).ToString(), "Salesperson Details")
            If Not Decimal.TryParse(DailySaleInput, DailySales(i)) Then
                MsgBox("Invalid sales amount. Please enter a number.", MsgBoxStyle.Exclamation)
                Exit Sub ' Exit the loop if invalid sales amount
            End If
        Next

        CalculateWeeklySalesAndCommission()

        ' Display results in listbox
        For i As Integer = 0 To 9
            SalesListBox.Items.Add(SalespersonNames(i) & vbCrLf &
                                            "Daily Sales: " & DailySales(i).ToString("C") & vbCrLf &
                                            "Weekly Sales: " & (DailySales(i) * 7).ToString("C") & vbCrLf &
                                            "Weekly Salary: " & CalculateWeeklySalary(DailySales(i) * 7).ToString("C"))
        Next

    End Sub

    Private Sub CalculateWeeklySalesAndCommission()
        For i As Integer = 0 To 9
            DailySales(i) = DailySales(i) * 7 ' Calculate weekly sales
        Next
    End Sub

    Private Function CalculateWeeklySalary(WeeklySales As Decimal) As Decimal
        Dim Commission As Decimal = 0
        If WeeklySales > QUOTA Then
            Commission = WeeklySales * COMMISSION_RATE
        End If
        Return WEEKLY_BASE_PAY + Commission
    End Function

End Class
