<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BodyMeasurementsForm
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
        SubmitButton = New Button()
        Label3 = New Label()
        BMITextBox = New TextBox()
        Label2 = New Label()
        HeightTextBox = New TextBox()
        Label1 = New Label()
        BodyWeightTextBox = New TextBox()
        BackToDashboardButton = New Button()
        BMIetcPictureBox = New PictureBox()
        Label4 = New Label()
        GroupBox1.SuspendLayout()
        CType(BMIetcPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.LightSlateGray
        GroupBox1.Controls.Add(SubmitButton)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(BMITextBox)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(HeightTextBox)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(BodyWeightTextBox)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(381, 328)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "BODY MEASUREMENTS:"
        ' 
        ' SubmitButton
        ' 
        SubmitButton.BackColor = Color.DarkOliveGreen
        SubmitButton.Font = New Font("Tahoma", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SubmitButton.ForeColor = Color.GhostWhite
        SubmitButton.Location = New Point(254, 253)
        SubmitButton.Name = "SubmitButton"
        SubmitButton.Size = New Size(87, 54)
        SubmitButton.TabIndex = 6
        SubmitButton.Text = "Save"
        SubmitButton.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.ButtonShadow
        Label3.Location = New Point(133, 170)
        Label3.Name = "Label3"
        Label3.Size = New Size(47, 25)
        Label3.TabIndex = 5
        Label3.Text = "BMI:"
        ' 
        ' BMITextBox
        ' 
        BMITextBox.Location = New Point(221, 164)
        BMITextBox.Name = "BMITextBox"
        BMITextBox.Size = New Size(150, 31)
        BMITextBox.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.ButtonShadow
        Label2.Location = New Point(28, 101)
        Label2.Name = "Label2"
        Label2.Size = New Size(132, 25)
        Label2.TabIndex = 3
        Label2.Text = " Height (in cm):"
        ' 
        ' HeightTextBox
        ' 
        HeightTextBox.Location = New Point(221, 95)
        HeightTextBox.Name = "HeightTextBox"
        HeightTextBox.Size = New Size(150, 31)
        HeightTextBox.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.ButtonShadow
        Label1.Location = New Point(21, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 25)
        Label1.TabIndex = 1
        Label1.Text = "Body weight in kg:"
        ' 
        ' BodyWeightTextBox
        ' 
        BodyWeightTextBox.Location = New Point(221, 41)
        BodyWeightTextBox.Name = "BodyWeightTextBox"
        BodyWeightTextBox.Size = New Size(150, 31)
        BodyWeightTextBox.TabIndex = 0
        ' 
        ' BackToDashboardButton
        ' 
        BackToDashboardButton.BackColor = Color.Brown
        BackToDashboardButton.Font = New Font("Tahoma", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BackToDashboardButton.Location = New Point(639, 325)
        BackToDashboardButton.Name = "BackToDashboardButton"
        BackToDashboardButton.Size = New Size(61, 51)
        BackToDashboardButton.TabIndex = 7
        BackToDashboardButton.Text = "🔙"
        BackToDashboardButton.UseVisualStyleBackColor = False
        ' 
        ' BMIetcPictureBox
        ' 
        BMIetcPictureBox.Location = New Point(408, 39)
        BMIetcPictureBox.Name = "BMIetcPictureBox"
        BMIetcPictureBox.Size = New Size(312, 280)
        BMIetcPictureBox.TabIndex = 8
        BMIetcPictureBox.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(610, 5)
        Label4.Name = "Label4"
        Label4.Size = New Size(99, 31)
        Label4.TabIndex = 9
        Label4.Text = "HeFits :)"
        ' 
        ' BodyMeasurementsForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonShadow
        ClientSize = New Size(735, 382)
        Controls.Add(Label4)
        Controls.Add(BMIetcPictureBox)
        Controls.Add(BackToDashboardButton)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "BodyMeasurementsForm"
        Text = "BodyMeasurementsForm"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(BMIetcPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BodyWeightTextBox As TextBox
    Friend WithEvents SubmitButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents BMITextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents HeightTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BackToDashboardButton As Button
    Friend WithEvents BMIetcPictureBox As PictureBox
    Friend WithEvents Label4 As Label
End Class
