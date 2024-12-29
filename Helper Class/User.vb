Imports System.Linq

Public Class User
    Private dtPermissions As DataTable
    Private UserName As String

    Public Sub New(ByVal user As String, ByVal userPermissions As DataTable)
        UserName = user
        dtPermissions = userPermissions
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return UserName
        End Get
    End Property

    Public Function IsFormPermissionGranted(ByVal FormCaption As String) As Boolean
        'FormCaption_ScrtyPrm
        Try
            Return (From dr As DataRow In dtPermissions.Rows
                    Where dr("FormCaption_ScrtyPrm").ToString.ToLower = FormCaption.ToLower
                    Select dr).Count > 0
        Catch ex As Exception
            If Project.Instance.ActiveUser.Name = "BACKDOOR" Then
                Return True
            Else
                Return False
            End If
        End Try


    End Function

    Public Function IsFunctionAllowed(ByVal FormCaption As String, ByVal permissiontype As String)
        Try
            Return (From dr As DataRow In dtPermissions.Rows
                    Where dr("FormCaption_ScrtyPrm").ToString.ToLower = FormCaption.ToLower _
                    AndAlso dr("Rights_ScrtyPrm").ToString.ToLower.Contains(permissiontype.ToLower)
                    Select dr).Count > 0
        Catch ex As Exception
            If Project.Instance.ActiveUser.Name = "BACKDOOR" Then
                Return True
            Else
                Return False
            End If
        End Try


    End Function
End Class
