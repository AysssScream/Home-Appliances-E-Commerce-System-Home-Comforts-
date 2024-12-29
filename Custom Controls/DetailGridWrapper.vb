Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Data.Common
Imports System.Linq
Imports System.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls
Imports MySql.Data.MySqlClient


Public Class DetailGridWrapper

    Private Delegate Sub CrossThreadInvoker(ByVal Param As Object)
    Private DetailGrid As DetailGrid
    Private DetailGridView As GridView
    Private DetailColumns As Collection
    Private DetailGridData As DataSet
    Private DetailDataConnection As DbConnection
    Private DetailDataAdapter As DbDataAdapter
    Private DetailCommandBuilder As DbCommandBuilder

    Private DetailPickLists As Collection
    Private DetailSourceTable As String
    Private DetailPKField As String
    Private DetailFKField As String
    Private DetailFKValue As String

    Private ActiveLookUpEditColumns As Collection
    Private ActiveLookUpEditSeletedRow As DataRow
    Private EnterKeyPressed As Boolean
    Private GridReady As Boolean = False
    'query variables
    Private DisplaySelectString As String = ""
    Private DisplayFromString As String = ""
    Private DisplayWhereString As String = ""
    Private DisplayOrderByString As String = ""

    Private TableSelectString As String = ""
    Private TableFromString As String = ""
    Private TableWhereString As String = ""
    Private TableOrderByString As String = ""
    Private DetailRecordsFilter As String = ""
    Private ClearOnReady As Boolean = False
    Private currentDataSourceQuery As String
    Private ActiveFilterColumn As String

    'Private WithEvents repedit As RepositoryItem

    Private Delegate Sub LoadDetailRecordsAsync()
    'Private Delegate Sub LoadDetailRecordsAsync()
    Private Delegate Sub ShowPickListDelegate(ByVal param1 As Object, ByVal param2 As Object)
    Private Delegate Sub BindDataDelegate(ByVal ar As IAsyncResult)
    Public Event FilterPickListBeforeShow(ByVal DetailGridName As String, ByRef FieldName As String, ByRef FilterValue As Object)
    Public Event FilterGridLookUp(ByVal FieldName As String, ByRef FilterColumn As String, ByRef FilterValue As Object)
    Private PrepareDataAsync As LoadDetailRecordsAsync
    Private CrossThreadMethodDelegate As CrossThreadMethodInvokerDelegate
    Public Event AfterPickListReturnValues(ByVal GridName As String)
    Public Event AfterRowSave(ByVal GridName As String, ByVal dtRow As DataRow)
    Public Event AfterRowDelete(ByVal GridName As String, ByVal dtRow As DataRow)
    Public Event BeforeRowSave(ByRef Cancel As Boolean)

    Public Event RepEditButtonItemClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)

    Public Sub New(ByVal FormDetailGrid As DetailGrid)
        Try
            Me.DetailGrid = FormDetailGrid
            DetailSourceTable = Me.DetailGrid.Name.Replace("__", "|").Split("|")(1)
            Debug.Print(Me.DetailGrid.Name)
            DetailGridView = DirectCast(Me.DetailGrid.MainView, GridView)

            Try
                'ADD HANDLER TO ParentRecordChange
                With DirectCast(Me.DetailGrid.FindForm, EditorBase)
                    AddHandler .LoadDetailRecords, AddressOf ParentRecordChanged
                    'AddHandler .AfterRecordSave, AddressOf SaveDetailRecords
                    AddHandler .FormStateChanged, AddressOf DetailGrid_ParentFormStateChanged
                    AddHandler .DeleteDetailRecords, AddressOf DeleteDetailRecords
                    AddHandler .FormStateChanged, AddressOf FormStateChanged
                End With
            Catch ex As Exception

            End Try

            'attach grid event handlers
            AddHandler Me.DetailGrid.ProcessGridKey, AddressOf DetailGrid_ProcessGridKey

            'attach view event handlers
            With DetailGridView
                AddHandler .InitNewRow, AddressOf DetailGrid_InitNewRow
                AddHandler .ShownEditor, AddressOf DetailGrid_ShownEditor
                AddHandler .CellValueChanged, AddressOf DetailGrid_CellValueChanged
                AddHandler .RowCellClick, AddressOf DetailGrid_RowCellClick
                AddHandler .FocusedRowChanged, AddressOf DetailGrid_FocusedRowChanged
                AddHandler .HiddenEditor, AddressOf DetailGrid_HiddenEditor
                AddHandler .CustomDrawRowIndicator, AddressOf DisplayRowNumber
                AddHandler .CustomDrawCell, AddressOf CustomDrawCell
                AddHandler .LostFocus, AddressOf DetailGrid_LostFocus

            End With



            'Load Grid Default Settings
            SetDetailGridDefaults()

            'Create Grid Column Collection
            If Not IsEmptyString(Me.DetailGrid.ColumnDefinitionInfo) Then _
                Me.DetailColumns = GetColumnInfo(Me.DetailGrid.ColumnDefinitionInfo)

            CreateGridColumns(Me.DetailGrid, DetailColumns)

            Try

                If Me.DetailGrid.ShowEditButton Then
                    Dim repUpdate As New RepositoryItemButtonEdit With {.Name = "updatebutton"}
                    DetailGrid.RepositoryItems.Add(repUpdate)
                    repUpdate.TextEditStyle = Controls.TextEditStyles.HideTextEditor
                    repUpdate.Buttons.Item(0).Tag = "update"
                    repUpdate.Buttons.Item(0).Kind = Controls.ButtonPredefines.Glyph
                    repUpdate.Buttons.Item(0).ImageOptions.Image = My.Resources.edit
                    repUpdate.Buttons.Item(0).EnableImageTransparency = True
                    repUpdate.ButtonsStyle = BorderStyles.NoBorder

                    'AddHandler repUpdate.ButtonPressed, AddressOf ButtonEdit_ButtonClick
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
                    repDelete.TextEditStyle = Controls.TextEditStyles.HideTextEditor
                    'repDelete.Buttons.Item(0).Kind = ButtonPredefines.Delete
                    repDelete.Buttons.Item(0).Tag = "delete"
                    repDelete.Buttons.Item(0).Kind = Controls.ButtonPredefines.Glyph
                    repDelete.Buttons.Item(0).ImageOptions.Image = My.Resources.delete
                    repDelete.Buttons.Item(0).EnableImageTransparency = True
                    repDelete.ButtonsStyle = BorderStyles.NoBorder

                    'AddHandler repDelete.ButtonPressed, AddressOf ButtonEdit_ButtonClick
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
                    repaddtocart.TextEditStyle = Controls.TextEditStyles.HideTextEditor
                    'repaddtocart.Buttons.Item(0).Kind = ButtonPredefines.Delete
                    repaddtocart.Buttons.Item(0).Tag = "addtocart"
                    repaddtocart.Buttons.Item(0).Kind = Controls.ButtonPredefines.Glyph
                    repaddtocart.Buttons.Item(0).ImageOptions.Image = My.Resources.arrow_right
                    repaddtocart.Buttons.Item(0).EnableImageTransparency = True
                    repaddtocart.ButtonsStyle = BorderStyles.NoBorder

                    'AddHandler repaddtocart.ButtonPressed, AddressOf ButtonEdit_ButtonClick
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


            AttachRepositoryItemEventHandlers()

            'attach editvaluechanged handler for all gridLookUpEdits
            Dim gridLookUpEdits = (From Column As ColumnInfo In Me.DetailColumns
                                   Where Column.CustProperty <> String.Empty AndAlso Column.CustProperty.ToLower.Contains("gridlookup")
                                   Select Column.FieldName)

            Try
                For Each GridLookUpEdit As String In gridLookUpEdits
                    AddHandler CType(Me.DetailGrid.MainView, GridView).Columns(GridLookUpEdit.ToLower).ColumnEdit.EditValueChanged, AddressOf Me.GridLookupEdit_EditValueChanged

                Next
            Catch ex As Exception

            End Try

            CreatePickLists()
            CreateSourceQuery()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Delete_ButtonPressed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If DetailGridView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If XtraMessageBox.Show("Are you sure you want To delete item?", "Validate Action", MessageBoxButtons.YesNo) = DialogResult.Yes Then DetailGridView.DeleteRow(DetailGridView.FocusedRowHandle)
        End If
    End Sub

    Private Sub CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        If IsNothing(e.Column.Tag) Then Exit Sub
        Try
            If e.Column.Tag.ToString = "picklist" OrElse e.Column.Tag.ToString = "gridlookup" Then
                Dim currentView As GridView = CType(sender, GridView)

                Dim backgroundRect As Rectangle = e.Bounds
                backgroundRect.Inflate(1, 1)
                Dim state As GridRowCellState = CType(e.Cell, GridCellInfo).State

                If ((state And GridRowCellState.Selected) = GridRowCellState.Selected) Then
                    e.Graphics.FillRectangle(e.Appearance.GetBackBrush(e.Cache), backgroundRect)
                End If

                ' Draw the focus rectangle if needed.
                If ((state And GridRowCellState.FocusedCell) _
                            = GridRowCellState.FocusedCell) Then
                    e.Cache.Paint.DrawFocusRectangle(e.Graphics, backgroundRect, e.Appearance.ForeColor, e.Appearance.BackColor)
                End If

                ' Draw the error icon.
                e.Graphics.DrawImage(My.Resources.search, e.Bounds.Location.X, e.Bounds.Location.Y)
                ' Draw the cell value
                Dim r As Rectangle = e.Bounds
                r.Width = (r.Width - 24)
                r.X = (r.X + 24)
                e.Appearance.DrawString(e.Cache, e.DisplayText, r)
                ' Set e.Handled to true to prevent default painting
                e.Handled = True
            End If
        Catch ex As Exception

        End Try

        'End If


    End Sub

    Private parentFormState As EditorState
    Private Sub FormStateChanged(ByVal formState As EditorState)
        parentFormState = formState
        If formState = EditorState.AddMode OrElse formState = EditorState.EditMode Then
            Me.DetailGridView.OptionsBehavior.ReadOnly = False

        Else
            Me.DetailGridView.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub DisplayRowNumber(ByVal sender As Object, ByVal e As RowIndicatorCustomDrawEventArgs)
        Try
            Dim view As GridView = CType(sender, GridView)

            If e.Info.IsRowIndicator AndAlso (e.RowHandle + 1) > 0 Then
                e.Info.DisplayText = (e.RowHandle + 1).ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AttachRepositoryItemEventHandlers()
        Try
            With DetailGridView
                For Each col As GridColumn In .Columns
                    If Not IsNothing(col.ColumnEdit) Then _
                    AddHandler col.ColumnEdit.MouseLeave, AddressOf Me.repedit_MouseLeave

                    If TypeOf col.ColumnEdit Is RepositoryItemButtonEdit Then
                        AddHandler DirectCast(col.ColumnEdit, RepositoryItemButtonEdit).ButtonClick, AddressOf Me.ButtonEdit_ButtonClick
                    End If
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridLookupEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim tmpInput As GridLookupEdit = CType(sender, GridLookupEdit)
            Dim edit As DevExpress.XtraEditors.GridLookUpEdit = CType(sender, DevExpress.XtraEditors.GridLookUpEdit)
            ActiveLookUpEditSeletedRow = edit.Properties.View.GetDataRow(edit.Properties.View.FocusedRowHandle)
            ActiveLookUpEditColumns = GetColumnInfo(CType(CType(Me.DetailGrid.FindForm, EditorBase).GetControl(CType(edit.Tag, RepositoryItemGridLookUpEdit).Tag), GridPickListInfo)._PickColumnsInfo)
            ActiveLookUpEditSeletedRow = tmpInput.GetSelectedDataRow

        Catch ex As Exception

        End Try
    End Sub

    'CREATE PICKLIST
    Private Sub CreatePickLists()
        Try
            Dim ownerForm As EditorBase = DirectCast(Me.DetailGrid.FindForm, EditorBase)
            DetailPickLists = New Collection

            Dim PickLists = (From Column As ColumnInfo In Me.DetailColumns
                             Where Column.CustProperty <> String.Empty AndAlso Column.CustProperty.Contains("picklist")
                             Select Column.CustProperty).Distinct
            If Not IsNothing(PickLists) Then
                For Each PickList As String In PickLists
                    Dim pickName() As String = PickList.Split(":")
                    If pickName.Length > 1 AndAlso pickName(1) <> String.Empty Then
                        Dim pickInfo As GridPickListInfo = DirectCast(ownerForm.GetControl(pickName(1)), GridPickListInfo)
                        If Not IsNothing(pickInfo) Then
                            pickInfo.OwnerGrid = Me.DetailGrid

                            AddHandler pickInfo.AfterReturnValues, AddressOf Me.AfterReturnValues
                            DetailPickLists.Add(pickInfo, pickName(1))
                        End If


                    End If


                Next

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AfterReturnValues(ByVal GridName As String)
        RaiseEvent AfterPickListReturnValues(GridName)
    End Sub

    Public Sub FilterPickList(ByRef FilterColumn As String, ByRef FilterValue As Long)
        Try
            RaiseEvent FilterPickListBeforeShow(Me.DetailGrid.Name, FilterColumn, FilterValue)
        Catch ex As Exception

        End Try
    End Sub
    'CREATE GRIDLOOKUP
    Private Sub CreateGridLookUps()
        Try
            Dim ownerForm As EditorBase = DirectCast(Me.DetailGrid.FindForm, EditorBase)

            Dim GridLookUps = (From Column As ColumnInfo In Me.DetailColumns
                               Where Column.CustProperty <> String.Empty AndAlso Column.CustProperty.Contains("gridlookup")
                               Select Column.CustProperty)

            If Not IsNothing(GridLookUps) Then
                For Each GridLookUp As String In GridLookUps
                    Dim pickName() As String = GridLookUp.Split(":")
                    If pickName.Length > 1 AndAlso pickName(1) <> String.Empty Then
                        Dim pickInfo As GridPickListInfo = DirectCast(ownerForm.GetControl(pickName(1)), GridPickListInfo)
                        Dim RepoEdit As New RepositoryItemGridLookUpEdit

                    End If


                Next

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DeleteDetailRecords()
        Try
            If DetailGrid.RowCount > 0 Then
                For i As Integer = DetailGrid.RowCount - 1 To 0 Step -1
                    DetailGrid.RowPosition = i
                    DetailGrid.DeleteRow()
                Next
            End If

            Dim DeletedRows = From p As DataRow In DetailGridData.Tables("DisplayData").Rows
                              Where p.RowState = DataRowState.Deleted
                              Select p

            If DeletedRows.Any Then
                With DetailGridData.Tables("TableData")
                    For Each DeletedRow As DataRow In DeletedRows
                        Using conn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                            Using cmd As DbCommand = conn.CreateCommand
                                cmd.CommandText = DELETEROWSQL
                                cmd.CommandType = CommandType.Text

                                'load parameters

                                Dim param As DbParameter = cmd.CreateParameter
                                param.ParameterName = "@" & DetailPKField
                                param.Value = DeletedRow(DetailPKField, DataRowVersion.Original)

                                cmd.Parameters.Add(param)

                                'execute save
                                conn.ConnectionString = AppData.ConnectionString
                                conn.Open()
                                cmd.ExecuteNonQuery()

                                RaiseEvent AfterRowDelete(DetailGrid.Name, DeletedRow)


                            End Using
                        End Using
                    Next
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Save Detail Records
    Public Sub SaveDetailRecords()
        Try
            If Me.DetailGrid.DisplayOnly Then
                Exit Sub
            End If
            Dim requiredField As String = ""

            Try
                For Each col As ColumnInfo In Me.DetailColumns
                    If col.CustProperty.ToLower.Contains("picklist") OrElse col.CustProperty.ToLower.Contains("gridlookup") Then
                        requiredField = col.FieldName
                        Exit For
                    End If
                Next
            Catch ex As Exception

            End Try


            System.Threading.Thread.Sleep(50)

            Dim DeletedRows = From p As DataRow In DetailGridData.Tables("DisplayData").Rows
                              Where p.RowState = DataRowState.Deleted
                              Select p

            If DeletedRows.Any Then
                Using conn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                    Using cmd As DbCommand = conn.CreateCommand
                        cmd.CommandText = DELETEROWSQL
                        cmd.CommandType = CommandType.Text
                        conn.ConnectionString = AppData.ConnectionString
                        conn.Open()

                        With DetailGridData.Tables("TableData")
                            For Each DeletedRow As DataRow In DeletedRows

                                Dim datarowCopy As DataRow = DeletedRow
                                'datarowCopy
                                'load parameters

                                Dim param As DbParameter = cmd.CreateParameter
                                param.ParameterName = "@" & DetailPKField
                                param.Value = DeletedRow(DetailPKField, DataRowVersion.Original)

                                cmd.Parameters.Add(param)



                                Try
                                    cmd.ExecuteNonQuery()

                                    RaiseEvent AfterRowDelete(DetailGrid.Name, DeletedRow)
                                Catch ex As Exception
                                    If UserName = "BACKDOOR" Then
                                        MsgBox("Deleted row!" & ex.StackTrace & ex.Message)
                                    End If
                                End Try

                                Try
                                    If InStr(DetailPKField.ToLower, "ldgrinvty") AndAlso DetailGrid.InventoryEnabled Then
                                        UpdateInventory(DeletedRow("fk_invty_ldgrInvty", DataRowVersion.Original))
                                    End If
                                Catch ex As Exception

                                End Try

                                cmd.Parameters.Clear()
                            Next
                        End With
                    End Using
                End Using
            End If

            System.Threading.Thread.Sleep(50)

            Dim ModifiedRows = From p As DataRow In DetailGridData.Tables("DisplayData").Rows
                               Where p.RowState = DataRowState.Modified
                               Select p

            If ModifiedRows.Any Then
                Using conn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                    Using cmd As DbCommand = conn.CreateCommand
                        cmd.CommandText = UPDATEROWSQL
                        cmd.CommandType = CommandType.Text
                        conn.ConnectionString = AppData.ConnectionString
                        conn.Open()

                        With DetailGridData.Tables("TableData")

                            For Each ModifiedRow As DataRow In ModifiedRows


                                'load parameters
                                For Each col As DataColumn In .Columns
                                    Dim param As DbParameter = cmd.CreateParameter
                                    param.ParameterName = "@" & col.ColumnName
                                    param.Value = ModifiedRow(col.ColumnName)

                                    cmd.Parameters.Add(param)
                                Next

                                'execute save
                                Try
                                    cmd.ExecuteNonQuery()

                                    RaiseEvent AfterRowSave(DetailGrid.Name, ModifiedRow)
                                Catch ex As Exception
                                    If UserName = "BACKDOOR" Then
                                        MsgBox("Added row!" & ex.StackTrace & ex.Message)
                                    End If
                                End Try

                                Try
                                    If InStr(DetailPKField.ToLower, "ldgrinvty") AndAlso DetailGrid.InventoryEnabled Then
                                        UpdateInventory(ModifiedRow("fk_invty_ldgrInvty", DataRowVersion.Current))
                                    End If
                                Catch ex As Exception

                                End Try

                                cmd.Parameters.Clear()
                            Next
                        End With
                    End Using
                End Using
            End If


            System.Threading.Thread.Sleep(50)

            Dim AddedRows = From p As DataRow In DetailGridData.Tables("DisplayData").Rows
                            Where p.RowState = DataRowState.Added
                            Select p
            If AddedRows.Any Then
                Dim params As New List(Of DbParameter)
                'commented 12/10/2015
                Using conn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                    Using cmd As DbCommand = conn.CreateCommand
                        cmd.CommandText = INSERTROWSQL
                        cmd.CommandType = CommandType.Text
                        conn.ConnectionString = AppData.ConnectionString
                        conn.Open()

                        With DetailGridData.Tables("TableData")
                            For Each AddedRow As DataRow In AddedRows
                                'load parameters
                                For Each col As DataColumn In .Columns
                                    Dim param As DbParameter = cmd.CreateParameter
                                    param.ParameterName = "@" & col.ColumnName
                                    param.Value = AddedRow(col.ColumnName)

                                    cmd.Parameters.Add(param)
                                Next
                                Dim Cancel As Boolean = False
                                Try
                                    RaiseEvent BeforeRowSave(Cancel)
                                    If Not Cancel Then
                                        cmd.ExecuteNonQuery()

                                        Try
                                            RaiseEvent AfterRowSave(DetailGrid.Name, AddedRow)
                                        Catch ex As Exception

                                        End Try

                                    End If
                                    Try

                                        If InStr(DetailPKField.ToLower, "ldgrinvty") AndAlso DetailGrid.InventoryEnabled Then
                                            UpdateInventory(AddedRow("fk_invty_ldgrInvty", DataRowVersion.Current))
                                        End If
                                    Catch ex As Exception

                                    End Try

                                    cmd.Parameters.Clear()
                                Catch ex As Exception
                                    If UserName = "BACKDOOR" Then
                                        MsgBox("Added row!" & ex.StackTrace & ex.Message)
                                    End If

                                End Try



                            Next
                        End With
                    End Using
                End Using
            Else

            End If


            'DetailDataAdapter.Update(DetailGridData, "TableData")
            DetailGridData.Tables("TableData").AcceptChanges()

            DetailGridData.Tables("DisplayData").AcceptChanges()
            'DetailGrid.RefreshDataSource()


        Catch ex As Exception
            ' MsgBox("Saving Detail records unsuccessful!" & ex.StackTrace & ex.Message)
        End Try


    End Sub

    'HANDLE RECORD CHANGE IN FORM HEADER
    Private Sub ParentRecordChanged(ByVal NewRecordPK As String)
        Try
            'If GridReady Then

            If NewRecordPK = "0" Then NewRecordPK = Guid.Empty.ToString

            If Me.DetailGrid.InvokeRequired Then
                Me.DetailGrid.Invoke(New CrossThreadInvoker(AddressOf ParentRecordChanged), New Object() {NewRecordPK})
            Else
                DetailFKValue = NewRecordPK
                'DetailRecordsFilter = String.Format("{0} = '{1}' AND {2}.IsDeleted = 0", DetailFKField, DetailFKValue, DetailSourceTable)
                DetailRecordsFilter = IIf(Me.DetailGrid.WithFK, String.Format("{0} = '{1}'", DetailFKField, DetailFKValue, DetailSourceTable), "") 'IIf(DetailFKValue, (String.Format("{0} = '{1}' ", DetailFKField, DetailFKValue, DetailSourceTable)), "")



                If Not Me.DetailGridData Is Nothing Then
                    DetailGridData = Nothing
                End If
                DetailGridData = New DataSet

                Me.DetailGrid.DataSource = Nothing
                ' System.Threading.Thread.Sleep(50)

                LoadData()

            End If

            'Else
            'ClearOnReady = True
            ' End If

        Catch ex As Exception

        End Try
    End Sub

    'CREATE QUERIES
    Private Sub CreateSourceQuery()

        UPDATEROWSQL = "UPDATE " & DetailSourceTable
        INSERTROWSQL = "INSERT INTO " & DetailSourceTable
        DELETEROWSQL = "DELETE FROM " & DetailSourceTable
        DELETEALLROWSSQL = "DELETE FROM " & DetailSourceTable


        If Not Me.DetailColumns Is Nothing Then

            DetailPKField = (From Column As ColumnInfo In Me.DetailColumns
                             Where Column.Caption.ToLower = "syspk"
                             Select Column.FieldName).Single

            Dim TableSuffix As String = ""
            Try
                DetailFKField = (From Column As ColumnInfo In Me.DetailColumns
                                 Where Column.Caption.ToLower = "sysfk"
                                 Select Column.FieldName).Single
            Catch ex As Exception

            End Try

            TableSuffix = DetailPKField.Split("_")(UBound(DetailPKField.Split("_"))).ToLower


            Dim FieldNames = From Column As ColumnInfo In Me.DetailColumns
                             Select Column.FieldName

            '''''''''''''''''''''''''''''
            Dim InsertFields As String = ""
            Dim InsertValues As String = ""
            Dim UpdateValues As String = ""


            For Each FieldName As Object In FieldNames
                Dim Field As String = DirectCast(FieldName, String)
                DisplaySelectString &= Field + ","

                If Field.ToLower.Contains(TableSuffix) Then
                    TableSelectString &= Field + ","
                    InsertFields &= Field + ","
                    InsertValues &= "@" + Field + ","
                    UpdateValues &= Field + " = @" & Field + ","
                End If


            Next

            InsertFields = InsertFields.TrimEnd(",")
            InsertValues = InsertValues.TrimEnd(",")
            UpdateValues = UpdateValues.TrimEnd(",")

            'build insert and update queries
            INSERTROWSQL &= String.Format(" ({0}) VALUES ({1})", InsertFields, InsertValues)
            UPDATEROWSQL &= String.Format(" SET {0} WHERE {1} = @{1}", UpdateValues, DetailPKField)
            DELETEROWSQL &= String.Format(" WHERE {0} = @{0}", DetailPKField)
            DELETEALLROWSSQL &= String.Format(" WHERE {0} = @{0}", DetailFKField)

            DisplaySelectString = "SELECT " + DisplaySelectString.TrimEnd(",")
            '''''NEXT HERE
            Dim tmp() As String = Me.DetailGrid.TableFromInfo.Split("|")

            For i As Integer = 0 To UBound(tmp)
                If tmp(i) <> "" Then
                    With tmp(i).ToUpper
                        Select Case True
                            Case .Contains("FROM")
                                DisplayFromString = tmp(i).Trim
                            Case .Contains("WHERE")
                                DisplayWhereString = tmp(i).Trim
                            Case .Contains("ORDER BY")
                                DisplayOrderByString = tmp(i).Trim
                        End Select
                    End With
                End If
            Next

            TableSelectString = "SELECT " + TableSelectString.TrimEnd(",")
            TableFromString = "FROM " + DetailSourceTable

        End If
    End Sub

    Private Sub LoadData()
        Try
            PrepareDataAsync = New LoadDetailRecordsAsync(AddressOf Me.PrepareData)

            Dim cb As AsyncCallback = New AsyncCallback(AddressOf Me.DataReadyCallBack)
            Dim oState As Object
            PrepareDataAsync.BeginInvoke(cb, oState)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataReadyCallBack(ByVal ar As IAsyncResult)
        Try
            Dim OwnerForm As Form = Me.DetailGrid.FindForm
            If OwnerForm.InvokeRequired Then
                OwnerForm.Invoke(New BindDataDelegate(AddressOf Me.DataReadyCallBack), New Object() {ar})
            Else
                With Me.DetailGrid
                    .DataSource = DetailGridData
                    .DataMember = "DisplayData"
                    .RefreshDataSource()
                End With
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PrepareData()
        Try
            If DetailDataConnection Is Nothing Then
                DetailDataConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                DetailDataConnection.ConnectionString = AppData.ConnectionString
            End If
            'DISPLAY DATA
            Dim DisplayQuery As String = String.Format("{0} {1} {2} {3}", DisplaySelectString,
                                                       DisplayFromString,
                                                       IIf(DisplayWhereString <> "", DisplayWhereString & IIf(DetailRecordsFilter <> "", " AND " & DetailRecordsFilter, " "), IIf(DetailRecordsFilter <> "", "WHERE " & DetailRecordsFilter, "")),
                                                       DisplayOrderByString)

            Dim tmpDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
            With tmpDataAdapter
                .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandText = DisplayQuery.ToLower
                .SelectCommand.Connection = DetailDataConnection
            End With

            If DetailDataConnection.State <> System.Data.ConnectionState.Open Then _
                DetailDataConnection.Open()
            tmpDataAdapter.Fill(DetailGridData, "DisplayData")
            currentDataSourceQuery = DisplayQuery

            'TABLE DATA
            ' If Not IsNothing(DetailPKField) Then
            Dim TableDataQuery As String = String.Format("{0} {1} {2}",
                                                     TableSelectString,
                                                     TableFromString,
                                                     IIf(DetailRecordsFilter <> "", "WHERE " & DetailRecordsFilter, " "))

            DetailDataAdapter = Nothing
            DetailDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
            With DetailDataAdapter
                .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandText = TableDataQuery.ToLower
                .SelectCommand.Connection = DetailDataConnection
            End With

            If DetailDataConnection.State <> System.Data.ConnectionState.Open Then _
                DetailDataConnection.Open()


            DetailDataAdapter.Fill(DetailGridData, "TableData")

            With DetailGridData.Tables("TableData")
                .Columns(DetailPKField).Unique = True
                .PrimaryKey = New DataColumn() { .Columns(DetailPKField)}
                .AcceptChanges()
            End With

            'If parentFormState <> EditorState.AddMode Then
            DetailCommandBuilder = Nothing
            DetailCommandBuilder = New MySqlCommandBuilder() ''DBFactory.GetCommandBuilder(AppData.DBProvider)
            DetailCommandBuilder.DataAdapter = DetailDataAdapter

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            DetailDataConnection.Close()
        Finally
            DetailDataConnection.Close()
        End Try

    End Sub

    Private UPDATEROWSQL As String
    Private INSERTROWSQL As String
    Private DELETEROWSQL As String
    Private DELETEALLROWSSQL As String

    'LOAD GRID DEFAULT SETTINGS
    Private Sub SetDetailGridDefaults()
        Dim OwnerForm As Form = Me.DetailGrid.FindForm
        If OwnerForm.InvokeRequired Then
            OwnerForm.Invoke(New CrossThreadMethodInvokerDelegate(AddressOf Me.SetDetailGridDefaults), New Object())
        Else
            With DetailGridView
                With .OptionsView

                    .ColumnAutoWidth = True
                    .EnableAppearanceEvenRow = True 'False
                    .EnableAppearanceOddRow = True 'False
                    .ShowGroupPanel = False
                    .ShowColumnHeaders = True
                    .ShowFooter = False
                    .NewItemRowPosition = IIf(Me.DetailGrid.HideAddNewRowItem, NewItemRowPosition.None, NewItemRowPosition.Bottom)


                End With
                '.ColumnPanelRowHeight = 1
                .NewItemRowText = "click here to add a new item..."
                '.showbuttonmode
                With .OptionsMenu
                    .EnableColumnMenu = True
                    .EnableGroupPanelMenu = False
                    .EnableFooterMenu = False

                End With

                With .OptionsBehavior
                    If Me.DetailGrid.DisplayOnly Then
                        .Editable = False
                    Else
                        .Editable = True
                    End If

                    .EditorShowMode = DevExpress.Utils.EditorShowMode.Default

                End With

                .OptionsCustomization.AllowFilter = False
                .OptionsNavigation.AutoFocusNewRow = True
                .OptionsCustomization.AllowSort = False
                .FocusRectStyle = DrawFocusRectStyle.CellFocus
                With .OptionsSelection
                    .EnableAppearanceFocusedCell = True
                    .EnableAppearanceFocusedRow = True
                End With


                .IndicatorWidth = 30
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

    'EVENT HANDLERS
    Private Sub DetailGrid_ParentFormStateChanged(ByVal FormState As EditorState)
        If Me.DetailGrid.FindForm.InvokeRequired Then
            Me.DetailGrid.FindForm.Invoke(New CrossThreadInvoker(AddressOf Me.DetailGrid_ParentFormStateChanged), New Object() {FormState})
        Else
            With Me.DetailGridView.OptionsBehavior
                Select Case FormState
                    Case EditorState.AddMode
                        .Editable = True
                    Case EditorState.EditMode
                        If Not Me.DetailGrid.DisplayOnly Then
                            .Editable = True
                        Else
                            .Editable = False
                        End If
                    Case EditorState.ViewMode
                        .Editable = False
                End Select
            End With
        End If


    End Sub

    Private Sub DetailGrid_FocusedRowChanged(ByVal sender As System.Object, ByVal e As FocusedRowChangedEventArgs)

    End Sub

    Private pkField As String
    Private fkField As String

    Private Sub DetailGrid_InitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
        Try


            'Dim columns As Collection = DirectCast(view.GridControl, DetailGrid).GetColumns
            If Not IsNothing(Me.DetailColumns) Then

                For Each col As ColumnInfo In Me.DetailColumns
                    ' If Not IsEmptyString(col.DefaultValue) Then
                    Dim defval As String = col.DefaultValue.ToLower.Trim

                    If col.Caption.ToLower = "syspk" Then
                        pkField = col.FieldName
                        Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), GetSysPK)
                    ElseIf col.Caption.ToLower = "sysfk" Then
                        fkField = col.FieldName
                        Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), DetailFKValue)
                    End If

                    Select Case defval
                        Case "now"
                            Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), Date.Today.ToString("yyyy-MM-dd"))
                        Case "user"
                            Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), Project.Instance.ActiveUser.Name)
                        Case "seq"
                            Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), Me.DetailGrid.RowCount + 1) '
                        Case Else

                            'try check if defval is a control name
                            Dim tmpControl As BaseEdit = Nothing
                            If TypeOf (Me.DetailGrid.FindForm) Is EditorBase AndAlso defval <> "" Then
                                tmpControl = CType(Me.DetailGrid.FindForm, EditorBase).GetControl(defval)
                            End If
                            If Not IsNothing(tmpControl) Then
                                Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), tmpControl.EditValue)
                            Else
                                If Not (defval.Contains("val") Or defval.Contains("mul") Or defval.Contains("expr") _
                                Or defval.Contains("add") Or defval.Contains("sub") _
                                    Or defval.Contains("div") Or defval.Contains("syspk") Or defval.Contains("sysfk") Or defval = String.Empty) Then

                                    Me.DetailGridView.SetRowCellValue(e.RowHandle, Me.DetailGridView.Columns(col.FieldName), col.DefaultValue)
                                End If
                            End If
                    End Select
                Next
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DetailGrid_ProcessGridKey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim view As GridView = DirectCast(DirectCast(sender, DetailGrid).MainView, GridView)
            EnterKeyPressed = False
            Select Case True
                Case e.KeyCode = Keys.Up
                    view.MovePrev()
                    e.Handled = True

                Case e.KeyCode = Keys.Down
                    view.MoveNext()
                    e.Handled = True

                Case e.Control AndAlso e.KeyCode = Keys.Delete
                    If view.FocusedRowHandle >= 0 Then
                        view.DeleteRow(view.FocusedRowHandle)
                        e.Handled = True
                    End If

                    Try
                        Dim HeaderTotalField As String = (From col As ColumnInfo In Me.DetailColumns
                                                          Where col.OutputField.ToLower = "headertotal"
                                                          Select col.FieldName.ToLower).Single
                        With DirectCast(Me.DetailGrid.FindForm, EditorBase)
                            If Not IsNothing(.DetailTotalControl) Then
                                Dim tmpColumn As GridColumn = Me.DetailGridView.Columns(HeaderTotalField)
                                .DetailTotalControl.Text = tmpColumn.SummaryText
                            End If
                        End With


                    Catch ex As Exception

                    End Try

                    Try
                        Dim TotalField As String = (From col As ColumnInfo In Me.DetailColumns
                                                    Where col.OutputCtrl.ToLower <> String.Empty
                                                    Select col.OutputCtrl.ToLower).Single

                        Dim colField As String = (From col As ColumnInfo In Me.DetailColumns
                                                  Where col.OutputCtrl.ToLower <> String.Empty
                                                  Select col.FieldName.ToLower).Single

                        Dim tmpColumn As GridColumn = Me.DetailGridView.Columns(colField)

                        Dim ctrl = DirectCast(Me.DetailGrid.FindForm, EditorBase).GetControl(TotalField)
                        Select Case TypeName(ctrl)
                            Case "GridLookupEdit"
                                DirectCast(ctrl, GridLookupEdit).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                            Case "TextInput", "UserPKInput"
                                DirectCast(ctrl, TextInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                            Case "MemoInput"
                                DirectCast(ctrl, MemoInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                            Case "ComboBoxInput"
                                DirectCast(ctrl, ComboBoxInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                        End Select

                    Catch ex As Exception

                    End Try

                Case e.Control AndAlso e.KeyCode = Keys.Insert
                    With view
                        .AddNewRow()
                        .RefreshData()
                        .FocusedRowHandle = .GetRowHandle(.RowCount - 1)
                        .FocusedColumn = .VisibleColumns(0)
                    End With
                Case e.KeyCode = Keys.F11   'SQL query

                    Try
                        XtraMessageBox.Show(currentDataSourceQuery)
                        Clipboard.SetText(currentDataSourceQuery, TextDataFormat.Text)
                    Catch ex As Exception

                    End Try
                Case e.KeyCode = Keys.F10
                    XtraMessageBox.Show("==========[ Column Info ]==========" & vbCrLf &
                                        "Caption: " & view.FocusedColumn.Caption & vbCrLf &
                                        "Data Field: " & view.FocusedColumn.FieldName & vbCrLf &
                                        "Width: " & view.FocusedColumn.Width & vbCrLf
                                        )
                Case e.KeyCode = Keys.Enter
                    EnterKeyPressed = True
                Case e.KeyCode = Keys.F12   'SQL query

                    Try
                        Dim sd As New SaveFileDialog
                        sd.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
                        sd.FilterIndex = 1
                        sd.RestoreDirectory = True

                        If sd.ShowDialog() = DialogResult.OK Then
                            Me.DetailGrid.ExportToXls(sd.FileName)
                        End If
                    Catch ex As Exception

                    End Try

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DetailGrid_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            With DirectCast(sender, GridView)
                Try
                    If TypeOf (.ActiveEditor) Is GridLookupEdit Then
                        Dim FilterValue As Object
                        Dim FilterColumn As String

                        RaiseEvent FilterGridLookUp(.FocusedColumn.FieldName, FilterColumn, FilterValue)
                        ActiveFilterColumn = FilterColumn
                        Dim repEdit As RepositoryItemGridLookUpEdit = CType(.FocusedColumn.ColumnEdit, RepositoryItemGridLookUpEdit)
                        repEdit.View.ClearColumnsFilter()
                        repEdit.View.Columns(FilterColumn.ToLower).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo(ColumnFilterType.Value, FilterValue, Nothing, "")
                        repEdit.View.LayoutChanged()
                        repEdit.View.ApplyColumnsFilter()

                    End If
                Catch ex As Exception
                    ActiveFilterColumn = ""
                End Try

                Dim col As GridColumn = .FocusedColumn
                If .FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                    .AddNewRow()
                    .RefreshData()
                    .FocusedRowHandle = .GetRowHandle(.DataRowCount - 1)
                    .FocusedColumn = .VisibleColumns(0)

                End If

            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DetailGrid_HiddenEditor(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.DetailGridView.UpdateTotalSummary()
        With DirectCast(sender, GridView)
            Try
                If TypeOf (.ActiveEditor) Is GridLookupEdit Then

                    Dim repEdit As RepositoryItemGridLookUpEdit = CType(.FocusedColumn.ColumnEdit, RepositoryItemGridLookUpEdit)
                    repEdit.View.ClearColumnsFilter()

                End If
            Catch ex As Exception

            End Try
        End With


        Try
            Dim HeaderTotalField As String = (From col As ColumnInfo In Me.DetailColumns
                                              Where col.OutputField.ToLower = "headertotal"
                                              Select col.FieldName.ToLower).Single
            With DirectCast(Me.DetailGrid.FindForm, EditorBase)
                If Not IsNothing(.DetailTotalControl) Then
                    Dim tmpColumn As GridColumn = Me.DetailGridView.Columns(HeaderTotalField)
                    .DetailTotalControl.Text = tmpColumn.SummaryText
                End If
            End With


        Catch ex As Exception

        End Try

        Try
            Dim TotalField As String = (From col As ColumnInfo In Me.DetailColumns
                                        Where col.OutputCtrl.ToLower <> String.Empty
                                        Select col.OutputCtrl.ToLower).Single
            Dim colField As String = (From col As ColumnInfo In Me.DetailColumns
                                      Where col.OutputCtrl.ToLower <> String.Empty
                                      Select col.FieldName.ToLower).Single

            Dim tmpColumn As GridColumn = Me.DetailGridView.Columns(colField)

            Dim ctrl = DirectCast(Me.DetailGrid.FindForm, EditorBase).GetControl(TotalField)
            Select Case TypeName(ctrl)
                Case "GridLookupEdit"
                    DirectCast(ctrl, GridLookupEdit).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                Case "TextInput", "UserPKInput"
                    DirectCast(ctrl, TextInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                Case "MemoInput"
                    DirectCast(ctrl, MemoInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                Case "ComboBoxInput"
                    DirectCast(ctrl, ComboBoxInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
            End Select

        Catch ex As Exception

        End Try


        'code for displaying return values from grid lookup

        If Not IsNothing(ActiveLookUpEditColumns) AndAlso Not IsNothing(ActiveLookUpEditSeletedRow) Then
            Try
                'Dim columns As Collection = GetColumnInfo(CType(CType(Me.DetailGrid.FindForm, BaseForm).GetControl(CType(ActiveGridLookUpEdit.Tag, RepositoryItemGridLookUpEdit).Tag), GridPickListInfo)._PickColumnsInfo)

                Dim returnColumns = From Column As ColumnInfo In ActiveLookUpEditColumns
                                    Where Column.OutputField <> String.Empty
                                    Select Column

                'MsgBox("editvalue changd")

                With Me.DetailGridView
                    For Each returnColumn As ColumnInfo In returnColumns
                        'Debug.Print(SelectedRow(returnColumn.FieldName))
                        If IsDBNull(ActiveLookUpEditSeletedRow(returnColumn.FieldName)) Then
                            If .Columns(returnColumn.OutputField.ToLower).ColumnType.Name = "Decimal" Then
                                .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, 0)
                            Else

                                .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, "")
                            End If

                        Else
                            .SetRowCellValue(.FocusedRowHandle, returnColumn.OutputField.ToLower, ActiveLookUpEditSeletedRow(returnColumn.FieldName))
                        End If

                    Next

                End With
                ActiveLookUpEditColumns = Nothing
                ActiveLookUpEditSeletedRow = Nothing

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub DetailGrid_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs)

        Me.DetailGridView.UpdateCurrentRow()
        Try
            Dim CalcFields = (From column As ColumnInfo In Me.DetailColumns
                              Where column.DefaultValue <> String.Empty AndAlso
                             column.DefaultValue.ToLower.Contains(e.Column.FieldName.ToLower)
                              Select column)

            For Each CalcField As ColumnInfo In CalcFields
                Dim tmpString() As String = CalcField.DefaultValue.Split(":")
                Dim FuncName As String = tmpString(0)
                'Dim FieldNames() As String = tmpString(1).Split(",")
                Dim Expression As String = tmpString(1)
                Dim FieldNames() As String = GetFieldNamesFromExpression(Expression)

                Dim res As Double
                Select Case FuncName.ToLower
                    Case "val"
                        Me.DetailGridView.SetRowCellValue(e.RowHandle, CalcField.FieldName.ToLower, e.Value)
                    Case "sub"
                        If FieldNames.Length = 2 Then
                            res = 0
                            res = IIf(IsDBNull(StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(0).ToLower))), 0, StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(0).ToLower)))
                            res -= IIf(IsDBNull(StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(1).ToLower))), 0, StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(1).ToLower)))
                            Me.DetailGridView.SetRowCellValue(e.RowHandle, CalcField.FieldName.ToLower, res)
                        End If

                    Case "expr"
                        If FieldNames.Length > 0 Then
                            Dim ValuesCollection As New Collection
                            For i As Integer = 0 To UBound(FieldNames)
                                Dim fldName As String = FieldNames(i).ToLower
                                Dim val As Double = IIf(IsDBNull(StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, fldName))), 0, StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, fldName)))
                                If Not ValuesCollection.Contains(fldName) Then
                                    ValuesCollection.Add(val, fldName)
                                End If
                                'res *= IIf(IsDBNull(StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(i).ToLower))), 0, StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(i).ToLower)))
                            Next
                            Me.DetailGridView.SetRowCellValue(e.RowHandle, CalcField.FieldName.ToLower, ExpressionSolver(Expression, ValuesCollection))

                            Try
                                Dim HeaderTotalField As String = (From col As ColumnInfo In Me.DetailColumns
                                                                  Where col.OutputField.ToLower = "headertotal"
                                                                  Select col.FieldName.ToLower).Single
                                With DirectCast(Me.DetailGrid.FindForm, EditorBase)
                                    If Not IsNothing(.DetailTotalControl) Then
                                        Dim tmpColumn As GridColumn = Me.DetailGridView.Columns(HeaderTotalField)
                                        .DetailTotalControl.Text = tmpColumn.SummaryText
                                    End If
                                End With


                            Catch ex As Exception

                            End Try

                        End If
                    Case "mul"
                        If FieldNames.Length > 0 Then
                            res = 1
                            For i As Integer = 0 To UBound(FieldNames)
                                res *= IIf(IsDBNull(StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(i).ToLower))), 0, StrVal9(Me.DetailGridView.GetRowCellValue(e.RowHandle, FieldNames(i).ToLower)))
                            Next
                            Me.DetailGridView.SetRowCellValue(e.RowHandle, CalcField.FieldName.ToLower, res)
                        End If
                End Select
            Next
            Try
                Dim TotalField As String = ""
                Try
                    TotalField = (From column As ColumnInfo In Me.DetailColumns
                                  Where column.OutputCtrl.ToLower <> String.Empty AndAlso
                             column.FieldName.ToLower = e.Column.FieldName.ToLower
                                  Select column.OutputCtrl.ToLower).Single

                Catch ex As Exception

                End Try


                Dim colField As String = (From col As ColumnInfo In Me.DetailColumns
                                          Where col.OutputCtrl.ToLower <> String.Empty AndAlso
                              col.FieldName.ToLower = e.Column.FieldName.ToLower
                                          Select col.FieldName.ToLower).Single

                Dim tmpColumn As GridColumn = Me.DetailGridView.Columns(colField)

                Dim ctrl = DirectCast(Me.DetailGrid.FindForm, EditorBase).GetControl(TotalField)
                ' ctrl.editvalue = tmpColumn.SummaryText.Split(" ")(1)
                Select Case TypeName(ctrl)
                    Case "GridLookupEdit"
                        DirectCast(ctrl, GridLookupEdit).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                    Case "TextInput", "UserPKInput"
                        DirectCast(ctrl, TextInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                    Case "MemoInput"
                        DirectCast(ctrl, MemoInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                    Case "ComboBoxInput"
                        DirectCast(ctrl, ComboBoxInput).EditValue = tmpColumn.SummaryText.Split(" ")(1)
                End Select

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DetailGrid_RowCellClick(ByVal sender As Object, ByVal e As RowCellClickEventArgs)
        If Me.DetailGridView.OptionsBehavior.Editable = True Then
            Try

                If (e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle) AndAlso e.Clicks = 2 Then

                    With Me.DetailGridView
                        .AddNewRow()
                        '.RefreshData()
                        .FocusedRowHandle = .FocusedRowHandle '.GetRowHandle(.DataRowCount)
                        '.FocusedRowHandle = .GetRowHandle(.DataRowCount + 1)
                        .FocusedColumn = .VisibleColumns(1)
                    End With

                End If

                If e.RowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso e.Clicks = 2 Then
                    With CType(Me.DetailGrid.FindForm, EditorBase)
                        If Me.DetailPickLists.Count > 0 Then
                            Dim picklistName As String = (From column As ColumnInfo In DetailColumns
                                                          Where column.FieldName = e.Column.FieldName
                                                          Select column.CustProperty).Single

                            If picklistName.Contains(":") AndAlso picklistName.Split(":").Length > 1 Then
                                picklistName = picklistName.Split(":")(1)
                                Dim PickList As GridPickListInfo = DirectCast(Me.DetailPickLists(picklistName), GridPickListInfo)
                                If Not IsNothing(PickList) Then
                                    PickList.OwnerGrid = Me.DetailGrid
                                    PickList.ShowPickList()
                                End If
                            End If

                        End If
                    End With


                End If

            Catch ex As Exception

            End Try
        End If



    End Sub

    Private Function GetFieldNamesFromExpression(ByVal Expression As String) As String()
        Try
            Dim FieldName As String = ""
            Dim Fields As New Stack(Of String)
            'Fields.t()
            Dim startCapture As Boolean = False
            For i As Integer = Expression.Length - 1 To 0 Step -1
                Select Case Expression.Chars(i)
                    Case "]"
                        startCapture = True
                        FieldName = ""

                    Case "["
                        startCapture = False
                        Fields.Push(FieldName)
                    Case Else
                        If startCapture Then FieldName = Expression.Chars(i) + FieldName
                End Select
                Debug.Print(FieldName)
            Next

            Return Fields.ToArray
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function ExpressionSolver(ByVal expression As String, ByVal ValuesCollection As Collection) As Double
        Try
            Dim result As Double
            Dim Expr As New Stack(Of String)
            Dim ExprVars As New Queue(Of String)
            Dim cleanExpr As String = expression.Replace("[", "").Replace("]", "").Replace(" ", "")
            Dim FieldName As String = ""
            Dim valueStr As String = ""
            Dim Value As Double = 0

            For i As Integer = 0 To cleanExpr.Length - 1
                Select Case cleanExpr.Chars(i)
                    Case "("
                        Expr.Push(cleanExpr.Chars(i))
                        ExprVars.Enqueue(cleanExpr.Chars(i))
                        valueStr = ""
                        FieldName = ""
                    Case ")"
                        If FieldName <> "" Then
                            Value = StrVal9(ValuesCollection(FieldName.ToLower))
                            Expr.Push(Value.ToString)
                            ExprVars.Enqueue(Value.ToString)
                            Debug.Print(FieldName.ToLower + ":" + Value.ToString())
                            'Debug.Print(Value.ToString)
                        Else
                            If valueStr <> String.Empty Then
                                Expr.Push(valueStr)
                                ExprVars.Enqueue(valueStr)
                                Debug.Print(valueStr)
                            End If

                        End If

                        Expr.Push(cleanExpr.Chars(i))
                        ExprVars.Enqueue(cleanExpr.Chars(i))
                        valueStr = ""
                        FieldName = ""
                    Case "*", "/", "+", "-"
                        If FieldName <> "" Then
                            Value = StrVal9(ValuesCollection(FieldName.ToLower))
                            Expr.Push(Value.ToString)
                            ExprVars.Enqueue(Value.ToString)
                            Debug.Print(FieldName.ToLower + ":" + Value.ToString())
                            'Debug.Print(Value.ToString)
                        Else
                            If valueStr <> String.Empty Then
                                Expr.Push(valueStr)
                                ExprVars.Enqueue(valueStr)
                                Debug.Print(valueStr)
                            End If

                        End If

                        Expr.Push(cleanExpr.Chars(i))
                        ExprVars.Enqueue(cleanExpr.Chars(i))
                        valueStr = ""
                        FieldName = ""

                    Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                        valueStr &= cleanExpr.Chars(i)
                    Case "."
                        valueStr &= cleanExpr.Chars(i)
                    Case Else
                        FieldName &= cleanExpr.Chars(i)
                End Select
                Debug.Print(FieldName)
            Next


            Dim res As Double = 0
            Dim solverStack As New Stack(Of String)
            Dim solverQueue As New Queue(Of String)
            Dim tmpQueue As New Queue(Of String)
            Dim currVar As String = ""

            While ExprVars.Count > 0
                Select Case ExprVars.Peek
                    Case "("
                        currVar = ExprVars.Dequeue
                        If ExprVars.Peek = "(" Then
                            tmpQueue.Enqueue(currVar)
                        End If
                    Case ")"

                        ExprVars.Dequeue() 'remove closing ")"
                        tmpQueue.Enqueue(SolveCurrentFunction(solverQueue))
                        solverQueue.Clear()
                        If ExprVars.Count = 0 Then
                            res = StrVal9(tmpQueue.Dequeue)
                        Else
                            'append reamining parts of expression to temp
                            While ExprVars.Count > 0
                                tmpQueue.Enqueue(ExprVars.Dequeue)
                            End While

                            'return all items to exprvars to continue calculation

                            While tmpQueue.Count > 0
                                ExprVars.Enqueue(tmpQueue.Dequeue)
                            End While
                        End If

                    Case Else
                        solverQueue.Enqueue(ExprVars.Dequeue)

                End Select
            End While


            Return res 'StrVal9(ExprVars.Dequeue)
        Catch ex As Exception

        End Try
    End Function

    Private Function SolveCurrentFunction(ByVal ExprStack As Queue(Of String)) As Double
        Try
            Dim result As Double
            Dim lastOpr As String = ""

            While ExprStack.Count > 0
                Select Case True
                    Case IsNumeric(ExprStack.Peek)
                        If lastOpr = "" Then
                            result = StrVal9(ExprStack.Dequeue)
                        Else
                            Select Case lastOpr
                                Case "*"
                                    result *= StrVal9(ExprStack.Dequeue)
                                Case "/"
                                    result /= StrVal9(ExprStack.Dequeue)
                                Case "+"
                                    result += StrVal9(ExprStack.Dequeue)
                                Case "-"
                                    result -= StrVal9(ExprStack.Dequeue)
                            End Select
                            lastOpr = ""
                        End If
                    Case Else
                        lastOpr = ExprStack.Dequeue
                End Select
            End While
            Return result
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub repedit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.DetailGridView.PostEditor()
    End Sub

    Private Sub DetailGrid_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.DetailGridView.PostEditor()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub repositoryItemCheckEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.DetailGridView.PostEditor()
    End Sub

    Public Sub LoadMyData()


        Try
            'If GridReady Then

            'If NewRecordPK = "0" Then NewRecordPK = Guid.Empty.ToString

            If Me.DetailGrid.InvokeRequired Then
                Me.DetailGrid.Invoke(New CrossThreadInvoker(AddressOf LoadMyData), New Object())
            Else
                If Not Me.DetailGridData Is Nothing Then
                    DetailGridData = Nothing
                End If
                DetailGridData = New DataSet

                Me.DetailGrid.DataSource = Nothing

                LoadData()
            End If

        Catch ex As Exception

        End Try

    End Sub


    Protected Overridable Sub ButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
        RaiseEvent RepEditButtonItemClick(sender, e)
    End Sub
End Class
