<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangePassword
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePassword))
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.chkConfirmPass = New System.Windows.Forms.CheckBox()
        Me.chkNewPass = New System.Windows.Forms.CheckBox()
        Me.chkCurrentPass = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New POS4U.TextInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNewPassword = New POS4U.TextInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsername = New POS4U.TextInput()
        Me.txtPassword = New POS4U.TextInput()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonEnter = New FontAwesome.Sharp.IconButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.HeaderPanel.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNewPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.Black
        Me.HeaderPanel.Controls.Add(Me.Label1)
        Me.HeaderPanel.Controls.Add(Me.ButtonClose)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(936, 40)
        Me.HeaderPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(380, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CHANGE PASSWORD"
        '
        'MainPanel
        '
        Me.MainPanel.AutoSize = True
        Me.MainPanel.Controls.Add(Me.chkConfirmPass)
        Me.MainPanel.Controls.Add(Me.chkNewPass)
        Me.MainPanel.Controls.Add(Me.chkCurrentPass)
        Me.MainPanel.Controls.Add(Me.Label9)
        Me.MainPanel.Controls.Add(Me.Label7)
        Me.MainPanel.Controls.Add(Me.Label8)
        Me.MainPanel.Controls.Add(Me.Label6)
        Me.MainPanel.Controls.Add(Me.PictureBox1)
        Me.MainPanel.Controls.Add(Me.Panel1)
        Me.MainPanel.Controls.Add(Me.Label5)
        Me.MainPanel.Controls.Add(Me.txtConfirmPassword)
        Me.MainPanel.Controls.Add(Me.Label4)
        Me.MainPanel.Controls.Add(Me.txtNewPassword)
        Me.MainPanel.Controls.Add(Me.Label2)
        Me.MainPanel.Controls.Add(Me.Label3)
        Me.MainPanel.Controls.Add(Me.txtUsername)
        Me.MainPanel.Controls.Add(Me.txtPassword)
        Me.MainPanel.Controls.Add(Me.ButtonEnter)
        Me.MainPanel.Controls.Add(Me.PictureBox3)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 40)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(936, 458)
        Me.MainPanel.TabIndex = 1
        '
        'chkConfirmPass
        '
        Me.chkConfirmPass.AutoSize = True
        Me.chkConfirmPass.BackColor = System.Drawing.Color.Transparent
        Me.chkConfirmPass.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConfirmPass.Location = New System.Drawing.Point(851, 295)
        Me.chkConfirmPass.Margin = New System.Windows.Forms.Padding(2)
        Me.chkConfirmPass.Name = "chkConfirmPass"
        Me.chkConfirmPass.Size = New System.Drawing.Size(15, 14)
        Me.chkConfirmPass.TabIndex = 48
        Me.chkConfirmPass.UseVisualStyleBackColor = False
        '
        'chkNewPass
        '
        Me.chkNewPass.AutoSize = True
        Me.chkNewPass.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNewPass.Location = New System.Drawing.Point(851, 223)
        Me.chkNewPass.Margin = New System.Windows.Forms.Padding(2)
        Me.chkNewPass.Name = "chkNewPass"
        Me.chkNewPass.Size = New System.Drawing.Size(15, 14)
        Me.chkNewPass.TabIndex = 47
        Me.chkNewPass.UseVisualStyleBackColor = True
        '
        'chkCurrentPass
        '
        Me.chkCurrentPass.AutoSize = True
        Me.chkCurrentPass.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCurrentPass.Location = New System.Drawing.Point(851, 148)
        Me.chkCurrentPass.Margin = New System.Windows.Forms.Padding(2)
        Me.chkCurrentPass.Name = "chkCurrentPass"
        Me.chkCurrentPass.Size = New System.Drawing.Size(15, 14)
        Me.chkCurrentPass.TabIndex = 46
        Me.chkCurrentPass.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(393, 333)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 21)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "- Home Comforts"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(248, 301)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 21)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "for others to guess."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(106, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(433, 21)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "long enough. It should be easy for you to remember but hard"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(95, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(448, 21)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Keep your data safe by creating a password that is complex and"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(2, 416)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(931, 48)
        Me.Panel1.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(579, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 21)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Confirm Password:"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.DisplayFormat = ""
        Me.txtConfirmPassword.EnterMoveNextControl = True
        Me.txtConfirmPassword.Location = New System.Drawing.Point(581, 289)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtConfirmPassword.Properties.Appearance.Options.UseFont = True
        Me.txtConfirmPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Properties.ValidateOnEnterKey = True
        Me.txtConfirmPassword.Size = New System.Drawing.Size(266, 28)
        Me.txtConfirmPassword.TabIndex = 31
        Me.txtConfirmPassword.TableField = ""
        Me.txtConfirmPassword.TableName = ""
        Me.txtConfirmPassword.UseSystemPasswordChar = Nothing
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(581, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 21)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "New Password:"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.DisplayFormat = ""
        Me.txtNewPassword.EnterMoveNextControl = True
        Me.txtNewPassword.Location = New System.Drawing.Point(580, 216)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtNewPassword.Properties.Appearance.Options.UseFont = True
        Me.txtNewPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Properties.ValidateOnEnterKey = True
        Me.txtNewPassword.Size = New System.Drawing.Size(266, 28)
        Me.txtNewPassword.TabIndex = 29
        Me.txtNewPassword.TableField = ""
        Me.txtNewPassword.TableName = ""
        Me.txtNewPassword.UseSystemPasswordChar = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(578, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 21)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Current Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(577, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 21)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.DisplayFormat = ""
        Me.txtUsername.Enabled = False
        Me.txtUsername.EnterMoveNextControl = True
        Me.txtUsername.Location = New System.Drawing.Point(580, 78)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtUsername.Properties.Appearance.Options.UseFont = True
        Me.txtUsername.Size = New System.Drawing.Size(266, 28)
        Me.txtUsername.TabIndex = 25
        Me.txtUsername.TableField = ""
        Me.txtUsername.TableName = ""
        Me.txtUsername.UseSystemPasswordChar = Nothing
        '
        'txtPassword
        '
        Me.txtPassword.DisplayFormat = ""
        Me.txtPassword.EnterMoveNextControl = True
        Me.txtPassword.Location = New System.Drawing.Point(580, 142)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtPassword.Properties.Appearance.Options.UseFont = True
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Properties.ValidateOnEnterKey = True
        Me.txtPassword.Size = New System.Drawing.Size(266, 28)
        Me.txtPassword.TabIndex = 26
        Me.txtPassword.TableField = ""
        Me.txtPassword.TableName = ""
        Me.txtPassword.UseSystemPasswordChar = Nothing
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(131, 68)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(372, 178)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'ButtonEnter
        '
        Me.ButtonEnter.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(151, Byte), Integer))
        Me.ButtonEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEnter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEnter.ForeColor = System.Drawing.Color.White
        Me.ButtonEnter.IconChar = FontAwesome.Sharp.IconChar.None
        Me.ButtonEnter.IconColor = System.Drawing.Color.Transparent
        Me.ButtonEnter.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonEnter.Location = New System.Drawing.Point(616, 340)
        Me.ButtonEnter.Name = "ButtonEnter"
        Me.ButtonEnter.Size = New System.Drawing.Size(202, 36)
        Me.ButtonEnter.TabIndex = 13
        Me.ButtonEnter.Text = "UPDATE PASSWORD"
        Me.ButtonEnter.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(935, 501)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 38
        Me.PictureBox3.TabStop = False
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.BackColor = System.Drawing.Color.Transparent
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.ButtonClose.IconColor = System.Drawing.Color.White
        Me.ButtonClose.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonClose.IconSize = 24
        Me.ButtonClose.Location = New System.Drawing.Point(897, 5)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(33, 30)
        Me.ButtonClose.TabIndex = 1
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 498)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SettlePayment"
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNewPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents MainPanel As Panel
    Friend WithEvents ButtonEnter As FontAwesome.Sharp.IconButton
    Friend WithEvents Label5 As Label
    Friend WithEvents txtConfirmPassword As TextInput
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNewPassword As TextInput
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextInput
    Friend WithEvents txtPassword As TextInput
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents chkConfirmPass As CheckBox
    Friend WithEvents chkNewPass As CheckBox
    Friend WithEvents chkCurrentPass As CheckBox
End Class
