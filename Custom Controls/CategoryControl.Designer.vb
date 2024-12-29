<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoryControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoryControl))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.CategoryPict = New System.Windows.Forms.PictureBox()
        Me.CategoryLabel = New System.Windows.Forms.Label()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.CategoryPict, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.Maroon
        Me.Guna2Panel1.BorderRadius = 5
        Me.Guna2Panel1.BorderThickness = 1
        Me.Guna2Panel1.Controls.Add(Me.CategoryPict)
        Me.Guna2Panel1.Controls.Add(Me.CategoryLabel)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(263, 155)
        Me.Guna2Panel1.TabIndex = 0
        '
        'CategoryPict
        '
        Me.CategoryPict.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CategoryPict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CategoryPict.Image = CType(resources.GetObject("CategoryPict.Image"), System.Drawing.Image)
        Me.CategoryPict.Location = New System.Drawing.Point(5, 5)
        Me.CategoryPict.Name = "CategoryPict"
        Me.CategoryPict.Size = New System.Drawing.Size(253, 114)
        Me.CategoryPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CategoryPict.TabIndex = 4
        Me.CategoryPict.TabStop = False
        '
        'CategoryLabel
        '
        Me.CategoryLabel.BackColor = System.Drawing.Color.Transparent
        Me.CategoryLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CategoryLabel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryLabel.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.CategoryLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CategoryLabel.Location = New System.Drawing.Point(5, 119)
        Me.CategoryLabel.Name = "CategoryLabel"
        Me.CategoryLabel.Size = New System.Drawing.Size(253, 31)
        Me.CategoryLabel.TabIndex = 3
        Me.CategoryLabel.Text = "CategoryLabel"
        Me.CategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CategoryControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Name = "CategoryControl"
        Me.Size = New System.Drawing.Size(263, 155)
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.CategoryPict, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents CategoryPict As PictureBox
    Friend WithEvents CategoryLabel As Label
End Class
