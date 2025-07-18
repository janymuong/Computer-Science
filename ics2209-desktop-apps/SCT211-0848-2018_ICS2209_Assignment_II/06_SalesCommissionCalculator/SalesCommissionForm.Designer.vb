<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesCommissionForm
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
        SalesListBox = New ListBox()
        SalesButton = New Button()
        SuspendLayout()
        ' 
        ' SalesListBox
        ' 
        SalesListBox.FormattingEnabled = True
        SalesListBox.ItemHeight = 25
        SalesListBox.Location = New Point(66, 0)
        SalesListBox.Name = "SalesListBox"
        SalesListBox.Size = New Size(673, 329)
        SalesListBox.TabIndex = 0
        ' 
        ' SalesButton
        ' 
        SalesButton.Location = New Point(269, 354)
        SalesButton.Name = "SalesButton"
        SalesButton.Size = New Size(182, 50)
        SalesButton.TabIndex = 1
        SalesButton.Text = "Sales"
        SalesButton.UseVisualStyleBackColor = True
        ' 
        ' SalesCommissionForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SalesButton)
        Controls.Add(SalesListBox)
        Name = "SalesCommissionForm"
        Text = "Sales Commission Calculator"
        ResumeLayout(False)
    End Sub

    Friend WithEvents SalesListBox As ListBox
    Friend WithEvents SalesButton As Button

End Class
