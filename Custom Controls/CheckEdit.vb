Imports DevExpress.XtraEditors

Public Class CheckEdit : Inherits DevExpress.XtraEditors.CheckEdit

    Private _TableField As String
    Private _TableName As String

    Public Property TableName() As String
        Get
            Return GetLowerCaseString(_TableName) 'IIf(IsNothing(_TableName) OrElse String.IsNullOrEmpty(_TableName), "", _TableName.ToLower)
        End Get
        Set(ByVal value As String)
            _TableName = value
        End Set
    End Property

    Public Property TableField() As String
        Get
            Return GetLowerCaseString(_TableField) 'IIf(IsNothing(_TableField) OrElse String.IsNullOrEmpty(_TableField), "", _TableField.ToLower)
        End Get
        Set(ByVal value As String)
            _TableField = value
        End Set
    End Property

End Class
