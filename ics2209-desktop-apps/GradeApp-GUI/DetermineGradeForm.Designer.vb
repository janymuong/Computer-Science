<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DetermineGradeForm
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
        GroupBox1 = New GroupBox()
        LogOffButton = New Button()
        CheckgradeButton = New Button()
        LATextBox = New TextBox()
        DBTextBox = New TextBox()
        CATextBox = New TextBox()
        SCTextBox = New TextBox()
        Label5 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label4 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Silver
        GroupBox1.Controls.Add(LogOffButton)
        GroupBox1.Controls.Add(CheckgradeButton)
        GroupBox1.Controls.Add(LATextBox)
        GroupBox1.Controls.Add(DBTextBox)
        GroupBox1.Controls.Add(CATextBox)
        GroupBox1.Controls.Add(SCTextBox)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(735, 426)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "SnugGrades"
        ' 
        ' LogOffButton
        ' 
        LogOffButton.BackColor = Color.Red
        LogOffButton.Font = New Font("Kristen ITC", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LogOffButton.Location = New Point(620, 24)
        LogOffButton.Name = "LogOffButton"
        LogOffButton.Size = New Size(95, 61)
        LogOffButton.TabIndex = 14
        LogOffButton.Text = "Log Off"
        LogOffButton.UseVisualStyleBackColor = False
        ' 
        ' CheckgradeButton
        ' 
        CheckgradeButton.BackColor = Color.RosyBrown
        CheckgradeButton.Font = New Font("Kristen ITC", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CheckgradeButton.Location = New Point(240, 335)
        CheckgradeButton.Name = "CheckgradeButton"
        CheckgradeButton.Size = New Size(168, 61)
        CheckgradeButton.TabIndex = 13
        CheckgradeButton.Text = "Check GRADE"
        CheckgradeButton.UseVisualStyleBackColor = False
        ' 
        ' LATextBox
        ' 
        LATextBox.Location = New Point(328, 288)
        LATextBox.Name = "LATextBox"
        LATextBox.Size = New Size(181, 31)
        LATextBox.TabIndex = 12
        ' 
        ' DBTextBox
        ' 
        DBTextBox.Location = New Point(328, 235)
        DBTextBox.Name = "DBTextBox"
        DBTextBox.Size = New Size(181, 31)
        DBTextBox.TabIndex = 11
        ' 
        ' CATextBox
        ' 
        CATextBox.Location = New Point(328, 180)
        CATextBox.Name = "CATextBox"
        CATextBox.Size = New Size(181, 31)
        CATextBox.TabIndex = 10
        ' 
        ' SCTextBox
        ' 
        SCTextBox.Location = New Point(328, 134)
        SCTextBox.Name = "SCTextBox"
        SCTextBox.Size = New Size(181, 31)
        SCTextBox.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Thistle
        Label5.Location = New Point(98, 288)
        Label5.Name = "Label5"
        Label5.Size = New Size(205, 25)
        Label5.TabIndex = 8
        Label5.Text = "ICS 2211: Linear Algebra"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Thistle
        Label3.Location = New Point(67, 235)
        Label3.Name = "Label3"
        Label3.Size = New Size(236, 25)
        Label3.TabIndex = 7
        Label3.Text = "ICS 2206: Database Systems"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.RosyBrown
        Label2.Location = New Point(28, 180)
        Label2.Name = "Label2"
        Label2.Size = New Size(275, 25)
        Label2.TabIndex = 6
        Label2.Text = "ICS 2209: Computer Applications"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Thistle
        Label1.Location = New Point(47, 134)
        Label1.Name = "Label1"
        Label1.Size = New Size(256, 25)
        Label1.TabIndex = 5
        Label1.Text = "ICS 2207: Scientific Computing"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Indigo
        Label4.BorderStyle = BorderStyle.Fixed3D
        Label4.Location = New Point(16, 40)
        Label4.Name = "Label4"
        Label4.Size = New Size(280, 52)
        Label4.TabIndex = 4
        Label4.Text = "Welcome to SnugGrades :)" & vbCrLf & "Where Learning Feels Like Home! "
        ' 
        ' DetermineGradeForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Lavender
        ClientSize = New Size(761, 454)
        Controls.Add(GroupBox1)
        ForeColor = SystemColors.GrayText
        FormBorderStyle = FormBorderStyle.None
        Name = "DetermineGradeForm"
        Text = "SnugGrades GUI"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckgradeButton As Button
    Friend WithEvents LATextBox As TextBox
    Friend WithEvents DBTextBox As TextBox
    Friend WithEvents CATextBox As TextBox
    Friend WithEvents SCTextBox As TextBox
    Friend WithEvents LogOffButton As Button

End Class
