' SCT211-O848/2018
' Jany Muong
' 03_SavingsAccountCalculator project: Calculate and display the amount of money in a savings account over 10 years

Imports System.Windows.Forms

Public Class SavingsAccountForm
    Inherits Form

    Private Sub CalculateAndDisplayAmounts()
        ' Constants
        Const Principal As Decimal = 1000000D ' KSh 1,000,000
        Const InterestRate As Decimal = 0.05D ' 5% annual interest rate
        Const NumYears As Integer = 10 ' Number of years

        ' Initialize ListBox items
        AmountsListBox.Items.Clear()
        AmountsListBox.Items.Add("Year" & vbTab & "Amount")

        ' compute and display the amount of money in the account for each year
        For year As Integer = 1 To NumYears
            ' AmountsListBox's dock property set to fill entire form form designer
            Dim amount As Decimal = Principal * CDec(Math.Pow((1 + InterestRate), year))
            AmountsListBox.Items.Add(year & vbTab & "Ksh " & amount.ToString("N2"))
        Next
    End Sub

    ' constructor - call the CalculateAndDisplayAmounts method
    ' when the form is initialized
    Public Sub New()
        InitializeComponent()
        CalculateAndDisplayAmounts()
    End Sub

End Class
