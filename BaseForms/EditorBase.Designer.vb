<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditorBase
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
        Me.InputValidator = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.lblSeparator = New System.Windows.Forms.Panel()
        Me.HeaderLabel = New System.Windows.Forms.Label()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.FormSplitter = New DevExpress.XtraEditors.SplitContainerControl()
        Me.FormPanel = New System.Windows.Forms.Panel()
        Me.ActionPanel = New System.Windows.Forms.Panel()
        Me.ButtonSave = New FontAwesome.Sharp.IconButton()
        Me.FooterTab = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.RecordInfo = New DevExpress.XtraTab.XtraTabPage()
        Me.txtUser = New POS4U.TextInput()
        Me.txtModuleType = New POS4U.TextInput()
        Me.txtModule = New POS4U.TextInput()
        Me.txtSysPK = New POS4U.TextInput()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Preview = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Print = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(Me.components)
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        CType(Me.InputValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel.SuspendLayout()
        CType(Me.FormSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FormSplitter.SuspendLayout()
        Me.ActionPanel.SuspendLayout()
        CType(Me.FooterTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FooterTab.SuspendLayout()
        Me.RecordInfo.SuspendLayout()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModuleType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSysPK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Print, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InputValidator
        '
        Me.InputValidator.ValidateHiddenControls = False
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.lblMode)
        Me.HeaderPanel.Controls.Add(Me.lblSeparator)
        Me.HeaderPanel.Controls.Add(Me.HeaderLabel)
        Me.HeaderPanel.Controls.Add(Me.ButtonClose)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(1229, 50)
        Me.HeaderPanel.TabIndex = 0
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMode.ForeColor = System.Drawing.Color.Gray
        Me.lblMode.Location = New System.Drawing.Point(197, 15)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(54, 17)
        Me.lblMode.TabIndex = 4
        Me.lblMode.Text = "MODE"
        '
        'lblSeparator
        '
        Me.lblSeparator.BackColor = System.Drawing.Color.Gray
        Me.lblSeparator.Location = New System.Drawing.Point(189, 10)
        Me.lblSeparator.Name = "lblSeparator"
        Me.lblSeparator.Size = New System.Drawing.Size(2, 30)
        Me.lblSeparator.TabIndex = 3
        '
        'HeaderLabel
        '
        Me.HeaderLabel.AutoSize = True
        Me.HeaderLabel.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderLabel.Location = New System.Drawing.Point(12, 15)
        Me.HeaderLabel.Name = "HeaderLabel"
        Me.HeaderLabel.Size = New System.Drawing.Size(53, 17)
        Me.HeaderLabel.TabIndex = 2
        Me.HeaderLabel.Text = "Setup"
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.ButtonClose.IconColor = System.Drawing.Color.Black
        Me.ButtonClose.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonClose.IconSize = 24
        Me.ButtonClose.Location = New System.Drawing.Point(1200, 4)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(24, 24)
        Me.ButtonClose.TabIndex = 1
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'FormSplitter
        '
        Me.FormSplitter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.FormSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormSplitter.Horizontal = False
        Me.FormSplitter.Location = New System.Drawing.Point(0, 50)
        Me.FormSplitter.Name = "FormSplitter"
        Me.FormSplitter.Panel1.Controls.Add(Me.FormPanel)
        Me.FormSplitter.Panel1.Controls.Add(Me.ActionPanel)
        Me.FormSplitter.Panel1.Text = "FormPanel"
        Me.FormSplitter.Panel2.Controls.Add(Me.FooterTab)
        Me.FormSplitter.Panel2.Text = "FooterPanel"
        Me.FormSplitter.Size = New System.Drawing.Size(1229, 523)
        Me.FormSplitter.SplitterPosition = 276
        Me.FormSplitter.TabIndex = 1
        Me.FormSplitter.Text = "SplitContainerControl1"
        '
        'FormPanel
        '
        Me.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormPanel.Location = New System.Drawing.Point(0, 40)
        Me.FormPanel.Name = "FormPanel"
        Me.FormPanel.Size = New System.Drawing.Size(1225, 236)
        Me.FormPanel.TabIndex = 1
        '
        'ActionPanel
        '
        Me.ActionPanel.Controls.Add(Me.ButtonSave)
        Me.ActionPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ActionPanel.Location = New System.Drawing.Point(0, 0)
        Me.ActionPanel.Name = "ActionPanel"
        Me.ActionPanel.Size = New System.Drawing.Size(1225, 40)
        Me.ActionPanel.TabIndex = 0
        '
        'ButtonSave
        '
        Me.ButtonSave.FlatAppearance.BorderSize = 0
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ButtonSave.IconChar = FontAwesome.Sharp.IconChar.Save
        Me.ButtonSave.IconColor = System.Drawing.Color.Black
        Me.ButtonSave.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ButtonSave.IconSize = 24
        Me.ButtonSave.Location = New System.Drawing.Point(13, 4)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(134, 30)
        Me.ButtonSave.TabIndex = 0
        Me.ButtonSave.Text = "[F2 ] Save"
        Me.ButtonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'FooterTab
        '
        Me.FooterTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FooterTab.Location = New System.Drawing.Point(0, 0)
        Me.FooterTab.Name = "FooterTab"
        Me.FooterTab.SelectedTabPage = Me.XtraTabPage1
        Me.FooterTab.Size = New System.Drawing.Size(1225, 238)
        Me.FooterTab.TabIndex = 0
        Me.FooterTab.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.RecordInfo})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1219, 210)
        Me.XtraTabPage1.Text = "XtraTabPage1"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1219, 178)
        Me.XtraTabPage2.Text = "XtraTabPage2"
        '
        'RecordInfo
        '
        Me.RecordInfo.Controls.Add(Me.txtUser)
        Me.RecordInfo.Controls.Add(Me.txtModuleType)
        Me.RecordInfo.Controls.Add(Me.txtModule)
        Me.RecordInfo.Controls.Add(Me.txtSysPK)
        Me.RecordInfo.Name = "RecordInfo"
        Me.RecordInfo.Size = New System.Drawing.Size(1219, 178)
        Me.RecordInfo.Text = "Record Info"
        '
        'txtUser
        '
        Me.txtUser.DisplayFormat = ""
        Me.txtUser.Location = New System.Drawing.Point(120, 130)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(348, 20)
        Me.txtUser.TabIndex = 3
        Me.txtUser.TableField = ""
        Me.txtUser.TableName = ""
        Me.txtUser.Tag = "1"
        Me.txtUser.UseSystemPasswordChar = Nothing
        '
        'txtModuleType
        '
        Me.txtModuleType.DisplayFormat = ""
        Me.txtModuleType.Location = New System.Drawing.Point(120, 104)
        Me.txtModuleType.Name = "txtModuleType"
        Me.txtModuleType.Size = New System.Drawing.Size(348, 20)
        Me.txtModuleType.TabIndex = 2
        Me.txtModuleType.TableField = ""
        Me.txtModuleType.TableName = ""
        Me.txtModuleType.Tag = "1"
        Me.txtModuleType.UseSystemPasswordChar = Nothing
        '
        'txtModule
        '
        Me.txtModule.DisplayFormat = ""
        Me.txtModule.Location = New System.Drawing.Point(120, 69)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(348, 20)
        Me.txtModule.TabIndex = 1
        Me.txtModule.TableField = ""
        Me.txtModule.TableName = ""
        Me.txtModule.Tag = "1"
        Me.txtModule.UseSystemPasswordChar = Nothing
        '
        'txtSysPK
        '
        Me.txtSysPK.DisplayFormat = ""
        Me.txtSysPK.Location = New System.Drawing.Point(120, 30)
        Me.txtSysPK.Name = "txtSysPK"
        Me.txtSysPK.Size = New System.Drawing.Size(348, 20)
        Me.txtSysPK.TabIndex = 0
        Me.txtSysPK.TableField = ""
        Me.txtSysPK.TableName = ""
        Me.txtSysPK.UseSystemPasswordChar = Nothing
        '
        'Preview
        '
        Me.Preview.Manager = Me.BarManager1
        Me.Preview.Name = "Preview"
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowMoveBarOnToolbar = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.DockingEnabled = False
        Me.BarManager1.Form = Me
        Me.BarManager1.MaxItemId = 0
        Me.BarManager1.OptionsLayout.AllowAddNewItems = False
        '
        'Print
        '
        Me.Print.Manager = Me.BarManager1
        Me.Print.Name = "Print"
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me.HeaderPanel
        '
        'EditorBase
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 573)
        Me.Controls.Add(Me.FormSplitter)
        Me.Controls.Add(Me.HeaderPanel)
        Me.KeyPreview = True
        Me.Name = "EditorBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditorBase"
        CType(Me.InputValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        CType(Me.FormSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FormSplitter.ResumeLayout(False)
        Me.ActionPanel.ResumeLayout(False)
        CType(Me.FooterTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FooterTab.ResumeLayout(False)
        Me.RecordInfo.ResumeLayout(False)
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModuleType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSysPK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Print, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents HeaderPanel As Panel
    Protected Friend WithEvents FormSplitter As DevExpress.XtraEditors.SplitContainerControl
    Protected Friend WithEvents FooterTab As DevExpress.XtraTab.XtraTabControl
    Protected Friend WithEvents txtSysPK As TextInput
    Protected Friend WithEvents txtModule As TextInput
    Protected Friend WithEvents ActionPanel As Panel
    Protected Friend WithEvents ButtonSave As FontAwesome.Sharp.IconButton
    Protected Friend WithEvents FormPanel As Panel
    Protected Friend WithEvents HeaderLabel As Label
    Protected Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Protected Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Protected Friend WithEvents RecordInfo As DevExpress.XtraTab.XtraTabPage
    Protected Friend WithEvents txtModuleType As TextInput
    Protected Friend WithEvents InputValidator As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Protected Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Protected Friend WithEvents Preview As DevExpress.XtraBars.PopupMenu
    Protected Friend WithEvents Print As DevExpress.XtraBars.PopupMenu
    Protected Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents HelpProvider1 As HelpProvider
    Public WithEvents ButtonClose As FontAwesome.Sharp.IconButton
    Protected Friend WithEvents txtUser As TextInput
    Protected Friend WithEvents lblSeparator As Panel
    Protected Friend WithEvents lblMode As Label
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Protected Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
