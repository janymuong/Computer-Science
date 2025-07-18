<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Welcome
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
        LoadObjectDemoButtton = New Button()
        ExitButton = New Button()
        SuspendLayout()
        ' 
        ' LoadObjectDemoButtton
        ' 
        LoadObjectDemoButtton.BackColor = SystemColors.AppWorkspace
        LoadObjectDemoButtton.Location = New Point(49, 185)
        LoadObjectDemoButtton.Name = "LoadObjectDemoButtton"
        LoadObjectDemoButtton.Size = New Size(230, 76)
        LoadObjectDemoButtton.TabIndex = 0
        LoadObjectDemoButtton.Text = "Load Object Demo"
        LoadObjectDemoButtton.UseVisualStyleBackColor = False
        ' 
        ' ExitButton
        ' 
        ExitButton.BackColor = SystemColors.AppWorkspace
        ExitButton.Location = New Point(390, 177)
        ExitButton.Name = "ExitButton"
        ExitButton.Size = New Size(174, 84)
        ExitButton.TabIndex = 1
        ExitButton.Text = "EXIT"
        ExitButton.UseVisualStyleBackColor = False
        ' 
        ' Welcome
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(694, 370)
        Controls.Add(ExitButton)
        Controls.Add(LoadObjectDemoButtton)
        Name = "Welcome"
        Text = "Welcoming Form"
        ResumeLayout(False)
    End Sub

    Friend WithEvents LoadObjectDemoButtton As Button
    Friend WithEvents ExitButton As Button

End Class
