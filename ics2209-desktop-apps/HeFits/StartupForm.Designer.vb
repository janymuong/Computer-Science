<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartupForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartupForm))
        GroupBox1 = New GroupBox()
        Label1 = New Label()
        Label2 = New Label()
        StartupButton = New Button()
        ExitHeFitsButton = New Button()
        LogoPictureBox = New PictureBox()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        GroupBox1.SuspendLayout()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.ButtonShadow
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(196, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(375, 149)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bernard MT Condensed", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(62, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(275, 38)
        Label1.TabIndex = 0
        Label1.Text = "WELCOME TO HeFits "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(82, 91)
        Label2.Name = "Label2"
        Label2.Size = New Size(217, 21)
        Label2.TabIndex = 1
        Label2.Text = "Your Path to Peak Health!"
        ' 
        ' StartupButton
        ' 
        StartupButton.BackColor = Color.LawnGreen
        StartupButton.FlatStyle = FlatStyle.Popup
        StartupButton.Font = New Font("Tahoma", 10F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        StartupButton.Location = New Point(315, 428)
        StartupButton.Name = "StartupButton"
        StartupButton.Size = New Size(136, 45)
        StartupButton.TabIndex = 3
        StartupButton.Text = "Get Started"
        StartupButton.UseVisualStyleBackColor = False
        ' 
        ' ExitHeFitsButton
        ' 
        ExitHeFitsButton.BackColor = Color.DarkRed
        ExitHeFitsButton.ForeColor = SystemColors.ButtonFace
        ExitHeFitsButton.Location = New Point(702, 440)
        ExitHeFitsButton.Name = "ExitHeFitsButton"
        ExitHeFitsButton.Size = New Size(77, 40)
        ExitHeFitsButton.TabIndex = 4
        ExitHeFitsButton.Text = "Close"
        ExitHeFitsButton.UseVisualStyleBackColor = False
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Location = New Point(258, 167)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(256, 241)
        LogoPictureBox.TabIndex = 5
        LogoPictureBox.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.ActiveBorder
        Label3.Font = New Font("Segoe MDL2 Assets", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(1, 452)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 28)
        Label3.TabIndex = 6
        Label3.Text = "HeFits :)"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(1, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(73, 55)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' StartupForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(791, 484)
        Controls.Add(PictureBox1)
        Controls.Add(Label3)
        Controls.Add(LogoPictureBox)
        Controls.Add(ExitHeFitsButton)
        Controls.Add(StartupButton)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "StartupForm"
        Text = "HeFits App"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents StartupButton As Button
    Friend WithEvents ExitHeFitsButton As Button
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox

End Class
