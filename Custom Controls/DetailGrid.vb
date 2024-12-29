Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Columns

Public Class DetailGrid : Inherits SearchGrid

    Private _InventoryEnabled As Boolean
    Private _WithFK As Boolean
    Private _Editable As Boolean
    Private _HideAddNewRowItem As Boolean
    Private _ShowEditButton As Boolean
    Private _ShowAddToCart As Boolean
    Private _ShowDeleteButton As Boolean
    '  Private _PopUpEdit As GridPopupEditForm

    <DefaultValue(False)>
    Public Property InventoryEnabled() As Boolean
        Get
            Return _InventoryEnabled
        End Get
        Set(ByVal value As Boolean)
            _InventoryEnabled = value
        End Set
    End Property
    <DefaultValue(False)>
    Public Property DisplayOnly() As Boolean
        Get
            Return _Editable
        End Get
        Set(ByVal value As Boolean)
            _Editable = value
        End Set
    End Property
    <DefaultValue(False)>
    Public Property WithFK() As Boolean
        Get
            Return _WithFK
        End Get
        Set(ByVal value As Boolean)
            _WithFK = value
        End Set
    End Property
    <DefaultValue(False)>
    Public Property HideAddNewRowItem() As Boolean
        Get
            Return _HideAddNewRowItem
        End Get
        Set(ByVal value As Boolean)
            _HideAddNewRowItem = value
        End Set
    End Property
    <DefaultValue(False)>
    Public Property ShowEditButton() As Boolean
        Get
            Return _ShowEditButton
        End Get
        Set(ByVal value As Boolean)
            _ShowEditButton = value
        End Set
    End Property
    <DefaultValue(False)>
    Public Property ShowDeleteButton() As Boolean
        Get
            Return _ShowDeleteButton
        End Get
        Set(ByVal value As Boolean)
            _ShowDeleteButton = value
        End Set
    End Property
    <DefaultValue(False)>
    Public Property ShowAddToCart() As Boolean
        Get
            Return _ShowAddToCart
        End Get
        Set(ByVal value As Boolean)
            _ShowAddToCart = value
        End Set
    End Property

    Public Property RowPosition() As Integer
        Get
            Return DirectCast(Me.MainView, GridView).FocusedRowHandle
        End Get
        Set(ByVal value As Integer)
            DirectCast(Me.MainView, GridView).FocusedRowHandle = value
        End Set
    End Property

    Public Property Field(ByVal FieldName As String) As Object
        Get
            Dim View As GridView = DirectCast(Me.MainView, GridView)
            Return View.GetRowCellValue(View.FocusedRowHandle, FieldName.ToLower)
        End Get
        Set(ByVal value As Object)
            Dim View As GridView = DirectCast(Me.MainView, GridView)
            View.SetRowCellValue(View.FocusedRowHandle, FieldName.ToLower, value)
        End Set
    End Property

    Public ReadOnly Property FieldTotal(ByVal FieldName As String) As Decimal
        Get
            Try
                Dim View As GridView = DirectCast(Me.MainView, GridView)
                Dim tmpColumn As GridColumn = View.Columns(FieldName.ToLower)

                If Not IsNothing(tmpColumn) Then
                    Return StrVal9(tmpColumn.SummaryText)
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    'Public WriteOnly Property PopUpEditForm() As GridPopupEditForm
    '    Set(ByVal value As GridPopupEditForm)
    '        _PopUpEdit = value
    '    End Set
    'End Property
    Public ReadOnly Property RowCount()
        Get
            Try
                Return DirectCast(Me.MainView, GridView).DataRowCount
            Catch ex As Exception
                Return 0
            End Try
            'Return DirectCast(Me.MainView, GridView).DataRowCount
        End Get
    End Property

    Public Sub AddNewRow()
        DirectCast(Me.MainView, GridView).AddNewRow()
    End Sub

    Public Sub UpdateCurrentRow()
        DirectCast(Me.MainView, GridView).UpdateCurrentRow()
    End Sub

    Public Sub RefreshData()
        DirectCast(Me.MainView, GridView).RefreshData()
    End Sub
    Public ReadOnly Property GetRowHandle(ByVal DataSourceIndex As Integer) As Integer
        Get
            Return DirectCast(Me.MainView, GridView).GetRowHandle(DataSourceIndex)
        End Get
    End Property

    Public Overloads Sub DeleteRow(ByVal RowIndex As Integer)
        With DirectCast(Me.MainView, GridView)
            .DeleteRow(RowIndex)
        End With
    End Sub

    Public Overloads Sub DeleteRow()
        Try
            With DirectCast(Me.MainView, GridView)
                .DeleteRow(.FocusedRowHandle)
            End With

        Catch ex As Exception

        End Try

    End Sub

    'Public Sub ShowPopUpEditForm(ByVal State As GridPopupEditForm.PopUpEditStateEnum)
    '    If Project.Instance.EnableGridPopUpEditForm Then
    '        If Not IsNothing(_PopUpEdit) Then
    '            _PopUpEdit.PopUpEditState = State
    '            _PopUpEdit.Show(Me.FindForm)
    '        End If
    '    End If
    'End Sub

    Private Sub DetailGrid_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        ''CType(e,DevExpress.Utils.DXMouseEventArgs).Handled = true
    End Sub
End Class
