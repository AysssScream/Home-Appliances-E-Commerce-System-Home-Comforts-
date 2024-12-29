<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportFormBase
    Inherits BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportFormBase))
        Dim XrDesignPanelListener1 As DevExpress.XtraReports.UserDesigner.XRDesignPanelListener = New DevExpress.XtraReports.UserDesigner.XRDesignPanelListener()
        Me.XrDesignBarManager1 = New DevExpress.XtraReports.UserDesigner.XRDesignBarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RecentlyUsedItemsComboBox1 = New DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox()
        Me.DesignRepositoryItemComboBox1 = New DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LeftSidePanel = New System.Windows.Forms.Panel()
        Me.ReportPanel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RightSidePanel = New System.Windows.Forms.Panel()
        Me.FilterPanel = New System.Windows.Forms.Panel()
        Me.DateFilter = New POS4U.DateFilter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReportDesigner1 = New DevExpress.XtraReports.UserDesigner.XRDesignMdiController(Me.components)
        CType(Me.XrDesignBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecentlyUsedItemsComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DesignRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel.SuspendLayout()
        Me.LeftSidePanel.SuspendLayout()
        Me.ReportPanel.SuspendLayout()
        Me.RightSidePanel.SuspendLayout()
        Me.FilterPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'XrDesignBarManager1
        '
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlTop)
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlRight)
        Me.XrDesignBarManager1.FontNameBox = Me.RecentlyUsedItemsComboBox1
        Me.XrDesignBarManager1.FontNameEdit = Nothing
        Me.XrDesignBarManager1.FontSizeBox = Me.DesignRepositoryItemComboBox1
        Me.XrDesignBarManager1.FontSizeEdit = Nothing
        Me.XrDesignBarManager1.Form = Me
        Me.XrDesignBarManager1.FormattingToolbar = Nothing
        Me.XrDesignBarManager1.HintStaticItem = Nothing
        Me.XrDesignBarManager1.ImageStream = CType(resources.GetObject("XrDesignBarManager1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.XrDesignBarManager1.LayoutToolbar = Nothing
        Me.XrDesignBarManager1.MaxItemId = 76
        Me.XrDesignBarManager1.Toolbar = Nothing
        Me.XrDesignBarManager1.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.XrDesignBarManager1.Updates.AddRange(New String() {"Toolbox"})
        Me.XrDesignBarManager1.ZoomItem = Nothing
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.XrDesignBarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(961, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 570)
        Me.barDockControlBottom.Manager = Me.XrDesignBarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(961, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.XrDesignBarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 570)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(961, 0)
        Me.barDockControlRight.Manager = Me.XrDesignBarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 570)
        '
        'RecentlyUsedItemsComboBox1
        '
        Me.RecentlyUsedItemsComboBox1.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.RecentlyUsedItemsComboBox1.AppearanceDropDown.Options.UseFont = True
        Me.RecentlyUsedItemsComboBox1.AutoHeight = False
        Me.RecentlyUsedItemsComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RecentlyUsedItemsComboBox1.DropDownRows = 12
        Me.RecentlyUsedItemsComboBox1.Name = "RecentlyUsedItemsComboBox1"
        '
        'DesignRepositoryItemComboBox1
        '
        Me.DesignRepositoryItemComboBox1.AutoHeight = False
        Me.DesignRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DesignRepositoryItemComboBox1.Name = "DesignRepositoryItemComboBox1"
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.HeaderPanel.Controls.Add(Me.Label1)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(961, 50)
        Me.HeaderPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sales History"
        '
        'LeftSidePanel
        '
        Me.LeftSidePanel.BackColor = System.Drawing.Color.White
        Me.LeftSidePanel.Controls.Add(Me.ReportPanel)
        Me.LeftSidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftSidePanel.Location = New System.Drawing.Point(0, 50)
        Me.LeftSidePanel.Name = "LeftSidePanel"
        Me.LeftSidePanel.Padding = New System.Windows.Forms.Padding(20)
        Me.LeftSidePanel.Size = New System.Drawing.Size(374, 520)
        Me.LeftSidePanel.TabIndex = 1
        '
        'ReportPanel
        '
        Me.ReportPanel.Controls.Add(Me.Panel1)
        Me.ReportPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReportPanel.Location = New System.Drawing.Point(20, 20)
        Me.ReportPanel.Name = "ReportPanel"
        Me.ReportPanel.Size = New System.Drawing.Size(334, 288)
        Me.ReportPanel.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(334, 40)
        Me.Panel1.TabIndex = 0
        '
        'RightSidePanel
        '
        Dim myColor As Color = ColorTranslator.FromHtml("#F6A645")
        Me.RightSidePanel.BackColor = myColor
        Me.RightSidePanel.Controls.Add(Me.FilterPanel)
        Me.RightSidePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightSidePanel.Location = New System.Drawing.Point(374, 50)
        Me.RightSidePanel.Name = "RightSidePanel"
        Me.RightSidePanel.Padding = New System.Windows.Forms.Padding(20)
        Me.RightSidePanel.Size = New System.Drawing.Size(587, 520)
        Me.RightSidePanel.TabIndex = 2
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.DateFilter)
        Me.FilterPanel.Controls.Add(Me.Panel2)
        Me.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.FilterPanel.Location = New System.Drawing.Point(20, 20)
        Me.FilterPanel.Name = "FilterPanel"
        Me.FilterPanel.Size = New System.Drawing.Size(547, 288)
        Me.FilterPanel.TabIndex = 0
        '
        'DateFilter
        '
        Me.DateFilter.Appearance.ForeColor = System.Drawing.Color.White
        Me.DateFilter.Appearance.Options.UseForeColor = True
        Me.DateFilter.Caption = "Date"
        Me.DateFilter.EditValue = " Like '%2023-05-09%'"
        Me.DateFilter.Location = New System.Drawing.Point(12, 46)
        Me.DateFilter.Name = "DateFilter"
        Me.DateFilter.Size = New System.Drawing.Size(434, 28)
        Me.DateFilter.TabIndex = 3
        Me.DateFilter.TableField = Nothing
        Me.DateFilter.TableName = Nothing
        Me.DateFilter.Tag = "5/9/2023"
        Me.DateFilter.UseTableName = False
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(547, 40)
        Me.Panel2.TabIndex = 2
        '
        'ReportDesigner1
        '
        Me.ReportDesigner1.ContainerControl = Nothing
        XrDesignPanelListener1.DesignControl = Me.XrDesignBarManager1
        Me.ReportDesigner1.DesignPanelListeners.AddRange(New DevExpress.XtraReports.UserDesigner.XRDesignPanelListener() {XrDesignPanelListener1})
        Me.ReportDesigner1.Form = Me
        '
        'ReportFormBase
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(961, 570)
        Me.Controls.Add(Me.RightSidePanel)
        Me.Controls.Add(Me.LeftSidePanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ReportFormBase"
        CType(Me.XrDesignBarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecentlyUsedItemsComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DesignRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.LeftSidePanel.ResumeLayout(False)
        Me.ReportPanel.ResumeLayout(False)
        Me.RightSidePanel.ResumeLayout(False)
        Me.FilterPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected Friend WithEvents HeaderPanel As Panel
    Protected Friend WithEvents LeftSidePanel As Panel
    Protected Friend WithEvents RightSidePanel As Panel
    Protected Friend WithEvents ReportPanel As Panel
    Protected Friend WithEvents FilterPanel As Panel
    Protected Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Protected Friend WithEvents DateFilter As DateFilter
    Friend WithEvents ReportDesigner1 As DevExpress.XtraReports.UserDesigner.XRDesignMdiController
    Friend WithEvents XrDesignBarManager1 As DevExpress.XtraReports.UserDesigner.XRDesignBarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RecentlyUsedItemsComboBox1 As DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox
    Friend WithEvents DesignRepositoryItemComboBox1 As DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox
End Class
