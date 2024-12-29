<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterNumber
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
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.HeaderLabel = New System.Windows.Forms.Label()
        Me.txtInput = New POS4U.TextInput()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.HeaderPanel.SuspendLayout()
        CType(Me.txtInput.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.Black
        Me.HeaderPanel.Controls.Add(Me.ButtonClose)
        Me.HeaderPanel.Controls.Add(Me.HeaderLabel)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(423, 50)
        Me.HeaderPanel.TabIndex = 0
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.ForeColor = System.Drawing.Color.White
        Me.ButtonClose.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.ButtonClose.IconColor = System.Drawing.Color.White
        Me.ButtonClose.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonClose.IconSize = 24
        Me.ButtonClose.Location = New System.Drawing.Point(393, 7)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(24, 24)
        Me.ButtonClose.TabIndex = 2
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'HeaderLabel
        '
        Me.HeaderLabel.AutoSize = True
        Me.HeaderLabel.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.HeaderLabel.ForeColor = System.Drawing.Color.White
        Me.HeaderLabel.Location = New System.Drawing.Point(12, 15)
        Me.HeaderLabel.Name = "HeaderLabel"
        Me.HeaderLabel.Size = New System.Drawing.Size(120, 18)
        Me.HeaderLabel.TabIndex = 0
        Me.HeaderLabel.Text = "Enter Number"
        '
        'txtInput
        '
        Me.txtInput.DisplayFormat = ""
        Me.txtInput.Location = New System.Drawing.Point(50, 76)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 30.0!)
        Me.txtInput.Properties.Appearance.Options.UseFont = True
        Me.txtInput.Properties.Appearance.Options.UseTextOptions = True
        Me.txtInput.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtInput.Size = New System.Drawing.Size(323, 54)
        Me.txtInput.TabIndex = 1
        Me.txtInput.TableField = ""
        Me.txtInput.TableName = ""
        Me.txtInput.UseSystemPasswordChar = Nothing
        '
        'IconButton1
        '
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.IconButton1.IconColor = System.Drawing.Color.Black
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 30
        Me.IconButton1.Location = New System.Drawing.Point(131, 148)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(164, 41)
        Me.IconButton1.TabIndex = 2
        Me.IconButton1.Text = "[Enter] DONE"
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 223)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(423, 39)
        Me.Panel1.TabIndex = 3
        '
        'EnterNumber
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(423, 262)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.IconButton1)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.HeaderPanel)
        Me.KeyPreview = True
        Me.Name = "EnterNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        CType(Me.txtInput.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents HeaderLabel As Label
    Protected Friend WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Friend WithEvents txtInput As TextInput
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
End Class
