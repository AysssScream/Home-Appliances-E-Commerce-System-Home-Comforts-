<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickListFormBase
    Inherits POS4U.BaseForm

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
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.ButtonClose = New FontAwesome.Sharp.IconButton()
        Me.lblSearchHeader = New System.Windows.Forms.Label()
        Me.FormPanel = New System.Windows.Forms.Panel()
        Me.ListGrid = New POS4U.SearchGrid()
        Me.ListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.HeaderPanel.SuspendLayout()
        Me.FormPanel.SuspendLayout()
        CType(Me.ListGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.ButtonClose)
        Me.HeaderPanel.Controls.Add(Me.lblSearchHeader)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(832, 50)
        Me.HeaderPanel.TabIndex = 0
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
        Me.ButtonClose.Location = New System.Drawing.Point(805, 3)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(24, 24)
        Me.ButtonClose.TabIndex = 4
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'lblSearchHeader
        '
        Me.lblSearchHeader.AutoSize = True
        Me.lblSearchHeader.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lblSearchHeader.Location = New System.Drawing.Point(11, 16)
        Me.lblSearchHeader.Name = "lblSearchHeader"
        Me.lblSearchHeader.Size = New System.Drawing.Size(53, 17)
        Me.lblSearchHeader.TabIndex = 3
        Me.lblSearchHeader.Text = "Label1"
        '
        'FormPanel
        '
        Me.FormPanel.Controls.Add(Me.ListGrid)
        Me.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormPanel.Location = New System.Drawing.Point(0, 50)
        Me.FormPanel.Name = "FormPanel"
        Me.FormPanel.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.FormPanel.Size = New System.Drawing.Size(832, 350)
        Me.FormPanel.TabIndex = 1
        '
        'ListGrid
        '
        Me.ListGrid.ColumnDefinitionInfo = ""
        Me.ListGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListGrid.Location = New System.Drawing.Point(10, 0)
        Me.ListGrid.MainView = Me.ListView
        Me.ListGrid.Name = "ListGrid"
        Me.ListGrid.Size = New System.Drawing.Size(812, 340)
        Me.ListGrid.TabIndex = 12
        Me.ListGrid.TableFromInfo = ""
        Me.ListGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListView})
        '
        'ListView
        '
        Me.ListView.ActiveFilterEnabled = False
        Me.ListView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.ListView.GridControl = Me.ListGrid
        Me.ListView.Name = "ListView"
        Me.ListView.OptionsCustomization.AllowColumnMoving = False
        Me.ListView.OptionsCustomization.AllowGroup = False
        Me.ListView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.ListView.OptionsFilter.AllowFilterEditor = False
        Me.ListView.OptionsFilter.AllowMRUFilterList = False
        Me.ListView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ListView.OptionsView.ShowGroupPanel = False
        '
        'PickListFormBase
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(832, 400)
        Me.Controls.Add(Me.FormPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.Name = "PickListFormBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.FormPanel.ResumeLayout(False)
        CType(Me.ListGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents FormPanel As Panel
    Friend WithEvents lblSearchHeader As Label
    Protected Friend WithEvents ListGrid As SearchGrid
    Protected Friend WithEvents ListView As DevExpress.XtraGrid.Views.Grid.GridView
    Public WithEvents ButtonClose As FontAwesome.Sharp.IconButton
End Class
