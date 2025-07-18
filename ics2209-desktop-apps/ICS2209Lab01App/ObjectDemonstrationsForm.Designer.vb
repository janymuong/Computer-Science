<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObjectDemonstrationsForm
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
        ObjectDemoHeaderLabel = New Label()
        ExitButton = New Button()
        ImagePictureBox = New PictureBox()
        LoadPictureButton = New Button()
        DisplayTestGroupBox = New GroupBox()
        DisplayTestTextBox = New TextBox()
        FontGroupBox = New GroupBox()
        TahomaRadioButton = New RadioButton()
        MagnetoRadioButton = New RadioButton()
        GaramondRadioButton = New RadioButton()
        FontStyleGroupBox = New GroupBox()
        BoldItalicCheckBox = New CheckBox()
        BoldCheckBox = New CheckBox()
        ItalicCheckBox = New CheckBox()
        FontColorGroupBox = New GroupBox()
        BlueRadioButton = New RadioButton()
        RedRadioButton = New RadioButton()
        GreenRadioButton = New RadioButton()
        CType(ImagePictureBox, ComponentModel.ISupportInitialize).BeginInit()
        DisplayTestGroupBox.SuspendLayout()
        FontGroupBox.SuspendLayout()
        FontStyleGroupBox.SuspendLayout()
        FontColorGroupBox.SuspendLayout()
        SuspendLayout()
        ' 
        ' ObjectDemoHeaderLabel
        ' 
        ObjectDemoHeaderLabel.AutoSize = True
        ObjectDemoHeaderLabel.BorderStyle = BorderStyle.FixedSingle
        ObjectDemoHeaderLabel.Location = New Point(241, 21)
        ObjectDemoHeaderLabel.Name = "ObjectDemoHeaderLabel"
        ObjectDemoHeaderLabel.Size = New Size(198, 27)
        ObjectDemoHeaderLabel.TabIndex = 0
        ObjectDemoHeaderLabel.Text = "Object Demonstrations"
        ' 
        ' ExitButton
        ' 
        ExitButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ExitButton.Location = New Point(626, 419)
        ExitButton.Name = "ExitButton"
        ExitButton.Size = New Size(97, 53)
        ExitButton.TabIndex = 16
        ExitButton.Text = "Exit"
        ExitButton.UseVisualStyleBackColor = True
        ' 
        ' ImagePictureBox
        ' 
        ImagePictureBox.BorderStyle = BorderStyle.FixedSingle
        ImagePictureBox.Location = New Point(51, 221)
        ImagePictureBox.Name = "ImagePictureBox"
        ImagePictureBox.Size = New Size(310, 178)
        ImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        ImagePictureBox.TabIndex = 17
        ImagePictureBox.TabStop = False
        ' 
        ' LoadPictureButton
        ' 
        LoadPictureButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LoadPictureButton.Location = New Point(73, 419)
        LoadPictureButton.Name = "LoadPictureButton"
        LoadPictureButton.Size = New Size(174, 53)
        LoadPictureButton.TabIndex = 18
        LoadPictureButton.Text = "Load Picture "
        LoadPictureButton.TextAlign = ContentAlignment.MiddleLeft
        LoadPictureButton.UseVisualStyleBackColor = True
        ' 
        ' DisplayTestGroupBox
        ' 
        DisplayTestGroupBox.Controls.Add(DisplayTestTextBox)
        DisplayTestGroupBox.Location = New Point(51, 104)
        DisplayTestGroupBox.Name = "DisplayTestGroupBox"
        DisplayTestGroupBox.Size = New Size(232, 89)
        DisplayTestGroupBox.TabIndex = 19
        DisplayTestGroupBox.TabStop = False
        DisplayTestGroupBox.Text = "Display Test"
        ' 
        ' DisplayTestTextBox
        ' 
        DisplayTestTextBox.Location = New Point(6, 30)
        DisplayTestTextBox.Name = "DisplayTestTextBox"
        DisplayTestTextBox.Size = New Size(142, 31)
        DisplayTestTextBox.TabIndex = 2
        DisplayTestTextBox.Text = "Sample Test"
        ' 
        ' FontGroupBox
        ' 
        FontGroupBox.Controls.Add(TahomaRadioButton)
        FontGroupBox.Controls.Add(MagnetoRadioButton)
        FontGroupBox.Controls.Add(GaramondRadioButton)
        FontGroupBox.Location = New Point(370, 104)
        FontGroupBox.Name = "FontGroupBox"
        FontGroupBox.Size = New Size(405, 89)
        FontGroupBox.TabIndex = 20
        FontGroupBox.TabStop = False
        FontGroupBox.Text = "Font"
        ' 
        ' TahomaRadioButton
        ' 
        TahomaRadioButton.AutoSize = True
        TahomaRadioButton.Location = New Point(256, 39)
        TahomaRadioButton.Name = "TahomaRadioButton"
        TahomaRadioButton.Size = New Size(99, 29)
        TahomaRadioButton.TabIndex = 10
        TahomaRadioButton.TabStop = True
        TahomaRadioButton.Text = "Tahoma"
        TahomaRadioButton.UseVisualStyleBackColor = True
        ' 
        ' MagnetoRadioButton
        ' 
        MagnetoRadioButton.AutoSize = True
        MagnetoRadioButton.Location = New Point(141, 39)
        MagnetoRadioButton.Name = "MagnetoRadioButton"
        MagnetoRadioButton.Size = New Size(109, 29)
        MagnetoRadioButton.TabIndex = 9
        MagnetoRadioButton.TabStop = True
        MagnetoRadioButton.Text = "Magneto"
        MagnetoRadioButton.UseVisualStyleBackColor = True
        ' 
        ' GaramondRadioButton
        ' 
        GaramondRadioButton.AutoSize = True
        GaramondRadioButton.Location = New Point(14, 39)
        GaramondRadioButton.Name = "GaramondRadioButton"
        GaramondRadioButton.Size = New Size(121, 29)
        GaramondRadioButton.TabIndex = 8
        GaramondRadioButton.TabStop = True
        GaramondRadioButton.Text = "Garamond"
        GaramondRadioButton.UseVisualStyleBackColor = True
        ' 
        ' FontStyleGroupBox
        ' 
        FontStyleGroupBox.Controls.Add(BoldItalicCheckBox)
        FontStyleGroupBox.Controls.Add(BoldCheckBox)
        FontStyleGroupBox.Controls.Add(ItalicCheckBox)
        FontStyleGroupBox.Location = New Point(405, 221)
        FontStyleGroupBox.Name = "FontStyleGroupBox"
        FontStyleGroupBox.Size = New Size(161, 157)
        FontStyleGroupBox.TabIndex = 21
        FontStyleGroupBox.TabStop = False
        FontStyleGroupBox.Text = "Font Style"
        ' 
        ' BoldItalicCheckBox
        ' 
        BoldItalicCheckBox.AutoSize = True
        BoldItalicCheckBox.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        BoldItalicCheckBox.Location = New Point(16, 101)
        BoldItalicCheckBox.Name = "BoldItalicCheckBox"
        BoldItalicCheckBox.Size = New Size(126, 29)
        BoldItalicCheckBox.TabIndex = 18
        BoldItalicCheckBox.Text = "Bold Italic"
        BoldItalicCheckBox.UseVisualStyleBackColor = True
        ' 
        ' BoldCheckBox
        ' 
        BoldCheckBox.AutoSize = True
        BoldCheckBox.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BoldCheckBox.Location = New Point(16, 67)
        BoldCheckBox.Name = "BoldCheckBox"
        BoldCheckBox.Size = New Size(77, 29)
        BoldCheckBox.TabIndex = 17
        BoldCheckBox.Text = "Bold"
        BoldCheckBox.UseVisualStyleBackColor = True
        ' 
        ' ItalicCheckBox
        ' 
        ItalicCheckBox.AutoSize = True
        ItalicCheckBox.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ItalicCheckBox.Location = New Point(16, 32)
        ItalicCheckBox.Name = "ItalicCheckBox"
        ItalicCheckBox.Size = New Size(77, 29)
        ItalicCheckBox.TabIndex = 16
        ItalicCheckBox.Text = "Italic"
        ItalicCheckBox.UseVisualStyleBackColor = True
        ' 
        ' FontColorGroupBox
        ' 
        FontColorGroupBox.Controls.Add(BlueRadioButton)
        FontColorGroupBox.Controls.Add(RedRadioButton)
        FontColorGroupBox.Controls.Add(GreenRadioButton)
        FontColorGroupBox.Location = New Point(592, 221)
        FontColorGroupBox.Name = "FontColorGroupBox"
        FontColorGroupBox.Size = New Size(133, 157)
        FontColorGroupBox.TabIndex = 22
        FontColorGroupBox.TabStop = False
        FontColorGroupBox.Text = "Font Color"
        ' 
        ' BlueRadioButton
        ' 
        BlueRadioButton.AutoSize = True
        BlueRadioButton.Location = New Point(20, 66)
        BlueRadioButton.Name = "BlueRadioButton"
        BlueRadioButton.Size = New Size(70, 29)
        BlueRadioButton.TabIndex = 13
        BlueRadioButton.TabStop = True
        BlueRadioButton.Text = "Blue"
        BlueRadioButton.UseVisualStyleBackColor = True
        ' 
        ' RedRadioButton
        ' 
        RedRadioButton.AutoSize = True
        RedRadioButton.Location = New Point(20, 101)
        RedRadioButton.Name = "RedRadioButton"
        RedRadioButton.Size = New Size(67, 29)
        RedRadioButton.TabIndex = 12
        RedRadioButton.TabStop = True
        RedRadioButton.Text = "Red"
        RedRadioButton.UseVisualStyleBackColor = True
        ' 
        ' GreenRadioButton
        ' 
        GreenRadioButton.AutoSize = True
        GreenRadioButton.Location = New Point(20, 31)
        GreenRadioButton.Name = "GreenRadioButton"
        GreenRadioButton.Size = New Size(83, 29)
        GreenRadioButton.TabIndex = 11
        GreenRadioButton.TabStop = True
        GreenRadioButton.Text = "Green"
        GreenRadioButton.UseVisualStyleBackColor = True
        ' 
        ' ObjectDemonstrationsForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 508)
        Controls.Add(FontColorGroupBox)
        Controls.Add(FontStyleGroupBox)
        Controls.Add(FontGroupBox)
        Controls.Add(DisplayTestGroupBox)
        Controls.Add(LoadPictureButton)
        Controls.Add(ImagePictureBox)
        Controls.Add(ExitButton)
        Controls.Add(ObjectDemoHeaderLabel)
        Name = "ObjectDemonstrationsForm"
        Text = "ObjectDemonstrationsForm"
        CType(ImagePictureBox, ComponentModel.ISupportInitialize).EndInit()
        DisplayTestGroupBox.ResumeLayout(False)
        DisplayTestGroupBox.PerformLayout()
        FontGroupBox.ResumeLayout(False)
        FontGroupBox.PerformLayout()
        FontStyleGroupBox.ResumeLayout(False)
        FontStyleGroupBox.PerformLayout()
        FontColorGroupBox.ResumeLayout(False)
        FontColorGroupBox.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ObjectDemoHeaderLabel As Label
    Friend WithEvents CheckBox As CheckBox
    Friend WithEvents ExitButton As Button
    Friend WithEvents ImagePictureBox As PictureBox
    Friend WithEvents LoadPictureButton As Button
    Friend WithEvents DisplayTestGroupBox As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TahomaRadioButton As RadioButton
    Friend WithEvents MagnetoRadioButton As RadioButton
    Friend WithEvents GaramondRadioButton As RadioButton
    Friend WithEvents DisplayTestTextBox As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BoldItalicCheckBox As CheckBox
    Friend WithEvents BoldCheckBox As CheckBox
    Friend WithEvents ItalicCheckBox As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BlueRadioButton As RadioButton
    Friend WithEvents RedRadioButton As RadioButton
    Friend WithEvents GreenRadioButton As RadioButton
    Friend WithEvents FontGroupBox As GroupBox
    Friend WithEvents FontStyleGroupBox As GroupBox
    Friend WithEvents FontColorGroupBox As GroupBox
End Class
