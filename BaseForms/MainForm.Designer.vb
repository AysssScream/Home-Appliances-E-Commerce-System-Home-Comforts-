<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SideMenuPanel = New System.Windows.Forms.Panel()
        Me.MenuPanel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonLogout = New FontAwesome.Sharp.IconButton()
        Me.LogoPanel = New System.Windows.Forms.Panel()
        Me.Logo = New POS4U.PictureEdit()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.lblUser = New POS4U.TextInput()
        Me.CompanyName = New System.Windows.Forms.Label()
        Me.UserPicture = New System.Windows.Forms.PictureBox()
        Me.Clock = New System.Windows.Forms.Label()
        Me.ButtonMinimized = New FontAwesome.Sharp.IconButton()
        Me.ButtonMaximized = New FontAwesome.Sharp.IconButton()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.DesktopPanel = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SideMenuPanel.SuspendLayout()
        Me.MenuPanel.SuspendLayout()
        Me.LogoPanel.SuspendLayout()
        CType(Me.Logo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel.SuspendLayout()
        CType(Me.lblUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SideMenuPanel
        '
        Me.SideMenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SideMenuPanel.Controls.Add(Me.MenuPanel)
        Me.SideMenuPanel.Controls.Add(Me.ButtonLogout)
        Me.SideMenuPanel.Controls.Add(Me.LogoPanel)
        Me.SideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SideMenuPanel.Location = New System.Drawing.Point(0, 0)
        Me.SideMenuPanel.Name = "SideMenuPanel"
        Me.SideMenuPanel.Size = New System.Drawing.Size(222, 505)
        Me.SideMenuPanel.TabIndex = 2
        '
        'MenuPanel
        '
        Me.MenuPanel.AutoScroll = True
        Me.MenuPanel.AutoScrollMinSize = New System.Drawing.Size(2, 0)
        Me.MenuPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.MenuPanel.Controls.Add(Me.Panel1)
        Me.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuPanel.Location = New System.Drawing.Point(0, 70)
        Me.MenuPanel.Name = "MenuPanel"
        Me.MenuPanel.Size = New System.Drawing.Size(222, 385)
        Me.MenuPanel.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(222, 35)
        Me.Panel1.TabIndex = 0
        '
        'ButtonLogout
        '
        Me.ButtonLogout.BackColor = System.Drawing.Color.Transparent
        Me.ButtonLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonLogout.FlatAppearance.BorderSize = 0
        Me.ButtonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLogout.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.ButtonLogout.ForeColor = System.Drawing.Color.White
        Me.ButtonLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt
        Me.ButtonLogout.IconColor = System.Drawing.Color.White
        Me.ButtonLogout.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonLogout.IconSize = 26
        Me.ButtonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLogout.Location = New System.Drawing.Point(0, 455)
        Me.ButtonLogout.Name = "ButtonLogout"
        Me.ButtonLogout.Size = New System.Drawing.Size(222, 50)
        Me.ButtonLogout.TabIndex = 1
        Me.ButtonLogout.Tag = "Logout"
        Me.ButtonLogout.Text = "Logout"
        Me.ButtonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonLogout.UseVisualStyleBackColor = False
        Me.ButtonLogout.Visible = False
        '
        'LogoPanel
        '
        Me.LogoPanel.BackColor = System.Drawing.Color.Transparent
        Me.LogoPanel.Controls.Add(Me.Logo)
        Me.LogoPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.LogoPanel.Location = New System.Drawing.Point(0, 0)
        Me.LogoPanel.Name = "LogoPanel"
        Me.LogoPanel.Size = New System.Drawing.Size(222, 70)
        Me.LogoPanel.TabIndex = 0
        '
        'Logo
        '
        Me.Logo.EditValue = CType(resources.GetObject("Logo.EditValue"), Object)
        Me.Logo.Location = New System.Drawing.Point(1, 0)
        Me.Logo.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.Logo.MinimumSize = New System.Drawing.Size(50, 50)
        Me.Logo.Name = "Logo"
        Me.Logo.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.Logo.Properties.Appearance.Options.UseBackColor = True
        Me.Logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.Logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.Logo.Size = New System.Drawing.Size(218, 70)
        Me.Logo.TabIndex = 2
        Me.Logo.TableField = ""
        Me.Logo.TableName = ""
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.HeaderPanel.Controls.Add(Me.lblUser)
        Me.HeaderPanel.Controls.Add(Me.CompanyName)
        Me.HeaderPanel.Controls.Add(Me.UserPicture)
        Me.HeaderPanel.Controls.Add(Me.Clock)
        Me.HeaderPanel.Controls.Add(Me.ButtonMinimized)
        Me.HeaderPanel.Controls.Add(Me.ButtonMaximized)
        Me.HeaderPanel.Controls.Add(Me.ButtonClose)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(222, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(813, 70)
        Me.HeaderPanel.TabIndex = 3
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.DisplayFormat = ""
        Me.lblUser.Enabled = False
        Me.lblUser.Location = New System.Drawing.Point(285, 39)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblUser.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lblUser.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Properties.Appearance.Options.UseBackColor = True
        Me.lblUser.Properties.Appearance.Options.UseFont = True
        Me.lblUser.Properties.Appearance.Options.UseForeColor = True
        Me.lblUser.Properties.Appearance.Options.UseTextOptions = True
        Me.lblUser.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblUser.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblUser.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Properties.AppearanceDisabled.Options.UseFont = True
        Me.lblUser.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.lblUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lblUser.Size = New System.Drawing.Size(471, 20)
        Me.lblUser.TabIndex = 6
        Me.lblUser.TableField = ""
        Me.lblUser.TableName = ""
        Me.lblUser.UseSystemPasswordChar = Nothing
        '
        'CompanyName
        '
        Me.CompanyName.AutoSize = True
        Me.CompanyName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.CompanyName.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.CompanyName.Location = New System.Drawing.Point(8, 9)
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.Size = New System.Drawing.Size(0, 17)
        Me.CompanyName.TabIndex = 5
        '
        'UserPicture
        '
        Me.UserPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserPicture.ErrorImage = Global.POS4U.My.Resources.Resources.user
        Me.UserPicture.Image = Global.POS4U.My.Resources.Resources.user
        Me.UserPicture.InitialImage = Global.POS4U.My.Resources.Resources.user
        Me.UserPicture.Location = New System.Drawing.Point(767, 30)
        Me.UserPicture.Name = "UserPicture"
        Me.UserPicture.Size = New System.Drawing.Size(33, 34)
        Me.UserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.UserPicture.TabIndex = 4
        Me.UserPicture.TabStop = False
        '
        'Clock
        '
        Me.Clock.AutoSize = True
        Me.Clock.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.Clock.Location = New System.Drawing.Point(7, 36)
        Me.Clock.Name = "Clock"
        Me.Clock.Size = New System.Drawing.Size(67, 23)
        Me.Clock.TabIndex = 3
        Me.Clock.Text = "12:00"
        '
        'ButtonMinimized
        '
        Me.ButtonMinimized.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMinimized.BackColor = System.Drawing.Color.Transparent
        Me.ButtonMinimized.FlatAppearance.BorderSize = 0
        Me.ButtonMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMinimized.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        Me.ButtonMinimized.IconColor = System.Drawing.Color.White
        Me.ButtonMinimized.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonMinimized.IconSize = 24
        Me.ButtonMinimized.Location = New System.Drawing.Point(732, 3)
        Me.ButtonMinimized.Name = "ButtonMinimized"
        Me.ButtonMinimized.Size = New System.Drawing.Size(24, 24)
        Me.ButtonMinimized.TabIndex = 2
        Me.ButtonMinimized.UseVisualStyleBackColor = False
        '
        'ButtonMaximized
        '
        Me.ButtonMaximized.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMaximized.BackColor = System.Drawing.Color.Transparent
        Me.ButtonMaximized.FlatAppearance.BorderSize = 0
        Me.ButtonMaximized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMaximized.IconChar = FontAwesome.Sharp.IconChar.WindowRestore
        Me.ButtonMaximized.IconColor = System.Drawing.Color.White
        Me.ButtonMaximized.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonMaximized.IconSize = 24
        Me.ButtonMaximized.Location = New System.Drawing.Point(759, 3)
        Me.ButtonMaximized.Name = "ButtonMaximized"
        Me.ButtonMaximized.Size = New System.Drawing.Size(24, 24)
        Me.ButtonMaximized.TabIndex = 1
        Me.ButtonMaximized.UseVisualStyleBackColor = False
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
        Me.ButtonClose.Location = New System.Drawing.Point(786, 3)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(24, 24)
        Me.ButtonClose.TabIndex = 0
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'DesktopPanel
        '
        Me.DesktopPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.DesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesktopPanel.Location = New System.Drawing.Point(222, 70)
        Me.DesktopPanel.Name = "DesktopPanel"
        Me.DesktopPanel.Size = New System.Drawing.Size(813, 435)
        Me.DesktopPanel.TabIndex = 4
        '
        'Timer1
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 505)
        Me.Controls.Add(Me.DesktopPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.SideMenuPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SideMenuPanel.ResumeLayout(False)
        Me.MenuPanel.ResumeLayout(False)
        Me.LogoPanel.ResumeLayout(False)
        CType(Me.Logo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        CType(Me.lblUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SideMenuPanel As Panel
    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents DesktopPanel As Panel
    Friend WithEvents ButtonMinimized As FontAwesome.Sharp.IconButton
    Friend WithEvents ButtonMaximized As FontAwesome.Sharp.IconButton
    Friend WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Friend WithEvents LogoPanel As Panel
    Friend WithEvents ButtonLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents Clock As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents UserPicture As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Protected Friend WithEvents CompanyName As Label
    Friend WithEvents MenuPanel As Panel
    Friend WithEvents Logo As PictureEdit
    Friend WithEvents lblUser As TextInput
    Friend WithEvents Panel1 As Panel
End Class
