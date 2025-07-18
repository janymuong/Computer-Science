<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SavingsAccountForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        AmountsListBox = New ListBox()
        SuspendLayout()
        ' 
        ' AmountsListBox
        ' 
        AmountsListBox.Dock = DockStyle.Fill
        AmountsListBox.FormattingEnabled = True
        AmountsListBox.ItemHeight = 25
        AmountsListBox.Location = New Point(0, 0)
        AmountsListBox.Name = "AmountsListBox"
        AmountsListBox.Size = New Size(800, 450)
        AmountsListBox.TabIndex = 0
        ' 
        ' SavingsAccountForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(AmountsListBox)
        Name = "SavingsAccountForm"
        Text = "Savings Account Balance Form Over 10 Years"
        ResumeLayout(False)
    End Sub

    Friend WithEvents AmountsListBox As ListBox

End Class
