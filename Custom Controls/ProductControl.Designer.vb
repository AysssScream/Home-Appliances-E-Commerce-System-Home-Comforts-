<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductControl))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Quantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.ButtonPlus = New FontAwesome.Sharp.IconPictureBox()
        Me.ButtonMinus = New FontAwesome.Sharp.IconPictureBox()
        Me.ProductLabel = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnReviews = New FontAwesome.Sharp.IconButton()
        Me.ProductPict = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.ButtonPlus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonMinus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.ProductPict, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Quantity)
        Me.Panel1.Controls.Add(Me.ButtonPlus)
        Me.Panel1.Controls.Add(Me.ButtonMinus)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(5, 276)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(309, 29)
        Me.Panel1.TabIndex = 4
        '
        'Quantity
        '
        Me.Quantity.BorderColor = System.Drawing.Color.DimGray
        Me.Quantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Quantity.DefaultText = "0"
        Me.Quantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Quantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Quantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Quantity.DisabledState.Parent = Me.Quantity
        Me.Quantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Quantity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Quantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Quantity.FocusedState.Parent = Me.Quantity
        Me.Quantity.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Quantity.ForeColor = System.Drawing.Color.Black
        Me.Quantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Quantity.HoverState.Parent = Me.Quantity
        Me.Quantity.Location = New System.Drawing.Point(27, 0)
        Me.Quantity.Margin = New System.Windows.Forms.Padding(7, 5, 7, 5)
        Me.Quantity.Name = "Stocks"
        Me.Quantity.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Quantity.PlaceholderText = ""
        Me.Quantity.SelectedText = ""
        Me.Quantity.SelectionStart = 1
        Me.Quantity.ShadowDecoration.Parent = Me.Quantity
        Me.Quantity.Size = New System.Drawing.Size(256, 29)
        Me.Quantity.TabIndex = 3
        Me.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonPlus
        '
        Me.ButtonPlus.BackColor = System.Drawing.Color.Transparent
        Me.ButtonPlus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ButtonPlus.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonPlus.ForeColor = System.Drawing.Color.Black
        Me.ButtonPlus.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.ButtonPlus.IconColor = System.Drawing.Color.Black
        Me.ButtonPlus.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonPlus.IconSize = 26
        Me.ButtonPlus.Location = New System.Drawing.Point(283, 0)
        Me.ButtonPlus.Name = "ButtonPlus"
        Me.ButtonPlus.Size = New System.Drawing.Size(26, 29)
        Me.ButtonPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ButtonPlus.TabIndex = 2
        Me.ButtonPlus.TabStop = False
        Me.ButtonPlus.UseGdi = True
        '
        'ButtonMinus
        '
        Me.ButtonMinus.BackColor = System.Drawing.Color.Transparent
        Me.ButtonMinus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ButtonMinus.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonMinus.ForeColor = System.Drawing.Color.Black
        Me.ButtonMinus.IconChar = FontAwesome.Sharp.IconChar.Minus
        Me.ButtonMinus.IconColor = System.Drawing.Color.Black
        Me.ButtonMinus.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonMinus.IconSize = 27
        Me.ButtonMinus.Location = New System.Drawing.Point(0, 0)
        Me.ButtonMinus.Name = "ButtonMinus"
        Me.ButtonMinus.Size = New System.Drawing.Size(27, 29)
        Me.ButtonMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ButtonMinus.TabIndex = 1
        Me.ButtonMinus.TabStop = False
        Me.ButtonMinus.UseGdi = True
        '
        'ProductLabel
        '
        Me.ProductLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProductLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductLabel.Location = New System.Drawing.Point(5, 5)
        Me.ProductLabel.Name = "ProductLabel"
        Me.ProductLabel.Size = New System.Drawing.Size(309, 26)
        Me.ProductLabel.TabIndex = 3
        Me.ProductLabel.Text = "Label1"
        Me.ProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.Black
        Me.Guna2Panel1.BorderRadius = 5
        Me.Guna2Panel1.BorderThickness = 1
        Me.Guna2Panel1.Controls.Add(Me.btnReviews)
        Me.Guna2Panel1.Controls.Add(Me.ProductPict)
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.ProductLabel)
        Me.Guna2Panel1.Controls.Add(Me.Panel1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(319, 310)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btnReviews
        '
        Me.btnReviews.BackColor = System.Drawing.Color.DarkGreen
        Me.btnReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReviews.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReviews.ForeColor = System.Drawing.Color.White
        Me.btnReviews.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnReviews.IconColor = System.Drawing.Color.Black
        Me.btnReviews.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnReviews.Location = New System.Drawing.Point(9, 34)
        Me.btnReviews.Name = "btnReviews"
        Me.btnReviews.Size = New System.Drawing.Size(90, 20)
        Me.btnReviews.TabIndex = 32
        Me.btnReviews.Text = "REVIEWS"
        Me.btnReviews.UseVisualStyleBackColor = False
        '
        'ProductPict
        '
        Me.ProductPict.BackColor = System.Drawing.Color.White
        Me.ProductPict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductPict.Image = CType(resources.GetObject("ProductPict.Image"), System.Drawing.Image)
        Me.ProductPict.Location = New System.Drawing.Point(5, 31)
        Me.ProductPict.Name = "ProductPict"
        Me.ProductPict.Padding = New System.Windows.Forms.Padding(10)
        Me.ProductPict.Size = New System.Drawing.Size(309, 212)
        Me.ProductPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ProductPict.TabIndex = 8
        Me.ProductPict.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(153, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 21)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Price: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 243)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 33)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Stocks: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Name = "ProductControl"
        Me.Size = New System.Drawing.Size(319, 310)
        Me.Panel1.ResumeLayout(False)
        CType(Me.ButtonPlus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonMinus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.ProductPict, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Quantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents ButtonPlus As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ButtonMinus As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ProductLabel As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ProductPict As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnReviews As FontAwesome.Sharp.IconButton
End Class
