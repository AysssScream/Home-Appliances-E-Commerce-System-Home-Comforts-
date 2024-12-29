Imports System.Data.Common
Imports System.Windows
Imports System.Data
Imports MySql.Data
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DatabaseConnection
    Private Testing As Boolean
    Private serverType As String
    Private providerType As DataProviderType
    Private tripleDES As ClsTripleDES

    Public Sub New()

        providerType = DataProviderType.Mysql

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        HeaderPanel.BackColor = Colors.black
        ButtonClose.IconColor = Colors.white

    End Sub

    Private Function TestConnection(Optional ByVal ShowTestConfirmation As Boolean = True) As Boolean
        Dim connStr As String = ""
        Dim conn As DbConnection
        Try

            conn = New MySqlConnection() ''DBFactory.GetConnection(DataProviderType.Mysql)
            conn.ConnectionString = String.Format("server={0};database={1};user id={2};password={3}", txtServerName.EditValue, cboDatabaseName.EditValue, txtUser.EditValue, txtPassword.EditValue)
            providerType = DataProviderType.Mysql

            conn.Open()
            If ShowTestConfirmation Then
                MsgBox("Successfully Connected to Database...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Database Settings")
            End If

            Return True
        Catch ex As Exception
            MsgBox("Invalid Database settings...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Invalid Settings")
            Return False
        Finally
            conn.Close()
            conn = Nothing
        End Try
    End Function

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub DatabaseConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            tripleDES = New ClsTripleDES

            serverType = If(IsNothing(GetValueFromRegistry("Database Settings", "Server Type")), "", GetValueFromRegistry("Database Settings", "Server Type").ToString)

            If serverType <> String.Empty Then
                providerType = DataProviderType.Mysql
                txtServerName.EditValue = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "Server Name"))
                txtUser.EditValue = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "User"))
                txtPassword.EditValue = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "Password"))
                cboDatabaseName.EditValue = tripleDES.Decrypt(GetValueFromRegistry("Database Settings", "Database Name"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        TestConnection()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If TestConnection(False) Then

                WriteValueToRegistry("Database Settings", "Server Type", "Mysql", Microsoft.Win32.RegistryValueKind.String)
                WriteValueToRegistry("Database Settings", "Server Name", tripleDES.Encrypt(txtServerName.EditValue), Microsoft.Win32.RegistryValueKind.Binary)
                WriteValueToRegistry("Database Settings", "User", tripleDES.Encrypt(txtUser.EditValue), Microsoft.Win32.RegistryValueKind.Binary)
                WriteValueToRegistry("Database Settings", "Password", tripleDES.Encrypt(txtPassword.EditValue), Microsoft.Win32.RegistryValueKind.Binary)
                WriteValueToRegistry("Database Settings", "Database Name", tripleDES.Encrypt(cboDatabaseName.EditValue), Microsoft.Win32.RegistryValueKind.Binary)

                With ApplicationSettings.Instance
                    AppData = New DataManager(.GetProviderType, .GetConnectionStringFromRegistry)
                End With

                MsgBox("Database Settings Saved...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Settings Saved")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else
                MsgBox("Invalid Database Settings," + vbCrLf +
                "Please check settings...", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Invalid Settings")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Try
            filelocation.EditValue = ShowOpenFileDialog("Locate Database File", "", "SQL Source File|*.sql")
        Catch ex As Exception

        End Try
    End Sub
End Class
