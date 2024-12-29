Imports DevExpress.XtraEditors

Public Class PictureEdit : Inherits DevExpress.XtraEditors.PictureEdit
    Private pTableName As String
    Friend WithEvents fProperties As Repository.RepositoryItemPictureEdit
    Private pTableField As String


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

    Private Sub InitializeComponent()
        Me.fProperties = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        CType(Me.fProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fProperties
        '
        Me.fProperties.Name = "fProperties"
        CType(Me.fProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
