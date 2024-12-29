<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lists
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lists))
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.ButtonAddNew = New FontAwesome.Sharp.IconButton()
        Me.HeaderLabel = New System.Windows.Forms.Label()
        Me.ListPanel = New System.Windows.Forms.Panel()
        Me.sgRecords = New POS4U.DetailGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FilterPanel = New System.Windows.Forms.Panel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.HeaderPanel.SuspendLayout()
        Me.ListPanel.SuspendLayout()
        CType(Me.sgRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.ButtonAddNew)
        Me.HeaderPanel.Controls.Add(Me.HeaderLabel)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(1228, 50)
        Me.HeaderPanel.TabIndex = 0
        '
        'ButtonAddNew
        '
        Me.ButtonAddNew.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ButtonAddNew.FlatAppearance.BorderSize = 0
        Me.ButtonAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAddNew.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ButtonAddNew.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        Me.ButtonAddNew.IconColor = System.Drawing.Color.Black
        Me.ButtonAddNew.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonAddNew.IconSize = 24
        Me.ButtonAddNew.Location = New System.Drawing.Point(1098, 11)
        Me.ButtonAddNew.Name = "ButtonAddNew"
        Me.ButtonAddNew.Size = New System.Drawing.Size(118, 30)
        Me.ButtonAddNew.TabIndex = 1
        Me.ButtonAddNew.Text = "[F2] Add New"
        Me.ButtonAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonAddNew.UseVisualStyleBackColor = True
        '
        'HeaderLabel
        '
        Me.HeaderLabel.AutoSize = True
        Me.HeaderLabel.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.HeaderLabel.Location = New System.Drawing.Point(12, 16)
        Me.HeaderLabel.Name = "HeaderLabel"
        Me.HeaderLabel.Size = New System.Drawing.Size(41, 17)
        Me.HeaderLabel.TabIndex = 0
        Me.HeaderLabel.Text = "Lists"
        '
        'ListPanel
        '
        Me.ListPanel.Controls.Add(Me.sgRecords)
        Me.ListPanel.Controls.Add(Me.Panel1)
        Me.ListPanel.Controls.Add(Me.FilterPanel)
        Me.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPanel.Location = New System.Drawing.Point(0, 50)
        Me.ListPanel.Name = "ListPanel"
        Me.ListPanel.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.ListPanel.Size = New System.Drawing.Size(1228, 510)
        Me.ListPanel.TabIndex = 1
        '
        'sgRecords
        '
        Me.sgRecords.ColumnDefinitionInfo = resources.GetString("sgRecords.ColumnDefinitionInfo")
        Me.sgRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sgRecords.Location = New System.Drawing.Point(10, 52)
        Me.sgRecords.MainView = Me.GridView1
        Me.sgRecords.Name = "sgRecords"
        Me.sgRecords.RowPosition = -2147483648
        Me.sgRecords.ShowDeleteButton = True
        Me.sgRecords.ShowEditButton = True
        Me.sgRecords.Size = New System.Drawing.Size(1208, 448)
        Me.sgRecords.TabIndex = 4
        Me.sgRecords.TableFromInfo = "|FROM inventories"
        Me.sgRecords.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.sgRecords
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsFind.AllowFindPanel = False
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1208, 10)
        Me.Panel1.TabIndex = 3
        '
        'FilterPanel
        '
        Me.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.FilterPanel.Location = New System.Drawing.Point(10, 0)
        Me.FilterPanel.Name = "FilterPanel"
        Me.FilterPanel.Size = New System.Drawing.Size(1208, 42)
        Me.FilterPanel.TabIndex = 0
        '
        'BackgroundWorker1
        '
        '
        'Lists
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 560)
        Me.Controls.Add(Me.ListPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.KeyPreview = True
        Me.Name = "Lists"
        Me.Text = "Lists"
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.ListPanel.ResumeLayout(False)
        CType(Me.sgRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected Friend WithEvents HeaderPanel As Panel
    Protected Friend WithEvents ListPanel As Panel
    Protected Friend WithEvents ButtonAddNew As FontAwesome.Sharp.IconButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Protected Friend WithEvents HeaderLabel As Label
    Protected Friend WithEvents FilterPanel As Panel
    Protected Friend WithEvents sgRecords As DetailGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Protected Friend WithEvents Panel1 As Panel
End Class
