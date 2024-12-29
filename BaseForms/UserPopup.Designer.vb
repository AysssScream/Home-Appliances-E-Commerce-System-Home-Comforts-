<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserPopup
    Inherits POS4U.BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserPopup))
        Me.ActionPanel = New System.Windows.Forms.Panel()
        Me.btnLogout = New FontAwesome.Sharp.IconButton()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.lblPopCustName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnChangePassword = New FontAwesome.Sharp.IconButton()
        Me.pbxUserPic = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Topay = New System.Windows.Forms.Button()
        Me.ToShip = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToReceive = New System.Windows.Forms.Button()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.COMPLETED = New System.Windows.Forms.Button()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ActionPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxUserPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ActionPanel
        '
        Me.ActionPanel.Controls.Add(Me.btnLogout)
        Me.ActionPanel.Controls.Add(Me.ButtonClose)
        Me.ActionPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ActionPanel.Location = New System.Drawing.Point(0, 539)
        Me.ActionPanel.Name = "ActionPanel"
        Me.ActionPanel.Size = New System.Drawing.Size(374, 56)
        Me.ActionPanel.TabIndex = 6
        '
        'btnLogout
        '
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnLogout.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnLogout.IconColor = System.Drawing.Color.Black
        Me.btnLogout.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnLogout.Location = New System.Drawing.Point(230, 3)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(132, 50)
        Me.btnLogout.TabIndex = 10
        Me.btnLogout.Text = "Log Out"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.ButtonClose.IconChar = FontAwesome.Sharp.IconChar.None
        Me.ButtonClose.IconColor = System.Drawing.Color.Black
        Me.ButtonClose.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonClose.Location = New System.Drawing.Point(12, 3)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(87, 50)
        Me.ButtonClose.TabIndex = 1
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'lblPopCustName
        '
        Me.lblPopCustName.AutoSize = True
        Me.lblPopCustName.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopCustName.Location = New System.Drawing.Point(119, 13)
        Me.lblPopCustName.Name = "lblPopCustName"
        Me.lblPopCustName.Size = New System.Drawing.Size(160, 23)
        Me.lblPopCustName.TabIndex = 8
        Me.lblPopCustName.Text = "Customer Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "My Purchases"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(35, 173)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(57, 38)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'btnChangePassword
        '
        Me.btnChangePassword.FlatAppearance.BorderSize = 0
        Me.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangePassword.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnChangePassword.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnChangePassword.IconColor = System.Drawing.Color.Black
        Me.btnChangePassword.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnChangePassword.Location = New System.Drawing.Point(119, 66)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(132, 30)
        Me.btnChangePassword.TabIndex = 0
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'pbxUserPic
        '
        Me.pbxUserPic.Image = CType(resources.GetObject("pbxUserPic.Image"), System.Drawing.Image)
        Me.pbxUserPic.Location = New System.Drawing.Point(25, 12)
        Me.pbxUserPic.Name = "pbxUserPic"
        Me.pbxUserPic.Size = New System.Drawing.Size(88, 84)
        Me.pbxUserPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxUserPic.TabIndex = 7
        Me.pbxUserPic.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(298, 12)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(42, 25)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 10
        Me.PictureBox5.TabStop = False
        '
        'Topay
        '
        Me.Topay.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Topay.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Topay.Location = New System.Drawing.Point(0, 162)
        Me.Topay.Name = "Topay"
        Me.Topay.Size = New System.Drawing.Size(374, 62)
        Me.Topay.TabIndex = 4
        Me.Topay.Text = "TO PAY"
        Me.Topay.UseVisualStyleBackColor = False
        '
        'ToShip
        '
        Me.ToShip.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToShip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToShip.Location = New System.Drawing.Point(0, 224)
        Me.ToShip.Name = "ToShip"
        Me.ToShip.Size = New System.Drawing.Size(374, 62)
        Me.ToShip.TabIndex = 18
        Me.ToShip.Text = "TO SHIP"
        Me.ToShip.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(34, 233)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(57, 44)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 19
        Me.PictureBox2.TabStop = False
        '
        'ToReceive
        '
        Me.ToReceive.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToReceive.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToReceive.Location = New System.Drawing.Point(0, 286)
        Me.ToReceive.Name = "ToReceive"
        Me.ToReceive.Size = New System.Drawing.Size(374, 62)
        Me.ToReceive.TabIndex = 20
        Me.ToReceive.Text = "TO RECEIVE"
        Me.ToReceive.UseVisualStyleBackColor = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(35, 299)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(57, 36)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 21
        Me.PictureBox6.TabStop = False
        '
        'COMPLETED
        '
        Me.COMPLETED.BackColor = System.Drawing.Color.WhiteSmoke
        Me.COMPLETED.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMPLETED.Location = New System.Drawing.Point(0, 348)
        Me.COMPLETED.Name = "COMPLETED"
        Me.COMPLETED.Size = New System.Drawing.Size(374, 62)
        Me.COMPLETED.TabIndex = 22
        Me.COMPLETED.Text = "COMPLETED"
        Me.COMPLETED.UseVisualStyleBackColor = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(35, 361)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(57, 36)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 6
        Me.PictureBox7.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 411)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(374, 62)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "CANCELLED"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(35, 425)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(57, 36)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(0, 473)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(374, 62)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "RETURN / REFUND"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(35, 486)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(57, 36)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 6
        Me.PictureBox8.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(123, 40)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "EDIT INFO"
        '
        'UserPopup
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(374, 595)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.COMPLETED)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.ToReceive)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ToShip)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Topay)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.lblPopCustName)
        Me.Controls.Add(Me.pbxUserPic)
        Me.Controls.Add(Me.ActionPanel)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "UserPopup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "User"
        Me.ActionPanel.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxUserPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActionPanel As Panel
    Friend WithEvents btnChangePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Friend WithEvents btnLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents pbxUserPic As PictureBox
    Friend WithEvents lblPopCustName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Topay As Button
    Friend WithEvents ToShip As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ToReceive As Button
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents COMPLETED As Button
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents Label7 As Label
End Class
