<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettlePayment
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
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button50 = New FontAwesome.Sharp.IconButton()
        Me.txtChange = New POS4U.TextInput()
        Me.txtTotal = New POS4U.TextInput()
        Me.Button00 = New FontAwesome.Sharp.IconButton()
        Me.IconButton4 = New FontAwesome.Sharp.IconButton()
        Me.Button500 = New FontAwesome.Sharp.IconButton()
        Me.Button200 = New FontAwesome.Sharp.IconButton()
        Me.Button100 = New FontAwesome.Sharp.IconButton()
        Me.ButtonEnter = New FontAwesome.Sharp.IconButton()
        Me.ButtonDot = New FontAwesome.Sharp.IconButton()
        Me.Button3 = New FontAwesome.Sharp.IconButton()
        Me.Button2 = New FontAwesome.Sharp.IconButton()
        Me.Button1 = New FontAwesome.Sharp.IconButton()
        Me.Button0 = New FontAwesome.Sharp.IconButton()
        Me.Button6 = New FontAwesome.Sharp.IconButton()
        Me.Button5 = New FontAwesome.Sharp.IconButton()
        Me.Button4 = New FontAwesome.Sharp.IconButton()
        Me.ButtonC = New FontAwesome.Sharp.IconButton()
        Me.Button9 = New FontAwesome.Sharp.IconButton()
        Me.Button8 = New FontAwesome.Sharp.IconButton()
        Me.Button7 = New FontAwesome.Sharp.IconButton()
        Me.ComputationPanel = New System.Windows.Forms.Panel()
        Me.txtTender = New POS4U.TextInput()
        Me.HeaderPanel.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        CType(Me.txtChange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ComputationPanel.SuspendLayout()
        CType(Me.txtTender.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.HeaderPanel.Size = New System.Drawing.Size(510, 45)
        Me.HeaderPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Settle Payment"
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
        Me.ButtonClose.Location = New System.Drawing.Point(483, 3)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(24, 24)
        Me.ButtonClose.TabIndex = 1
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.lblChange)
        Me.MainPanel.Controls.Add(Me.lblTotal)
        Me.MainPanel.Controls.Add(Me.Label3)
        Me.MainPanel.Controls.Add(Me.Label2)
        Me.MainPanel.Controls.Add(Me.Button50)
        Me.MainPanel.Controls.Add(Me.txtChange)
        Me.MainPanel.Controls.Add(Me.txtTotal)
        Me.MainPanel.Controls.Add(Me.Button00)
        Me.MainPanel.Controls.Add(Me.IconButton4)
        Me.MainPanel.Controls.Add(Me.Button500)
        Me.MainPanel.Controls.Add(Me.Button200)
        Me.MainPanel.Controls.Add(Me.Button100)
        Me.MainPanel.Controls.Add(Me.ButtonEnter)
        Me.MainPanel.Controls.Add(Me.ButtonDot)
        Me.MainPanel.Controls.Add(Me.Button3)
        Me.MainPanel.Controls.Add(Me.Button2)
        Me.MainPanel.Controls.Add(Me.Button1)
        Me.MainPanel.Controls.Add(Me.Button0)
        Me.MainPanel.Controls.Add(Me.Button6)
        Me.MainPanel.Controls.Add(Me.Button5)
        Me.MainPanel.Controls.Add(Me.Button4)
        Me.MainPanel.Controls.Add(Me.ButtonC)
        Me.MainPanel.Controls.Add(Me.Button9)
        Me.MainPanel.Controls.Add(Me.Button8)
        Me.MainPanel.Controls.Add(Me.Button7)
        Me.MainPanel.Controls.Add(Me.ComputationPanel)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 45)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(510, 458)
        Me.MainPanel.TabIndex = 1
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.lblChange.Location = New System.Drawing.Point(149, 142)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(44, 18)
        Me.lblChange.TabIndex = 23
        Me.lblChange.Text = "0.00"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.lblTotal.Location = New System.Drawing.Point(149, 107)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 18)
        Me.lblTotal.TabIndex = 22
        Me.lblTotal.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(17, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 18)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "CHANGE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(17, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 18)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "TOTAL SALES:"
        '
        'Button50
        '
        Me.Button50.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button50.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button50.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button50.ForeColor = System.Drawing.Color.White
        Me.Button50.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button50.IconColor = System.Drawing.Color.Black
        Me.Button50.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button50.Location = New System.Drawing.Point(390, 308)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(100, 60)
        Me.Button50.TabIndex = 19
        Me.Button50.Text = "50"
        Me.Button50.UseVisualStyleBackColor = False
        '
        'txtChange
        '
        Me.txtChange.DisplayFormat = "n2"
        Me.txtChange.EditValue = ""
        Me.txtChange.Enabled = False
        Me.txtChange.Location = New System.Drawing.Point(354, 139)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 15.0!)
        Me.txtChange.Properties.Appearance.Options.UseFont = True
        Me.txtChange.Properties.Mask.EditMask = "n2"
        Me.txtChange.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtChange.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtChange.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtChange.Size = New System.Drawing.Size(135, 32)
        Me.txtChange.TabIndex = 2
        Me.txtChange.TableField = ""
        Me.txtChange.TableName = ""
        Me.txtChange.UseSystemPasswordChar = Nothing
        Me.txtChange.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.DisplayFormat = "n2"
        Me.txtTotal.EditValue = "0"
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(354, 104)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(3, 10, 10, 10)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 15.0!)
        Me.txtTotal.Properties.Appearance.Options.UseFont = True
        Me.txtTotal.Properties.Mask.EditMask = "n2"
        Me.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(135, 32)
        Me.txtTotal.TabIndex = 0
        Me.txtTotal.TableField = ""
        Me.txtTotal.TableName = ""
        Me.txtTotal.UseSystemPasswordChar = Nothing
        Me.txtTotal.Visible = False
        '
        'Button00
        '
        Me.Button00.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button00.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button00.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button00.ForeColor = System.Drawing.Color.White
        Me.Button00.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button00.IconColor = System.Drawing.Color.Black
        Me.Button00.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button00.Location = New System.Drawing.Point(218, 176)
        Me.Button00.Name = "Button00"
        Me.Button00.Size = New System.Drawing.Size(60, 60)
        Me.Button00.TabIndex = 18
        Me.Button00.Text = "00"
        Me.Button00.UseVisualStyleBackColor = False
        '
        'IconButton4
        '
        Me.IconButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.IconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton4.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.IconButton4.ForeColor = System.Drawing.Color.White
        Me.IconButton4.IconChar = FontAwesome.Sharp.IconChar.None
        Me.IconButton4.IconColor = System.Drawing.Color.Black
        Me.IconButton4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton4.Location = New System.Drawing.Point(284, 176)
        Me.IconButton4.Name = "IconButton4"
        Me.IconButton4.Size = New System.Drawing.Size(100, 60)
        Me.IconButton4.TabIndex = 17
        Me.IconButton4.Text = "1000"
        Me.IconButton4.UseVisualStyleBackColor = False
        '
        'Button500
        '
        Me.Button500.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button500.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button500.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button500.ForeColor = System.Drawing.Color.White
        Me.Button500.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button500.IconColor = System.Drawing.Color.Black
        Me.Button500.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button500.Location = New System.Drawing.Point(284, 242)
        Me.Button500.Name = "Button500"
        Me.Button500.Size = New System.Drawing.Size(100, 60)
        Me.Button500.TabIndex = 16
        Me.Button500.Text = "500"
        Me.Button500.UseVisualStyleBackColor = False
        '
        'Button200
        '
        Me.Button200.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button200.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button200.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button200.ForeColor = System.Drawing.Color.White
        Me.Button200.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button200.IconColor = System.Drawing.Color.Black
        Me.Button200.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button200.Location = New System.Drawing.Point(389, 242)
        Me.Button200.Name = "Button200"
        Me.Button200.Size = New System.Drawing.Size(100, 60)
        Me.Button200.TabIndex = 15
        Me.Button200.Text = "200"
        Me.Button200.UseVisualStyleBackColor = False
        '
        'Button100
        '
        Me.Button100.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button100.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button100.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button100.ForeColor = System.Drawing.Color.White
        Me.Button100.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button100.IconColor = System.Drawing.Color.Black
        Me.Button100.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button100.Location = New System.Drawing.Point(284, 308)
        Me.Button100.Name = "Button100"
        Me.Button100.Size = New System.Drawing.Size(100, 60)
        Me.Button100.TabIndex = 14
        Me.Button100.Text = "100"
        Me.Button100.UseVisualStyleBackColor = False
        '
        'ButtonEnter
        '
        Me.ButtonEnter.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ButtonEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEnter.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.ButtonEnter.ForeColor = System.Drawing.Color.White
        Me.ButtonEnter.IconChar = FontAwesome.Sharp.IconChar.None
        Me.ButtonEnter.IconColor = System.Drawing.Color.Black
        Me.ButtonEnter.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonEnter.Location = New System.Drawing.Point(20, 374)
        Me.ButtonEnter.Name = "ButtonEnter"
        Me.ButtonEnter.Size = New System.Drawing.Size(470, 60)
        Me.ButtonEnter.TabIndex = 13
        Me.ButtonEnter.Text = "Enter"
        Me.ButtonEnter.UseVisualStyleBackColor = False
        '
        'ButtonDot
        '
        Me.ButtonDot.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.ButtonDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDot.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.ButtonDot.ForeColor = System.Drawing.Color.White
        Me.ButtonDot.IconChar = FontAwesome.Sharp.IconChar.None
        Me.ButtonDot.IconColor = System.Drawing.Color.Black
        Me.ButtonDot.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonDot.Location = New System.Drawing.Point(218, 308)
        Me.ButtonDot.Name = "ButtonDot"
        Me.ButtonDot.Size = New System.Drawing.Size(60, 60)
        Me.ButtonDot.TabIndex = 12
        Me.ButtonDot.Text = "."
        Me.ButtonDot.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button3.IconColor = System.Drawing.Color.Black
        Me.Button3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button3.Location = New System.Drawing.Point(152, 308)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 60)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button2.IconColor = System.Drawing.Color.Black
        Me.Button2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button2.Location = New System.Drawing.Point(86, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 60)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button1.IconColor = System.Drawing.Color.Black
        Me.Button1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button1.Location = New System.Drawing.Point(20, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 60)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button0
        '
        Me.Button0.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button0.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button0.ForeColor = System.Drawing.Color.White
        Me.Button0.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button0.IconColor = System.Drawing.Color.Black
        Me.Button0.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button0.Location = New System.Drawing.Point(218, 242)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(60, 60)
        Me.Button0.TabIndex = 8
        Me.Button0.Text = "0"
        Me.Button0.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button6.IconColor = System.Drawing.Color.Black
        Me.Button6.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button6.Location = New System.Drawing.Point(152, 242)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(60, 60)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button5.IconColor = System.Drawing.Color.Black
        Me.Button5.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button5.Location = New System.Drawing.Point(86, 242)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(60, 60)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button4.IconColor = System.Drawing.Color.Black
        Me.Button4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button4.Location = New System.Drawing.Point(20, 242)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(60, 60)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ButtonC
        '
        Me.ButtonC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.ButtonC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonC.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.ButtonC.ForeColor = System.Drawing.Color.White
        Me.ButtonC.IconChar = FontAwesome.Sharp.IconChar.None
        Me.ButtonC.IconColor = System.Drawing.Color.Black
        Me.ButtonC.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonC.Location = New System.Drawing.Point(389, 176)
        Me.ButtonC.Name = "ButtonC"
        Me.ButtonC.Size = New System.Drawing.Size(100, 60)
        Me.ButtonC.TabIndex = 4
        Me.ButtonC.Text = "C"
        Me.ButtonC.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button9.IconColor = System.Drawing.Color.Black
        Me.Button9.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button9.Location = New System.Drawing.Point(152, 176)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(60, 60)
        Me.Button9.TabIndex = 3
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button8.IconColor = System.Drawing.Color.Black
        Me.Button8.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button8.Location = New System.Drawing.Point(86, 176)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(60, 60)
        Me.Button8.TabIndex = 2
        Me.Button8.Text = "8"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Button7.IconColor = System.Drawing.Color.Black
        Me.Button7.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Button7.Location = New System.Drawing.Point(20, 176)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(60, 60)
        Me.Button7.TabIndex = 1
        Me.Button7.Text = "7"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'ComputationPanel
        '
        Me.ComputationPanel.Controls.Add(Me.txtTender)
        Me.ComputationPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComputationPanel.Location = New System.Drawing.Point(0, 0)
        Me.ComputationPanel.Name = "ComputationPanel"
        Me.ComputationPanel.Padding = New System.Windows.Forms.Padding(20)
        Me.ComputationPanel.Size = New System.Drawing.Size(510, 103)
        Me.ComputationPanel.TabIndex = 0
        '
        'txtTender
        '
        Me.txtTender.DisplayFormat = ""
        Me.txtTender.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTender.Location = New System.Drawing.Point(20, 20)
        Me.txtTender.Name = "txtTender"
        Me.txtTender.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 20.0!)
        Me.txtTender.Properties.Appearance.Options.UseFont = True
        Me.txtTender.Properties.AutoHeight = False
        Me.txtTender.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTender.Size = New System.Drawing.Size(470, 60)
        Me.txtTender.TabIndex = 3
        Me.txtTender.TableField = ""
        Me.txtTender.TableName = ""
        Me.txtTender.UseSystemPasswordChar = Nothing
        '
        'SettlePayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 503)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SettlePayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SettlePayment"
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        CType(Me.txtChange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ComputationPanel.ResumeLayout(False)
        CType(Me.txtTender.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents MainPanel As Panel
    Friend WithEvents ComputationPanel As Panel
    Friend WithEvents ButtonC As FontAwesome.Sharp.IconButton
    Friend WithEvents Button9 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button8 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button7 As FontAwesome.Sharp.IconButton
    Friend WithEvents ButtonEnter As FontAwesome.Sharp.IconButton
    Friend WithEvents ButtonDot As FontAwesome.Sharp.IconButton
    Friend WithEvents Button3 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button2 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button0 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button6 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button5 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button4 As FontAwesome.Sharp.IconButton
    Friend WithEvents txtTotal As TextInput
    Friend WithEvents txtChange As TextInput
    Friend WithEvents txtTender As TextInput
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button500 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button200 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button100 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button00 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button50 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblTotal As Label
End Class
