Imports System.ComponentModel
'Imports DevExpress.XtraEditors
'Imports DevExpress.XtraGrid.Export
'Imports DevExpress.XtraExport
'Imports DevExpress.XtraBars
'Imports DevExpress.Utils
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports DevExpress.XtraGrid.Views.Grid
Imports System.IO
Imports DevExpress.XtraGrid.Columns
Imports System.Data.Common
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient
Public Class SearchFormBase
    Private Delegate Function BuildDataAsyncDelegate() As DataSet
    Public Event AdditionalWhere(ByRef Criteria As String)
    Public Event RecordSelected(ByVal RecordPK As String)

    Protected pColumns As Collection
    Private AdditionalCriteria As String
    Private pQueryString As String
    Protected pData As DataSet

    Protected WithEvents pGridView As GridView
    Private pCreateDataSourceAsyncDelegate As BuildDataAsyncDelegate
    Private _DefaultFocusedColumn As String
    Private _ColumnDefinitionInfo As String
    Private _TableFromInfo As String
    Protected DataLoaded As Boolean = False
    Private LayoutFileName As String
    Protected SourceQuery As String
    Private pkField As String
    '======================
    Private WithEvents bgw As New BackgroundWorker
    Private LoadDataInProgress As Boolean = False

    Private moduleCtrl As Control
    Private moduleTypeCtrl As Control

    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))>
    Public Property ColumnDefinitionInfo() As String
        Get
            Return _ColumnDefinitionInfo
        End Get
        Set(ByVal value As String)
            _ColumnDefinitionInfo = value
        End Set
    End Property

    Public Property TableFromInfo() As String
        Get
            Return _TableFromInfo
        End Get
        Set(ByVal value As String)
            _TableFromInfo = value
        End Set
    End Property

    Public Property AdditionalFilter() As String
        Get
            Return AdditionalCriteria
        End Get
        Set(ByVal value As String)
            AdditionalCriteria = value
        End Set
    End Property

    Public Property DefaultFocusedColumn() As String
        Get
            Return _DefaultFocusedColumn
        End Get
        Set(ByVal value As String)
            _DefaultFocusedColumn = value
        End Set
    End Property

    Public Sub New(ByVal ColumnDefinitionInfo As String, ByVal TableFromInfo As String, Optional ByVal _moduleCtrl As Control = Nothing, Optional ByVal _moduletypeCtrl As Control = Nothing)

        InitializeComponent()
        If Not Me.DesignMode Then
            Try

                Me.ColumnDefinitionInfo = ColumnDefinitionInfo
                Me.TableFromInfo = TableFromInfo
                moduleCtrl = _moduleCtrl
                moduleTypeCtrl = _moduletypeCtrl
                pGridView = DirectCast(Me.SearchGrid.MainView, GridView)
                SetGridDefaults()
                If Not IsEmptyString(Me.ColumnDefinitionInfo) Then pColumns = GetColumnInfo(Me.ColumnDefinitionInfo)
            Catch ex As Exception

            End Try
        End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SetGridDefaults()
        With pGridView
            .GroupFormat = "{0}: [#image]{1}"
            With .OptionsView
                .ColumnAutoWidth = True
                .EnableAppearanceEvenRow = False
                .EnableAppearanceOddRow = True
                .ShowGroupPanel = False ''
                .ShowColumnHeaders = True
                .ShowAutoFilterRow = True
                .ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
                .ShowFooter = True                             'set to enable if need to display summaries
                .NewItemRowPosition = NewItemRowPosition.None   'change to NewItemRowPosition.Bottom for adding new rows
            End With
            With .OptionsMenu
                .EnableColumnMenu = True
                .EnableGroupPanelMenu = False
                .EnableFooterMenu = True
            End With
            With .OptionsBehavior
                .Editable = False
                .EditorShowMode = DevExpress.Utils.EditorShowMode.Default
            End With
            .OptionsCustomization.AllowFilter = True
            .OptionsCustomization.AllowGroup = True
            .OptionsCustomization.AllowQuickHideColumns = False ''hans
            .OptionsCustomization.AllowColumnMoving = False ''hans
            .OptionsNavigation.AutoFocusNewRow = True
            .FocusRectStyle = DrawFocusRectStyle.None
            With .OptionsSelection
                .EnableAppearanceFocusedCell = False
                .EnableAppearanceFocusedRow = True
            End With
            With .Appearance.FocusedRow
                .BackColor = Color.White
                .BackColor2 = Color.LightGray
                .GradientMode = Drawing2D.LinearGradientMode.Vertical
                .ForeColor = Color.Black
                .Font = New Font(.Font.Name, 8.25, FontStyle.Bold)
            End With

        End With
    End Sub

    Private Sub BuildQueryString()
        Dim sqlSelect As String = "",
        sqlFrom As String = "",
        sqlWhere As String = "",
         sqlGroupBy As String = "",
        sqlOrderBy As String = ""

        For Each col As ColumnInfo In pColumns
            sqlSelect &= col.FieldName + ","
        Next

        sqlSelect = "SELECT " + sqlSelect.TrimEnd(",")

        Dim tmp() As String = Me.TableFromInfo.Split("|")

        For i As Integer = 0 To UBound(tmp)
            If tmp(i) <> "" Then
                With tmp(i).ToUpper
                    Select Case True
                        Case .Contains("SELECT")
                            sqlSelect = tmp(i).Trim
                        Case .Contains("FROM ")
                            sqlFrom = tmp(i).Trim
                        Case .Contains("WHERE")
                            sqlWhere = tmp(i).Trim
                        Case .Contains("ORDER BY")
                            sqlOrderBy = tmp(i).Trim
                        Case .Contains("GROUP BY")
                            sqlGroupBy = tmp(i).Trim
                    End Select
                End With
            End If
        Next

        'BUILD SQL QUERY STRING
        RaiseEvent AdditionalWhere(AdditionalCriteria)
        If Not IsEmptyString(Trim(sqlWhere)) Then
            If Not IsEmptyString(Trim(AdditionalCriteria)) Then sqlWhere &= " AND " + AdditionalCriteria
        Else
            If Not IsEmptyString(Trim(AdditionalCriteria)) Then sqlWhere = "WHERE " + AdditionalCriteria
        End If

        Try
            If Not IsNothing(moduleCtrl) AndAlso Not IsEmptyString(DirectCast(moduleCtrl, TextInput).TableField) AndAlso Not IsEmptyString(DirectCast(moduleCtrl, TextInput).Text) Then
                sqlWhere &= String.Format(" AND  {2}.{0}='{1}'", CType(moduleCtrl, TextInput).TableField, CType(moduleCtrl, TextInput).EditValue, CType(moduleCtrl, TextInput).TableName)
            End If
        Catch ex As Exception

        End Try

        Try
            If Not IsNothing(moduleTypeCtrl) AndAlso Not IsEmptyString(DirectCast(moduleTypeCtrl, TextInput).TableField) AndAlso Not IsEmptyString(DirectCast(moduleTypeCtrl, TextInput).Text) Then
                sqlWhere &= String.Format(" AND  {2}.{0}='{1}'", CType(moduleTypeCtrl, TextInput).TableField, CType(moduleTypeCtrl, TextInput).EditValue, CType(moduleTypeCtrl, TextInput).TableName)
            End If
        Catch ex As Exception

        End Try

        pQueryString = String.Format("{0} {1} {2} {3} {4}", sqlSelect, sqlFrom, sqlWhere, sqlGroupBy, sqlOrderBy)
        Debug.Print(pQueryString)


    End Sub


    Private Function PrepareData() As DataSet

        Using Connection As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
            Using tmpDbAdapter As DbDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
                Try
                    Connection.ConnectionString = AppData.ConnectionString

                    With tmpDbAdapter
                        .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                        .SelectCommand.CommandType = CommandType.Text
                        .SelectCommand.CommandText = pQueryString
                        .SelectCommand.Connection = Connection
                        .SelectCommand.CommandTimeout = 5000
                    End With

                    Dim tmpData As New DataSet

                    If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()
                    tmpDbAdapter.Fill(tmpData, "SearchGridData")
                    SourceQuery = pQueryString
                    Return tmpData

                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        End Using
    End Function

    Private Sub SaveGridViewLayout()
    End Sub

    Private Sub RestoreGridLayout()

    End Sub

    Private Sub SearchFormBase_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not LoadDataInProgress Then LoadData()
    End Sub

    Private Sub SearchFormBase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SaveGridViewLayout()
        'e.Cancel = True
        'Me.Close()
    End Sub

    Private Sub SearchFormBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'System.Threading.Thread.Sleep(5000)
        If Not Me.DesignMode Then
            Try
                Me.SearchGrid.ForceInitialize()
                PrepareGrid()
                With pGridView
                    .Focus()
                    .FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                    .FocusedColumn = .VisibleColumns(0)
                    .ShowEditor()
                End With


            Catch ex As Exception

            End Try

        End If



    End Sub

    Private Sub PrepareGrid()
        pkField = (From cInfo In Me.pColumns
                   Where cInfo.Caption.tolower = "syspk"
                   Select cInfo.FieldName).FirstOrDefault

        CreateGridColumns(Me.SearchGrid, Me.pColumns)
        RestoreGridLayout()
    End Sub

    Protected Overridable Sub SearchGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchGrid.DoubleClick
        Try
            With pGridView
                If .FocusedRowHandle >= 0 Then
                    RaiseEvent RecordSelected(.GetFocusedRowCellValue(pkField))
                    .ClearColumnsFilter()
                    Me.Hide()
                    'Me.Close()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Overridable Sub SearchGrid_ProcessGridKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchGrid.ProcessGridKey
        If e.KeyCode = Keys.Enter Then

            Try
                With pGridView
                    If .FocusedRowHandle >= 0 Then
                        RaiseEvent RecordSelected(.GetFocusedRowCellValue(.Columns(0).FieldName.ToString)) '(StrVal9(.GetFocusedRowCellValue(.Columns(0).FieldName.ToString)))
                        Me.Hide()
                    ElseIf .FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                        'Dim gcs As GridColumnReadOnlyCollection = .VisibleColumns
                        For Each gc As GridColumn In .Columns
                            Dim currFilter As String '= IIf(.GetFocusedRowCellValue(gc) Is Nothing, "", .GetFocusedRowCellValue(gc).ToString.Trim)
                            If .GetFocusedRowCellValue(gc) Is Nothing Then
                                currFilter = ""
                            Else
                                currFilter = .GetFocusedRowCellValue(gc).ToString.Trim
                            End If
                            If currFilter <> String.Empty Then
                                Dim newFilter As String = ""
                                Select Case gc.ColumnType().Name
                                    Case "DateTime"
                                        Dim BinaryFilter As CriteriaOperator
                                        'newFilter = String.Format("[{0}]", .FocusedColumn.FieldName)
                                        Select Case True
                                            Case currFilter.Substring(0, 1) = ">"
                                                'newFilter &= String.Format(" > {0}", currFilter.Replace(">", "").Trim)
                                                BinaryFilter = (New OperandProperty(gc.FieldName) > New OperandValue(DateValue(currFilter.Replace(">", "").Trim)))
                                            Case currFilter.Substring(0, 2) = ">="
                                                'newFilter &= String.Format(" >= {0}", currFilter.Replace(">=", "").Trim)
                                                BinaryFilter = (New OperandProperty(gc.FieldName) >= New OperandValue(DateValue(currFilter.Replace(">", "").Trim)))
                                            Case currFilter.Substring(0, 2) = "<="
                                                'newFilter &= String.Format(" <= {0}", currFilter.Replace("<=", "").Trim)
                                                BinaryFilter = (New OperandProperty(gc.FieldName) <= New OperandValue(DateValue(currFilter.Replace(">", "").Trim)))
                                            Case currFilter.Substring(0, 1) = "<"
                                                'newFilter &= String.Format(" < {0}", currFilter.Replace("<", "").Trim)
                                                BinaryFilter = (New OperandProperty(gc.FieldName) < New OperandValue(DateValue(currFilter.Replace(">", "").Trim)))
                                            Case currFilter.Contains("to")
                                                Dim strValues() As String = currFilter.Split(New String() {"to"}, StringSplitOptions.RemoveEmptyEntries)
                                                'newFilter &= String.Format(" >= {0} AND {1} <= {2}", +strValues(0), newFilter, strValues(1))
                                                BinaryFilter = (New OperandProperty(gc.FieldName) >= New OperandValue(DateValue(strValues(0)))) And (New OperandProperty(gc.FieldName) <= New OperandValue(DateValue(strValues(1))))
                                            Case Else
                                                BinaryFilter = (New OperandProperty(gc.FieldName) = New OperandValue(DateValue(currFilter.Trim)))
                                        End Select

                                        newFilter = BinaryFilter.ToString
                                    Case "Decimal", "Integer"

                                        newFilter = String.Format("[{0}]", gc.FieldName)
                                        Select Case True
                                            Case currFilter.Substring(0, 1) = ">"
                                                newFilter &= " > " + currFilter.Replace(">", "").Trim
                                            Case currFilter.Substring(0, 2) = ">="
                                                newFilter &= " >= " + currFilter.Replace(">=", "").Trim
                                            Case currFilter.Substring(0, 2) = "<="
                                                newFilter &= " <= " + currFilter.Replace("<=", "").Trim
                                            Case currFilter.Substring(0, 1) = "<"
                                                newFilter &= " < " + currFilter.Replace("<", "").Trim
                                            Case currFilter.Contains("to")
                                                Dim strValues() As String = currFilter.Split(New String() {"to"}, StringSplitOptions.RemoveEmptyEntries)
                                                newFilter &= String.Format(" >= {0} AND {1} <= {2}", strValues(0), newFilter, strValues(1))
                                        End Select

                                End Select
                                Dim valFilter As New DevExpress.XtraGrid.Columns.ColumnFilterInfo(newFilter)
                                gc.FilterInfo = valFilter
                            End If
                        Next

                    End If
                End With
            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.F5 Then
            ' Refresh()
        ElseIf e.KeyCode = Keys.F11 Then   'SQL query

            Try
                XtraMessageBox.Show(pQueryString)
                Clipboard.SetText(pQueryString, TextDataFormat.Text)
            Catch ex As Exception

            End Try

        End If
    End Sub



    Private Sub DisposeObjects()
        pColumns = Nothing
        pData = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        DisposeObjects()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub pGridView_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pGridView.ColumnFilterChanged
        Try
            Me.lblRecordCount.Text = DirectCast(sender, GridView).RowCount & " Records on File..."
            If Not pGridView.ActiveFilterEnabled Then
                pGridView.ClearColumnsFilter()
                pGridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                pGridView.FocusedColumn = pGridView.VisibleColumns(0)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SearchFormBase_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True AndAlso e.KeyCode = Keys.F5 Then
            Me.Refresh()
        ElseIf e.KeyCode = Keys.F5 Then
            SearchGrid.RefreshDataSource()
        ElseIf e.KeyCode = Keys.F11 Then   'SQL query
            If Project.Instance.ActiveUser.ToString.ToLower = "backdoor" Then
                Try
                    XtraMessageBox.Show(pQueryString)
                    Clipboard.SetText(pQueryString, TextDataFormat.Text)
                Catch ex As Exception

                End Try
            End If

        End If
    End Sub
    Private Sub LoadData()
        'If IsNothing(DataSource) OrElse Me.OwnerPickListInfo.ReloadPickListOnPopup Then
        LoadDataInProgress = True
        bgw.RunWorkerAsync()
        'End If
    End Sub


    Private Sub bgw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgw.DoWork
        If IsEmptyString(pQueryString) Then BuildQueryString()
        'Me.lblRecordCount.Text = "Please wait while loading Picklist Data..."
        pData = PrepareData()
    End Sub

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        If Not IsNothing(pData) Then
            Me.SearchGrid.DataSource = pData
            Me.SearchGrid.DataMember = pData.Tables(0).TableName
            Me.SearchGrid.RefreshDataSource()

            Me.lblRecordCount.Text = pData.Tables("SearchGridData").Rows.Count & " Records on File..."
            LoadDataInProgress = False
        End If
    End Sub
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        'Me.Close()
        Me.Hide()
    End Sub

    Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        Try
            GridView1.FindFilterText = SearchBox.Text
        Catch ex As Exception

        End Try
    End Sub
End Class
