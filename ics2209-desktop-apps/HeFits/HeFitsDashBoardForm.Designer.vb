<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeFitsDashBoardForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HeFitsDashBoardForm))
        GroupBox1 = New GroupBox()
        NotStartedGoalsListBox = New ListBox()
        Label2 = New Label()
        GoalsProgressButton = New Button()
        SettingsButton = New Button()
        BodyMeasurementsButton = New Button()
        ActivityTrackingButton = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox5 = New PictureBox()
        GroupBox1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(NotStartedGoalsListBox)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Font = New Font("Bernard MT Condensed", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.ForeColor = SystemColors.ButtonHighlight
        GroupBox1.Location = New Point(22, 22)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(674, 136)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        GroupBox1.Text = "DASHBOARD"
        ' 
        ' NotStartedGoalsListBox
        ' 
        NotStartedGoalsListBox.Font = New Font("Bernard MT Condensed", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        NotStartedGoalsListBox.FormattingEnabled = True
        NotStartedGoalsListBox.ItemHeight = 21
        NotStartedGoalsListBox.Location = New Point(321, 57)
        NotStartedGoalsListBox.Name = "NotStartedGoalsListBox"
        NotStartedGoalsListBox.Size = New Size(297, 25)
        NotStartedGoalsListBox.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Lucida Sans Typewriter", 13F)
        Label2.ForeColor = Color.SeaShell
        Label2.Location = New Point(25, 57)
        Label2.Name = "Label2"
        Label2.Size = New Size(255, 31)
        Label2.TabIndex = 1
        Label2.Text = "Upcoming goals:"
        ' 
        ' GoalsProgressButton
        ' 
        GoalsProgressButton.BackColor = Color.Transparent
        GoalsProgressButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        GoalsProgressButton.ForeColor = Color.Black
        GoalsProgressButton.Location = New Point(105, 301)
        GoalsProgressButton.Name = "GoalsProgressButton"
        GoalsProgressButton.Size = New Size(199, 44)
        GoalsProgressButton.TabIndex = 4
        GoalsProgressButton.Text = "Goals/Progress"
        GoalsProgressButton.TextAlign = ContentAlignment.MiddleLeft
        GoalsProgressButton.UseVisualStyleBackColor = False
        ' 
        ' SettingsButton
        ' 
        SettingsButton.BackColor = Color.Transparent
        SettingsButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        SettingsButton.ForeColor = Color.Black
        SettingsButton.Location = New Point(105, 367)
        SettingsButton.Name = "SettingsButton"
        SettingsButton.Size = New Size(93, 44)
        SettingsButton.TabIndex = 5
        SettingsButton.Text = "Settings"
        SettingsButton.TextAlign = ContentAlignment.MiddleLeft
        SettingsButton.UseVisualStyleBackColor = False
        ' 
        ' BodyMeasurementsButton
        ' 
        BodyMeasurementsButton.BackColor = Color.Transparent
        BodyMeasurementsButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        BodyMeasurementsButton.ForeColor = Color.Black
        BodyMeasurementsButton.Location = New Point(103, 175)
        BodyMeasurementsButton.Name = "BodyMeasurementsButton"
        BodyMeasurementsButton.Size = New Size(199, 44)
        BodyMeasurementsButton.TabIndex = 2
        BodyMeasurementsButton.Text = "Body Measurements"
        BodyMeasurementsButton.TextAlign = ContentAlignment.MiddleLeft
        BodyMeasurementsButton.UseVisualStyleBackColor = False
        ' 
        ' ActivityTrackingButton
        ' 
        ActivityTrackingButton.BackColor = Color.Transparent
        ActivityTrackingButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        ActivityTrackingButton.ForeColor = Color.Black
        ActivityTrackingButton.Location = New Point(106, 240)
        ActivityTrackingButton.Name = "ActivityTrackingButton"
        ActivityTrackingButton.Size = New Size(196, 44)
        ActivityTrackingButton.TabIndex = 0
        ActivityTrackingButton.Text = "Activity Tracking"
        ActivityTrackingButton.TextAlign = ContentAlignment.MiddleLeft
        ActivityTrackingButton.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(35, 368)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(51, 44)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.White
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(36, 241)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(51, 43)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(337, 175)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(379, 236)
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.White
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(36, 302)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(51, 43)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 10
        PictureBox4.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.White
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(36, 176)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(51, 43)
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox5.TabIndex = 11
        PictureBox5.TabStop = False
        ' 
        ' HeFitsDashBoardForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(7), CByte(11), CByte(71))
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(737, 437)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(GroupBox1)
        Controls.Add(SettingsButton)
        Controls.Add(GoalsProgressButton)
        Controls.Add(BodyMeasurementsButton)
        Controls.Add(ActivityTrackingButton)
        FormBorderStyle = FormBorderStyle.None
        Name = "HeFitsDashBoardForm"
        Text = "HeFits App :)"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents NutritionButton As Button
    Friend WithEvents VitalSignsButton As Button
    Friend WithEvents FeedbackButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents WellnessInsightsButton As Button
    Friend WithEvents GoalsProgressButton As Button
    Friend WithEvents SettingsButton As Button
    Friend WithEvents BodyMeasurementsButton As Button
    Friend WithEvents ActivityTrackingButton As Button
    Friend WithEvents NotStartedGoalsListBox As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
End Class
