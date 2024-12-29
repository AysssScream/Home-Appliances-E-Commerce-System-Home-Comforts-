Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Data.Common
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls
Imports MySql.Data.MySqlClient


Public Class Lists

    Private _SearchFormColumnDefinitionInfo As String
    Private _SearchFormTableFromInfo As String

    Private DetailGrid As DetailGrid
    Private DetailGridView As GridView

    Private MainNavigationData As DataSet
    Private MainNavigationColumnsInfo As Collection
    Private MainNavigationSQLQuery As String

    Public Event MainNavigationAdditionalWhere(ByRef AdditionalWhere As String)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.BackColor = Colors.whiteSecondary
        Me.ButtonAddNew.BackColor = Colors.blueSecondary
        Me.ButtonAddNew.ForeColor = Colors.white
        Me.ButtonAddNew.IconColor = Colors.white

    End Sub

    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))>
    Public Property SearchFormColumnDefinitionInfo() As String
        Get
            Return GetLowerCaseString(_SearchFormColumnDefinitionInfo)
        End Get
        Set(ByVal value As String)
            _SearchFormColumnDefinitionInfo = value
        End Set
    End Property

    Public Property SearchFormTableFromInfo() As String
        Get
            Return GetLowerCaseString(_SearchFormTableFromInfo)
        End Get
        Set(ByVal value As String)
            _SearchFormTableFromInfo = value
        End Set
    End Property

    Private Sub Lists_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MainNavigationColumnsInfo = GetColumnInfo(Me.SearchFormColumnDefinitionInfo)
            BackgroundWorker1.RunWorkerAsync()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BuildNavigationData()
        Try
            Dim sqlSelect As String = "",
                    sqlFrom As String = "",
                    sqlWhere As String = "",
                    sqlOrderBy As String = ""

            For Each col As ColumnInfo In MainNavigationColumnsInfo
                sqlSelect &= col.FieldName + ","
            Next

            sqlSelect = "SELECT " + sqlSelect.TrimEnd(",")

            Dim tmp() As String = Me.SearchFormTableFromInfo.Split("|")

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

            Dim pQueryString As String
            Dim AdditionalCriteria As String
            'BUILD SQL QUERY STRING
            RaiseEvent MainNavigationAdditionalWhere(AdditionalCriteria)

            If Not IsEmptyString(Trim(sqlWhere)) Then
                If Not IsEmptyString(Trim(AdditionalCriteria)) Then
                    sqlWhere &= " AND " & AdditionalCriteria '& " AND " & Me.GetSoftDeleteWhere(Me.SearchFormTableFromInfo) 'CType(Me.PKControl, TextInput).TableName & ".IsDeleted <> 1"
                Else
                    ' sqlWhere &= " AND " & Me.GetSoftDeleteWhere(Me.SearchFormTableFromInfo)
                End If


            Else
                If Not IsEmptyString(Trim(AdditionalCriteria)) Then
                    sqlWhere = "WHERE " & AdditionalCriteria '& " AND " & Me.GetSoftDeleteWhere(Me.SearchFormTableFromInfo)
                Else
                    '  sqlWhere = "WHERE " & Me.GetSoftDeleteWhere(Me.SearchFormTableFromInfo)
                End If

            End If

            pQueryString = String.Format("{0} {1} {2} {3}", sqlSelect, sqlFrom, sqlWhere, sqlOrderBy)

            'Debug.Print(pQueryString)

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

                        MainNavigationData = New DataSet
                        MainNavigationData.Tables.Add("SearchGridData")
                        If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()
                        MainNavigationData.Tables("SearchGridData").BeginLoadData()
                        tmpDbAdapter.Fill(MainNavigationData, "SearchGridData")
                        MainNavigationData.Tables("SearchGridData").EndLoadData()
                        MainNavigationSQLQuery = pQueryString
                        'SourceQuery = pQueryString
                        'Return tmpData

                    Catch ex As Exception
                        'Return Nothing
                    Finally
                        If Not IsNothing(Connection) AndAlso
                            Connection.State <> System.Data.ConnectionState.Closed Then _
                                Connection.Close()
                    End Try
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Lists_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            SetNavigationData(MainNavigationColumnsInfo, MainNavigationData)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SetNavigationData(ByVal ColumnsInfo As Collection, ByVal DataSource As DataSet)
        Try
            If Not IsNothing(ColumnsInfo) AndAlso Not IsNothing(DataSource) Then
                'SetGridDefaults()
                CreateGridColumns(Me.sgRecords, ColumnsInfo, Me)

                Try

                    Me.DetailGrid = CType(sgRecords, DetailGrid)
                    DetailGridView = DirectCast(Me.DetailGrid.MainView, GridView)

                    If Me.DetailGrid.ShowEditButton Then
                        Dim repUpdate As New RepositoryItemButtonEdit With {.Name = "updatebutton"}
                        DetailGrid.RepositoryItems.Add(repUpdate)
                        repUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                        repUpdate.Buttons.Item(0).Tag = "update"
                        repUpdate.Buttons.Item(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                        repUpdate.Buttons.Item(0).ImageOptions.Image = My.Resources.edit
                        repUpdate.Buttons.Item(0).EnableImageTransparency = True
                        repUpdate.ButtonsStyle = BorderStyles.NoBorder

                        AddHandler repUpdate.ButtonPressed, AddressOf RepItemButtonClick
                        Dim grdColumn = DetailGridView.Columns.AddField("")
                        With grdColumn
                            .Caption = ""
                            .Width = 20
                            .OptionsColumn.AllowSize = False
                            .OptionsColumn.FixedWidth = True
                            .VisibleIndex = DetailGridView.VisibleColumns.Count
                            .ColumnEdit = repUpdate
                            .ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                            .UnboundType = DevExpress.Data.UnboundColumnType.String
                            .Visible = True
                        End With
                    End If

                    If Me.DetailGrid.ShowDeleteButton Then
                        Dim repDelete As New RepositoryItemButtonEdit With {.Name = "deletebutton"}
                        DetailGrid.RepositoryItems.Add(repDelete)
                        repDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                        'repDelete.Buttons.Item(0).Kind = ButtonPredefines.Delete
                        repDelete.Buttons.Item(0).Tag = "delete"
                        repDelete.Buttons.Item(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                        repDelete.Buttons.Item(0).ImageOptions.Image = My.Resources.delete
                        repDelete.Buttons.Item(0).EnableImageTransparency = True
                        repDelete.ButtonsStyle = BorderStyles.NoBorder

                        AddHandler repDelete.ButtonPressed, AddressOf RepItemButtonClick
                        Dim grdColumn = DetailGridView.Columns.AddField("")
                        With grdColumn
                            .Caption = ""
                            .Width = 20
                            .OptionsColumn.AllowSize = False
                            .OptionsColumn.FixedWidth = True
                            .VisibleIndex = DetailGridView.VisibleColumns.Count
                            .ColumnEdit = repDelete
                            .ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                            .UnboundType = DevExpress.Data.UnboundColumnType.String
                            .Visible = True
                        End With
                    End If



                    If Me.DetailGrid.ShowAddToCart Then
                        Dim repaddtocart As New RepositoryItemButtonEdit With {.Name = "addtocart"}
                        DetailGrid.RepositoryItems.Add(repaddtocart)
                        repaddtocart.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                        'repaddtocart.Buttons.Item(0).Kind = ButtonPredefines.Delete
                        repaddtocart.Buttons.Item(0).Tag = "addtocart"
                        repaddtocart.Buttons.Item(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                        repaddtocart.Buttons.Item(0).ImageOptions.Image = My.Resources.arrow_right
                        repaddtocart.Buttons.Item(0).EnableImageTransparency = True
                        repaddtocart.ButtonsStyle = BorderStyles.NoBorder

                        AddHandler repaddtocart.ButtonPressed, AddressOf RepItemButtonClick
                        Dim grdColumn = DetailGridView.Columns.AddField("")
                        With grdColumn
                            .Caption = ""
                            .Width = 20
                            .OptionsColumn.AllowSize = False
                            .OptionsColumn.FixedWidth = True
                            .VisibleIndex = DetailGridView.VisibleColumns.Count
                            .ColumnEdit = repaddtocart
                            .ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                            .UnboundType = DevExpress.Data.UnboundColumnType.String
                            .Visible = True
                        End With
                    End If
                Catch ex As Exception

                End Try

                Me.sgRecords.DataSource = DataSource
                Me.sgRecords.DataMember = DataSource.Tables(0).TableName
                Me.sgRecords.RefreshDataSource()
            Else
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Overridable Sub RepItemButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)

    End Sub

    Private Sub ButtonAddNew_Click(sender As Object, e As EventArgs) Handles ButtonAddNew.Click

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        BuildNavigationData()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        SetNavigationData(MainNavigationColumnsInfo, MainNavigationData)
    End Sub

End Class