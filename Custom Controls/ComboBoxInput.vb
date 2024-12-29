Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports System.Threading
Imports System.Data.Common
Imports MySql.Data.MySqlClient

Public Class ComboBoxInput : Inherits ComboBoxEdit
    Private Delegate Sub PrepareComboDataDelegate()

    Private LoadComboDataDelegate As PrepareComboDataDelegate
    Private pTableName As String
    Private pTableField As String
    Private pQuery As String
    Private pQueryFrom As String
    Private pFieldSource As String
    Private pData As New DataSet
    Private pDataSourceCustom As String
    Private LoadStarted As Boolean = False
    Private _UseQuery As Boolean
    Private _TableQuery As String
    Private _QueryField As String
    Private pUseCustomData As Boolean
    Private pDropDownSizeable As Boolean
    Private pAdditionalWhere As String
    Private FieldName As String
    Private LoaderThread As Thread
    Private LoaderThreadStart As New ThreadStart(AddressOf GetData)

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

    Public Property AdditionalWhere() As String
        Get
            Return GetLowerCaseString(pAdditionalWhere)
        End Get
        Set(ByVal value As String)
            pAdditionalWhere = value
        End Set
    End Property

    <DefaultValue(False)>
    Public Property UseQuery() As Boolean
        Get
            Return _UseQuery
        End Get
        Set(ByVal value As Boolean)
            _UseQuery = value
        End Set
    End Property

    Public Property TableQuery() As String
        Get
            Return _TableQuery
        End Get
        Set(ByVal value As String)
            _TableQuery = value
        End Set
    End Property

    Public Property QueryField() As String
        Get
            Return _QueryField
        End Get
        Set(ByVal value As String)
            _QueryField = value
        End Set
    End Property


    <DefaultValue(False)>
    Public Property DataSourceUseCustom() As Boolean
        Get
            Return pUseCustomData
        End Get
        Set(ByVal value As Boolean)
            pUseCustomData = value
        End Set
    End Property

    Public Property DataSourceCustom() As String
        Get
            Return pDataSourceCustom
        End Get
        Set(ByVal value As String)
            pDataSourceCustom = value
        End Set
    End Property

    <DefaultValue(False)>
    Public Property DropDownSizeable() As Boolean
        Get
            Return pDropDownSizeable
        End Get
        Set(ByVal value As Boolean)
            pDropDownSizeable = value
        End Set
    End Property

    Private Sub LoadDefaultProperties()
        Try
            If Me.FindForm.InvokeRequired Then
                Me.FindForm.Invoke(New PrepareComboDataDelegate(AddressOf LoadDefaultProperties))
            Else
                With Me.Properties
                    .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
                    .ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick
                    .HighlightedItemStyle = HighlightStyle.Default
                    .DropDownItemHeight = 0
                    .PopupSizeable = Me.DropDownSizeable
                    .AutoComplete = True
                    .HotTrackItems = True
                End With
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadCustomData()
        Try
            If Me.FindForm.InvokeRequired Then
                Me.FindForm.Invoke(New PrepareComboDataDelegate(AddressOf Me.LoadCustomData))
            Else
                Dim lstItems() As String = pDataSourceCustom.Split("|")
                Me.Properties.Items.Clear()
                If Not IsNothing(lstItems) Then
                    For i As Integer = 0 To UBound(lstItems)

                        If Not String.IsNullOrEmpty(lstItems(i).ToString.Trim) Then Me.Properties.Items.Add(lstItems(i).ToString.Trim)

                    Next
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadComboData()
        Try
            LoadDefaultProperties()
            If pUseCustomData Then
                If Not String.IsNullOrEmpty(pDataSourceCustom) Then
                    LoadCustomData()
                End If
            Else
                If Not IsEmptyString(Me.TableField) AndAlso Not IsEmptyString(Me.TableName) Then
                    BuildComboSourceQry()
                    GetData()
                    LoadComboItems()
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Sub LoadData()
        Try
            LoadComboDataDelegate = New PrepareComboDataDelegate(AddressOf Me.LoadComboData)
            LoadComboDataDelegate.BeginInvoke(Nothing, Nothing)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetData()

        Dim tblQuery As String = ""
        Dim tmpCommand As DbCommand
        Dim tmpConnection As DbConnection
        Dim tmpDataAdapter As DbDataAdapter
        Try

            tmpConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
            tmpConnection.ConnectionString = AppData.ConnectionString

            tmpCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
            tmpCommand.CommandText = pQuery
            tmpCommand.Connection = tmpConnection
            tmpCommand.CommandTimeout = 5000

            tmpDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
            tmpDataAdapter.SelectCommand = tmpCommand

            tmpDataAdapter.Fill(pData)


        Catch ex As Exception
            'Throw (New Exception(ex.Message))
        Finally
            If Not tmpCommand Is Nothing Then tmpCommand.Dispose()
            If Not tmpConnection Is Nothing Then tmpConnection.Dispose()
            If Not tmpDataAdapter Is Nothing Then tmpDataAdapter.Dispose()
        End Try

        'With Data
        '    .CallSource = "ComboInput:" + Me.Name + " - GetData"
        '    pData = .GetDataSet(pQuery)
        'End With


        'Invoke(New CallCrossThreadMethod(AddressOf Me.LoadComboItems))

    End Sub

    Private Sub LoadComboItems()

        Try
            If Me.FindForm.InvokeRequired Then
                Me.FindForm.Invoke(New PrepareComboDataDelegate(AddressOf Me.LoadComboItems))
            Else
                With Me.Properties.Items
                    .Clear()
                    If pData.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In pData.Tables(0).Rows
                            Dim item As String = ""
                            If UseQuery Then
                                item = row.Item(0).ToString()
                            Else
                                item = row.Item(FieldName).ToString()
                            End If
                            If Not IsEmptyString(item) Then
                                .Add(ProperCase(item))
                            End If
                        Next
                    End If
                End With
            End If

        Catch ex As Exception
        Finally
            If Not pData Is Nothing Then pData.Dispose()
        End Try


    End Sub

    Private Sub BuildComboSourceQry()
        Try
            If Me.UseQuery Then
                pQuery = String.Format("Select {0} {1}", Me.QueryField, Me.TableQuery)
            Else
                Dim tmpFrom As String = ""
                Dim tmpWhere As String = ""
                Dim tmpOrderBy As String = ""
                FieldName = Me.TableField
                If FieldName.Contains(".") Then
                    FieldName = FieldName.Split(".")(1)
                End If
                Dim TableName As String = Me.TableName
                If TableName.ToLower.Contains(" as ") Then
                    TableName = TableName.Split(" ")(0)
                End If
                pQuery = String.Format("SELECT DISTINCT({0})", FieldName)
                tmpOrderBy = "ORDER BY " + FieldName

                If TypeOf (Me.FindForm) Is EditorBase Then
                    Dim myEditor As EditorBase = DirectCast(Me.FindForm, EditorBase)
                    Dim pkCtrl As TextInput = DirectCast(myEditor.PKControl, TextInput)
                    Dim modCtrl As TextInput = DirectCast(myEditor.ModuleControl, TextInput)
                    Dim modTypeCtrl As TextInput = DirectCast(myEditor.ModuleTypeControl, TextInput)

                    tmpFrom = "FROM " + TableName

                    If TableName = pkCtrl.TableName Then
                        tmpWhere = ""
                        If Not IsEmptyString(modCtrl.TableName) AndAlso Not IsEmptyString(modCtrl.TableField) Then
                            tmpWhere += String.Format("WHERE {0}={1} ", modCtrl.TableField, AddQuote9(modCtrl.EditValue))
                        End If

                    End If
                ElseIf TypeOf (Me.FindForm) Is ReportFormBase Then
                    tmpFrom = "FROM " + TableName
                    tmpWhere = IIf(Me.AdditionalWhere <> "", "WHERE " + Me.AdditionalWhere, "")
                End If



                pQuery = String.Format("{0} {1} {2} {3}", pQuery, tmpFrom, tmpWhere, tmpOrderBy)
            End If

        Catch ex As Exception

        End Try


    End Sub

End Class
