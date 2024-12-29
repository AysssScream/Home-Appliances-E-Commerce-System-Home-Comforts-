Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
'Imports System.Data.OracleClient
Imports System.IO
Imports MySql.Data
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class DBHelper
    Implements IDisposable

    Private strConnectionString As String
    Private objConnection As DbConnection
    Private objCommand As DbCommand
    Private objFactory As DbProviderFactory = Nothing
    Private boolHandleErrors As Boolean
    Private strLastError As String
    Private boolLogError As Boolean
    Private strLogFile As String
    Private pCallSource As String


    Public Sub New(ByVal connectionstring As String)
        strConnectionString = connectionstring + ";default command timeout=300;Allow Zero Datetime=True;Convert Zero Datetime=true;Old Guids=true;"
        objFactory = MySqlClient.MySqlClientFactory.Instance

        objConnection = objFactory.CreateConnection
        objCommand = objFactory.CreateCommand
        objConnection.ConnectionString = strConnectionString
        objCommand.Connection = objConnection
    End Sub

    Public Sub New()
        'MyClass.New(ConfigurationManager.ConnectionStrings("connectionstring").ConnectionString, Providers.ConfigDefined)
    End Sub

    Public Function TryConnect() As Boolean
        Return TryConnect(strConnectionString)
    End Function

    Public Function TryConnect(ByVal ConnStr As String, Optional ByVal ShowConfirmation As Boolean = False) As Boolean
        Dim cur As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor
        Using connection As MySqlConnection = New MySqlConnection(ConnStr)
            Try
                connection.Open()
                connection.Close()
                If ShowConfirmation Then XtraMessageBox.Show("Test connection succeeded.", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch
                If ShowConfirmation Then XtraMessageBox.Show("Test connection failed.", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False

            Finally
                Cursor.Current = cur
            End Try
        End Using
        Return True
    End Function

    <DefaultValue(True)>
    Public Property HandleErrors() As Boolean
        Get
            Return boolHandleErrors
        End Get
        Set(ByVal value As Boolean)
            boolHandleErrors = value
        End Set
    End Property

    Public ReadOnly Property LastError() As String
        Get
            Return strLastError
        End Get
    End Property

    Public Property LogErrors() As Boolean
        Get
            Return boolLogError
        End Get
        Set(ByVal value As Boolean)
            boolLogError = value
        End Set
    End Property

    Public Property LogFile() As String
        Get
            Return strLogFile
        End Get
        Set(ByVal value As String)
            strLogFile = value
        End Set
    End Property

    Public Function AddParameter(ByVal name As String, ByVal value As Object) As Integer
        Dim p As DbParameter = objFactory.CreateParameter
        p.ParameterName = name
        p.Value = value
        Return objCommand.Parameters.Add(p)
    End Function

    Public Function AddParameter(ByVal parameter As DbParameter) As Integer
        Return objCommand.Parameters.Add(parameter)
    End Function

    Public ReadOnly Property Command() As DbCommand
        Get
            Return objCommand
        End Get
    End Property

    Public Sub BeginTransaction()
        If objConnection.State = System.Data.ConnectionState.Closed Then
            objConnection.Open()
        End If
        objCommand.Transaction = objConnection.BeginTransaction
    End Sub

    Public Sub CommitTransaction()
        objCommand.Transaction.Commit()
        objConnection.Close()
    End Sub

    Public Sub RollbackTransaction()
        objCommand.Transaction.Rollback()
        objConnection.Close()
    End Sub

    Public Function ExecuteNonQuery(ByVal query As String) As Integer
        Return ExecuteNonQuery(query, CommandType.Text, ConnectionState.CloseOnExit)
    End Function

    Public Function ExecuteNonQuery(ByVal query As String, ByVal commandtype As CommandType) As Integer
        Return ExecuteNonQuery(query, commandtype, ConnectionState.CloseOnExit)
    End Function

    Public Function ExecuteNonQuery(ByVal query As String, ByVal connectionstate As ConnectionState) As Integer
        Return ExecuteNonQuery(query, CommandType.Text, connectionstate)
    End Function

    Public Function ExecuteNonQuery(ByVal query As String, ByVal commandtype As CommandType, ByVal connectionstate As ConnectionState) As Integer
        objCommand.CommandText = query
        objCommand.CommandType = commandtype
        Dim i As Integer = -1
        Try
            If objConnection.State = System.Data.ConnectionState.Closed Then
                objConnection.Open()
            End If
            i = objCommand.ExecuteNonQuery
        Catch ex As Exception
            HandleExceptions(ex)
        Finally
            objCommand.Parameters.Clear()
            If connectionstate = ConnectionState.CloseOnExit Then
                objConnection.Close()
            End If
        End Try
        Return i
    End Function

    Public Function ExecuteScalar(ByVal query As String) As Object
        Return ExecuteScalar(query, CommandType.Text, ConnectionState.CloseOnExit)
    End Function

    Public Function ExecuteScalar(ByVal query As String, ByVal commandtype As CommandType) As Object
        Return ExecuteScalar(query, commandtype, ConnectionState.CloseOnExit)
    End Function

    Public Function ExecuteScalar(ByVal query As String, ByVal connectionstate As ConnectionState) As Object
        Return ExecuteScalar(query, CommandType.Text, connectionstate)
    End Function

    Public Function ExecuteScalar(ByVal query As String, ByVal commandtype As CommandType, ByVal connectionstate As ConnectionState) As Object
        objCommand.CommandText = query
        objCommand.CommandType = commandtype
        Dim o As Object = Nothing
        Try
            If objConnection.State = System.Data.ConnectionState.Closed Then
                objConnection.Open()
            End If
            o = objCommand.ExecuteScalar
        Catch ex As Exception
            HandleExceptions(ex)
        Finally
            objCommand.Parameters.Clear()
            If connectionstate = ConnectionState.CloseOnExit Then
                objConnection.Close()
            End If
        End Try
        Return o
    End Function

    Public Function ExecuteReader(ByVal query As String) As DbDataReader
        Return ExecuteReader(query, CommandType.Text, ConnectionState.CloseOnExit)
    End Function

    Public Function ExecuteReader(ByVal query As String, ByVal commandtype As CommandType) As DbDataReader
        Return ExecuteReader(query, commandtype, ConnectionState.CloseOnExit)
    End Function

    Public Function ExecuteReader(ByVal query As String, ByVal connectionstate As ConnectionState) As DbDataReader
        Return ExecuteReader(query, CommandType.Text, connectionstate)
    End Function

    Public Function ExecuteReader(ByVal query As String, ByVal commandtype As CommandType, ByVal connectionstate As ConnectionState) As DbDataReader
        objCommand.CommandText = query
        objCommand.CommandType = commandtype
        Dim reader As DbDataReader = Nothing
        Try
            If objConnection.State = System.Data.ConnectionState.Closed Then
                objConnection.Open()
            End If
            If connectionstate = ConnectionState.CloseOnExit Then
                reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
            Else
                reader = objCommand.ExecuteReader
            End If
        Catch ex As Exception
            HandleExceptions(ex)
        Finally
            objCommand.Parameters.Clear()
        End Try
        Return reader
    End Function

    Public Function GetDataSet(ByVal query As String) As DataSet
        Return GetDataSet(query, CommandType.Text, ConnectionState.CloseOnExit)
    End Function

    Public Function GetDataSet(ByVal query As String, ByVal commandtype As CommandType) As DataSet
        Return GetDataSet(query, commandtype, ConnectionState.CloseOnExit)
    End Function

    Public Function GetDataSet(ByVal query As String, ByVal connectionstate As ConnectionState) As DataSet
        Return GetDataSet(query, CommandType.Text, connectionstate)
    End Function

    Public Function GetDataSet(ByVal query As String, ByVal commandtype As CommandType, ByVal connectionstate As ConnectionState) As DataSet

        Dim adapter As DbDataAdapter = objFactory.CreateDataAdapter
        objCommand.CommandText = query
        objCommand.CommandType = commandtype
        adapter.SelectCommand = objCommand
        Dim ds As DataSet = New DataSet
        Try
            If objConnection.State = System.Data.ConnectionState.Closed Then
                objConnection.Open()
            End If

            adapter.Fill(ds)
        Catch ex As Exception
            HandleExceptions(ex)
        Finally
            objCommand.Parameters.Clear()
            If connectionstate = ConnectionState.CloseOnExit Then
                If objConnection.State = System.Data.ConnectionState.Open Then
                    objConnection.Close()
                End If
            End If
        End Try
        Return ds
    End Function

    Public Function GetDataAdapter() As DbDataAdapter
        Return objFactory.CreateDataAdapter
    End Function

    Public Function GetCommandBuilder() As DbCommandBuilder
        Return objFactory.CreateCommandBuilder()
    End Function

    Public Function GetCommand() As DbCommand
        Return objFactory.CreateCommand
    End Function

    Public Function GetConnection() As DbConnection
        Return objFactory.CreateConnection
    End Function

    'Public Function GetConnection(ByVal ConnectionString As String) As DbConnection
    '    Return objFactory.CreateConnection
    'End Function

    Public Function GetConnectionString() As String
        Return strConnectionString
    End Function

    Public Property CallSource() As String
        Get
            Return pCallSource
        End Get
        Set(ByVal value As String)
            pCallSource = value
        End Set
    End Property

    Private Sub HandleExceptions(ByVal ex As Exception)

        If LogErrors Then
            WriteToLog(ex.Message)
        End If
        If HandleErrors Then
            strLastError = ex.Message
            XtraMessageBox.Show(ex.Message, "Error Source: " + pCallSource, MessageBoxButtons.OK)
        Else
            Throw ex
        End If
    End Sub

    Private Sub WriteToLog(ByVal msg As String)
        Dim writer As StreamWriter = File.AppendText(LogFile)
        writer.WriteLine(String.Format("{0} - {1}", DateTime.Now, msg))
        writer.Close()
    End Sub

    Public Sub Dispose1() Implements System.IDisposable.Dispose
        objConnection.Close()
        objConnection.Dispose()
        objCommand.Dispose()
    End Sub
End Class

Public Enum Providers
    SqlServer
    OleDb
    Oracle
    ODBC
    ConfigDefined
    Mysql
End Enum

Public Enum ConnectionState
    KeepOpen
    CloseOnExit
End Enum

