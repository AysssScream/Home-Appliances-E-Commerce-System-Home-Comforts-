<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    'Inherits POS4U.BaseForm
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
        Me.components = New System.ComponentModel.Container()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.InputValidator = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.txtUsername = New POS4U.TextInput()
        Me.txtPassword = New POS4U.TextInput()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnConnection = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkCheck = New System.Windows.Forms.CheckBox()
        Me.btnLog_In = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Clear = New Guna.UI2.WinForms.Guna2Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCreate = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblForgotPassword = New System.Windows.Forms.Label()
        CType(Me.InputValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.DisplayFormat = ""
        Me.txtUsername.EnterMoveNextControl = True
        Me.txtUsername.Location = New System.Drawing.Point(476, 415)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Properties.Appearance.Options.UseFont = True
        Me.txtUsername.Size = New System.Drawing.Size(280, 24)
        Me.txtUsername.TabIndex = 3
        Me.txtUsername.TableField = ""
        Me.txtUsername.TableName = ""
        Me.txtUsername.UseSystemPasswordChar = Nothing
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Input username..."
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.InputValidator.SetValidationRule(Me.txtUsername, ConditionValidationRule1)
        '
        'txtPassword
        '
        Me.txtPassword.DisplayFormat = ""
        Me.txtPassword.EnterMoveNextControl = True
        Me.txtPassword.Location = New System.Drawing.Point(476, 457)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Properties.Appearance.Options.UseFont = True
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Properties.ValidateOnEnterKey = True
        Me.txtPassword.Size = New System.Drawing.Size(280, 24)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.TableField = ""
        Me.txtPassword.TableName = ""
        Me.txtPassword.UseSystemPasswordChar = Nothing
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Input password..."
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.InputValidator.SetValidationRule(Me.txtPassword, ConditionValidationRule2)
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.Black
        Me.HeaderPanel.Controls.Add(Me.Label5)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(1159, 47)
        Me.HeaderPanel.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 18)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "LOGIN"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.btnConnection)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 830)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1159, 36)
        Me.Panel2.TabIndex = 12
        '
        'btnConnection
        '
        Me.btnConnection.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnConnection.FlatAppearance.BorderSize = 0
        Me.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnection.ForeColor = System.Drawing.Color.White
        Me.btnConnection.IconChar = FontAwesome.Sharp.IconChar.Database
        Me.btnConnection.IconColor = System.Drawing.Color.White
        Me.btnConnection.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnConnection.IconSize = 20
        Me.btnConnection.Location = New System.Drawing.Point(3, 3)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(37, 30)
        Me.btnConnection.TabIndex = 27
        Me.btnConnection.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(376, 416)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Username:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(381, 458)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 21)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Password:"
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCheck.Location = New System.Drawing.Point(476, 495)
        Me.chkCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.Size = New System.Drawing.Size(138, 25)
        Me.chkCheck.TabIndex = 38
        Me.chkCheck.Text = "Show Password"
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'btnLog_In
        '
        Me.btnLog_In.BorderRadius = 8
        Me.btnLog_In.BorderThickness = 1
        Me.btnLog_In.CheckedState.Parent = Me.btnLog_In
        Me.btnLog_In.CustomImages.Parent = Me.btnLog_In
        Me.btnLog_In.FillColor = System.Drawing.Color.OrangeRed
        Me.btnLog_In.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLog_In.ForeColor = System.Drawing.Color.White
        Me.btnLog_In.HoverState.Parent = Me.btnLog_In
        Me.btnLog_In.Location = New System.Drawing.Point(378, 558)
        Me.btnLog_In.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLog_In.Name = "btnLog_In"
        Me.btnLog_In.ShadowDecoration.Parent = Me.btnLog_In
        Me.btnLog_In.Size = New System.Drawing.Size(188, 33)
        Me.btnLog_In.TabIndex = 39
        Me.btnLog_In.Text = "Log In"
        '
        'btn_Clear
        '
        Me.btn_Clear.BorderRadius = 8
        Me.btn_Clear.BorderThickness = 1
        Me.btn_Clear.CheckedState.Parent = Me.btn_Clear
        Me.btn_Clear.CustomImages.Parent = Me.btn_Clear
        Me.btn_Clear.FillColor = System.Drawing.Color.OrangeRed
        Me.btn_Clear.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Clear.ForeColor = System.Drawing.Color.White
        Me.btn_Clear.HoverState.Parent = Me.btn_Clear
        Me.btn_Clear.Location = New System.Drawing.Point(581, 558)
        Me.btn_Clear.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.ShadowDecoration.Parent = Me.btn_Clear
        Me.btn_Clear.Size = New System.Drawing.Size(188, 33)
        Me.btn_Clear.TabIndex = 40
        Me.btn_Clear.Text = "Clear"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(439, 613)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 23)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "No Account yet?"
        '
        'lblCreate
        '
        Me.lblCreate.AutoSize = True
        Me.lblCreate.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreate.Location = New System.Drawing.Point(577, 613)
        Me.lblCreate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCreate.Name = "lblCreate"
        Me.lblCreate.Size = New System.Drawing.Size(128, 23)
        Me.lblCreate.TabIndex = 43
        Me.lblCreate.Text = "Create Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(497, 374)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 24)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Ready To Login"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(320, 119)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(508, 241)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 36
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(574, 790)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(574, 40)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(587, 790)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'lblForgotPassword
        '
        Me.lblForgotPassword.AutoSize = True
        Me.lblForgotPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgotPassword.Location = New System.Drawing.Point(631, 494)
        Me.lblForgotPassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblForgotPassword.Name = "lblForgotPassword"
        Me.lblForgotPassword.Size = New System.Drawing.Size(133, 21)
        Me.lblForgotPassword.TabIndex = 46
        Me.lblForgotPassword.Text = "Forgot Password?"
        '
        'Login
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.ClientSize = New System.Drawing.Size(1159, 866)
        Me.Controls.Add(Me.lblForgotPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCreate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.btnLog_In)
        Me.Controls.Add(Me.chkCheck)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "McSkin"
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.InputValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As POS4U.TextInput
    Friend WithEvents txtUsername As POS4U.TextInput
    Friend WithEvents PictureEdit1 As POS4U.PictureEdit
    Friend WithEvents InputValidator As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnConnection As FontAwesome.Sharp.IconButton
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkCheck As CheckBox
    Friend WithEvents btnLog_In As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Clear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lblCreate As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblForgotPassword As Label
End Class
