Imports System.IO
Imports System.Reflection
Imports System.Xml


Public Class ApplicationSettings
    Private Shared _instance As ApplicationSettings

    Private Const PROJECT_SETTINGS_FILENAME = "SysConfig.Exe"
    Private Const XML_ROOT = "System"
    Private Const XML_NODE_PREFIX = "Settings"
    Private _XMLPath As String
    Private _AppPath As String
    Private _ExeName As String


    Private _SettingsLoaded As Boolean




    Private Sub GetConfigFilePath()

        _AppPath = System.Reflection.Assembly.GetExecutingAssembly.Location
        _ExeName = Dir(_AppPath)
        _AppPath = Path.GetFullPath((Left(_AppPath, (Len(_AppPath) - Len(_ExeName)))))

        _XMLPath = _AppPath & PROJECT_SETTINGS_FILENAME

    End Sub

    Public Sub LoadConfig()

        GetConfigFilePath()
        Try
            If File.Exists(_XMLPath) Then
                SystemSettings = New XmlDocument
                SystemSettings.Load(_XMLPath)
            Else
                SystemSettings = XmlHelper.CreateXmlDocument(XML_ROOT)
                SaveConfigFile()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            If File.Exists(_XMLPath) Then Kill(_XMLPath)
            SystemSettings = XmlHelper.CreateXmlDocument(XML_ROOT)
            SaveConfigFile()
        End Try


        LoadDBSettings()

        _SettingsLoaded = True
    End Sub

    Public Sub SaveConfigFile()
        'SystemSettings.Save(_XMLPath)
    End Sub

    Public Function GetSettings(ByVal xPath As String, ByVal field As String) As String
        Dim sValue As String = XmlHelper.QueryScalar(SystemSettings, xPath, field)
        Return IIf(sValue Is Nothing, "", sValue)
    End Function

    Public Sub LoadDBSettings()

        Dim tmpUserName As String, tmpPassword As String, tmpHostName As String, tmpDatabaseName As String
        Dim xbasePath As String = "Settings[@Name='Database Settings']/"
        With ApplicationSettings.Instance
            tmpHostName = .GetSettings(xbasePath + "Hostname", "Value")
            tmpDatabaseName = .GetSettings(xbasePath + "Database", "Value")
            tmpUserName = .GetSettings(xbasePath + "Username", "Value")
            tmpPassword = .GetSettings(xbasePath + "Password", "Value")
            'Dim TMPrOOT As XmlNode = SystemSettings.SelectSingleNode("/" + XML_ROOT)
            If Not IsEmptyString(tmpHostName) AndAlso Not IsEmptyString(tmpDatabaseName) _
                AndAlso Not IsEmptyString(tmpUserName) AndAlso Not IsEmptyString(tmpPassword) Then
                DBConnectionString = "server=" + tmpHostName + ";database=" + tmpDatabaseName + ";user id=" + tmpUserName + ";password=" + tmpPassword
            Else
                DBConnectionString = ""
            End If

        End With

    End Sub

    Public Function GetConnectionStringFromRegistry() As String
        Dim connString As String = ""
        Try
            Dim tripleDES As ClsTripleDES = New ClsTripleDES
            Dim dbserver As String = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "Server Name"))
            Dim dbuser As String = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "User"))
            Dim dbpass As String = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "Password"))
            Dim dbname As String = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "Database Name"))
            connString = String.Format("server={0};database={1};user id={2};password={3};Old Guids=true;Pooling=False;Connection Timeout=10000;", dbserver, dbname, dbuser, dbpass)

        Catch ex As Exception
            connString = ""
        End Try
        Return connString
    End Function

    Public Function GetProviderType() As DataProviderType
        Try
            Dim tripleDES As clsTripleDES = New clsTripleDES
            Return DataProviderType.Mysql
        Catch ex As Exception

        End Try

    End Function

    Public Shared Function Instance() As ApplicationSettings
        If _instance Is Nothing Then
            _instance = New ApplicationSettings
        End If

        Return _instance
    End Function

    Private Sub New()
        '+=======================+
        '| prevent instantiation |
        '+=======================+
    End Sub

    Protected Overrides Sub Finalize()
        SaveConfigFile()
        MyBase.Finalize()
    End Sub
End Class
