Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports System.ComponentModel.Design
Imports System.Drawing.Design

Public Class GridPickListInfo : Inherits MemoEdit

    Public Event AdditionalWhereEvent(ByRef AddWhereClause As String)
    Public Event AfterReturnValues(ByVal GridName As String)

    Private _reloadonPopup As Boolean
    Private PickColumnsInfo As String = ""
    Private PickFromInfo As String = ""
    Private _name As String
    Private _ValueMember As String
    Private pickList As PickListFormBase
    Private addWhereString As String

    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))> _
    Public Property _PickColumnsInfo() As String
        Get
            Return PickColumnsInfo
        End Get
        Set(ByVal value As String)
            PickColumnsInfo = value
            Me.Text = PickColumnsInfo
        End Set
    End Property

    Public Property _PickTableFromInfo() As String
        Get
            Return PickFromInfo
        End Get
        Set(ByVal value As String)
            PickFromInfo = value
        End Set
    End Property

    Public Property ValueMember() As String
        Get
            Return _ValueMember
        End Get
        Set(ByVal value As String)
            _ValueMember = value
        End Set
    End Property

    'added harry for picklist revision
    <DefaultValue(False)> _
    Public Property ReloadPickListOnPopup() As Boolean
        Get
            Return _reloadonPopup
        End Get
        Set(ByVal value As Boolean)
            _reloadonPopup = value
        End Set
    End Property

    Private parentGrid As DetailGrid
    Public Property OwnerGrid() As DetailGrid
        Get
            Return parentGrid
        End Get
        Set(ByVal value As DetailGrid)
            parentGrid = value
        End Set
    End Property

    Public ReadOnly Property AdditionalWhere() As String
        Get
            Return addWhereString
        End Get
    End Property
    Public Event BeforeReturnValues(ByVal dr As DataRow, ByRef cancel As Boolean)
    Public ShowingPicklist As Boolean = False
    Private Sub BeforePickBaseReturnValues(ByVal dr As DataRow, ByRef cancel As Boolean)
        RaiseEvent BeforeReturnValues(dr, cancel)
    End Sub

    Private Sub AfterPickBaseReturnValues(ByVal gridname As String)
        RaiseEvent AfterReturnValues(gridname)
    End Sub
    Public Sub ShowPickList()
        'If IsNothing(pickList) Then pickList = New PickListBase4(Me)
        'If ReloadPickListOnPopup Then RaiseEvent AdditionalWhereEvent(addWhereString)
        'If pickList.ShowDialog = DialogResult.OK Then
        '    RaiseEvent AfterReturnValues(Me.OwnerGrid.Name)
        'End If
        If IsNothing(pickList) Then
            pickList = New PickListFormBase(Me)
            pickList.lblSearchHeader.Text = "Pick " & Me.Text
            AddHandler pickList.BeforeReturnValues, AddressOf Me.BeforePickBaseReturnValues
            AddHandler pickList.AfterReturnValues, AddressOf Me.AfterPickBaseReturnValues
        End If

        If ReloadPickListOnPopup Then
            RaiseEvent AdditionalWhereEvent(addWhereString)
        End If

        ShowingPicklist = True
        If pickList.ShowDialog = DialogResult.OK Then
            If Not IsNothing(Me.OwnerGrid) Then
                RaiseEvent AfterReturnValues(Me.OwnerGrid.Name)
            Else
                RaiseEvent AfterReturnValues("")
            End If

        End If
        ShowingPicklist = False
    End Sub

End Class
