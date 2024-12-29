
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports System.Data.Common
Imports System.Linq
Imports System.IO
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports DevExpress.XtraReports.UI
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraTab
Imports DevExpress.XtraEditors.Controls

Public Class EditorBase

    Public UsePKFilter As Boolean = True

    Protected Delegate Sub GetFormDataDelegate()
    Protected Delegate Sub AttachDetailWrappersDelegate()
    Protected Delegate Sub SetControlTextDelegate(ByVal Obj As Object, ByVal value As Object)
    Protected Delegate Sub CrossThreadMethodDelegate(ByVal val As Object)

    Public Event LoadSelectedRecord(ByVal RecordPK As String)
    Public Event LoadDetailRecords(ByVal RecordPK As String)
    Public Event DeleteDetailRecords()

    'Private Variables
    Protected Resaving As Boolean
    Protected _FormState As EditorState
    Private _ctrlOrigBackColor As Color
    Protected _CtrlCollection As Collection
    Private PKControlCollection As Collection
    Private FKControlCollection As Collection
    Private TableNames As Collection
    Private TableQueries As Collection
    Private DataAdapters As Collection
    Private CommandBuilders As Collection
    Private DetailGridWrappers As Collection
    Public ReportWrappers As Collection
    Private Connection As DbConnection
    Private GetFormDataAsync As GetFormDataDelegate
    Private SearchFilter As String
    Private FormData As DataSet
    Private IsSearching As Boolean = False
    Private PrimaryKey As String
    Private PrimaryTable As String
    Public SearchForm As SearchFormBase
    'Property Holders
    Private _SearchFormColumnDefinitionInfo As String
    Private _SearchFormTableFromInfo As String
    Private _PKControl As Control
    Private _ModuleControl As Control
    Private _ModuleTypeControl As Control
    Private _BranchControl As Control
    Private _UserPkControl As Control
    Private FirstLoad As Boolean = True
    Private _Reports As String
    Private _DetailTotalControl As BaseEdit

    'MainForm Navigation Storage
    Private MainNavigationData As DataSet
    Private MainNavigationColumnsInfo As Collection
    Private MainNavigationSQLQuery As String

    'xml settings
    Private FormSettings As XmlDocument
    Private XML_FILENAME = ""
    Private Const XML_ROOT = "FORM"
    Private Const XML_NODE_PREFIX = "SETTINGS"
    Private _XMLPath As String
    Private _AppPath As String
    Private _ExeName As String


    'Private DisplayRecordPK As Long

    'Events
    Public Event BeforeRecordAdd(ByRef Cancel As Boolean)
    Public Event BeforeRecordEdit(ByRef Cancel As Boolean)
    Public Event BeforeRecordSave(ByRef Cancel As Boolean)
    Public Event BeforeRecordDelete(ByRef Cancel As Boolean)
    Public Event BeforeRecordPreview(ByRef Cancel As Boolean)
    Public Event BeforeRecordPrint(ByRef Cancel As Boolean)

    Public Event AfterRecordAdd()
    Public Event AfterRecordEdit()
    Public Event AfterRecordSave()
    Public Event AfterRecordDelete()
    Public Event AfterRecordOpen()

    Public Event FormStateChanged(ByVal FormState As EditorState)
    Public Event FormInitComplete()

    'EVENT for MainForm Navigation
    Public Event MainNavigationAdditionalWhere(ByRef AdditionalWhere As String)

    Private LayoutFileName As String = String.Format("{0}{1}.xml", GetApplicationPath(), Me.Name)


    Public FormLoaded As Boolean = False ''hans
    Private pPKTableName As String
    Private pPKFieldName As String

    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))>
    Public Property AttachReports() As String
        Get
            Return _Reports
        End Get
        Set(ByVal value As String)
            _Reports = value
        End Set
    End Property

    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))>
    Public Property SearchFormColumnDefinitionInfo() As String
        Get
            Return GetLowerCaseString(_SearchFormColumnDefinitionInfo) 'IIf(IsNothing() OrElse String.IsNullOrEmpty(_SearchFormColumnDefinitionInfo), "", _SearchFormColumnDefinitionInfo.ToLower)
        End Get
        Set(ByVal value As String)
            _SearchFormColumnDefinitionInfo = value
        End Set
    End Property

    Public Property SearchFormTableFromInfo() As String
        Get
            Return GetLowerCaseString(_SearchFormTableFromInfo) 'IIf(IsNothing() OrElse String.IsNullOrEmpty(_SearchFormTableFromInfo), "", _SearchFormTableFromInfo.ToLower)
        End Get
        Set(ByVal value As String)
            _SearchFormTableFromInfo = value
        End Set
    End Property

    Public Property DetailTotalControl() As BaseEdit
        Get
            Return _DetailTotalControl
        End Get
        Set(ByVal value As BaseEdit)
            _DetailTotalControl = value
        End Set
    End Property

    Public ReadOnly Property FormState() As EditorState
        Get
            Return _FormState
        End Get
    End Property

    Public Property UserPKControl() As Control
        Get
            Return _UserPkControl
        End Get
        Set(ByVal value As Control)
            _UserPkControl = value
        End Set
    End Property

    Public Property PKControl() As Control
        Get
            Return _PKControl
        End Get
        Set(ByVal value As Control)
            _PKControl = value
        End Set
    End Property

    Public ReadOnly Property ModuleControl() As Control
        Get
            Return _ModuleControl
        End Get
    End Property

    Public ReadOnly Property ModuleTypeControl() As Control
        Get
            Return _ModuleTypeControl
        End Get
    End Property
    Public ReadOnly Property BranchNameControl() As Control
        Get
            Return _BranchControl
        End Get
    End Property
    Private IsGridOnly As Boolean = True

    <DefaultValue(False)>
    Public Property GridOnly()
        Get
            Return IsGridOnly
        End Get
        Set(ByVal value)
            IsGridOnly = value
        End Set
    End Property


    Private _IsFromDialog As Boolean = True
    <DefaultValue(False)>
    Public Property IsFromDialog() As Boolean
        Get
            Return _IsFromDialog
        End Get
        Set(ByVal value As Boolean)
            _IsFromDialog = value
        End Set
    End Property
    Private Sub SetMenuDisplay(Optional ByVal DisableEditingControls As Boolean = False)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CrossThreadMethodDelegate(AddressOf Me.SetMenuDisplay), New Object() {DisableEditingControls})
            Else

            End If

            'End If
            ' End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ProcessEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        _ctrlOrigBackColor = DirectCast(sender, Control).BackColor
        DirectCast(sender, Control).BackColor = Color.LemonChiffon
    End Sub

    Private Sub ProcessLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, Control).BackColor = _ctrlOrigBackColor
    End Sub

    Public Function GetControl(ByVal controlName As String) As Control
        Try
            Return _CtrlCollection(controlName.ToLower)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Protected Friend Sub LoadControlsToCollection(ByVal ctrlContainer As Control)

        For Each ctrl As Control In ctrlContainer.Controls
            Dim ctrlName As String = ctrl.Name
            If TypeOf ctrl Is TextInput Or
                TypeOf ctrl Is UserPKInput Or
                    TypeOf ctrl Is ComboBoxInput Or
                        TypeOf ctrl Is MemoInput Or
                            TypeOf ctrl Is GridLookupEdit Or
                                TypeOf ctrl Is DetailGrid Or
                                    TypeOf ctrl Is DateEdit Or
                                        TypeOf ctrl Is PictureEdit Or
                                            TypeOf ctrl Is GridPickListInfo Or
                                                TypeOf ctrl Is CheckEdit Or
                                                    TypeOf ctrl Is TimeEdit Then

                AddHandler ctrl.Enter, AddressOf ProcessEnter
                AddHandler ctrl.Leave, AddressOf ProcessLeave

                'add handler/load default events for selected controls
                Select Case True
                    Case TypeOf (ctrl) Is GridLookupEdit
                        With DirectCast(ctrl, GridLookupEdit)
                            'If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = True

                            .LoadData()
                            .Refresh()
                            AddHandler .EditValueChanged, AddressOf GridLookupEdit_EditValueChanged
                            AddHandler .Popup, AddressOf GridLookupEdit_Popup
                            AddHandler .KeyDown, AddressOf Me.GridLookUpKeyDown
                            'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                        End With

                    Case TypeOf (ctrl) Is ComboBoxInput
                        With DirectCast(ctrl, ComboBoxInput)
                            .LoadData()
                            'start
                            'If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = True
                            'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                            ''uncomment end test ctrl f2
                        End With
                    Case TypeOf (ctrl) Is DateEdit
                        With DirectCast(ctrl, DateEdit)
                            AddHandler .QueryPopUp, AddressOf DateEdit_QueryPopUp
                            ''start
                            'If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = True
                            'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                            ''uncomment end test ctrl f2
                        End With

                    Case TypeOf (ctrl) Is TimeEdit
                        ''start
                        'With DirectCast(ctrl, TimeEdit)
                        'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                        '    'AddHandler .QueryPopUp, AddressOf DateEdit_QueryPopUp
                        '    If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = True
                        'End With
                        'uncomment end test ctrl f2
                    Case TypeOf (ctrl) Is PictureEdit
                        With DirectCast(ctrl, PictureEdit)
                            'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                            .Properties.NullText = "Double click to add pic"
                            .Properties.ShowMenu = False
                            AddHandler .DoubleClick, AddressOf PictureEdit_DoubleClick
                        End With

                    Case TypeOf (ctrl) Is TextInput
                        ''start
                        'With DirectCast(ctrl, TextInput)
                        'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                        '    If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = True
                        'End With
                        'end ctrl f2 test
                    Case TypeOf (ctrl) Is UserPKInput
                        With DirectCast(ctrl, UserPKInput)
                            'If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = False
                        End With

                    Case TypeOf (ctrl) Is MemoInput
                        'With DirectCast(ctrl, MemoInput)
                        'AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress
                        '    If Not (.TableField <> "" AndAlso .TableName <> "") Then .TabStop = True
                        'End With
                End Select

                AddHandler ctrl.PreviewKeyDown, AddressOf PreviewKeyDown
                AddHandler ctrl.KeyDown, AddressOf ProcessTabKeyPress

                _CtrlCollection.Add(ctrl, ctrlName)
            Else
                'ctrl.TabStop = False
            End If

            If ctrl.HasChildren Then
                'ctrl.TabStop = False
                LoadControlsToCollection(ctrl)
            End If

        Next

    End Sub

    Private Sub GridLookUpKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.F5 Then
            CType(sender, GridLookupEdit).LoadData()
        End If
    End Sub

    Private Sub ProcessTabKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            'commented by ars 
            'processtabkeypress no longer used because the client requested that if they pressed enter key it will go to next line not next txtbox
            'so i commented below to enable na ctrl f2 without changing the clients request

            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
                Dim focusedCtrl As Control = CType(sender, Control)
                Dim AllowedFocus = From Ctrl As Object In Me._CtrlCollection
                                   Where Not (TypeOf (Ctrl) Is DetailGrid Or TypeOf (Ctrl) Is GridPickListInfo)
                                   Select Ctrl

                Dim nxtControl = (From nxtCtl As Object In AllowedFocus
                                  Where ((nxtCtl.Location.Y >= focusedCtrl.Location.Y AndAlso nxtCtl.Location.X > focusedCtrl.Location.X) Or (nxtCtl.Location.Y > focusedCtrl.Location.Y)) _
                                  AndAlso nxtCtl.TableField <> "" AndAlso nxtCtl.TableName <> "" AndAlso Not nxtCtl.TableField.Tolower.Contains("pk_") _
                                  AndAlso Not nxtCtl.TableField.Tolower.Contains("module") AndAlso Not nxtCtl.TableField.Tolower.Contains("userpk") _
                                  AndAlso nxtCtl.Visible = True AndAlso nxtCtl.Tag <> "1" AndAlso nxtCtl.enabled = True
                                  Order By nxtCtl.Location.Y, nxtCtl.Location.X
                                  Select nxtCtl).FirstOrDefault

                'Dim nxtControl = (From nxtCtl As Object In AllowedFocus _
                '                    Where nxtCtl.TableField <> "" AndAlso nxtCtl.TableName <> "" AndAlso Not nxtCtl.TableField.Tolower.Contains("syspk") _
                '                    AndAlso Not nxtCtl.TableField.Tolower.Contains("module") AndAlso Not nxtCtl.TableField.Tolower.Contains("userpk") _
                '                    AndAlso nxtCtl.Visible = True AndAlso nxtCtl.Tag <> "1" _
                '                    Order By nxtCtl.Location.Y, nxtCtl.Location.X _
                '                    Select nxtCtl)
                'Dim match As Boolean = False
                'Dim nxtctl2 As Control = Nothing
                'For Each ctl As Object In nxtControl
                '    If match Then
                '        nxtctl2 = CType(ctl, Control)
                '        Exit For
                '    End If
                '    If focusedCtrl.Name = CType(ctl, Control).Name Then
                '        match = True
                '    End If
                'Next


                If Not IsNothing(nxtControl) Then
                    nxtControl.Focus()
                Else
                    FocusFirstControl()
                End If
            End If

            If e.KeyCode = Keys.Delete AndAlso TypeOf (sender) Is GridLookupEdit Then
                CType(sender, GridLookupEdit).EditValue = Nothing
            End If
            'End If

            If e.Control AndAlso e.KeyCode = Keys.F2 AndAlso
                TypeOf (sender) Is BaseEdit AndAlso
                    Project.Instance.ActiveUser.Name = "BACKDOOR" Then

                Select Case True
                    Case TypeOf (sender) Is GridLookupEdit
                        With DirectCast(sender, GridLookupEdit)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                   "Table Name: " & .TableName,
                                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")

                        End With

                    Case TypeOf (sender) Is ComboBoxInput
                        With DirectCast(sender, ComboBoxInput)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                   "Table Name: " & .TableName,
                                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With
                    Case TypeOf (sender) Is DateEdit
                        With DirectCast(sender, DateEdit)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                    "Table Name: " & .TableName,
                                    MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With

                    Case TypeOf (sender) Is TimeEdit
                        With DirectCast(sender, TimeEdit)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                    "Table Name: " & .TableName,
                                    MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With

                    Case TypeOf (sender) Is PictureEdit
                        With DirectCast(sender, PictureEdit)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                   "Table Name: " & .TableName,
                                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With

                    Case TypeOf (sender) Is TextInput
                        With DirectCast(sender, TextInput)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                    "Table Name: " & .TableName,
                                    MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With
                    Case TypeOf (sender) Is UserPKInput
                        With DirectCast(sender, UserPKInput)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                   "Table Name: " & .TableName,
                                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With
                    Case TypeOf (sender) Is MemoInput
                        With DirectCast(sender, MemoInput)
                            MsgBox("Field Name: " & .TableField & vbCrLf &
                                   "Table Name: " & .TableName,
                                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FIELD INFO")
                        End With
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FocusFirstControl()

        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CrossAppDomainDelegate(AddressOf Me.FocusFirstControl), New Object() {})
            Else
                Dim AllowedFocus = From Ctrl As Object In Me._CtrlCollection
                                   Where Not (TypeOf (Ctrl) Is DetailGrid Or TypeOf (Ctrl) Is GridPickListInfo)
                                   Select Ctrl

                Dim firstCtrl = (From Ctrl As Object In AllowedFocus
                                 Where Ctrl.TableField <> "" AndAlso Ctrl.TableName <> "" AndAlso Not Ctrl.TableField.Contains("sys") _
                                 AndAlso Not Ctrl.TableField.Contains("module") AndAlso Not Ctrl.TableField.Contains("userpk") _
                                 AndAlso Ctrl.Visible = True AndAlso Ctrl.Tag <> "1"
                                 Order By Ctrl.Location.Y, Ctrl.Location.X
                                 Select Ctrl).FirstOrDefault

                firstCtrl.focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFormData()
        Try

            BuildFormSource()

            If FirstLoad Then
                FirstLoad = False
                Me.DefaultBehavior()
                RaiseEvent FormInitComplete()

            End If

            If IsSearching Then
                ClearInputs()
                DisplayData()
                EnableInputs(False)
                IsSearching = False
                SearchFilter = ""
                RaiseEvent AfterRecordOpen()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataReadyCallBack(ByVal ar As IAsyncResult)

    End Sub

    Private Sub AttachDetailWrappers()
        Dim DetailControls = From myChildControl As Object In Me._CtrlCollection
                             Where TypeOf (myChildControl) Is DetailGrid
                             Select myChildControl


        For Each DetailControl As Object In DetailControls
            Dim gridWrapper As DetailGridWrapper = New DetailGridWrapper(DirectCast(DetailControl, DetailGrid))
            AddHandler gridWrapper.FilterGridLookUp, AddressOf FilterGridLookUp
            AddHandler gridWrapper.FilterPickListBeforeShow, AddressOf Me.FilterPickList
            AddHandler gridWrapper.AfterPickListReturnValues, AddressOf AfterPickListReturnValues
            AddHandler gridWrapper.AfterRowSave, AddressOf AfterRowSave
            AddHandler gridWrapper.AfterRowDelete, AddressOf AfterRowDelete
            AddHandler gridWrapper.RepEditButtonItemClick, AddressOf RepItemButtonClick
            DetailGridWrappers.Add(gridWrapper, DetailControl.Name)

        Next

    End Sub

    Protected Overridable Sub RepItemButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)

    End Sub

    Protected Overridable Sub AfterPickListReturnValues(ByVal GridName As String)

    End Sub
    Protected Overridable Sub BeforeRowSave(ByVal GridName As String, ByVal dtRow As DataRow)

    End Sub
    Protected Overridable Sub AfterRowSave(ByVal GridName As String, ByVal dtRow As DataRow)

    End Sub
    Protected Overridable Sub AfterRowDelete(ByVal GridName As String, ByVal dtRow As DataRow)

    End Sub

    Protected Overridable Sub FilterGridLookUp(ByVal FieldName As String, ByRef FilterColumn As String, ByRef FilterValue As Object)

    End Sub

    Protected Overridable Sub FilterPickList(ByVal DetailGridName As String, ByRef FieldName As String, ByRef FilterValue As Object)

    End Sub

    Protected Overridable Sub AddWhereUserPK(ByVal Criteria As String)

    End Sub

    Private Sub CallBack(ByVal ar As IAsyncResult)
        If FirstLoad Then
            FirstLoad = False
            Me.DefaultBehavior()
            RaiseEvent FormInitComplete()
        End If

        If IsSearching Then
            ClearInputs()
            DisplayData()
            EnableInputs(False)
            IsSearching = False
            SearchFilter = ""
            RaiseEvent AfterRecordOpen()
        End If
    End Sub

    Public Overridable Sub DefaultBehavior()
        Me.ViewMode()
    End Sub

    Private Sub BuildFormSource()
        Try
            If TableQueries Is Nothing Then
                Try

                    ListTableNames()

                    TableQueries = New Collection
                    PKControlCollection = New Collection

                    FKControlCollection = New Collection


                    If TableNames.Count > 0 Then
                        For Each TableName As String In TableNames
                            Dim selectSql As String = ""
                            Dim tbName As String = TableName
                            Dim myChildTextBoxes = From myChildControl As Object In Me._CtrlCollection
                                                   Where (Not TypeOf (myChildControl) Is DetailGrid AndAlso
                                   Not TypeOf (myChildControl) Is GridPickListInfo AndAlso
                                   myChildControl.Tablename = tbName AndAlso
                                   myChildControl.TableField <> "")
                                                   Select myChildControl

                            Dim PKSuffix As String = DirectCast(Me.PKControl, TextInput).TableField.Split("_")(1)
                            For Each myChildTextBox As Object In myChildTextBoxes
                                Dim FieldName As String = myChildTextBox.TableField
                                Dim dummyCollection As New Collection

                                If (FieldName.Contains("pk_") And Not FieldName.Contains("userpk_")) AndAlso TypeOf (myChildTextBox) Is TextInput Then PKControlCollection.Add(myChildTextBox, tbName)
                                If FieldName.Contains("fk_") AndAlso FieldName.Contains(PKSuffix) AndAlso tbName <> DirectCast(Me.PKControl, TextInput).TableName AndAlso TypeOf (myChildTextBox) Is TextInput Then _
                                    FKControlCollection.Add(myChildTextBox, tbName)

                                If Not dummyCollection.Contains(FieldName) Then
                                    selectSql &= FieldName & ","
                                    dummyCollection.Add(FieldName, FieldName)
                                End If

                            Next

                            If IsSearching AndAlso AppData.DBProvider = DataProviderType.OleDb Then
                                selectSql = String.Format("SELECT TOP 1 {0} FROM {1}", selectSql.TrimEnd(","), tbName)
                            Else
                                selectSql = String.Format("SELECT {0} FROM {1}", selectSql.TrimEnd(","), tbName)

                            End If

                            TableQueries.Add(selectSql, tbName)
                        Next

                    End If
                Catch ex As Exception

                End Try
            End If

            If Not FormData Is Nothing Then FormData = Nothing
            If Not DataAdapters Is Nothing Then FormData = Nothing
            If Not CommandBuilders Is Nothing Then CommandBuilders = Nothing

            FormData = New DataSet
            DataAdapters = New Collection
            CommandBuilders = New Collection

            System.Threading.Thread.Sleep(50)
            If Connection Is Nothing Then
                Connection = New MySqlConnection ''DBFactory.GetConnection(AppData.DBProvider)
                Connection.ConnectionString = AppData.ConnectionString
            End If

            For Each tableName As String In TableNames
                Try
                    Dim Adapter As DbDataAdapter
                    Dim CommandBuilder As DbCommandBuilder

                    If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()

                    Adapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
                    Adapter.SelectCommand = New MySqlCommand()  ''DBFactory.GetCommand(AppData.DBProvider)
                    Adapter.SelectCommand.CommandType = CommandType.Text

                    Dim query As String = DirectCast(TableQueries(tableName), String)

                    Dim modWhere As String = ""
                    If tableName = DirectCast(Me.PKControl, TextInput).TableName Then
                        With DirectCast(Me.ModuleControl, TextInput)
                            If .TableField <> "" AndAlso .Text <> "" Then
                                modWhere &= String.Format("{0} = {1}", .TableField, AddQuote9(.Text))
                            End If
                        End With


                    End If
                    If modWhere <> "" Then modWhere = " WHERE " & modWhere


                    If Not IsSearching Then
                        If AppData.DBProvider = DataProviderType.Mysql Then '
                            'query = String.Format("{0}{1} ", query, IIf(modWhere <> "", modWhere, ""))
                            query = String.Format("{0}{1} LIMIT 1 ", query, IIf(modWhere <> "", modWhere, ""))
                        Else
                            query = String.Format("{0}{1}", query, IIf(modWhere <> "", modWhere, ""))
                        End If

                    Else
                        Dim addQuery As String
                        If DirectCast(Me.PKControl, TextInput).TableName = tableName Then
                            addQuery = DirectCast(Me.PKControl, TextInput).TableField & " = " & AddQuote9(SearchFilter)
                        Else
                            addQuery = DirectCast(FKControlCollection(tableName), TextInput).TableField & " = " & AddQuote9(SearchFilter)
                        End If

                        query = String.Format("{0}{1}{2}", query,
                                              IIf(modWhere <> "", modWhere, ""),
                                              IIf(modWhere <> "", " AND " & addQuery, " WHERE " & addQuery))

                    End If

                    Debug.Print(query)




                    Adapter.SelectCommand.CommandText = query
                    Adapter.SelectCommand.CommandTimeout = 5000
                    Adapter.SelectCommand.Connection = Connection

                    CommandBuilder = New MySqlCommandBuilder() ''DBFactory.GetCommandBuilder(AppData.DBProvider)
                    CommandBuilder.DataAdapter = Adapter

                    Adapter.Fill(FormData, tableName)

                    DataAdapters.Add(Adapter, tableName)
                    CommandBuilders.Add(CommandBuilder, tableName)


                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    'If Not IsNothing(Connection) AndAlso
                    '    Connection.State <> System.Data.ConnectionState.Closed Then _
                    '        Connection.Close()
                End Try
            Next
        Catch ex As Exception
        End Try


    End Sub

    Private Sub GridLookupEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim popup As DevExpress.Utils.Win.IPopupControl = DirectCast(sender, DevExpress.Utils.Win.IPopupControl)
            Dim popupForm As DevExpress.XtraEditors.Popup.PopupGridLookUpEditForm = DirectCast(popup.PopupWindow, DevExpress.XtraEditors.Popup.PopupGridLookUpEditForm)
            popupForm.Width = DirectCast(sender, Control).FindForm.Width - DirectCast(sender, Control).Left
            'set default focus
            Dim popupGrid As GridLookupEdit = CType(sender, GridLookupEdit)
            With popupGrid.Properties.View
                .FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
                .FocusedColumn = .Columns(popupGrid.DisplayField)
            End With
        Catch ex As Exception

        End Try


    End Sub

    Private Sub GridLookupEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim tmpInput As GridLookupEdit = CType(sender, GridLookupEdit)
            Dim cols As Collection = tmpInput.GetColumns
            Dim row As DataRowView = tmpInput.GetSelectedDataRow
            Dim tmpField As String
            If Not IsNothing(row) Then
                For Each col As ColumnInfo In cols
                    If col.OutputCtrl <> "" Then
                        tmpField = col.FieldName '.ToLower.Split(" ")(2)
                        If tmpField.Contains(" as ") Then
                            tmpField = tmpField.Substring(tmpField.IndexOf(" as ") + 4).Trim
                        End If
                        Dim ctrl = DirectCast(Me.FindForm, EditorBase).GetControl(col.OutputCtrl)
                        Select Case TypeName(ctrl)
                            Case "DateEdit"
                                DirectCast(ctrl, DateEdit).EditValue = row(tmpField)
                            Case "GridLookupEdit"
                                DirectCast(ctrl, GridLookupEdit).EditValue = row(tmpField)
                            Case "TextInput", "UserPKInput"
                                DirectCast(ctrl, TextInput).EditValue = row(tmpField)
                            Case "MemoInput"
                                DirectCast(ctrl, MemoInput).EditValue = row(tmpField)
                            Case "ComboBoxInput"
                                DirectCast(ctrl, ComboBoxInput).EditValue = row(tmpField)
                        End Select
                        ' ctrl.EditValue = row(col.FieldName.ToLower)
                    End If
                Next
            End If
            'End If



            'Dim value As Object = row(tmpInput.ValueMember)
            'MsgBox(tmpInput.EditValue)
        Catch ex As Exception

        End Try


    End Sub

    Public Sub PictureEdit_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.FormState = EditorState.AddMode Or Me.FormState = EditorState.EditMode Then
            Dim fileName As String = ShowOpenFileDialog("Load Picture", "", "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg|All Files|*.*")

            If File.Exists(fileName) Then
                AutosizeImage(fileName, CType(sender, PictureEdit))
            End If
        End If

    End Sub

    Private Sub DisplayData()

        Try

            If TableNames.Count > 0 Then
                For Each TableName As String In TableNames
                    Dim tbName As String = TableName
                    Dim myChildTextBoxes = From myChildControl As Object In Me._CtrlCollection
                                           Where (Not TypeOf (myChildControl) Is DetailGrid AndAlso
                                                  Not TypeOf (myChildControl) Is GridPickListInfo AndAlso
                                                  myChildControl.TableField <> "" AndAlso
                                                  myChildControl.Tablename = tbName)
                                           Select myChildControl

                    If Not IsNothing(FormData.Tables(tbName)) AndAlso FormData.Tables(tbName).Rows.Count > 0 Then
                        With FormData.Tables(tbName).Rows(0)
                            For Each myChildTextBox As Object In myChildTextBoxes
                                Dim FieldValue As Object = .Item(DirectCast(myChildTextBox.TableField, String))
                                If IsDBNull(FieldValue) OrElse FieldValue.ToString = String.Empty Then
                                    FieldValue = Nothing
                                End If
                                If TypeOf (myChildTextBox) Is DateEdit Then
                                    'Dim ctrl As DateEdit = 
                                    If Not FieldValue Is Nothing Then
                                        FieldValue = DateValue(FieldValue).ToString("d")
                                    End If
                                    Me.Invoke(New SetControlTextDelegate(AddressOf SetControlEditValue), New Object() {myChildTextBox, FieldValue})
                                    'myChildTextBox.EditValue = DateValue(.Item(DirectCast(myChildTextBox.TableField, String))).ToString("d")
                                ElseIf TypeOf (myChildTextBox) Is TimeEdit Then
                                    'Dim ctrl As DateEdit = 
                                    If Not FieldValue Is Nothing Then
                                        FieldValue = TimeValue(FieldValue).ToString("t")
                                    End If
                                    Me.Invoke(New SetControlTextDelegate(AddressOf SetControlEditValue), New Object() {myChildTextBox, FieldValue})
                                ElseIf TypeOf (myChildTextBox) Is GridLookupEdit Then
                                    If Not FieldValue Is Nothing Then
                                        FieldValue = (FieldValue)
                                    End If
                                    'myChildTextBox.EditValue = CLng(.Item(DirectCast(myChildTextBox.TableField, String)))
                                    Me.Invoke(New SetControlTextDelegate(AddressOf SetControlEditValue), New Object() {myChildTextBox, FieldValue})
                                ElseIf TypeOf (myChildTextBox) Is PictureEdit Then
                                    ' Dim picEdit As PictureEdit = CType(myChildTextBox, PictureEdit)

                                    If Not FieldValue Is Nothing Then
                                        Dim picdata() As Byte = FieldValue
                                        Using ms As New MemoryStream(picdata)
                                            'picEdit.EditValue = Image.FromStream(ms)
                                            FieldValue = Image.FromStream(ms)
                                            ' Me.Invoke(New SetControlTextDelegate(AddressOf SetControlEditValue), New Object() {picEdit, Image.FromStream(ms)})
                                        End Using
                                    End If
                                    Me.Invoke(New SetControlTextDelegate(AddressOf SetControlEditValue), New Object() {myChildTextBox, FieldValue})
                                Else
                                    Me.Invoke(New SetControlTextDelegate(AddressOf SetControlEditValue), New Object() {myChildTextBox, FieldValue})
                                End If
                            Next
                        End With
                    End If

                Next

            End If
            Me._FormState = EditorState.ViewMode
            lblMode.Text = "VIEW MODE"
            SetMenuDisplay()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListTableNames()
        TableNames = New Collection

        Dim myChildTextBoxes = (From myChildControl As Object In Me._CtrlCollection
                                Where (Not TypeOf (myChildControl) Is DetailGrid AndAlso
                                       Not TypeOf (myChildControl) Is GridPickListInfo AndAlso
                                       myChildControl.Tablename <> "")
                                Select myChildControl.Tablename).Distinct()
        'Loop through my TextBoxes.
        For Each myChildTextBox As Object In myChildTextBoxes
            'Clear the TextBox.
            Dim tbName As String = CType(myChildTextBox, String)
            If Not TableNames.Contains(tbName) Then TableNames.Add(tbName, tbName)
        Next
    End Sub

    Private Sub EnableInputs(ByVal blnenable As Boolean)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CrossThreadMethodDelegate(AddressOf Me.EnableInputs), New Object() {blnenable})
            Else
                'Retrieve all textbox controls using LINQ
                Dim myChildTextBoxes = From myChildControl As Object In Me._CtrlCollection
                                       Where (Not TypeOf (myChildControl) Is DetailGrid AndAlso
                                              Not TypeOf (myChildControl) Is GridPickListInfo AndAlso
                                              Not (TypeOf myChildControl Is UserPKInput AndAlso myChildControl.UserPKType = UserPkTypeEnum.System) AndAlso
                                              myChildControl.Tag <> "1" AndAlso myChildControl.TableField <> "" AndAlso
                                              myChildControl.enabled = True)
                                       Select myChildControl

                'Loop through my TextBoxes.
                For Each myChildTextBox As Object In myChildTextBoxes
                    'Clear the TextBox.
                    If Me.InvokeRequired Then
                        Me.Invoke(New SetControlTextDelegate(AddressOf Me.LockInput), New Object() {myChildTextBox, Not blnenable})
                    Else
                        myChildTextBox.Properties.ReadOnly = Not blnenable
                    End If

                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DateEdit_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Me.FormState <> EditorState.AddMode AndAlso Me.FormState <> EditorState.EditMode Then
            e.Cancel = True
        End If
    End Sub

    Public Sub LockInput(ByVal objControl As Object, ByVal LockValue As Boolean)
        objControl.Properties.ReadOnly = LockValue
        If LockValue Then
            'objControl.Appearance
        End If
    End Sub

    Private Sub ClearInputs()
        'On Error Resume Next
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CrossThreadMethodInvokerDelegate(AddressOf Me.ClearInputs), New Object())
            Else
                Dim myChildTextBoxes = From myChildControl As Object In Me._CtrlCollection
                                       Where (Not TypeOf (myChildControl) Is DetailGrid AndAlso
                                              Not TypeOf (myChildControl) Is GridPickListInfo AndAlso
                                              myChildControl.Tag <> "1")
                                       Select myChildControl


                For Each myChildTextBox As Object In myChildTextBoxes
                    If Me.InvokeRequired Then
                        Me.Invoke(New SetControlTextDelegate(AddressOf Me.SetControlEditValue), New Object() {myChildTextBox, Nothing})
                    Else
                        If TypeOf (myChildTextBox) Is CheckEdit Then
                            DirectCast(myChildTextBox, CheckEdit).CheckState = CheckState.Unchecked
                        Else
                            myChildTextBox.EditValue = Nothing
                        End If

                    End If

                Next
            End If
        Catch ex As Exception

        End Try


    End Sub

    Protected Overridable Sub NewRecordSelected(ByVal RecordPK As String)
        Try

            IsSearching = True
            SearchFilter = RecordPK
            LoadFormData()
            'Me._FormState = EditorState.ViewMode
            RaiseEvent LoadDetailRecords(RecordPK)
        Catch ex As Exception

        End Try
    End Sub

    '++===============================================================++'
    '||                     Attach Report Format                      ||'
    '++===============================================================++'
    '|| |Key	|Report Caption		|Report Name		              ||'
    '|| @	    |Sample Report	    |rpt1   		                  ||'
    '||                                                               ||'
    '++===============================================================++'


    Protected Overridable Sub Report_AdditionalWhere(ByRef AdditionalWhere As String) ''enhanced
        If UsePKFilter Then
            With DirectCast(Me.PKControl, TextInput)
                AdditionalWhere &= .TableName & "." & .TableField & " = " & AddQuote9(.EditValue.ToString)
            End With
        Else
            AdditionalWhere = String.Format("FK_CSession_TransH = '{0}'", Project.Instance.SessionId)
        End If
    End Sub

    Protected Overridable Sub OverridePreviewReport(ByRef ReportName As String)

    End Sub

    Private Sub BuildReportMenu()
        Try
            'BarManager1.ForceInitialize()

            Me.Preview.ClearLinks()
            Me.Print.ClearLinks()

            If Not IsEmptyString(Me.AttachReports) AndAlso Me.AttachReports.Split("@").Length > 1 Then

                Dim tmpMenu() As String = Me.AttachReports.Split("@")
                Dim rptCaption As String, rptClass As String

                For i As Integer = 1 To UBound(tmpMenu)

                    rptCaption = tmpMenu(i).Split("|")(1).TrimEnd(ChrW(Keys.Tab))
                    rptClass = tmpMenu(i).Split("|")(2).TrimEnd(ChrW(Keys.Tab))

                    Dim rptObj As ReportBase = CreateObject(rptClass.Trim)
                    Dim rptWrapper As New ReportWrapper(rptObj, rptCaption, ReportWrapper.ReportOwnerTypeEnum.TransactionForm)
                    AddHandler rptWrapper.AdditionalWhere, AddressOf Me.Report_AdditionalWhere
                    ReportWrappers.Add(rptWrapper, rptCaption)

                    Dim PreviewItem As New BarButtonItem(Me.BarManager1, rptCaption) With {.AccessibleName = "Preview"}
                    Preview.AddItem(PreviewItem)
                    AddHandler PreviewItem.ItemClick, AddressOf ReportMenuItemClick

                    Dim PrintItem As New BarButtonItem(Me.BarManager1, rptCaption) With {.AccessibleName = "Print"}
                    Print.AddItem(PrintItem)
                    AddHandler PrintItem.ItemClick, AddressOf ReportMenuItemClick

                Next
            Else
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReportMenuItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            Dim selMenu As String = e.Item.AccessibleName.ToString
            Dim selItem As String = e.Item.Caption
            Dim SelectedReport As ReportWrapper = DirectCast(ReportWrappers(selItem), ReportWrapper)

            If selMenu.ToLower = "preview" Then
                If Project.Instance.ActiveUser.Name = "BACKDOOR" OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can PrintPreview") OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can Print") Then
                    SelectedReport.PreviewReport()
                Else
                    XtraMessageBox.Show("You are not allowed to use this function, Contact system admin...", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                If Project.Instance.ActiveUser.Name = "BACKDOOR" OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can Print") Then
                    SelectedReport.PrintReport()
                Else
                    XtraMessageBox.Show("You are not allowed to use this function, Contact system admin...", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception

        End Try


        'XtraMessageBox.Show(selMenuItem.AccessibleName + " " + selMenuItem.Caption, "selected menu item", MessageBoxButtons.OKCancel)

        'add code to handle report loading
    End Sub

    Private Function GetSoftDeleteWhere(ByVal queryFrom As String) As String
        Dim SoftDeleteAddWhere As String = ""
        Try

            Dim tables() As String = queryFrom.ToLower.Split("|").Where(Function(s) s.Contains("from")).FirstOrDefault.Replace("(", "").Replace(")", "").Split(" ")
            Dim prevIsTablename As String = ""
            Dim addTBName As String = ""
            For i As Integer = 1 To UBound(tables)


                With tables(i)
                    If .Contains("_") AndAlso Not tables(i).Contains(".") Then
                        If i > 0 Then
                            If tables(i + 1) <> "=" AndAlso tables(i - 1) <> "=" Then
                                prevIsTablename = tables(i)
                                'If (i + 1) OrElse i = UBound(tables) Then
                                '    addTBName = prevIsTablename
                                'End If
                            End If
                        End If

                    Else

                        If .ToLower = "right" OrElse .ToLower = "left" OrElse .ToLower = "inner" OrElse .ToLower = "" Then
                            If prevIsTablename <> "" Then
                                addTBName = prevIsTablename
                            End If
                        Else
                            If prevIsTablename <> "" AndAlso tables(i).ToLower <> "on" Then addTBName = tables(i)
                        End If
                        prevIsTablename = ""
                    End If
                    If addTBName <> "" Then
                        If SoftDeleteAddWhere = "" Then
                            SoftDeleteAddWhere = String.Format(" ({0}.IsDeleted = 0 OR {0}.IsDeleted IS NULL) ", addTBName)
                        Else
                            If Not SoftDeleteAddWhere.Contains(String.Format(" AND ({0}.IsDeleted = 0 OR {0}.IsDeleted IS NULL) ", addTBName)) Then
                                SoftDeleteAddWhere &= String.Format(" AND ({0}.IsDeleted = 0 OR {0}.IsDeleted IS NULL) ", addTBName)
                            End If

                        End If
                        addTBName = ""
                    End If

                End With



                'If tables(i).Contains("_") AndAlso Not tables(i).Contains(".") Then
                '    If i + 1 <= UBound(tables) Then
                '        Dim tbName As String
                '        If (tables(i + 1).ToLower = "right" OrElse tables(i + 1).ToLower = "left" OrElse tables(i + 1).ToLower = "inner" OrElse tables(i + 1).ToLower = "on") AndAlso tables(i - 1).ToLower <> "=" Then
                '            tbName = tables(i)
                '        Else
                '            If tables(i - 1).ToLower = "from" Then
                '                tbName = tables(i)
                '            Else
                '                If tables(i - 1).ToLower = "join" Then tbName = tables(i + 1)
                '            End If

                '        End If
                '        If SoftDeleteAddWhere = "" Then
                '            SoftDeleteAddWhere = String.Format(" ({0}.IsDeleted = 0 OR {0}.IsDeleted IS NULL) ", tbName)
                '        Else
                '            If Not SoftDeleteAddWhere.Contains(String.Format(" AND ({0}.IsDeleted = 0 OR {0}.IsDeleted IS NULL) ", tbName)) Then
                '                SoftDeleteAddWhere &= String.Format(" AND ({0}.IsDeleted = 0 OR {0}.IsDeleted IS NULL) ", tbName)
                '            End If

                '        End If
                '    End If

                'End If
            Next
        Catch ex As Exception

        End Try

        Return SoftDeleteAddWhere
    End Function

    Private Sub BuildNavigationData()
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

        Using Connection As DbConnection = DBFactory.GetConnection(AppData.DBProvider)
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
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadFormDefaults()
        'SearchForm = New SearchFormBase(Me.SearchFormColumnDefinitionInfo, Me.SearchFormTableFromInfo)
        ''SearchForm.Tag = Me.Name
        ''SearchForm.Text = Me.Text
        SearchForm = New SearchFormBase(Me.SearchFormColumnDefinitionInfo, Me.SearchFormTableFromInfo, Me.txtModule, Me.txtModuleType)
        SearchForm.Tag = Me.Name
        SearchForm.Text = Me.Text

        AddHandler SearchForm.AdditionalWhere, AddressOf Me.AdditionalSearchFormFilter
        AddHandler SearchForm.RecordSelected, AddressOf Me.NewRecordSelected

        'Build Control Collection
        _CtrlCollection = New Collection
        LoadControlsToCollection(Me)

        'build report menu
        ReportWrappers = New Collection
        BuildReportMenu()

        DetailGridWrappers = New Collection
        'Attach Grid Wrappers via Async Method
        'Dim wrapperDelegate As AttachDetailWrappersDelegate
        'wrapperDelegate = New AttachDetailWrappersDelegate(AddressOf Me.AttachDetailWrappers)

        'wrapperDelegate.BeginInvoke(Nothing, Nothing)
        Me.AttachDetailWrappers()

        'Load Default PK Control and Module Controls
        '_PKControl = Me.txtSysPK
        '_ModuleControl = Me.txtModule
        '_ModuleTypeControl = Me.txtModuleType

        'If DisplayRecordPK <> 0 Then
        '    IsSearching = True
        '    SearchFilter = DisplayRecordPK
        'End If
        'Load Form data in back ground
        LoadFormData()

        'LoadConfig()
        'Me.Top = CInt(GetSettings("Top"))
        'Me.Left = CInt(GetSettings("Left"))
        'Me.Width = CInt(GetSettings("Width"))
        'Me.Height = CInt(GetSettings("Height"))

        'RestoreFormLayout()
        'Me.LayoutControlItem1.Height = CInt(GetSettings("HeaderHeight"))

        'set form default mode
        'Me.AddRecord()

    End Sub

    Protected Overridable Sub AdditionalSearchFormFilter(ByRef AdditionalWhere As String)

    End Sub

    Private Sub SetDefaulPKFKValues()
        Try
            For i As Integer = 1 To PKControlCollection.Count
                DirectCast(PKControlCollection(i), TextInput).EditValue = GetSysPK()
            Next

            If FKControlCollection.Count > 0 Then
                For i As Integer = 1 To FKControlCollection.Count
                    DirectCast(FKControlCollection(i), TextInput).EditValue = DirectCast(Me.PKControl, TextInput).EditValue
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadDefaultData()
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CrossThreadMethodInvokerDelegate(AddressOf Me.LoadDefaultData), New Object())
            Else
                'Generate ALL PK FK and UserPK
                'For i As Integer = 1 To PKControlCollection.Count
                '    DirectCast(PKControlCollection(i), TextInput).EditValue = GetSysPK()
                'Next

                'If FKControlCollection.Count > 0 Then
                '    For i As Integer = 1 To FKControlCollection.Count
                '        DirectCast(FKControlCollection(i), TextInput).EditValue = DirectCast(Me.PKControl, TextInput).EditValue
                '    Next
                'End If
                SetDefaulPKFKValues()

                If Not IsNothing(Me.UserPKControl) Then
                    DirectCast(Me.UserPKControl, UserPKInput).GenerateUserPK()
                End If

                For Each dateCtrl As Control In _CtrlCollection
                    If TypeOf (dateCtrl) Is DateEdit AndAlso Not DirectCast(dateCtrl, DateEdit).IsBlankDate Then
                        DirectCast(dateCtrl, DateEdit).EditValue = Now.ToString("d")
                    End If

                Next

            End If
        Catch ex As Exception

        End Try

    End Sub

#Region "CRUD"
    Protected Overridable Sub AddRecord()

        'Me._FormState = EditorState.AddMode
        'SetMenuDisplay()
        'ClearInputs()


        Try
            Dim Cancel As Boolean = False

            RaiseEvent BeforeRecordAdd(Cancel)

            If Not Cancel Then
                Me._FormState = EditorState.AddMode
                lblMode.Text = "ADD MODE"
                SetMenuDisplay()

                ClearInputs()
                EnableInputs(True)

                'load default
                Me.LoadDefaultData()

                'Clear Grids
                RaiseEvent FormStateChanged(Me.FormState)
                RaiseEvent LoadDetailRecords(Me.PKControl.Text)

                Try
                    txtUser.EditValue = Project.Instance.ActiveUserPK
                    FocusFirstControl()
                Catch ex As Exception

                End Try


                RaiseEvent AfterRecordAdd()

            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.GetBaseException.ToString, "Error adding new record...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ViewRecord()

    End Sub

    Protected Overridable Sub DeleteRecord()
        'Try
        '    Dim Cancel As Boolean = False
        '    RaiseEvent BeforeRecordDelete(Cancel)
        '    If Not Cancel Then
        '        If XtraMessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then

        '            'Delete record code here
        '            If Project.Instance.UseMainFormNavigation Then
        '                Me.RemoveItem(StrVal9(Me.PKControl.Text))
        '            Else
        '                Me.SearchForm.RemoveItem(StrVal9(Me.PKControl.Text))
        '            End If

        '            For Each TableName As String In TableNames
        '                Dim tbName As String = TableName
        '                With FormData.Tables(tbName)
        '                    If .Rows.Count > 0 Then
        '                        .Rows(0).Delete()

        '                        DirectCast(DataAdapters(tbName), DbDataAdapter).Update(FormData, tbName)
        '                        .AcceptChanges()
        '                    End If
        '                End With

        '                'remove from search list


        '                'Delete Detail Records here
        '                RaiseEvent AfterRecordDelete()
        '            Next
        '            XtraMessageBox.Show("Record Deleted Successfully", "DELETE RECORD SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        '            'Go back to add mode after delete
        '            ClearInputs()
        '            Call Me.ViewMode()
        '        End If
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Record Deleted failed", "DELETE RECORD FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        'End Try
        Try
            Dim Cancel As Boolean = False
            RaiseEvent BeforeRecordDelete(Cancel)
            If Not Cancel Then
                If XtraMessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                    'Dim userPK As String = Me.UserPKControl.Text
                    'Delete record code here
                    RaiseEvent DeleteDetailRecords()

                    For Each TableName As String In TableNames
                        Dim tbName As String = TableName
                        With FormData.Tables(tbName)
                            If .Rows.Count > 0 Then
                                .Rows(0).Delete()

                                DirectCast(DataAdapters(tbName), DbDataAdapter).Update(FormData, tbName)
                                .AcceptChanges()
                            End If
                        End With

                        'remove from search list


                        'Delete Detail Records here

                    Next

                    'Project.LogEvent("DELETE RECORD", Me.Text, "RECORD ID: " & userPK)
                    RaiseEvent AfterRecordDelete()
                    XtraMessageBox.Show("Record Deleted Successfully", "DELETE RECORD SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    'Go back to add mode after delete
                    ClearInputs()
                    Call Me.ViewMode()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Record Deleted failed", "DELETE RECORD FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Protected Overridable Sub EditRecord()


        Dim Cancel As Boolean = False
        RaiseEvent BeforeRecordEdit(Cancel)

        If Not Cancel Then
            Me._FormState = EditorState.EditMode
            lblMode.Text = "EDIT MODE"
            SetMenuDisplay()
            EnableInputs(True)
            Me.FocusFirstControl()
            RaiseEvent FormStateChanged(Me.FormState)

        End If
    End Sub

    Protected Overridable Sub SaveRecord(Optional ByVal ask As Boolean = True)

        If Not InputValidator.Validate Then
            MsgBox("Please fill-in all required data before saving...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Validation Error")
            Exit Sub

        End If

        Dim Cancel As Boolean = False
        'Dim transPK As Integer = StrVal9(CType(Me.PKControl, TextEdit).EditValue)
        'If Me.FormState = EditorState.AddMode Then RaiseEvent BeforeRecordSave(Cancel)
        'lets get a new pk for sequence accurancy in networked systems
        'Me.PKControl.Text = GetSysPK()
        RaiseEvent BeforeRecordSave(Cancel)
        If Not Cancel Then

            Try
                Dim PKField As String = DirectCast(Me.PKControl, TextInput).TableField
                Dim PKValue As String = Me.PKControl.Text
                'If Not IsNothing(Me.UserPKControl) AndAlso UserPKControl.Text = String.Empty Then
                If Me._FormState = EditorState.AddMode AndAlso Not IsNothing(Me.UserPKControl) Then
                    CType(Me.UserPKControl, UserPKInput).GenerateUserPK()
                End If

                'End If

                If TableNames.Count > 0 Then

                    For Each TableName As String In TableNames
                        Dim tbName As String = TableName
                        Dim NewRow As DataRow
                        Dim myChildTextBoxes = From myChildControl As Object In Me._CtrlCollection
                                               Where (Not TypeOf (myChildControl) Is DetailGrid AndAlso
                                                      Not TypeOf (myChildControl) Is GridPickListInfo AndAlso
                                                      myChildControl.Tablename = tbName AndAlso
                                                      myChildControl.TableField <> "")
                                               Select myChildControl

                        Dim CurrentRow As DataRow
                        If Me.FormState <> EditorState.AddMode Then
                            If FormData.Tables(tbName).Rows.Count > 0 Then
                                CurrentRow = FormData.Tables(tbName).Rows(0)
                            Else
                                Exit Sub
                            End If
                        Else
                            CurrentRow = FormData.Tables(tbName).NewRow
                        End If

                        'NewRow = FormData.Tables(tbName).NewRow
                        For Each myChildTextBox As Object In myChildTextBoxes
                            With CurrentRow
                                Dim EditValue As Object
                                If TypeOf (myChildTextBox) Is DateEdit Then
                                    Dim ctrl As DateEdit = DirectCast(myChildTextBox, DateEdit)
                                    Try
                                        EditValue = DateValue(ctrl.Text).ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss")
                                    Catch ex As Exception
                                        EditValue = DBNull.Value
                                    End Try
                                    'hh:mm tt
                                ElseIf TypeOf (myChildTextBox) Is TimeEdit Then
                                    Dim ctrl As TimeEdit = DirectCast(myChildTextBox, TimeEdit)
                                    Try
                                        EditValue = Now.ToString("yyyy-MM-dd") & CDate(ctrl.EditValue).ToString(" HH:mm:ss")
                                    Catch ex As Exception
                                        EditValue = DBNull.Value
                                    End Try
                                ElseIf TypeOf (myChildTextBox) Is GridLookupEdit Then
                                    Dim ctrl As GridLookupEdit = DirectCast(myChildTextBox, GridLookupEdit)
                                    If IsNothing(ctrl.EditValue) Then
                                        EditValue = DBNull.Value
                                    Else
                                        EditValue = ctrl.EditValue
                                    End If
                                ElseIf TypeOf (myChildTextBox) Is CheckEdit Then
                                    Dim ctrl As CheckEdit = DirectCast(myChildTextBox, CheckEdit)
                                    EditValue = IIf(ctrl.Checked, 1, 0)
                                ElseIf TypeOf (myChildTextBox) Is PictureEdit Then
                                    Dim picBox As PictureEdit = CType(myChildTextBox, PictureEdit)
                                    With picBox
                                        If Not IsDBNull(.EditValue) AndAlso Not IsNothing(.EditValue) Then
                                            Dim picBytes() As Byte
                                            Using ms As New MemoryStream
                                                picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                                                picBytes = ms.ToArray
                                            End Using
                                            EditValue = picBytes
                                        Else
                                            EditValue = DBNull.Value
                                        End If
                                        'End If
                                    End With
                                Else
                                    EditValue = IIf(Not IsNothing(myChildTextBox.EditValue), myChildTextBox.EditValue, DBNull.Value)
                                End If
                                .Item(myChildTextBox.TableField) = EditValue
                            End With

                        Next
                        If Me.FormState = EditorState.AddMode Then _
                            FormData.Tables(tbName).Rows.Add(CurrentRow)
                    Next

                    If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()

                    For Each TableName As String In TableNames
                        Dim tbName As String = TableName



                        DirectCast(DataAdapters(tbName), DbDataAdapter).Update(FormData, tbName)
                        FormData.Tables(tbName).AcceptChanges()

                    Next
                    Me.SaveDetailRecords()



                End If

                If Me.FormState = EditorState.AddMode Then
                    Me.AddNewItem(PKValue, PKField)

                ElseIf Me.FormState = EditorState.EditMode Then
                    Me.RemoveItem(PKValue)
                    Me.AddNewItem(PKValue, PKField)
                End If

                Dim evtType As String

                Select Case Me.FormState
                    Case EditorState.AddMode
                        evtType = "ADD RECORD"
                    Case EditorState.EditMode
                        evtType = "EDIT RECORD"
                    Case Else
                End Select

                'Project.LogEvent(evtType, Me.Text, "RECORD ID: " & Me.UserPKControl.Text)
                If ask Then
                    If XtraMessageBox.Show("Record Saved" + IIf(Me.FormState = EditorState.AddMode, vbCrLf + "Would you like to add a new record?", ""),
                    "Save Record Successful", IIf(Me.FormState = EditorState.AddMode, MessageBoxButtons.YesNo, MessageBoxButtons.OK),
                        MessageBoxIcon.Information, IIf(Me.FormState = EditorState.AddMode, MessageBoxDefaultButton.Button2, MessageBoxDefaultButton.Button1)) = System.Windows.Forms.DialogResult.Yes Then

                        Me.AddRecord()
                    Else
                        NewRecordSelected(Me.txtSysPK.Text)
                        Connection.Close()
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        'Me.Close()
                    End If
                Else
                    Me.ViewMode(True)
                    Connection.Close()
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    MsgBox("Successfully Saved.")
                End If

                RaiseEvent AfterRecordSave()
            Catch ex As Exception
                XtraMessageBox.Show(ex.GetBaseException.ToString, "Save Record Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Finally
                Connection.Close()
            End Try
        End If

    End Sub

    Protected Overridable Sub SaveDetailRecords()
        Try
            For Each GridWrapperObject As DetailGridWrapper In DetailGridWrappers
                'System.Threading.Thread.Sleep(50)
                GridWrapperObject.SaveDetailRecords()
            Next

            'RaiseEvent AfterRecordSave()
        Catch ex As Exception

        End Try

    End Sub
#End Region
    Protected Overridable Sub ViewMode(Optional ByVal LeaveCurrecntRecordOpen As Boolean = False)
        Try
            Dim prevIsAddMode As Boolean = False
            If Me.FormState = EditorState.AddMode Then
                If Not LeaveCurrecntRecordOpen Then
                    prevIsAddMode = True
                    ClearInputs()
                    RaiseEvent LoadDetailRecords(0)
                End If

            End If
            Me._FormState = EditorState.ViewMode
            lblMode.Text = "VIEW MODE"
            Me.SetMenuDisplay(prevIsAddMode)
            Me.EnableInputs(False)
            RaiseEvent FormStateChanged(Me.FormState)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub EditorBase_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


    End Sub

    Private Sub EditorBase_AfterRecordAdd() Handles Me.AfterRecordAdd
    End Sub

    Private Sub EditorBase_BeforeRecordSave(ByRef Cancel As Boolean) Handles Me.BeforeRecordSave
        Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditorBase_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Try

        Catch ex As Exception

        End Try
    End Sub



    Private Sub EditorBase_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        'If Project.Instance.UseMainFormMenu Then
        '    Me.AttachParentMenuHandler()
        'End If
    End Sub

    Private Sub EditorBase_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditorBase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SaveFormLayout()
        'SaveConfigFile()
        DisposeObjects()
        e.Cancel = False
    End Sub

    Private Sub AttachParentMenuHandler()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RemoveParentMenuHandler()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MenuItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            Select Case e.Item.Caption.ToLower
                Case "add"
                    Me.AddRecord()
                Case "edit"
                    Me.EditRecord()
                Case "delete"
                    Me.DeleteRecord2()
                Case "cancel"
                    Me.CancelCurrentAction()
                Case "save"
                    Me.SaveRecord2()
                Case "search"
                Case "preview"

                Case "print"

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Public Sub EditorBase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            'If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            '    ProcessTabKeyPress(sender, e)
            'End If
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.N
                        Me.AddRecord()
                    Case Keys.E
                        Me.EditRecord()
                    Case Keys.D
                        'Me.DeleteRecord2()
                    Case Keys.S
                        'Me.SaveRecord2()
                    Case Keys.P
                        'Dim SelectedReport As ReportWrapper = DirectCast(ReportWrappers(1), ReportWrapper)
                        'If Project.Instance.ActiveUser.Name = "BACKDOOR" OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can Print") Then
                        '    SelectedReport.PrintReport()
                        'Else
                        '    XtraMessageBox.Show("You are not allowed to use this function, Contact system admin...", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If

                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditorBase_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        'If Project.Instance.UseMainFormMenu Then
        '    Me.RemoveParentMenuHandler()
        '    DirectCast(Me.MdiParent, MDIMain).Bar1.ClearLinks()
        'End If
    End Sub



    Protected Overridable Sub DeleteRecord2()
        Try
            Dim Cancel As Boolean = False
            RaiseEvent BeforeRecordDelete(Cancel)
            If Not Cancel Then
                If XtraMessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then

                    RaiseEvent DeleteDetailRecords()
                    'Delete record code here
                    Me.RemoveItem(Me.PKControl.Text)

                    For Each FKControl As Control In FKControlCollection

                        With CType(FKControl, TextInput)
                            Dim delSQL As String = String.Format("DELETE FROM {0} WHERE {1} = @{1};", .TableName, .TableField)
                            If IsNothing(Connection) Then
                                Connection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                                Connection.ConnectionString = AppData.ConnectionString
                            End If

                            If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()

                            Using cmd As DbCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                                cmd.Connection = Connection
                                cmd.CommandText = delSQL

                                Dim p As DbParameter = New MySqlParameter() ''DBFactory.GetParameter(AppData.DBProvider)
                                p.ParameterName = "@" & .TableField
                                p.Value = .EditValue
                                p.DbType = IIf(AppData.DBProvider = DataProviderType.SqlServer, DbType.Guid, DbType.String)
                                cmd.Parameters.Add(p)
                                cmd.ExecuteNonQuery()
                            End Using

                        End With

                    Next




                    Dim pkctrl As TextInput = CType(Me.PKControl, TextInput)
                    'Dim tbName As String = CType(Me.PKControl, TextInput).TableName
                    Dim delMain As String = String.Format("DELETE FROM {0} WHERE {1} = @{1};", pkctrl.TableName, pkctrl.TableField)
                    If IsNothing(Connection) Then
                        Connection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                        Connection.ConnectionString = AppData.ConnectionString
                    End If

                    If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()

                    Using cmd As DbCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                        cmd.Connection = Connection
                        cmd.CommandText = delMain

                        Dim param As DbParameter = New MySqlParameter() ''DBFactory.GetParameter(AppData.DBProvider)
                        param.ParameterName = "@" & pkctrl.TableField
                        param.Value = pkctrl.EditValue
                        param.DbType = IIf(AppData.DBProvider = DataProviderType.SqlServer, DbType.Guid, DbType.String)

                        cmd.Parameters.Add(param)
                        ' cmd.Parameters.AddWithValue("@" & pkctrl.TableField, pkctrl.EditValue)
                        cmd.ExecuteNonQuery()
                    End Using

                    RaiseEvent AfterRecordDelete()

                    XtraMessageBox.Show("Record Deleted Successfully", "DELETE RECORD SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    'Go back to add mode after delete
                    ClearInputs()
                    Call Me.ViewMode()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Record Deleted failed", "DELETE RECORD FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(Connection) Then
                If Connection.State <> System.Data.ConnectionState.Closed Then Connection.Close()
                Connection = Nothing
            End If
        End Try
    End Sub


    Protected Overridable Sub SaveRecord2(Optional ByVal SilentSave As Boolean = False)
        If Me.InvokeRequired Then
            Me.Invoke(New CrossThreadMethodInvokerDelegate(AddressOf Me.SaveRecord2), New Object() {SilentSave})
        Else
            If Not InputValidator.Validate Then
                MsgBox("Please fill-in all required data before saving...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Validation Error")
                Exit Sub
            End If
            Dim cancel As Boolean = False
            RaiseEvent BeforeRecordSave(cancel)
            If Me.FormState <> EditorState.AddMode AndAlso Me.FormState <> EditorState.EditMode Then
                cancel = True
            End If

            If Not cancel Then

                Try
                    Dim UpdateCommands As New Collection
                    Dim PKField As String = DirectCast(Me.PKControl, TextInput).TableField
                    Dim PKValue As String = Me.PKControl.Text
                    If Me._FormState = EditorState.AddMode AndAlso Not IsNothing(Me.UserPKControl) Then
                        CType(Me.UserPKControl, UserPKInput).GenerateUserPK()
                    End If

                    If TableNames.Count > 0 Then

                        For Each TableName As String In TableNames
                            Dim tbName As String = TableName
                            'Dim NewRow As DataRow
                            Dim myChildTextBoxes = From myChildControl As Object In Me._CtrlCollection
                                                   Where ((TypeOf myChildControl Is TextInput Or
                                   TypeOf myChildControl Is UserPKInput Or
                                           TypeOf myChildControl Is ComboBoxInput Or
                                               TypeOf myChildControl Is MemoInput Or
                                                   TypeOf myChildControl Is GridLookupEdit Or
                                                           TypeOf myChildControl Is DateEdit Or
                                                               TypeOf myChildControl Is PictureEdit Or
                                                                       TypeOf myChildControl Is CheckEdit Or
                                                                           TypeOf myChildControl Is TimeEdit) AndAlso
                                                                         myChildControl.Tablename <> "" AndAlso myChildControl.Tablename = tbName AndAlso
                                                                          myChildControl.TableField <> "")
                                                   Select myChildControl


                            Dim paramType As DbType
                            Dim UpdateQuery As String
                            Dim UPDATE_PREFIX As String = ""

                            Dim CurrentRow As DataRow
                            If Me.FormState <> EditorState.AddMode Then
                                If FormData.Tables(tbName).Rows.Count > 0 Then
                                    CurrentRow = FormData.Tables(tbName).Rows(0)
                                    UpdateQuery = GetUpdateQuery(TableQueries(tbName))
                                Else
                                    UpdateQuery = GetInsertQuery(TableQueries(tbName))
                                End If
                            Else
                                CurrentRow = FormData.Tables(tbName).NewRow
                                UpdateQuery = GetInsertQuery(TableQueries(tbName))
                            End If

                            Dim cmd As DbCommand = New MySqlCommand() 'DBFactory.GetCommand(AppData.DBProvider)
                            cmd.CommandText = UpdateQuery

                            Try


                                For Each myChildTextBox As Object In myChildTextBoxes
                                    'With CurrentRow
                                    Dim EditValue As Object
                                    Dim paramName As String
                                    If TypeOf (myChildTextBox) Is DateEdit Then
                                        Dim ctrl As DateEdit = DirectCast(myChildTextBox, DateEdit)
                                        Try
                                            EditValue = DateValue(ctrl.Text).ToString("yyyy-MM-dd")

                                        Catch ex As Exception
                                            EditValue = DBNull.Value
                                        End Try
                                        paramType = DbType.DateTime
                                        paramName = "@" & ctrl.TableField

                                    ElseIf TypeOf (myChildTextBox) Is ComboBoxInput Then
                                        Dim ctrl As ComboBoxInput = DirectCast(myChildTextBox, ComboBoxInput)
                                        Try
                                            EditValue = IIf(Not IsNothing(ctrl.EditValue), ctrl.Text.Trim, DBNull.Value)
                                        Catch ex As Exception
                                            EditValue = DBNull.Value
                                        End Try
                                        paramType = DbType.String
                                        paramName = "@" & ctrl.TableField
                                    ElseIf TypeOf (myChildTextBox) Is TimeEdit Then
                                        Dim ctrl As TimeEdit = DirectCast(myChildTextBox, TimeEdit)
                                        Try
                                            EditValue = Now.ToString("yyyy-MM-dd") & CDate(ctrl.EditValue).ToString(" HH:mm:ss")
                                        Catch ex As Exception
                                            EditValue = DBNull.Value
                                        End Try
                                        paramType = DbType.DateTime
                                        paramName = "@" & ctrl.TableField
                                    ElseIf TypeOf (myChildTextBox) Is GridLookupEdit Then
                                        Dim ctrl As GridLookupEdit = DirectCast(myChildTextBox, GridLookupEdit)
                                        If (ctrl.TableField.ToLower.Contains("pk_") OrElse ctrl.TableField.ToLower.Contains("fk_")) AndAlso AppData.DBProvider = DataProviderType.SqlServer Then
                                            If IsNothing(ctrl.EditValue) Then
                                                EditValue = Guid.Empty
                                                paramType = DbType.Guid
                                            Else

                                                If AppData.DBProvider = DataProviderType.SqlServer Then
                                                    EditValue = New Guid(ctrl.EditValue.ToString)
                                                    paramType = DbType.Guid

                                                End If



                                            End If
                                        Else

                                            If Not IsNothing(ctrl.EditValue) Then
                                                EditValue = IIf(Not IsEmptyString(ctrl.EditValue.ToString), ctrl.EditValue.ToString, "")
                                                paramType = DbType.String
                                            Else
                                                If InStr(ctrl.TableField, "sysfk") <> 0 Then
                                                    EditValue = Guid.Empty
                                                    paramType = DbType.Guid
                                                Else
                                                    EditValue = DBNull.Value
                                                    paramType = DbType.String

                                                End If

                                            End If


                                        End If
                                        paramName = "@" & ctrl.TableField
                                    ElseIf TypeOf (myChildTextBox) Is CheckEdit Then
                                        Dim ctrl As CheckEdit = DirectCast(myChildTextBox, CheckEdit)
                                        EditValue = IIf(ctrl.Checked, 1, 0)
                                        paramType = DbType.Byte
                                        paramName = "@" & ctrl.TableField
                                    ElseIf TypeOf (myChildTextBox) Is PictureEdit Then
                                        Dim picBox As PictureEdit = CType(myChildTextBox, PictureEdit)
                                        With picBox
                                            If Not IsDBNull(.EditValue) AndAlso Not IsNothing(.EditValue) Then
                                                Dim picBytes() As Byte
                                                Using ms As New MemoryStream
                                                    picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                                                    picBytes = ms.ToArray
                                                End Using
                                                EditValue = picBytes
                                            Else
                                                EditValue = DBNull.Value
                                            End If
                                            'End If
                                        End With
                                        paramType = DbType.Binary
                                        paramName = "@" & picBox.TableField
                                    Else

                                        If Not IsNothing(myChildTextBox.EditValue) AndAlso (myChildTextBox.TableField.ToString.ToLower.Contains("pk_") OrElse myChildTextBox.TableField.ToString.ToLower.Contains("fk_")) Then
                                            If AppData.DBProvider = DataProviderType.SqlServer Then
                                                If Not IsDBNull(myChildTextBox.EditValue) Then
                                                    EditValue = New Guid(myChildTextBox.EditValue.ToString) '.ToString)
                                                    paramType = DbType.Guid
                                                Else
                                                    'EditValue = Guid.Empty.ToString
                                                End If

                                            Else
                                                EditValue = myChildTextBox.EditValue
                                                paramType = DbType.String
                                            End If

                                        Else
                                            EditValue = IIf(Not IsNothing(myChildTextBox.EditValue), myChildTextBox.EditValue, DBNull.Value)
                                            paramType = DbType.String

                                            Dim Num As Double
                                            If Not IsDBNull(EditValue) AndAlso Not TypeOf (myChildTextBox) Is UserPKInput Then
                                                If Double.TryParse(EditValue, Num) Then
                                                    paramType = DbType.Decimal
                                                    EditValue = EditValue.ToString.Replace(",", "")
                                                End If
                                            End If
                                        End If
                                        paramName = "@" & myChildTextBox.TableField


                                    End If
                                    Dim dbparam As DbParameter = cmd.CreateParameter
                                    With dbparam
                                        .DbType = paramType
                                        .ParameterName = paramName
                                        .Value = EditValue
                                    End With
                                    Debug.Print("param type: " & paramType.ToString & " paramname: " & paramName & " param value: " & EditValue.ToString)
                                    cmd.Parameters.Add(dbparam)
                                Next

                            Catch ex As Exception
                                If UserName = "BACKDOOR" Then
                                    XtraMessageBox.Show(ex.GetBaseException.ToString, "Save Record Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                                End If
                            End Try

                            UpdateCommands.Add(cmd, tbName)

                        Next

                        If IsNothing(Connection) Then
                            Connection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                            Connection.ConnectionString = AppData.ConnectionString
                        End If

                        If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()

                        'SAVE PRIMARY TABLE FIRST
                        Dim pTable As String = Me.txtSysPK.TableName.ToString
                        'DirectCast(DataAdapters(pTable), DbDataAdapter).Update(FormData, pTable)
                        'FormData.Tables(pTable).AcceptChanges()
                        With CType(UpdateCommands(pTable), DbCommand)
                            .Connection = Connection

                            .ExecuteNonQuery()
                        End With

                        Try
                            If TableNames.Count > 1 Then
                                For Each TableName As String In TableNames
                                    Dim tbName As String = TableName

                                    If tbName <> pTable Then
                                        'DirectCast(DataAdapters(tbName), DbDataAdapter).Update(FormData, tbName)
                                        'FormData.Tables(tbName).AcceptChanges()
                                        With CType(UpdateCommands(tbName), DbCommand)
                                            .Connection = Connection
                                            .ExecuteNonQuery()
                                        End With
                                    End If

                                Next
                            End If
                        Catch ex As Exception

                        End Try


                        Me.SaveDetailRecords()

                    End If



                    'silent save used for self updates /resaves
                    If Not SilentSave Then
                        If Me.FormState = EditorState.AddMode Then
                            Me.AddNewItem(PKValue, PKField)

                        ElseIf Me.FormState = EditorState.EditMode Then

                            Me.RemoveItem(PKValue)
                            Me.AddNewItem(PKValue, PKField)
                        End If

                        If Not Resaving Then
                            If XtraMessageBox.Show("Record Saved" + IIf(Me.FormState = EditorState.AddMode, vbCrLf + "Would you like to add a new record?", ""),
                        "Save Record Successful", IIf(Me.FormState = EditorState.AddMode, MessageBoxButtons.YesNo, MessageBoxButtons.OK),
                            MessageBoxIcon.Information, IIf(Me.FormState = EditorState.AddMode, MessageBoxDefaultButton.Button2, MessageBoxDefaultButton.Button1)) = System.Windows.Forms.DialogResult.Yes Then

                                Me.AddRecord()
                            Else
                                If Me.IsFromDialog Then
                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                    Me.Close()
                                Else
                                    NewRecordSelected(Me.txtSysPK.Text)
                                    Me.ViewMode(True)
                                End If
                            End If
                        Else
                            Me.ViewMode(True)
                        End If
                    End If



                Catch ex As Exception
                    If UserName = "BACKDOOR" Then
                        XtraMessageBox.Show(ex.GetBaseException.ToString, "Save Record Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                    End If
                Finally
                    If Not IsNothing(Connection) Then
                        If Connection.State <> System.Data.ConnectionState.Closed Then Connection.Close()
                        Connection = Nothing
                    End If

                End Try
            End If

        End If

    End Sub

    Public Sub Search()
        If Not SearchForm Is Nothing Then Me.SearchForm.Show(Me)
    End Sub
    Private Function GetUpdateQuery(ByVal SelectQuery As String) As String
        Dim query As String = ""
        Try
            Dim tbName As String
            Dim splitQuery() As String
            Dim Columns() As String
            Dim PKField As String

            SelectQuery = SelectQuery.ToLower.Replace("select", "").Replace(" from ", "|")

            splitQuery = SelectQuery.Split("|")
            tbName = splitQuery(1).Trim
            Columns = splitQuery(0).Split(",")

            query = String.Format("UPDATE {0} SET ", tbName)
            For i As Integer = 0 To UBound(Columns)
                Dim colName As String = Columns(i).Trim
                If colName.Contains("syspk") Or colName.Contains("pk_") Then
                    PKField = colName
                Else
                    query &= String.Format("{0} = @{0}", colName)
                    Debug.Print(String.Format("{0} query= {1}", i, query))
                    If i <> UBound(Columns) Then query &= ","
                End If

            Next
            query = query.TrimEnd(",")
            query &= String.Format(" WHERE {0} = @{0}", PKField)
        Catch ex As Exception

        End Try
        Return query
    End Function


    Public Function GetInsertQuery(ByVal SelectQuery As String) As String
        Dim query As String = ""
        Try
            Dim tbName As String
            Dim splitQuery() As String
            Dim Columns() As String
            Dim Fields As String = ""
            Dim Values As String = ""

            SelectQuery = SelectQuery.ToLower.Replace("select", "").Replace(" from ", "|")

            splitQuery = SelectQuery.Split("|")
            tbName = splitQuery(1).Trim
            Columns = splitQuery(0).Split(",")


            'query = String.Format("INSERT INTO {0} ", tbName)
            For i As Integer = 0 To UBound(Columns)
                Dim colName As String = Columns(i).Trim
                Fields &= colName
                Values &= "@" & colName
                If i <> UBound(Columns) Then
                    Fields &= ","
                    Values &= ","
                End If

            Next

            query &= String.Format("INSERT INTO {0} ({1}) VALUES ({2})", tbName, Fields, Values)
        Catch ex As Exception

        End Try
        Return query
    End Function





    Private Sub EditorBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        XML_FILENAME = Me.Name & "Settings.xml"
        If Not Me.DesignMode Then
            LoadFormDefaults()
        End If
    End Sub

    Private Sub DisposeObjects()
        _CtrlCollection = Nothing
        PKControlCollection = Nothing
        FKControlCollection = Nothing
        TableNames = Nothing
        TableQueries = Nothing
        DataAdapters = Nothing
        CommandBuilders = Nothing
        Connection = Nothing
        FormData = Nothing
        SearchForm = Nothing
        _PKControl = Nothing
        _ModuleControl = Nothing
        _ModuleTypeControl = Nothing
        _BranchControl = Nothing
        _UserPkControl = Nothing
    End Sub

    Public Sub New()
        'Me.New(0)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''Load Default PK Control and Module Controls
        _PKControl = Me.txtSysPK
        _ModuleControl = Me.txtModule
        Me.BackColor = Colors.whiteSecondary
        FormSplitter.BackColor = Colors.whiteSecondary

        HeaderPanel.BackColor = Colors.whiteSecondary
        HeaderLabel.ForeColor = Colors.blackSecondary
        ButtonClose.IconColor = Colors.white
        ActionPanel.BackColor = Colors.whiteSecondary
        FormPanel.BackColor = Colors.white
        ButtonSave.BackColor = Colors.lightBlue
        ButtonSave.ForeColor = Colors.white
        ButtonSave.IconColor = Colors.white


    End Sub

    'Public Sub New(ByVal DefaultRecordPK As Long)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    'Load Default PK Control and Module Controls
    '    DisplayRecordPK = DefaultRecordPK

    '    _PKControl = Me.txtSysPK
    '    _ModuleControl = Me.txtModule
    '    _ModuleTypeControl = Me.txtModuleType
    'End Sub


    Private Sub SetControlEditValue(ByVal obj As Object, ByVal value As Object)
        Try

            If Not TypeOf (obj) Is CheckEdit Then
                obj.EditValue = value
            Else
                CType(obj, CheckEdit).Checked = value
            End If
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub cmdDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDelete.ItemClick
    '    If (Project.Instance.ActiveUser.Name = "BACKDOOR" Or Project.Instance.ActiveUser.Name = "") OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can Delete") Then
    '        Me.DeleteRecord2()
    '    Else
    '        XtraMessageBox.Show("You are not allowed to use this function, Contact system admin...", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If

    'End Sub

    'Private Sub cmdAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdAdd.ItemClick
    '    Try
    '        If (Project.Instance.ActiveUser.Name = "BACKDOOR" Or Project.Instance.ActiveUser.Name = "") OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can Add") Then
    '            Me.AddRecord()

    '        Else

    '            XtraMessageBox.Show("You are not allowed to use this function, Contact system admin...", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub cmdEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.ItemClick
    '    If (Project.Instance.ActiveUser.Name = "BACKDOOR" Or Project.Instance.ActiveUser.Name = "") OrElse Project.Instance.ActiveUser.IsFunctionAllowed(Me.Text, "Can Edit") Then
    '        Me.EditRecord()

    '    Else
    '        XtraMessageBox.Show("You are not allowed to use this function, Contact system admin...", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If

    'End Sub

    Private Sub CancelCurrentAction()
        Me.ViewMode()
    End Sub

    'Private Sub cmdCancel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
    '    Me.CancelCurrentAction()
    'End Sub

    'Private Sub cmdSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
    '    FocusFirstControl()
    '    Me.SaveRecord2()
    'End Sub

#Region "FormSettings"
    Private Function GetSettingsFilePath() As String

        _AppPath = System.Reflection.Assembly.GetExecutingAssembly.Location
        _ExeName = Dir(_AppPath)
        '_AppPath = Path.GetFullPath((Left(_AppPath, (Len(_AppPath) - Len(_ExeName)))))
        _AppPath = Path.GetFullPath(_AppPath.Substring(0, Len(_AppPath) - Len(_ExeName)))
        '_XMLPath = _AppPath & XML_FILENAME
        Return _AppPath & XML_FILENAME
    End Function

    Public Sub LoadConfig()

        _XMLPath = GetSettingsFilePath()
        Try
            If File.Exists(_XMLPath) Then
                FormSettings = New XmlDocument
                FormSettings.Load(_XMLPath)
            Else
                FormSettings = XmlHelper.CreateXmlDocument(XML_ROOT)
                CreateDefaultSettings()
                'SaveConfigFile()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            If File.Exists(_XMLPath) Then Kill(_XMLPath)
            FormSettings = XmlHelper.CreateXmlDocument(XML_ROOT)
            CreateDefaultSettings()
            'SaveConfigFile()
        End Try

    End Sub

    Private Sub CreateDefaultSettings()
        Dim pNode As XmlNode, cNode As XmlNode
        Dim rootNode As XmlNode = FormSettings.SelectSingleNode("/FORM")

        pNode = FormSettings.CreateElement("Settings")
        XmlHelper.CreateAttribute(pNode, "Name", "Form Settings")

        cNode = FormSettings.CreateElement("Width")
        XmlHelper.CreateAttribute(cNode, "Value", Me.Width)
        pNode.AppendChild(cNode)

        cNode = FormSettings.CreateElement("Height")
        XmlHelper.CreateAttribute(cNode, "Value", Me.Height)
        pNode.AppendChild(cNode)

        cNode = FormSettings.CreateElement("Top")
        XmlHelper.CreateAttribute(cNode, "Value", Me.Top)
        pNode.AppendChild(cNode)

        cNode = FormSettings.CreateElement("Left")
        XmlHelper.CreateAttribute(cNode, "Value", Me.Left)
        pNode.AppendChild(cNode)

        rootNode.AppendChild(pNode)

        'SaveConfigFile()


    End Sub

    Public Sub SaveConfigFile()
        '.SaveSetting(
        Dim xBasePath As String = "Settings[@Name='Form Settings']/"
        XmlHelper.Update(FormSettings, xBasePath + "Width", "Value", Me.Width)
        XmlHelper.Update(FormSettings, xBasePath + "Height", "Value", Me.Height)
        XmlHelper.Update(FormSettings, xBasePath + "Top", "Value", Me.Top)
        XmlHelper.Update(FormSettings, xBasePath + "Left", "Value", Me.Left)

        FormSettings.Save(_XMLPath)
    End Sub

    Public Function GetSettings(ByVal xPath As String, Optional ByVal field As String = "Value") As String
        Try
            Dim sValue As String = XmlHelper.QueryScalar(FormSettings, "Settings[@Name='Form Settings']/" + xPath, field)

            Return sValue 'IIf(sValue = "", "", sValue)
        Catch ex As Exception

        End Try

    End Function
#End Region

    Private Sub EditorBase_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        'SaveConfigFile()
    End Sub

    Protected Overridable Sub HideRestrictedControls(ByVal Show As Boolean)

    End Sub

    Private Sub PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        e.IsInputKey = True
    End Sub

#Region "ADD/REMOVE MAIN NAVIGATION RECORDS"
    Public Sub RemoveItem(ByVal RecordPK As String)
        Try
            Dim pkField As String = (From colInfo As ColumnInfo In Me.MainNavigationColumnsInfo
                                     Where colInfo.Caption = "syspk"
                                     Select colInfo.FieldName).SingleOrDefault
            Dim pkValue As Object
            If AppData.DBProvider = DataProviderType.SqlServer Then
                pkValue = New Guid(RecordPK)
            Else
                pkValue = RecordPK
            End If
            Dim EditedItems = From EditedRow In MainNavigationData.Tables(0).Rows
                              Where EditedRow(pkField) = pkValue
                              Select EditedRow

            For Each EditedItem In EditedItems
                EditedItem.delete()
            Next

            'Dim dr As DataRow = pData.Tables(0).Rows.Find(RecordPK)

            'If Not IsNothing(dr) Then
            '    dr.Delete()
            MainNavigationData.Tables(0).AcceptChanges()

            'End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddNewItem(ByVal EntryID As String, ByVal EntryField As String)
        Try
            Dim newQuery As String = ""
            Dim newquerywhere As String = ""
            Dim queryWhere As String = ""
            Dim WhereIdx As Integer = MainNavigationSQLQuery.IndexOf("where")
            Dim OrderByIdx As Integer = MainNavigationSQLQuery.IndexOf("order by")
            If OrderByIdx = -1 Then
                If WhereIdx <> -1 Then queryWhere = MainNavigationSQLQuery.Substring(WhereIdx)
            Else
                queryWhere = MainNavigationSQLQuery.Substring(WhereIdx, OrderByIdx - WhereIdx)
            End If
            If queryWhere <> "" Then
                newquerywhere &= String.Format("{0} AND {1} = '{2}' ", queryWhere, EntryField, EntryID)
            Else
                newquerywhere &= String.Format("WHERE {1} = '{2}' ", queryWhere, EntryField, EntryID)
            End If


            If queryWhere.Length > 0 Then
                newQuery = MainNavigationSQLQuery.Replace(queryWhere, newquerywhere)
            Else
                newQuery &= MainNavigationSQLQuery & " " & newquerywhere
            End If


            Using Connection As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                Using tmpDbAdapter As DbDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
                    Try
                        Connection.ConnectionString = AppData.ConnectionString

                        With tmpDbAdapter
                            .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                            .SelectCommand.CommandType = CommandType.Text
                            .SelectCommand.CommandText = newQuery
                            .SelectCommand.Connection = Connection
                            .SelectCommand.CommandTimeout = 5000
                        End With

                        Dim tmpData As New DataSet

                        If Connection.State <> System.Data.ConnectionState.Open Then Connection.Open()
                        tmpDbAdapter.Fill(tmpData, "NewData")

                        If tmpData.Tables(0).Rows.Count > 0 Then
                            Dim dr As DataRow = MainNavigationData.Tables(0).NewRow

                            For Each col As DataColumn In MainNavigationData.Tables(0).Columns
                                dr(col.ColumnName) = tmpData.Tables(0).Rows(0)(col.ColumnName)
                            Next
                            MainNavigationData.Tables(0).Rows.Add(dr)
                            MainNavigationData.Tables(0).AcceptChanges()


                        End If

                    Catch ex As Exception
                        'Return Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
#End Region

    Private Sub CrossThreadRecordProcessor()
        If Me.InvokeRequired Then
            Me.Invoke(New CrossAppDomainDelegate(AddressOf Me.CrossThreadRecordProcessor))
        Else
            DoResaveCurrentRecord()
        End If
    End Sub

    Protected Overridable Sub DoResaveCurrentRecord()

    End Sub


    Private Sub UpdateResaveProgress(ByVal Progress As Object)
        If Me.InvokeRequired Then
            Me.Invoke(New CrossThreadMethodDelegate(AddressOf Me.UpdateResaveProgress), New Object() {Progress})
        Else
        End If

    End Sub


    Public Overloads Sub ShowEditor(ByRef OwnerForm As Form, Optional ByVal editorMode As EditorState = EditorState.AddMode, Optional ByVal PrimaryKey As Long = 0)
        Try
            'Dim TimeStart As Date = Now
            MyBase.Show()
            'Me.pOwnerForm = OwnerForm

            LoadAndActivateForm()
            MyBase.MdiParent = OwnerForm.MdiParent
            MyBase.BringToFront()
            'pOwnerForm.Enabled = False

            Select Case editorMode
                Case EditorState.AddMode
                    Me.AddRecord()
                    lblMode.Text = "ADD MODE"

                    'Case EditorState.DeleteMode
                    '    'Application.DoEvents()
                    '    SearchRecord(PrimaryKey)
                    '    Me.DeleteRecord()

                    'Case EditorState.EditMode
                    '    'Application.DoEvents()
                    '    SearchRecord(PrimaryKey)
                    '    Me.EditRecord()

                Case EditorState.ViewMode
                    'Application.DoEvents()
                    'SearchRecord(PrimaryKey)
                    NewRecordSelected(PrimaryKey)
                    Me._FormState = EditorState.ViewMode
                    lblMode.Text = "VIEW MODE"
                    'Me.EditorMode = EditorState.ViewMode
                    SetMenuDisplay()
            End Select
            'MsgBox(TimeStart.Subtract(Now).TotalSeconds)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadAndActivateForm()
        If Not Me.DesignMode And Not Me.FormLoaded Then
            pPKTableName = CType(Me.PKControl, TextInput).TableName.ToLower
            pPKFieldName = CType(Me.PKControl, TextInput).TableField.ToLower

            LoadControlsToCollection(Me)
            BuildReportMenu()

            FormLoaded = True


        End If
    End Sub

    Private Sub EditorBase_LoadDetailRecords(RecordPK As String) Handles Me.LoadDetailRecords

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub EditorBase_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            'LoadFormDefaults()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CloseConnection()
        If Not IsNothing(Connection) Then
            If Connection.State <> System.Data.ConnectionState.Closed Then Connection.Close()
            Connection = Nothing
        End If
    End Sub
End Class
