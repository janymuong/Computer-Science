<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        Label1 = New Label()
        SubmitFeedbackButton = New Button()
        FeedbackTextBox = New TextBox()
        HeFitsSettingsPictureBox = New PictureBox()
        UserNameLabel = New Label()
        LogoutButton = New Button()
        BackToDashboardButton = New Button()
        ProfilePictureBox = New PictureBox()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(HeFitsSettingsPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(ProfilePictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Controls.Add(HeFitsSettingsPictureBox)
        GroupBox1.Controls.Add(UserNameLabel)
        GroupBox1.Controls.Add(LogoutButton)
        GroupBox1.Controls.Add(BackToDashboardButton)
        GroupBox1.Controls.Add(ProfilePictureBox)
        GroupBox1.Location = New Point(12, 2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(752, 426)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "SETTINGS:"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.OliveDrab
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(SubmitFeedbackButton)
        GroupBox2.Controls.Add(FeedbackTextBox)
        GroupBox2.Font = New Font("Segoe UI Emoji", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox2.Location = New Point(359, 250)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(385, 176)
        GroupBox2.TabIndex = 7
        GroupBox2.TabStop = False
        GroupBox2.Text = "Feedback"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.AppWorkspace
        Label1.Location = New Point(276, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 30)
        Label1.TabIndex = 9
        Label1.Text = "HeFits :)"
        ' 
        ' SubmitFeedbackButton
        ' 
        SubmitFeedbackButton.BackColor = Color.NavajoWhite
        SubmitFeedbackButton.Font = New Font("Tw Cen MT Condensed Extra Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SubmitFeedbackButton.Location = New Point(291, 119)
        SubmitFeedbackButton.Name = "SubmitFeedbackButton"
        SubmitFeedbackButton.Size = New Size(69, 36)
        SubmitFeedbackButton.TabIndex = 8
        SubmitFeedbackButton.Text = "Submit"
        SubmitFeedbackButton.UseVisualStyleBackColor = False
        ' 
        ' FeedbackTextBox
        ' 
        FeedbackTextBox.Location = New Point(6, 30)
        FeedbackTextBox.Multiline = True
        FeedbackTextBox.Name = "FeedbackTextBox"
        FeedbackTextBox.Size = New Size(249, 140)
        FeedbackTextBox.TabIndex = 7
        ' 
        ' HeFitsSettingsPictureBox
        ' 
        HeFitsSettingsPictureBox.Location = New Point(6, 28)
        HeFitsSettingsPictureBox.Name = "HeFitsSettingsPictureBox"
        HeFitsSettingsPictureBox.Size = New Size(341, 215)
        HeFitsSettingsPictureBox.TabIndex = 5
        HeFitsSettingsPictureBox.TabStop = False
        ' 
        ' UserNameLabel
        ' 
        UserNameLabel.AutoSize = True
        UserNameLabel.Location = New Point(537, 100)
        UserNameLabel.Name = "UserNameLabel"
        UserNameLabel.Size = New Size(89, 25)
        UserNameLabel.TabIndex = 4
        UserNameLabel.Text = "username"
        ' 
        ' LogoutButton
        ' 
        LogoutButton.BackColor = Color.RosyBrown
        LogoutButton.ForeColor = SystemColors.ActiveCaptionText
        LogoutButton.Location = New Point(655, 40)
        LogoutButton.Name = "LogoutButton"
        LogoutButton.Size = New Size(89, 42)
        LogoutButton.TabIndex = 3
        LogoutButton.Text = "Log Out"
        LogoutButton.UseVisualStyleBackColor = False
        ' 
        ' BackToDashboardButton
        ' 
        BackToDashboardButton.BackColor = Color.Teal
        BackToDashboardButton.Font = New Font("Tahoma", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackToDashboardButton.Location = New Point(16, 341)
        BackToDashboardButton.Name = "BackToDashboardButton"
        BackToDashboardButton.Size = New Size(62, 64)
        BackToDashboardButton.TabIndex = 2
        BackToDashboardButton.Text = "🔙"
        BackToDashboardButton.UseVisualStyleBackColor = False
        ' 
        ' ProfilePictureBox
        ' 
        ProfilePictureBox.Location = New Point(520, 28)
        ProfilePictureBox.Name = "ProfilePictureBox"
        ProfilePictureBox.Size = New Size(114, 69)
        ProfilePictureBox.TabIndex = 0
        ProfilePictureBox.TabStop = False
        ' 
        ' SettingsForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(772, 441)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "SettingsForm"
        Text = "SettingsForm"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(HeFitsSettingsPictureBox, ComponentModel.ISupportInitialize).EndInit()
        CType(ProfilePictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LogoutButton As Button
    Friend WithEvents BackToDashboardButton As Button
    Friend WithEvents ProfilePictureBox As PictureBox
    Friend WithEvents UserNameLabel As Label
    Friend WithEvents HeFitsSettingsPictureBox As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents FeedbackTextBox As TextBox
    Friend WithEvents SubmitFeedbackButton As Button
    Friend WithEvents Label1 As Label
End Class
