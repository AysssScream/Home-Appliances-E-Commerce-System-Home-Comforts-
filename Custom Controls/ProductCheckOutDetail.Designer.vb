<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductCheckOutDetail
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductCheckOutDetail))
        Me.Panle = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnReviews = New FontAwesome.Sharp.IconButton()
        Me.numQty = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.txtProductName = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ItemPicture = New System.Windows.Forms.PictureBox()
        Me.Panle.SuspendLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panle
        '
        Me.Panle.BorderColor = System.Drawing.Color.Gray
        Me.Panle.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Panle.BorderThickness = 1
        Me.Panle.Controls.Add(Me.btnReviews)
        Me.Panle.Controls.Add(Me.numQty)
        Me.Panle.Controls.Add(Me.txtProductName)
        Me.Panle.Controls.Add(Me.txtPrice)
        Me.Panle.Controls.Add(Me.txtQuantity)
        Me.Panle.Controls.Add(Me.Label17)
        Me.Panle.Controls.Add(Me.Label18)
        Me.Panle.Controls.Add(Me.ItemPicture)
        Me.Panle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panle.Location = New System.Drawing.Point(5, 5)
        Me.Panle.Name = "Panle"
        Me.Panle.ShadowDecoration.Parent = Me.Panle
        Me.Panle.Size = New System.Drawing.Size(497, 108)
        Me.Panle.TabIndex = 0
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
        Me.btnReviews.Location = New System.Drawing.Point(11, 3)
        Me.btnReviews.Name = "btnReviews"
        Me.btnReviews.Size = New System.Drawing.Size(90, 20)
        Me.btnReviews.TabIndex = 19
        Me.btnReviews.Text = "REVIEWS"
        Me.btnReviews.UseVisualStyleBackColor = False
        '
        'numQty
        '
        Me.numQty.BackColor = System.Drawing.Color.Transparent
        Me.numQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.numQty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.numQty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.numQty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.numQty.DisabledState.Parent = Me.numQty
        Me.numQty.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.numQty.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.numQty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.numQty.FocusedState.Parent = Me.numQty
        Me.numQty.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.numQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.numQty.Location = New System.Drawing.Point(170, 46)
        Me.numQty.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.numQty.Name = "numQty"
        Me.numQty.ShadowDecoration.Parent = Me.numQty
        Me.numQty.Size = New System.Drawing.Size(100, 28)
        Me.numQty.TabIndex = 18
        Me.numQty.UpDownButtonFillColor = System.Drawing.Color.Red
        Me.numQty.UpDownButtonForeColor = System.Drawing.Color.White
        '
        'txtProductName
        '
        Me.txtProductName.AutoSize = True
        Me.txtProductName.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(105, 28)
        Me.txtProductName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(131, 17)
        Me.txtProductName.TabIndex = 17
        Me.txtProductName.Text = "Appliances Name"
        '
        'txtPrice
        '
        Me.txtPrice.AutoSize = True
        Me.txtPrice.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(148, 74)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(25, 15)
        Me.txtPrice.TabIndex = 16
        Me.txtPrice.Text = "000"
        '
        'txtQuantity
        '
        Me.txtQuantity.AutoSize = True
        Me.txtQuantity.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(168, 52)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(25, 15)
        Me.txtQuantity.TabIndex = 15
        Me.txtQuantity.Text = "000"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(106, 74)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 15)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Price :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(106, 52)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 15)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Quantity :"
        '
        'ItemPicture
        '
        Me.ItemPicture.Image = CType(resources.GetObject("ItemPicture.Image"), System.Drawing.Image)
        Me.ItemPicture.Location = New System.Drawing.Point(11, 28)
        Me.ItemPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.ItemPicture.Name = "ItemPicture"
        Me.ItemPicture.Size = New System.Drawing.Size(90, 61)
        Me.ItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ItemPicture.TabIndex = 11
        Me.ItemPicture.TabStop = False
        '
        'ProductCheckOutDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panle)
        Me.Name = "ProductCheckOutDetail"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(507, 118)
        Me.Panle.ResumeLayout(False)
        Me.Panle.PerformLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panle As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtProductName As Label
    Friend WithEvents txtPrice As Label
    Friend WithEvents txtQuantity As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ItemPicture As PictureBox
    Friend WithEvents numQty As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents btnReviews As FontAwesome.Sharp.IconButton
End Class
