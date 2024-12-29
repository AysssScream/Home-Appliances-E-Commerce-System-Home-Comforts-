<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchFormBase
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
        Me.components = New System.ComponentModel.Container()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.HeaderLabel = New System.Windows.Forms.Label()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.SearchPanel = New System.Windows.Forms.Panel()
        Me.SearchBox = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.ListPanel = New System.Windows.Forms.Panel()
        Me.SearchGrid = New POS4U.SearchGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.HeaderPanel.SuspendLayout()
        Me.SearchPanel.SuspendLayout()
        Me.ListPanel.SuspendLayout()
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.Black
        Me.HeaderPanel.Controls.Add(Me.HeaderLabel)
        Me.HeaderPanel.Controls.Add(Me.ButtonClose)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(1046, 50)
        Me.HeaderPanel.TabIndex = 0
        '
        'HeaderLabel
        '
        Me.HeaderLabel.AutoSize = True
        Me.HeaderLabel.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.HeaderLabel.ForeColor = System.Drawing.Color.White
        Me.HeaderLabel.Location = New System.Drawing.Point(12, 16)
        Me.HeaderLabel.Name = "HeaderLabel"
        Me.HeaderLabel.Size = New System.Drawing.Size(56, 17)
        Me.HeaderLabel.TabIndex = 3
        Me.HeaderLabel.Text = "Search"
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.ButtonClose.IconColor = System.Drawing.Color.White
        Me.ButtonClose.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonClose.IconSize = 24
        Me.ButtonClose.Location = New System.Drawing.Point(1016, 5)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(24, 24)
        Me.ButtonClose.TabIndex = 2
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'SearchPanel
        '
        Me.SearchPanel.Controls.Add(Me.SearchBox)
        Me.SearchPanel.Controls.Add(Me.lblRecordCount)
        Me.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SearchPanel.Location = New System.Drawing.Point(0, 50)
        Me.SearchPanel.Name = "SearchPanel"
        Me.SearchPanel.Size = New System.Drawing.Size(1046, 40)
        Me.SearchPanel.TabIndex = 1
        '
        'SearchBox
        '
        Me.SearchBox.BorderRadius = 13
        Me.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SearchBox.DefaultText = ""
        Me.SearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.SearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SearchBox.DisabledState.Parent = Me.SearchBox
        Me.SearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SearchBox.FocusedState.Parent = Me.SearchBox
        Me.SearchBox.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.SearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SearchBox.HoverState.Parent = Me.SearchBox
        Me.SearchBox.Location = New System.Drawing.Point(11, 4)
        Me.SearchBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.SearchBox.PlaceholderText = "Scan Barcode / Search Product"
        Me.SearchBox.SelectedText = ""
        Me.SearchBox.ShadowDecoration.Parent = Me.SearchBox
        Me.SearchBox.Size = New System.Drawing.Size(375, 30)
        Me.SearchBox.TabIndex = 3
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.Location = New System.Drawing.Point(675, 4)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(50, 13)
        Me.lblRecordCount.TabIndex = 1
        Me.lblRecordCount.Text = "Label1"
        Me.lblRecordCount.Visible = False
        '
        'ListPanel
        '
        Me.ListPanel.Controls.Add(Me.SearchGrid)
        Me.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPanel.Location = New System.Drawing.Point(0, 90)
        Me.ListPanel.Name = "ListPanel"
        Me.ListPanel.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.ListPanel.Size = New System.Drawing.Size(1046, 481)
        Me.ListPanel.TabIndex = 2
        '
        'SearchGrid
        '
        Me.SearchGrid.ColumnDefinitionInfo = Nothing
        Me.SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchGrid.Location = New System.Drawing.Point(10, 0)
        Me.SearchGrid.MainView = Me.GridView1
        Me.SearchGrid.Name = "SearchGrid"
        Me.SearchGrid.Size = New System.Drawing.Size(1026, 471)
        Me.SearchGrid.TabIndex = 0
        Me.SearchGrid.TableFromInfo = Nothing
        Me.SearchGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.GridControl = Me.SearchGrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AllowFindPanel = False
        Me.GridView1.OptionsFind.ClearFindOnClose = False
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowCloseButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me.HeaderPanel
        '
        'SearchFormBase
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1046, 571)
        Me.Controls.Add(Me.ListPanel)
        Me.Controls.Add(Me.SearchPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Name = "SearchFormBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.SearchPanel.ResumeLayout(False)
        Me.SearchPanel.PerformLayout()
        Me.ListPanel.ResumeLayout(False)
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Protected Friend WithEvents HeaderLabel As Label
    Protected Friend WithEvents HeaderPanel As Panel
    Protected Friend WithEvents SearchPanel As Panel
    Protected Friend WithEvents ListPanel As Panel
    Protected Friend WithEvents SearchGrid As SearchGrid
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents SearchBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
