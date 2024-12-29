Imports System.Data.Common
Imports System.Data
Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient

Public NotInheritable Class DataManager
    'Private dbConn As DbConnection
    Private strConnectionString As [String]
    Private dataProviderType As DataProviderType

    Public Sub New(ByVal providerType As DataProviderType, ByVal connectionString As String)
        Me.strConnectionString = connectionString
        Me.dataProviderType = providerType
        'dbConn = DBFactory.GetConnection(providerType)
        'dbConn.ConnectionString = connectionString
    End Sub

    Public Function TryConnect() As Boolean
        Dim cur As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor
        Using conn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)

            Try
                conn.ConnectionString = Me.strConnectionString
                conn.Open()
                Return True
            Catch
                Return False
            Finally
                conn.Close()
            End Try
        End Using
    End Function

    'Public Sub Open()
    '    If Me.Connection.State <> System.Data.ConnectionState.Open Then
    '        Me.Connection.Open()
    '    End If
    'End Sub

    'Public Sub Close()
    '    If Me.Connection.State <> System.Data.ConnectionState.Open Then
    '        Me.Connection.Close()
    '    End If
    'End Sub


    'Public ReadOnly Property Connection() As DbConnection
    '    Get
    '        Return
    '    End Get
    'End Property

    Public ReadOnly Property ConnectionString() As [String]
        Get
            Return strConnectionString
        End Get
    End Property

    Public ReadOnly Property DBProvider() As DataProviderType
        Get
            Return dataProviderType
        End Get
    End Property

    Public Function GetDataSet(ByVal query As String) As DataSet
        Return GetDataSet(query, CommandType.Text)
    End Function

    Public Function GetDataSet(ByVal query As String, ByVal CommandType As CommandType) As DataSet
        Return GetDataSet(query, CommandType, Nothing)
    End Function

    Public Function GetDataSet(ByVal sqlString As [String], ByVal CommandType As CommandType, ByVal ParamArray Parameters() As DbParameter) As DataSet
        Using dbConn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)
            dbConn.ConnectionString = Me.ConnectionString
            Using dbDataAdapter As DbDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(Me.DBProvider)
                Try
                    With dbDataAdapter
                        .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(Me.DBProvider)
                        .SelectCommand.CommandType = CommandType
                        .SelectCommand.CommandText = sqlString
                        If Not IsNothing(Parameters) Then _
                           .SelectCommand.Parameters.AddRange(Parameters)
                        .SelectCommand.Connection = dbConn
                    End With
                    dbConn.Open()

                    Dim dataSet As New DataSet()
                    Dim dataTable As New DataTable()
                    dataTable.BeginLoadData()
                    dbDataAdapter.Fill(dataTable)
                    dataTable.EndLoadData()
                    dataSet.EnforceConstraints = False
                    dataSet.Tables.Add(dataTable)
                    Return dataSet

                Catch ex As Exception
                    Return Nothing
                Finally
                    dbConn.Close()
                End Try
            End Using
        End Using

    End Function

    Public Function ExecuteReader(ByVal query As String) As DbDataReader
        Return ExecuteReader(query, CommandType.Text)
    End Function

    Public Function ExecuteReader(ByVal query As String, ByVal CommandType As CommandType) As DbDataReader
        Return ExecuteReader(query, CommandType.Text, Nothing)
    End Function

    Public Function ExecuteReader(ByVal sqlString As [String], ByVal CommandType As CommandType, ByVal ParamArray Parameters() As DbParameter) As DbDataReader
        Dim DataReader As DbDataReader
        Using dbConn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)
            dbConn.ConnectionString = Me.ConnectionString
            Using DbCommand As DbCommand = New MySqlCommand() ''DBFactory.GetCommand(Me.DBProvider)
                Try
                    With DbCommand
                        .CommandType = CommandType
                        .CommandText = sqlString
                        If Not IsNothing(Parameters) Then _
                           .Parameters.AddRange(Parameters)
                        .Connection = dbConn
                    End With
                    dbConn.Open()
                    DataReader = DbCommand.ExecuteReader
                    Return DataReader

                Catch ex As Exception
                    Return Nothing
                Finally
                    dbConn.Close()
                End Try
            End Using
        End Using


    End Function

    Public Function ExecuteScalar(ByVal query As String) As Object
        Return ExecuteScalar(query, CommandType.Text)
    End Function

    Public Function ExecuteScalar(ByVal query As String, ByVal CommandType As CommandType) As Object
        Return ExecuteScalar(query, CommandType.Text, Nothing)
    End Function

    Public Function ExecuteScalar(ByVal sqlString As [String], ByVal CommandType As CommandType, ByVal ParamArray Parameters() As DbParameter) As Object
        Dim Result As Object
        Using dbConn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)
            dbConn.ConnectionString = Me.ConnectionString
            Using DbCmd As DbCommand = New MySqlCommand() ''DBFactory.GetCommand(Me.DBProvider)
                Try
                    With DbCmd
                        .CommandType = CommandType
                        .CommandText = sqlString
                        If Not IsNothing(Parameters) Then _
                           .Parameters.AddRange(Parameters)
                        .Connection = dbConn
                    End With
                    dbConn.Open()

                    Result = DbCmd.ExecuteScalar
                    Return Result

                Catch ex As Exception
                    Return Nothing
                Finally
                    dbConn.Close()
                End Try
            End Using
        End Using


    End Function

    Public Function ExecuteNonQuery(ByVal query As String) As Long
        Return ExecuteNonQuery(query, CommandType.Text)
    End Function

    Public Function ExecuteNonQuery(ByVal query As String, ByVal CommandType As CommandType) As Long
        Return ExecuteNonQuery(query, CommandType.Text, Nothing)
    End Function

    Public Function ExecuteNonQuery(ByVal sqlString As [String], ByVal CommandType As CommandType, ByVal ParamArray Parameters() As DbParameter) As Long
        Dim Result As Long = -1
        Using dbConn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)
            dbConn.ConnectionString = Me.ConnectionString
            Using DbCommand As DbCommand = New MySqlCommand() ''DBFactory.GetCommand(Me.DBProvider)

                Try
                    Dim conn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)
                    conn.ConnectionString = Me.ConnectionString
                    If conn.State <> System.Data.ConnectionState.Open Then
                        conn.Open()
                    End If
                    With DbCommand
                        .CommandType = CommandType
                        .CommandText = sqlString
                        If Not IsNothing(Parameters) Then _
                           .Parameters.AddRange(Parameters)
                        .Connection = dbConn
                    End With
                    dbConn.Open()
                    Result = DbCommand.ExecuteNonQuery
                    Return Result

                Catch ex As Exception

                Finally
                    dbConn.Close()

                End Try
            End Using
        End Using


    End Function

    Public Function GetDataTable(ByVal query As String) As DataTable
        Return GetDataTable(query, CommandType.Text)
    End Function

    Public Function GetDataTable(ByVal query As String, ByVal CommandType As CommandType) As DataTable
        Return GetDataTable(query, CommandType.Text, Nothing)
    End Function

    Public Function GetDataTable(ByVal sqlString As [String], ByVal CommandType As CommandType, ByVal ParamArray Parameters() As DbParameter) As DataTable
        Using dbConn As DbConnection = New MySqlConnection() ''DBFactory.GetConnection(Me.DBProvider)
            dbConn.ConnectionString = Me.ConnectionString
            Using dbDataAdapter As DbDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(Me.DBProvider)
                Try
                    With dbDataAdapter
                        .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(Me.DBProvider)
                        .SelectCommand.CommandType = CommandType
                        .SelectCommand.CommandText = sqlString
                        If Not IsNothing(Parameters) Then _
                            .SelectCommand.Parameters.AddRange(Parameters)
                        .SelectCommand.Connection = dbConn
                    End With
                    dbConn.Open()
                    Dim dataTable As New DataTable()
                    dataTable.BeginLoadData()
                    dbDataAdapter.Fill(dataTable)
                    dataTable.EndLoadData()
                    Return dataTable

                Catch ex As Exception
                    Return Nothing
                Finally
                    dbConn.Close()
                End Try
            End Using
        End Using

    End Function

End Class

