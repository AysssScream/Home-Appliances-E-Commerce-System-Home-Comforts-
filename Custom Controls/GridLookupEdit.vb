Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.ComponentModel.Design
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Threading
Imports System.Data.Common
Imports DevExpress.XtraEditors.Repository
Imports MySql.Data.MySqlClient

Public Class GridLookupEdit : Inherits DevExpress.XtraEditors.GridLookUpEdit

    Private Delegate Sub PrepareGridDelegate()

    Private DataLoadDelegate As PrepareGridDelegate

    Private LoadStarted As Boolean = False
    Private pData As DataTable
    Private pDataView As DataView
    Private pDataAdapter As DbDataAdapter
    Private pQueryString As String
    Private pColumns As Collection
    Private pDisplayField As String
    Private pTableName As String
    Private pTableField As String
    Private pFromString As String
    Private pValueMember As String
    Private pColumnDefinitionString As String
    Private pUsePoUpWidth As Boolean
    Private pPopUpWidth As Integer

    Private LoaderThread As Thread
    'Private LoaderThreadStart As New ThreadStart(AddressOf GetData)
    Private currFilter As String

    Private IsFirstLoad As Boolean = True
    Public Event AdditionalWhere(ByRef Criteria As String)


#Region "Custom Properties"
    Private _RefreshOnFilterChange As Boolean
    <DefaultValue(False)> _
    Public Property RefreshOnFilterChange() As Boolean
        Get
            Return _RefreshOnFilterChange
        End Get
        Set(ByVal value As Boolean)
            _RefreshOnFilterChange = value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return GetLowerCaseString(pTableName) 'IIf(IsNothing(pTableName) OrElse String.IsNullOrEmpty(pTableName), "", pTableName.ToLower)
        End Get
        Set(ByVal value As String)
            pTableName = value
        End Set
    End Property

    Public Property TableField() As String
        Get
            Return GetLowerCaseString(pTableField) 'IIf(IsNothing(pTableField) OrElse String.IsNullOrEmpty(pTableField), "", pTableField.ToLower)
        End Get
        Set(ByVal value As String)
            pTableField = value
        End Set
    End Property

    <Category("CustomProperties")> _
    Public Property FromString() As String
        Get
            Return GetLowerCaseString(pFromString) 'IIf(IsNothing(pFromString) OrElse String.IsNullOrEmpty(pFromString), "", pFromString.ToLower)
        End Get
        Set(ByVal value As String)
            pFromString = value
        End Set
    End Property

    <Category("CustomProperties")> _
    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))> _
    Public Property ColumnDefinitionString() As String
        Get
            Return GetLowerCaseString(pColumnDefinitionString) 'IIf(IsNothing(pColumnDefinitionString) OrElse String.IsNullOrEmpty(pColumnDefinitionString), "", pColumnDefinitionString.ToLower)
        End Get
        Set(ByVal value As String)
            pColumnDefinitionString = value
        End Set
    End Property

    Public Property DisplayField() As String
        Get
            Return GetLowerCaseString(pDisplayField) 'IIf(IsNothing(pDisplayField) OrElse String.IsNullOrEmpty(pDisplayField), "", pDisplayField.ToLower)
        End Get
        Set(ByVal value As String)
            pDisplayField = value

        End Set
    End Property

    Public Property ValueMember() As String
        Get
            Return GetLowerCaseString(pValueMember) 'IIf(IsNothing(pValueMember) OrElse String.IsNullOrEmpty(pValueMember), "", pValueMember.ToLower)
        End Get
        Set(ByVal value As String)
            pValueMember = value
        End Set
    End Property

    <DefaultValue(False)>
    Public Property UsePoUpSize() As Boolean
        Get
            Return pUsePoUpWidth
        End Get
        Set(ByVal value As Boolean)
            pUsePoUpWidth = value
        End Set
    End Property

    Public Property PopUpWidth() As Integer
        Get
            Return pPopUpWidth
        End Get
        Set(ByVal value As Integer)
            pPopUpWidth = value
        End Set
    End Property

    Public ReadOnly Property GetColumns() As Collection
        Get
            Return pColumns
        End Get
    End Property

    Private _AdditionalFilter As String
    Friend WithEvents fProperties As RepositoryItemGridLookUpEdit
    Friend WithEvents fPropertiesView As GridView
    Friend WithEvents GridView1 As GridView
    Friend WithEvents GridView2 As GridView
    Friend WithEvents GridView3 As GridView
    Private isReloadFromFilterChange As Boolean
    Public Property AdditionalFilter() As String
        Get
            Return _AdditionalFilter
        End Get
        Set(ByVal value As String)
            If value <> _AdditionalFilter Then
                _AdditionalFilter = value
                isReloadFromFilterChange = True
                Me.LoadData()
            End If

        End Set
    End Property

    Private Sub BuildGridData()
        Try

            If Not IsEmptyString(Me.FromString) AndAlso Not IsEmptyString(Me.ColumnDefinitionString) Then
                If IsFirstLoad Then
                    SetGridDefaults()
                    CreateGridColumns()

                End If

                'EMPTY DATASOURCE & REMOVE ALL COLUMNS

                'Application.DoEvents()
                BuildQueryString()
                GetData()
                BindDataSourceToGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub LoadData(Optional ByVal async As Boolean = True)
        Try
            If async Then
                origBackColor = Me.BackColor
                'Me.BackColor = Color.Red
                DataLoadDelegate = New PrepareGridDelegate(AddressOf Me.BuildGridData)
                DataLoadDelegate.BeginInvoke(Nothing, Nothing)
            Else
                BuildGridData()
            End If

        Catch ex As Exception
            Me.BackColor = origBackColor
        End Try

    End Sub

    Private Sub SetGridDefaults()
        If Me.FindForm.InvokeRequired Then
            Me.FindForm.Invoke(New PrepareGridDelegate(AddressOf Me.SetGridDefaults))
        Else
            Me.Properties.PopupFilterMode = PopupFilterMode.Contains
            Me.Properties.ImmediatePopup = True
            'me.Properties.AutoComplete = True
            With CType(Me.Properties.View, GridView)

                With .OptionsView
                    .EnableAppearanceEvenRow = False
                    .EnableAppearanceOddRow = True
                    .ShowGroupPanel = False
                    .ShowColumnHeaders = True
                    .ShowAutoFilterRow = True
                    .ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
                    .ShowFooter = False                             'set to enable if need to display summaries
                    .NewItemRowPosition = NewItemRowPosition.None   'change to NewItemRowPosition.Bottom for adding new rows
                End With
                With .OptionsMenu
                    .EnableColumnMenu = False
                    .EnableGroupPanelMenu = False
                    .EnableFooterMenu = False
                End With
                With .OptionsBehavior
                    .AutoPopulateColumns = False

                    .Editable = False
                    .EditorShowMode = DevExpress.Utils.EditorShowMode.Default
                End With

                .OptionsCustomization.AllowFilter = True
                .OptionsNavigation.AutoFocusNewRow = True
                .FocusRectStyle = DrawFocusRectStyle.RowFocus
                With .OptionsSelection
                    .EnableAppearanceFocusedCell = True
                    .EnableAppearanceFocusedRow = True

                End With
                With .Appearance.FocusedRow
                    .BackColor = Color.White
                    .BackColor2 = Color.LightBlue
                    .GradientMode = Drawing2D.LinearGradientMode.Vertical
                    .ForeColor = Color.Black
                    .Font = New Font(.Font.Name, 8.25, FontStyle.Bold)
                End With

                .ColumnPanelRowHeight = 40 '20
                With .Appearance.HeaderPanel
                    .Options.UseTextOptions = True
                    .TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

                    .TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
                    '.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End With
            End With
        End If

    End Sub

    Private Sub CreateGridColumns()


        Try
            If Me.FindForm.InvokeRequired Then
                Me.FindForm.Invoke(New PrepareGridDelegate(AddressOf Me.CreateGridColumns))
            Else
                Dim columnView As GridView = CType(Me.Properties.View, GridView)
                With columnView
                    .Columns.Clear()

                    If Not IsEmptyString(Me.ColumnDefinitionString) Then
                        pColumns = GetColumnInfo(Me.ColumnDefinitionString)

                        If Not IsNothing(pColumns) Then
                            For Each col As ColumnInfo In pColumns
                                With .Columns.AddField(col.FieldName)
                                    .OptionsColumn.FixedWidth = False
                                    If col.Caption.ToUpper.Contains("\") Then
                                        .Caption = col.Caption.ToUpper.Split("\")(0) & Global.Microsoft.VisualBasic.ChrW(10) & col.Caption.ToUpper.Split("\")(1)
                                    Else
                                        .Caption = col.Caption.ToUpper
                                    End If
                                    '.Caption = col.Caption.ToUpper
                                    .Width = col.Width
                                    If Not IsEmptyString(col.Format) Then
                                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                        .DisplayFormat.FormatString = col.Format
                                    End If

                                    .Visible = IIf(col.Width > 0, True, False)
                                    'add code for generating Summaries or comboedits
                                    .OptionsFilter.AutoFilterCondition = IIf(col.Format <> "", AutoFilterCondition.Default, AutoFilterCondition.Contains)

                                End With

                            Next

                        End If
                    End If

                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearFilters()
        pDataView.RowFilter = ""
    End Sub

    Public Sub SetFilter(ByVal FilterExpression As String)
        Try
            'Dim view As GridView = Me.Properties.View
            'view.Columns(Field).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo(ColumnFilterType.Value, FilterValue, Nothing, "")
            'view.LayoutChanged()
            'view.ApplyColumnsFilter()
            pDataView.RowFilter = FilterExpression.ToLower
            currFilter = FilterExpression.ToLower
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetData()

        Using tmpCommand As DbCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
            Using tmpConnection As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                'Dim tmpDataAdapter As DbDataAdapter

                Try

                    'tmpConnection = DBFactory.GetConnection(AppData.DBProvider)
                    tmpConnection.ConnectionString = AppData.ConnectionString

                    'tmpCommand = DBFactory.GetCommand(AppData.DBProvider)
                    tmpCommand.CommandText = pQueryString 'IIf(ApplyFilter, String.Format("{0} WHERE {1}", pQueryString, FilterString), pQueryString)
                    tmpCommand.Connection = tmpConnection
                    tmpCommand.CommandTimeout = 5000

                    pDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
                    pDataAdapter.SelectCommand = tmpCommand

                    If Not IsNothing(pData) Then
                        pData.Clear()
                    Else
                        pData = New DataTable
                    End If
                    'If pData.Tables.Count = 0 Then pData.Tables.Add("lookupsource")
                    'pData.EnforceConstraints = False
                    '' Dim tmpData As New DataSet


                    pData.BeginLoadData()
                    pDataAdapter.Fill(pData)
                    pData.EndLoadData()
                    'pDataAdapter.Fill(pData)

                    'Invoke(New CallCrossThreadMethod(AddressOf Me.BindDataSourceToGrid))

                Catch ex As Exception
                    'If ex.Message <> "There is already an open DataReader associated with this Connection which must be closed first." Then
                    '    XtraMessageBox.Show("Data source creation failed..." & Me.Name.ToString, "Data Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    'End If
                    Clipboard.SetText(ex.Message + vbCrLf + ex.StackTrace, TextDataFormat.Text)
                Finally
                    If Not tmpCommand Is Nothing Then tmpCommand.Dispose()
                    If Not tmpConnection Is Nothing Then tmpConnection.Dispose()
                End Try
            End Using

        End Using


    End Sub
    Private origBackColor As Color
    Private Sub BindDataSourceToGrid()
        Try
            If Me.FindForm.InvokeRequired Then
                Me.FindForm.Invoke(New PrepareGridDelegate(AddressOf Me.BindDataSourceToGrid))
            Else
                Me.BackColor = origBackColor
                'Dim dvMain As DataView
                'Dim dvm As New DataViewManager(pData)
                'dvMain = dvm.CreateDataView(pData.Tables(0))
                pDataView = New DataView(pData)
                'pDataView.
                Me.Properties.DataSource = pDataView 'pData.Tables(0) 'dvMain
                Me.Properties.AutoComplete = True
                Me.Properties.NullText = ""
                Me.Properties.NullValuePrompt = ""
                Me.Properties.DisplayMember = Me.DisplayField.ToLower
                Me.Properties.ValueMember = Me.ValueMember.ToLower

                If IsFirstLoad Then IsFirstLoad = False
                If isReloadFromFilterChange Then isReloadFromFilterChange = False
            End If
        Catch ex As Exception
            Me.BackColor = origBackColor
        End Try


    End Sub

    Private Sub BuildQueryString()
        Try
            Dim sqlSelect As String = "", sqlFrom As String = "", sqlWhere As String = "", sqlGroupBy As String = "", sqlOrderBy As String = "", sqlAdditionalCriteria As String = ""
            For Each col As ColumnInfo In pColumns

                'If Me.GridMode <> GridModeEnum.Navigation Then
                'If col.FieldName.Contains(MainTableSuffix) Then sqlSelect += col.FieldName + ","
                'Else
                sqlSelect &= col.FieldName + ","
                'End If

            Next

            'added for joined tables
            Dim columnView As GridView = CType(Me.Properties.View, GridView)
            With columnView
                For Each col As GridColumn In .Columns
                    If col.FieldName.ToLower.Contains(" as ") Then
                        col.FieldName = col.FieldName.Split(" ")(2)
                    End If
                Next
            End With


            sqlSelect = "SELECT " + sqlSelect.TrimEnd(",")
            '''''''''''''''''BUILD QUERY'''''''''''''''''
            'Build FROM SQL
            Dim tmp() As String = FromString.Split("|")

            For i As Integer = 0 To UBound(tmp)
                If tmp(i) <> "" Then
                    With tmp(i).ToUpper
                        Select Case True
                            Case .Contains("FROM")
                                sqlFrom = tmp(i).Trim
                            Case .Contains("WHERE")
                                sqlWhere = tmp(i).Trim
                            Case .Contains("GROUP BY")
                                sqlGroupBy = tmp(i).Trim
                            Case .Contains("ORDER BY")
                                sqlOrderBy = tmp(i).Trim
                        End Select
                    End With
                End If
            Next

            'BUILD SQL QUERY STRING
            'sqlAdditionalCriteria = ""
            'raise AdditionalWhere event only if not building query for AdditionalFilter value changed
            If Not isReloadFromFilterChange Then RaiseEvent AdditionalWhere(Me.AdditionalFilter)


            If Not IsEmptyString(Trim(sqlWhere)) Then

                If Not IsEmptyString(Trim(Me.AdditionalFilter)) Then sqlWhere += " AND " + Me.AdditionalFilter

            Else
                If Not IsEmptyString(Trim(Me.AdditionalFilter)) Then sqlWhere = "WHERE " + Me.AdditionalFilter
            End If


            pQueryString = String.Format("{0} {1} {2} {3} {4}", sqlSelect, sqlFrom, sqlWhere, sqlGroupBy, sqlOrderBy)
            'pQueryString = pQueryString.ToLower.Replace(CompanyName, AddQuote9(Project.Instance.CompanyGroup))
        Catch ex As Exception

        End Try
       
    End Sub
#End Region

    Private Sub GridLookupEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EditValueChanged
       

    End Sub



    Private Sub GridLookupEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            Me.EditValue = Nothing
        ElseIf e.KeyCode = Keys.F11 Then
            If UserName = "" Then
                Try
                    XtraMessageBox.Show(pQueryString)
                    Clipboard.SetText(pQueryString, TextDataFormat.Text)
                Catch ex As Exception

                End Try
            End If
          
        End If
    End Sub

    Private Sub InitializeComponent()
        Me.fProperties = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.fProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fProperties
        '
        Me.fProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fProperties.Name = "fProperties"
        Me.fProperties.PopupView = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridLookupEdit
        '
        CType(Me.fProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub GridLookupEdit_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Me.QueryPopUp
        Dim editor As DevExpress.XtraEditors.GridLookUpEdit = CType(sender, DevExpress.XtraEditors.GridLookUpEdit)
        editor.Properties.PopupFormSize = New Size(IIf(UsePoUpSize, PopUpWidth, editor.Width - 4), Properties.PopupFormSize.Height)

        'ReloadData()
        BuildGridData()

        If currFilter <> "" Then pDataView.RowFilter = currFilter.ToLower



    End Sub

    Private Sub ReloadData()

        'RaiseEvent AdditionalWhere(Me.AdditionalFilter)
        ' LoadData()
        ' Dim pquerywhere As String = String.Format("{0} {1} {2} {3} {4}", sqlSelect, sqlFrom, sqlWhere+= " AND " + Me.AdditionalFilter, sqlGroupBy, sqlOrderBy)
        'Dim mydt As DataTable = AppData.GetDataTable(pQueryString)

        'Dim rcount As Integer = mydt.Rows.Count

        'If rcount > pData.Rows.Count Then
        BuildGridData()
        'End If

    End Sub
End Class


