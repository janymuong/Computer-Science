<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CharacterFollowerForm
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
        Label1 = New Label()
        GetNextCharacterButton = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.ButtonShadow
        Label1.Location = New Point(30, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(707, 25)
        Label1.TabIndex = 0
        Label1.Text = "Enter a character and click the button to find the character following it in the ASCII table."
        ' 
        ' GetNextCharacterButton
        ' 
        GetNextCharacterButton.BackColor = SystemColors.ActiveCaption
        GetNextCharacterButton.FlatStyle = FlatStyle.Popup
        GetNextCharacterButton.ForeColor = Color.RosyBrown
        GetNextCharacterButton.Location = New Point(254, 161)
        GetNextCharacterButton.Name = "GetNextCharacterButton"
        GetNextCharacterButton.Size = New Size(197, 67)
        GetNextCharacterButton.TabIndex = 1
        GetNextCharacterButton.Text = "Get Next Character"
        GetNextCharacterButton.UseVisualStyleBackColor = False
        ' 
        ' CharacterFollowerForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(GetNextCharacterButton)
        Controls.Add(Label1)
        Name = "CharacterFollowerForm"
        Text = "Character Follower (Generator) Form"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GetNextCharacterButton As Button

End Class
