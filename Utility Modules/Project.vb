Public Class Project

    Private Shared _ProjInstance As Project
    Private _CompanyName As String
    Private _CompanyAddress As String
    Private _TIN As String
    Private _ContactNo As String
    Private _Logo As Byte()
    Private _CurrentUser As User
    Private _CurrentUserId As String
    Private _SessionId As String
    Private _CurrentUserPK As String
    Private _CurrentAccountType As String
    Private _IsPrint As Boolean
    Private _IsAutoPrint As Boolean

    Public Property CompanyName() As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property

    Public Property CompanyAddress() As String
        Get
            Return _CompanyAddress
        End Get
        Set(ByVal value As String)
            _CompanyAddress = value
        End Set
    End Property

    Public Property TIN() As String
        Get
            Return _TIN
        End Get
        Set(ByVal value As String)
            _TIN = value
        End Set
    End Property

    Public Property ContactNumber() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
        End Set
    End Property

    Public Property Logo() As Byte()
        Get
            Return _Logo
        End Get
        Set(ByVal value As Byte())
            _Logo = value
        End Set
    End Property

    Public Property ActiveUser() As User
        Get
            Return _CurrentUser
        End Get
        Set(ByVal value As User)
            _CurrentUser = value
        End Set
    End Property

    Public Property ActiveAccountType() As String
        Get
            Return _CurrentAccountType
        End Get
        Set(ByVal value As String)
            _CurrentAccountType = value
        End Set
    End Property
    Public Property ActiveUserId() As String
        Get
            Return _CurrentUserId
        End Get
        Set(ByVal value As String)
            _CurrentUserId = value
        End Set
    End Property
    Public Property SessionId() As String
        Get
            Return _SessionId
        End Get
        Set(ByVal value As String)
            _SessionId = value
        End Set
    End Property
    Public Property ActiveUserPK() As String
        Get
            Return _CurrentUserPK
        End Get
        Set(ByVal value As String)
            _CurrentUserPK = value
        End Set
    End Property

    Public ReadOnly Property ExeName() As String
        Get
            Return Process.GetCurrentProcess.ProcessName.Split(".")(0)
        End Get
    End Property

    <System.ComponentModel.DefaultValue(False)>
    Public Property IsPrint() As Boolean
        Get
            Return _IsPrint
        End Get
        Set(ByVal value As Boolean)
            _IsPrint = value
        End Set
    End Property

    <System.ComponentModel.DefaultValue(False)>
    Public Property IsAutoPrint() As Boolean
        Get
            Return _IsAutoPrint
        End Get
        Set(ByVal value As Boolean)
            _IsAutoPrint = value
        End Set
    End Property


    Private Sub New()

    End Sub

    Public Shared Function Instance() As Project
        If _ProjInstance Is Nothing Then
            _ProjInstance = New Project
        End If

        Return _ProjInstance
    End Function

End Class
