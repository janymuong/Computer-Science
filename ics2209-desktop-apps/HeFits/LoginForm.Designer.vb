<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        GroupBox1 = New GroupBox()
        Label4 = New Label()
        LoginPictureBox = New PictureBox()
        LoginPagePictureBox = New PictureBox()
        Label3 = New Label()
        SignupLinkLabel = New Label()
        LoginPasswordMaskedTextBox = New MaskedTextBox()
        LoginIdentifierTextBox = New TextBox()
        LoginButton = New Button()
        Label2 = New Label()
        Label1 = New Label()
        ExitLoginButton = New Button()
        GroupBox1.SuspendLayout()
        CType(LoginPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(LoginPagePictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Lavender
        GroupBox1.Controls.Add(ExitLoginButton)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(LoginPictureBox)
        GroupBox1.Controls.Add(LoginPagePictureBox)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(SignupLinkLabel)
        GroupBox1.Controls.Add(LoginPasswordMaskedTextBox)
        GroupBox1.Controls.Add(LoginIdentifierTextBox)
        GroupBox1.Controls.Add(LoginButton)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(1, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(715, 432)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(64), CByte(0), CByte(64))
        Label4.Font = New Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.DarkSalmon
        Label4.Location = New Point(32, -3)
        Label4.Name = "Label4"
        Label4.Size = New Size(75, 25)
        Label4.TabIndex = 2
        Label4.Text = "HeFits"
        ' 
        ' LoginPictureBox
        ' 
        LoginPictureBox.Location = New Point(32, 27)
        LoginPictureBox.Name = "LoginPictureBox"
        LoginPictureBox.Size = New Size(286, 199)
        LoginPictureBox.TabIndex = 8
        LoginPictureBox.TabStop = False
        ' 
        ' LoginPagePictureBox
        ' 
        LoginPagePictureBox.Image = CType(resources.GetObject("LoginPagePictureBox.Image"), Image)
        LoginPagePictureBox.Location = New Point(455, 80)
        LoginPagePictureBox.Name = "LoginPagePictureBox"
        LoginPagePictureBox.Size = New Size(30, 30)
        LoginPagePictureBox.SizeMode = PictureBoxSizeMode.AutoSize
        LoginPagePictureBox.TabIndex = 7
        LoginPagePictureBox.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CadetBlue
        Label3.Font = New Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(449, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(244, 38)
        Label3.TabIndex = 6
        Label3.Text = "Don't have an account?" & vbCrLf & "Take the first step! Sign up for HeFits :)"
        ' 
        ' SignupLinkLabel
        ' 
        SignupLinkLabel.AutoSize = True
        SignupLinkLabel.BackColor = Color.OliveDrab
        SignupLinkLabel.BorderStyle = BorderStyle.Fixed3D
        SignupLinkLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SignupLinkLabel.Location = New Point(519, 80)
        SignupLinkLabel.Name = "SignupLinkLabel"
        SignupLinkLabel.Size = New Size(105, 34)
        SignupLinkLabel.TabIndex = 5
        SignupLinkLabel.Text = "Sign Up"
        ' 
        ' LoginPasswordMaskedTextBox
        ' 
        LoginPasswordMaskedTextBox.BackColor = SystemColors.Window
        LoginPasswordMaskedTextBox.Location = New Point(274, 301)
        LoginPasswordMaskedTextBox.Name = "LoginPasswordMaskedTextBox"
        LoginPasswordMaskedTextBox.PasswordChar = "*"c
        LoginPasswordMaskedTextBox.Size = New Size(248, 31)
        LoginPasswordMaskedTextBox.TabIndex = 4
        ' 
        ' LoginIdentifierTextBox
        ' 
        LoginIdentifierTextBox.BackColor = SystemColors.Window
        LoginIdentifierTextBox.Location = New Point(274, 248)
        LoginIdentifierTextBox.Name = "LoginIdentifierTextBox"
        LoginIdentifierTextBox.Size = New Size(248, 31)
        LoginIdentifierTextBox.TabIndex = 3
        ' 
        ' LoginButton
        ' 
        LoginButton.BackColor = SystemColors.ActiveCaption
        LoginButton.Font = New Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LoginButton.ForeColor = SystemColors.ControlDarkDark
        LoginButton.Location = New Point(294, 360)
        LoginButton.Name = "LoginButton"
        LoginButton.Size = New Size(117, 49)
        LoginButton.TabIndex = 2
        LoginButton.Text = "Log In"
        LoginButton.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.ActiveBorder
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(138, 304)
        Label2.Name = "Label2"
        Label2.Size = New Size(97, 25)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.ActiveBorder
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(85, 251)
        Label1.Name = "Label1"
        Label1.Size = New Size(156, 25)
        Label1.TabIndex = 0
        Label1.Text = "Username/Email:"
        ' 
        ' ExitLoginButton
        ' 
        ExitLoginButton.BackColor = Color.DarkRed
        ExitLoginButton.ForeColor = SystemColors.ButtonFace
        ExitLoginButton.Location = New Point(633, 360)
        ExitLoginButton.Name = "ExitLoginButton"
        ExitLoginButton.Size = New Size(60, 49)
        ExitLoginButton.TabIndex = 9
        ExitLoginButton.Text = "Exit"
        ExitLoginButton.UseVisualStyleBackColor = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(761, 464)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "LoginForm"
        Text = "LoginForm"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(LoginPictureBox, ComponentModel.ISupportInitialize).EndInit()
        CType(LoginPagePictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LoginPasswordMaskedTextBox As MaskedTextBox
    Friend WithEvents LoginIdentifierTextBox As TextBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SignupLinkLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LoginPagePictureBox As PictureBox
    Friend WithEvents LoginPictureBox As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ExitLoginButton As Button
End Class
