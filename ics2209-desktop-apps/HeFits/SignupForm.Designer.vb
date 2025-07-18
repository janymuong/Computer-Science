<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignupForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignupForm))
        GroupBox1 = New GroupBox()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        SignupUsernameTextBox = New TextBox()
        Label3 = New Label()
        SignupPasswordMaskedTextBox = New MaskedTextBox()
        SignupEmailTextBox = New TextBox()
        SignupButton = New Button()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        GroupBox1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Gray
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(PictureBox2)
        GroupBox1.Controls.Add(PictureBox1)
        GroupBox1.Controls.Add(SignupUsernameTextBox)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(SignupPasswordMaskedTextBox)
        GroupBox1.Controls.Add(SignupEmailTextBox)
        GroupBox1.Controls.Add(SignupButton)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(879, 426)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.ActiveBorder
        Label4.Font = New Font("Segoe MDL2 Assets", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(6, 57)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 28)
        Label4.TabIndex = 8
        Label4.Text = "HeFits :)"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(517, 44)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(337, 356)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' SignupUsernameTextBox
        ' 
        SignupUsernameTextBox.Cursor = Cursors.IBeam
        SignupUsernameTextBox.Location = New Point(203, 151)
        SignupUsernameTextBox.Name = "SignupUsernameTextBox"
        SignupUsernameTextBox.Size = New Size(259, 31)
        SignupUsernameTextBox.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BorderStyle = BorderStyle.Fixed3D
        Label3.Font = New Font("Tw Cen MT Condensed Extra Bold", 9F)
        Label3.Location = New Point(78, 149)
        Label3.Name = "Label3"
        Label3.Size = New Size(87, 23)
        Label3.TabIndex = 5
        Label3.Text = "Username:"
        ' 
        ' SignupPasswordMaskedTextBox
        ' 
        SignupPasswordMaskedTextBox.Cursor = Cursors.IBeam
        SignupPasswordMaskedTextBox.Location = New Point(203, 201)
        SignupPasswordMaskedTextBox.Name = "SignupPasswordMaskedTextBox"
        SignupPasswordMaskedTextBox.Size = New Size(259, 31)
        SignupPasswordMaskedTextBox.TabIndex = 4
        ' 
        ' SignupEmailTextBox
        ' 
        SignupEmailTextBox.Cursor = Cursors.IBeam
        SignupEmailTextBox.Location = New Point(203, 103)
        SignupEmailTextBox.Name = "SignupEmailTextBox"
        SignupEmailTextBox.Size = New Size(265, 31)
        SignupEmailTextBox.TabIndex = 3
        ' 
        ' SignupButton
        ' 
        SignupButton.BackColor = Color.DarkOliveGreen
        SignupButton.FlatStyle = FlatStyle.Popup
        SignupButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SignupButton.ForeColor = SystemColors.ActiveCaptionText
        SignupButton.Location = New Point(278, 268)
        SignupButton.Name = "SignupButton"
        SignupButton.Size = New Size(104, 43)
        SignupButton.TabIndex = 2
        SignupButton.Text = "Sign Up"
        SignupButton.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Tw Cen MT Condensed Extra Bold", 9F)
        Label2.Location = New Point(84, 201)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 23)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BorderStyle = BorderStyle.Fixed3D
        Label1.Font = New Font("Tw Cen MT Condensed Extra Bold", 9F)
        Label1.Location = New Point(115, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 23)
        Label1.TabIndex = 0
        Label1.Text = "Email:"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(18, 15)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(73, 55)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' SignupForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Silver
        ClientSize = New Size(903, 450)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "SignupForm"
        Text = "SignupForm"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SignupButton As Button
    Friend WithEvents SignupPasswordMaskedTextBox As MaskedTextBox
    Friend WithEvents SignupEmailTextBox As TextBox
    Friend WithEvents SignupUsernameTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
