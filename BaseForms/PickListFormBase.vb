Imports DevExpress.XtraGrid.Views.Grid
Imports System.ComponentModel
Imports System.Data.Common
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports MySql.Data.MySqlClient

Public Class PickListFormBase
    Public Event AfterReturnValues(ByVal GridName As String)
    Public Event RefreshList()

    Private DataSource As DataSet
    Private OwnerPickListInfo As GridPickListInfo
    Private QueryString As String
    Private viewColumns As Collection
    Private LoadDataInProgress As Boolean = False
    Private dataLoaded As Boolean
    Private WithEvents bgw As New BackgroundWorker

    Sub New(ByVal pickInfo As GridPickListInfo)

        Me.OwnerPickListInfo = pickInfo

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        HeaderPanel.BackColor = Colors.blueSecondary
        ButtonClose.IconColor = Colors.white
        lblSearchHeader.ForeColor = Colors.white

        ' Add any initialization after the InitializeComponent() call.
        SetGridDefaults()
        If Not IsEmptyString(pickInfo._PickColumnsInfo) Then _
                viewColumns = GetColumnInfo(pickInfo._PickColumnsInfo)
        CreateGridColumns(Me.ListGrid, Me.viewColumns)
    End Sub

    Public Property PickListTitle() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property


    'Grid Initialize
    Private Sub SetGridDefaults()
        With Me.ListView
            .GroupFormat = "{0}: [#image]{1}"
            With .OptionsView
                .ColumnAutoWidth = True
                .EnableAppearanceEvenRow = False
                .EnableAppearanceOddRow = True
                .ShowGroupPanel = False
                .ShowColumnHeaders = True
                .ShowAutoFilterRow = True
                .ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
                .ShowFooter = False
                .NewItemRowPosition = NewItemRowPosition.None

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
                .Font = New Font("Verdana", 9.25, FontStyle.Bold)
            End With
            .ColumnPanelRowHeight = 40
        End With
    End Sub

    Private Sub LoadData()
        If IsNothing(DataSource) OrElse Me.OwnerPickListInfo.ReloadPickListOnPopup Then
            LoadDataInProgress = True
            bgw.RunWorkerAsync()

            With CType(ListGrid.MainView, GridView)
                .ClearColumnsFilter()
                .FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                .FocusedColumn = .VisibleColumns(0)
            End With
        End If
    End Sub


    Private Sub bgw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgw.DoWork
        If IsEmptyString(QueryString) OrElse Me.OwnerPickListInfo.ReloadPickListOnPopup Then BuildQueryString()
        If Not dataLoaded Then
            DataSource = PrepareData()
        End If

    End Sub

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        If Not IsNothing(DataSource) Then
            Me.ListGrid.DataSource = DataSource
            Me.ListGrid.DataMember = DataSource.Tables(0).TableName
            Me.ListGrid.RefreshDataSource()

            ''Me.lblRecordCount.Text = DataSource.Tables("SearchGridData").Rows.Count & " Records on File..."
            LoadDataInProgress = False

            dataLoaded = True
        End If
    End Sub

    Private Sub BuildQueryString()
        Dim sqlSelect As String = "",
        sqlFrom As String = "",
        sqlWhere As String = "",
        sqlOrderBy As String = ""

        For Each col As ColumnInfo In viewColumns
            sqlSelect &= col.FieldName + ","
        Next

        sqlSelect = "SELECT " + sqlSelect.TrimEnd(",")

        Dim tmp() As String = Me.OwnerPickListInfo._PickTableFromInfo.Split("|")

        For i As Integer = 0 To UBound(tmp)
            If tmp(i) <> "" Then
                With tmp(i).ToUpper
                    Select Case True
                        Case .Contains("FROM")
                            sqlFrom = tmp(i).Trim
                        Case .Contains("WHERE")
                            sqlWhere = tmp(i).Trim
                        Case .Contains("ORDER BY")
                            sqlOrderBy = tmp(i).Trim
                    End Select
                End With
            End If
        Next

        'BUILD SQL QUERY STRING
        If Not IsEmptyString(Trim(Me.OwnerPickListInfo.AdditionalWhere)) Then
            If Not IsEmptyString(Trim(sqlWhere)) Then
                sqlWhere &= " AND " + Me.OwnerPickListInfo.AdditionalWhere
            Else
                sqlWhere = "WHERE " + Me.OwnerPickListInfo.AdditionalWhere
            End If
        End If

        QueryString = String.Format("{0} {1} {2} {3}", sqlSelect, sqlFrom, sqlWhere, sqlOrderBy)
        Debug.Print(QueryString)
    End Sub

    Private Function PrepareData() As DataSet

        Using Connection As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
            Using tmpDbAdapter As DbDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
                Try
                    Connection.ConnectionString = AppData.ConnectionString

                    With tmpDbAdapter
                        .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                        .SelectCommand.CommandType = CommandType.Text
                        .SelectCommand.CommandText = QueryString
                        .SelectCommand.Connection = Connection
                        .SelectCommand.CommandTimeout = 5000
                    End With

                    Dim tmpData As New DataSet

                    If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()
                    tmpDbAdapter.Fill(tmpData, "SearchGridData")
                    Return tmpData

                Catch ex As Exception
                    Return Nothing
                    If UserName = "" Then
                        MessageBox.Show(ex.Message)
                    End If
                End Try
            End Using
        End Using
    End Function

    Private Sub PickListBase4_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        dataLoaded = False
        If Not LoadDataInProgress Then LoadData()
    End Sub

    Public Event BeforeReturnValues(ByVal dr As DataRow, ByRef cancel As Boolean)

    Private Sub PickListBase4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.F5 AndAlso Not LoadDataInProgress Then
            LoadData()
        ElseIf e.KeyCode = Keys.F1 Then
            With CType(ListGrid.MainView, GridView)
                .ClearColumnsFilter()
                .FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                .FocusedColumn = .VisibleColumns(0)
            End With
        End If
    End Sub

    Private Sub ListView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim res As Boolean


                Dim SelectedRow As DataRow = ListView.GetDataRow(ListView.FocusedRowHandle)
                RaiseEvent BeforeReturnValues(SelectedRow, res)

                If Not res Then
                    Dim returnColumns = From Column As ColumnInfo In viewColumns
                                        Where Column.OutputField <> String.Empty
                                        Select Column

                    Dim OwnerView As GridView = DirectCast(Me.OwnerPickListInfo.OwnerGrid.MainView, GridView)

                    With OwnerView
                        For Each returnColumn As ColumnInfo In returnColumns
                            If IsDBNull(SelectedRow(returnColumn.FieldName)) Then
                                If .Columns(returnColumn.OutputField.ToLower).ColumnType.Name = "Decimal" Then
                                    .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, 0)
                                Else

                                    .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, "")
                                End If

                            Else
                                .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, SelectedRow(returnColumn.FieldName))
                            End If

                            Dim currRowHandle As Integer = .FocusedRowHandle
                            .FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                            .FocusedColumn = .VisibleColumns(0)
                            .FocusedRowHandle = currRowHandle
                            .FocusedColumn = .VisibleColumns(0)
                        Next

                    End With
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If

            Catch ex As Exception

                XtraMessageBox.Show(QueryString)
                Clipboard.SetText(QueryString, TextDataFormat.Text)

            Finally
                ListView.ClearColumnsFilter()
                Me.DialogResult = System.Windows.Forms.DialogResult.Abort
            End Try
        ElseIf e.KeyCode = Keys.F11 Then

        End If
    End Sub

    Private Sub ListView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView.DoubleClick

        Try
            Dim res As Boolean


            Dim SelectedRow As DataRow = ListView.GetDataRow(ListView.FocusedRowHandle)
            RaiseEvent BeforeReturnValues(SelectedRow, res)

            If Not res Then
                Dim returnColumns = From Column As ColumnInfo In viewColumns
                                    Where Column.OutputField <> String.Empty
                                    Select Column

                Dim OwnerView As GridView = DirectCast(Me.OwnerPickListInfo.OwnerGrid.MainView, GridView)

                With OwnerView
                    For Each returnColumn As ColumnInfo In returnColumns
                        If IsDBNull(SelectedRow(returnColumn.FieldName)) Then
                            If .Columns(returnColumn.OutputField.ToLower).ColumnType.Name = "Decimal" Then
                                .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, 0)
                            Else

                                .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, "")
                            End If

                        Else
                            .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, SelectedRow(returnColumn.FieldName))
                        End If

                        Dim currRowHandle As Integer = .FocusedRowHandle
                        .FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                        .FocusedColumn = .VisibleColumns(0)
                        .FocusedRowHandle = currRowHandle
                        .FocusedColumn = .VisibleColumns(0)
                    Next

                End With
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If


            RaiseEvent AfterReturnValues(Me.OwnerPickListInfo.OwnerGrid.Name)
        Catch ex As Exception

            XtraMessageBox.Show(QueryString)
            Clipboard.SetText(QueryString, TextDataFormat.Text)

        Finally
            ListView.ClearColumnsFilter()
            Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class
