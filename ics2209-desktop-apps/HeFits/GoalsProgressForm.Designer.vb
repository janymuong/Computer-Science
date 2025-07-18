<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoalsProgressForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoalsProgressForm))
        GroupBox1 = New GroupBox()
        CreateGoalButton = New Button()
        GoalStatusComboBox = New ComboBox()
        Label2 = New Label()
        DescriptionLabel = New Label()
        GoalDescriptionTextBox = New TextBox()
        GroupBox2 = New GroupBox()
        GoalsListBox = New ListBox()
        Label4 = New Label()
        ActualWeightLabel = New Label()
        UserNameLabel = New Label()
        WeightProgressBar = New ProgressBar()
        ProgressSubmitButton = New Button()
        ProgressWeightGoalTextBox = New TextBox()
        Label1 = New Label()
        BackToDashboardButton = New Button()
        GoalsPictureBox = New PictureBox()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(GoalsPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.ActiveCaption
        GroupBox1.Controls.Add(CreateGoalButton)
        GroupBox1.Controls.Add(GoalStatusComboBox)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(DescriptionLabel)
        GroupBox1.Controls.Add(GoalDescriptionTextBox)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(583, 167)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "GOAL:"
        ' 
        ' CreateGoalButton
        ' 
        CreateGoalButton.BackColor = SystemColors.WindowFrame
        CreateGoalButton.FlatStyle = FlatStyle.Popup
        CreateGoalButton.Location = New Point(474, 104)
        CreateGoalButton.Name = "CreateGoalButton"
        CreateGoalButton.Size = New Size(70, 39)
        CreateGoalButton.TabIndex = 8
        CreateGoalButton.Text = "Create"
        CreateGoalButton.UseVisualStyleBackColor = False
        ' 
        ' GoalStatusComboBox
        ' 
        GoalStatusComboBox.FormattingEnabled = True
        GoalStatusComboBox.Items.AddRange(New Object() {"Not Started", "In Progress", "Completed"})
        GoalStatusComboBox.Location = New Point(117, 104)
        GoalStatusComboBox.Name = "GoalStatusComboBox"
        GoalStatusComboBox.Size = New Size(283, 33)
        GoalStatusComboBox.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(19, 91)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 25)
        Label2.TabIndex = 6
        Label2.Text = "Status:"
        ' 
        ' DescriptionLabel
        ' 
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New Point(6, 39)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New Size(106, 25)
        DescriptionLabel.TabIndex = 5
        DescriptionLabel.Text = "Description:"
        ' 
        ' GoalDescriptionTextBox
        ' 
        GoalDescriptionTextBox.Location = New Point(118, 39)
        GoalDescriptionTextBox.Name = "GoalDescriptionTextBox"
        GoalDescriptionTextBox.Size = New Size(288, 31)
        GoalDescriptionTextBox.TabIndex = 4
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.WhiteSmoke
        GroupBox2.Controls.Add(GoalsListBox)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(ActualWeightLabel)
        GroupBox2.Controls.Add(UserNameLabel)
        GroupBox2.Controls.Add(WeightProgressBar)
        GroupBox2.Controls.Add(ProgressSubmitButton)
        GroupBox2.Controls.Add(ProgressWeightGoalTextBox)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.FlatStyle = FlatStyle.Popup
        GroupBox2.Location = New Point(142, 250)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(614, 310)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "WEIGHT PROGRESS:"
        ' 
        ' GoalsListBox
        ' 
        GoalsListBox.FormattingEnabled = True
        GoalsListBox.ItemHeight = 25
        GoalsListBox.Location = New Point(384, 134)
        GoalsListBox.Name = "GoalsListBox"
        GoalsListBox.Size = New Size(189, 29)
        GoalsListBox.TabIndex = 15
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(35, 122)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 25)
        Label4.TabIndex = 14
        Label4.Text = "STATS FOR:"
        ' 
        ' ActualWeightLabel
        ' 
        ActualWeightLabel.AutoSize = True
        ActualWeightLabel.Location = New Point(168, 165)
        ActualWeightLabel.Name = "ActualWeightLabel"
        ActualWeightLabel.Size = New Size(69, 25)
        ActualWeightLabel.TabIndex = 12
        ActualWeightLabel.Text = "weight:"
        ' 
        ' UserNameLabel
        ' 
        UserNameLabel.AutoSize = True
        UserNameLabel.Location = New Point(168, 122)
        UserNameLabel.Name = "UserNameLabel"
        UserNameLabel.Size = New Size(56, 25)
        UserNameLabel.TabIndex = 11
        UserNameLabel.Text = "name"
        ' 
        ' WeightProgressBar
        ' 
        WeightProgressBar.Location = New Point(13, 205)
        WeightProgressBar.Name = "WeightProgressBar"
        WeightProgressBar.Size = New Size(586, 79)
        WeightProgressBar.TabIndex = 10
        ' 
        ' ProgressSubmitButton
        ' 
        ProgressSubmitButton.Location = New Point(497, 30)
        ProgressSubmitButton.Name = "ProgressSubmitButton"
        ProgressSubmitButton.Size = New Size(102, 47)
        ProgressSubmitButton.TabIndex = 9
        ProgressSubmitButton.Text = "Submit"
        ProgressSubmitButton.UseVisualStyleBackColor = True
        ' 
        ' ProgressWeightGoalTextBox
        ' 
        ProgressWeightGoalTextBox.Location = New Point(215, 38)
        ProgressWeightGoalTextBox.Name = "ProgressWeightGoalTextBox"
        ProgressWeightGoalTextBox.Size = New Size(219, 31)
        ProgressWeightGoalTextBox.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(13, 44)
        Label1.Name = "Label1"
        Label1.Size = New Size(156, 25)
        Label1.TabIndex = 7
        Label1.Text = "Weight goal in kg:"
        ' 
        ' BackToDashboardButton
        ' 
        BackToDashboardButton.Location = New Point(12, 515)
        BackToDashboardButton.Name = "BackToDashboardButton"
        BackToDashboardButton.Size = New Size(56, 45)
        BackToDashboardButton.TabIndex = 2
        BackToDashboardButton.Text = "🔙"
        BackToDashboardButton.UseVisualStyleBackColor = True
        ' 
        ' GoalsPictureBox
        ' 
        GoalsPictureBox.Image = CType(resources.GetObject("GoalsPictureBox.Image"), Image)
        GoalsPictureBox.Location = New Point(625, 22)
        GoalsPictureBox.Name = "GoalsPictureBox"
        GoalsPictureBox.Size = New Size(151, 157)
        GoalsPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        GoalsPictureBox.TabIndex = 3
        GoalsPictureBox.TabStop = False
        ' 
        ' GoalsProgressForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.RosyBrown
        ClientSize = New Size(800, 580)
        Controls.Add(GoalsPictureBox)
        Controls.Add(BackToDashboardButton)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "GoalsProgressForm"
        Text = "GoalsProgressForm"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(GoalsPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BackToDashboardButton As Button
    Friend WithEvents CreateGoalButton As Button
    Friend WithEvents GoalStatusComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents GoalDescriptionTextBox As TextBox
    Friend WithEvents ProgressSubmitButton As Button
    Friend WithEvents ProgressWeightGoalTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GoalsPictureBox As PictureBox
    Friend WithEvents ActualWeightLabel As Label
    Friend WithEvents UserNameLabel As Label
    Friend WithEvents WeightProgressBar As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents GoalsListBox As ListBox
End Class
