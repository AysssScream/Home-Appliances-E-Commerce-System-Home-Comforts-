Imports DevExpress.XtraEditors

Public Class DateEdit : Inherits DevExpress.XtraEditors.DateEdit
    Private pTableName As String
    Private pTableField As String
    Private pDefaultDate As Boolean

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
    <System.ComponentModel.DefaultValue(False)> _
    Public Property IsBlankDate() As Boolean
        Get
            Return pDefaultDate
        End Get
        Set(ByVal value As Boolean)
            pDefaultDate = value
        End Set
    End Property
    Private Sub DateEdit_Spin(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.SpinEventArgs) Handles Me.Spin
        e.Handled = True
    End Sub
End Class
