<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AuditReportLists
    Inherits POS4U.Lists

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuditReportLists))
        Me.SearchBox = New Guna.UI2.WinForms.Guna2TextBox()
        Me.HeaderPanel.SuspendLayout()
        Me.ListPanel.SuspendLayout()
        CType(Me.sgRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilterPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonAddNew
        '
        Me.ButtonAddNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ButtonAddNew.CausesValidation = False
        Me.ButtonAddNew.FlatAppearance.BorderSize = 0
        Me.ButtonAddNew.ForeColor = System.Drawing.Color.White
        Me.ButtonAddNew.IconColor = System.Drawing.Color.White
        Me.ButtonAddNew.Location = New System.Drawing.Point(1103, 7)
        Me.ButtonAddNew.Size = New System.Drawing.Size(118, 35)
        Me.ButtonAddNew.Visible = False
        '
        'HeaderLabel
        '
        Me.HeaderLabel.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderLabel.Size = New System.Drawing.Size(92, 17)
        Me.HeaderLabel.Text = "COURIERS"
        '
        'sgRecords
        '
        Me.sgRecords.ShowDeleteButton = False
        Me.sgRecords.ShowEditButton = False
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.SearchBox)
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
        Me.SearchBox.Location = New System.Drawing.Point(17, 5)
        Me.SearchBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.SearchBox.PlaceholderText = "Search Courier"
        Me.SearchBox.SelectedText = ""
        Me.SearchBox.ShadowDecoration.Parent = Me.SearchBox
        Me.SearchBox.Size = New System.Drawing.Size(375, 30)
        Me.SearchBox.TabIndex = 3
        '
        'AuditReportLists
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1228, 560)
        Me.Name = "AuditReportLists"
        Me.SearchFormColumnDefinitionInfo = resources.GetString("$this.SearchFormColumnDefinitionInfo")
        Me.SearchFormTableFromInfo = "|from audit_trails |order by datetime_at desc"
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.ListPanel.ResumeLayout(False)
        CType(Me.sgRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SearchBox As Guna.UI2.WinForms.Guna2TextBox
End Class
