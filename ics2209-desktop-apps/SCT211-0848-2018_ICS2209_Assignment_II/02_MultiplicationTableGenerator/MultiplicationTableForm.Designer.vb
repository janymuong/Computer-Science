<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiplicationTableForm
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
        MultiplicationTableRichTextBox = New RichTextBox()
        SuspendLayout()
        ' 
        ' MultiplicationTableRichTextBox
        ' 
        MultiplicationTableRichTextBox.Location = New Point(234, 63)
        MultiplicationTableRichTextBox.Name = "MultiplicationTableRichTextBox"
        MultiplicationTableRichTextBox.ReadOnly = True
        MultiplicationTableRichTextBox.Size = New Size(323, 305)
        MultiplicationTableRichTextBox.TabIndex = 0
        MultiplicationTableRichTextBox.TabStop = False
        MultiplicationTableRichTextBox.Text = ""
        ' 
        ' MultiplicationTableForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 465)
        Controls.Add(MultiplicationTableRichTextBox)
        Name = "MultiplicationTableForm"
        Text = "MultiplicationTable Module - Display  multiplication table"
        ResumeLayout(False)
    End Sub

    Friend WithEvents MultiplicationTableRichTextBox As RichTextBox

End Class
