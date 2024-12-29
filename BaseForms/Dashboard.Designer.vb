<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.DashboardPanel = New System.Windows.Forms.Panel()
        Me.BarChartPanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Column1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.Column2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSales = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblOnhand = New System.Windows.Forms.Label()
        Me.Column4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCritical = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.DashboardPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Column1.SuspendLayout()
        Me.Column2.SuspendLayout()
        Me.Column3.SuspendLayout()
        Me.Column4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DashboardPanel
        '
        Me.DashboardPanel.Controls.Add(Me.BarChartPanel)
        Me.DashboardPanel.Controls.Add(Me.Panel2)
        Me.DashboardPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.DashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DashboardPanel.Location = New System.Drawing.Point(0, 50)
        Me.DashboardPanel.Name = "DashboardPanel"
        Me.DashboardPanel.Padding = New System.Windows.Forms.Padding(20, 0, 20, 20)
        Me.DashboardPanel.Size = New System.Drawing.Size(1009, 495)
        Me.DashboardPanel.TabIndex = 1
        '
        'BarChartPanel
        '
        Me.BarChartPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BarChartPanel.Location = New System.Drawing.Point(20, 170)
        Me.BarChartPanel.Name = "BarChartPanel"
        Me.BarChartPanel.Size = New System.Drawing.Size(969, 305)
        Me.BarChartPanel.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(20, 125)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(969, 45)
        Me.Panel2.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Column1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Column2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Column3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Column4, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(20, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(969, 125)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Column1.Controls.Add(Me.PictureBox1)
        Me.Column1.Controls.Add(Me.Label2)
        Me.Column1.Controls.Add(Me.lblInventory)
        Me.Column1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Column1.Location = New System.Drawing.Point(5, 5)
        Me.Column1.Margin = New System.Windows.Forms.Padding(5)
        Me.Column1.Name = "Column1"
        Me.Column1.Size = New System.Drawing.Size(232, 115)
        Me.Column1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(87, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Product Line"
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventory.ForeColor = System.Drawing.Color.White
        Me.lblInventory.Location = New System.Drawing.Point(86, 29)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(64, 32)
        Me.lblInventory.TabIndex = 1
        Me.lblInventory.Text = "0.00"
        '
        'Column2
        '
        Me.Column2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Column2.Controls.Add(Me.PictureBox2)
        Me.Column2.Controls.Add(Me.Label3)
        Me.Column2.Controls.Add(Me.lblSales)
        Me.Column2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Column2.Location = New System.Drawing.Point(247, 5)
        Me.Column2.Margin = New System.Windows.Forms.Padding(5)
        Me.Column2.Name = "Column2"
        Me.Column2.Size = New System.Drawing.Size(232, 115)
        Me.Column2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(79, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 21)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Daily Sales"
        '
        'lblSales
        '
        Me.lblSales.AutoSize = True
        Me.lblSales.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSales.ForeColor = System.Drawing.Color.White
        Me.lblSales.Location = New System.Drawing.Point(79, 30)
        Me.lblSales.Name = "lblSales"
        Me.lblSales.Size = New System.Drawing.Size(64, 32)
        Me.lblSales.TabIndex = 2
        Me.lblSales.Text = "0.00"
        '
        'Column3
        '
        Me.Column3.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Column3.Controls.Add(Me.PictureBox3)
        Me.Column3.Controls.Add(Me.Label4)
        Me.Column3.Controls.Add(Me.lblOnhand)
        Me.Column3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Column3.Location = New System.Drawing.Point(489, 5)
        Me.Column3.Margin = New System.Windows.Forms.Padding(5)
        Me.Column3.Name = "Column3"
        Me.Column3.Size = New System.Drawing.Size(232, 115)
        Me.Column3.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(81, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 21)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total On Hand"
        '
        'lblOnhand
        '
        Me.lblOnhand.AutoSize = True
        Me.lblOnhand.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOnhand.ForeColor = System.Drawing.Color.White
        Me.lblOnhand.Location = New System.Drawing.Point(79, 30)
        Me.lblOnhand.Name = "lblOnhand"
        Me.lblOnhand.Size = New System.Drawing.Size(64, 32)
        Me.lblOnhand.TabIndex = 3
        Me.lblOnhand.Text = "0.00"
        '
        'Column4
        '
        Me.Column4.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Column4.Controls.Add(Me.PictureBox4)
        Me.Column4.Controls.Add(Me.Label5)
        Me.Column4.Controls.Add(Me.lblCritical)
        Me.Column4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Column4.Location = New System.Drawing.Point(731, 5)
        Me.Column4.Margin = New System.Windows.Forms.Padding(5)
        Me.Column4.Name = "Column4"
        Me.Column4.Size = New System.Drawing.Size(233, 115)
        Me.Column4.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(81, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 21)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Critical Items"
        '
        'lblCritical
        '
        Me.lblCritical.AutoSize = True
        Me.lblCritical.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCritical.ForeColor = System.Drawing.Color.White
        Me.lblCritical.Location = New System.Drawing.Point(79, 30)
        Me.lblCritical.Name = "lblCritical"
        Me.lblCritical.Size = New System.Drawing.Size(64, 32)
        Me.lblCritical.TabIndex = 3
        Me.lblCritical.Text = "0.00"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1009, 50)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Tag = ""
        Me.Label1.Text = "DASHBOARD"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(69, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, 28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(62, 58)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(13, 29)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(62, 58)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(11, 28)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(62, 58)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 5
        Me.PictureBox4.TabStop = False
        '
        'Dashboard
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1009, 545)
        Me.Controls.Add(Me.DashboardPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Dashboard"
        Me.DashboardPanel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Column1.ResumeLayout(False)
        Me.Column1.PerformLayout()
        Me.Column2.ResumeLayout(False)
        Me.Column2.PerformLayout()
        Me.Column3.ResumeLayout(False)
        Me.Column3.PerformLayout()
        Me.Column4.ResumeLayout(False)
        Me.Column4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DashboardPanel As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Column1 As Panel
    Friend WithEvents Column2 As Panel
    Friend WithEvents Column3 As Panel
    Friend WithEvents Column4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblInventory As Label
    Friend WithEvents lblSales As Label
    Friend WithEvents lblOnhand As Label
    Friend WithEvents lblCritical As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BarChartPanel As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
End Class
