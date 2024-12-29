Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient

Public Enum DataProviderType
    Mysql
    SqlServer
    OleDb
    Odbc
End Enum

Friend Class DBFactory
    Private Shared objFactory As DbProviderFactory = Nothing

    Public Shared Function GetDataProvider(ByVal provider As DataProviderType) As DbProviderFactory
        Return MySqlClientFactory.Instance
        'Select Case provider
        '    Case DataProviderType.SqlServer
        '        objFactory = SqlClientFactory.Instance
        '        Exit Select
        '    Case DataProviderType.OleDb
        '        objFactory = OleDbFactory.Instance
        '        Exit Select
        '    Case DataProviderType.Mysql
        '        objFactory = MySqlClientFactory.Instance
        '        Exit Select
        '    Case DataProviderType.Odbc
        '        objFactory = OdbcFactory.Instance
        '        Exit Select
        'End Select
        'Return objFactory
    End Function

    Public Shared Function GetConnection(Optional ByVal providerType__1 As DataProviderType = DataProviderType.Mysql) As DbConnection
        Return New MySqlConnection()
        'Select Case providerType__1
        '    Case DataProviderType.SqlServer
        '        Return New SqlConnection()
        '    Case DataProviderType.OleDb
        '        Return New OleDbConnection()
        '    Case DataProviderType.Odbc
        '        Return New OdbcConnection()
        '    Case DataProviderType.Mysql
        '        Return New MySqlConnection()
        '    Case Else
        '        Return Nothing
        'End Select
    End Function

    Public Shared Function GetParameter(Optional ByVal providerType__1 As DataProviderType = DataProviderType.Mysql) As DbParameter
        Return New MySqlParameter()
        'Select Case providerType__1
        '    Case DataProviderType.SqlServer
        '        Return New SqlParameter()
        '    Case DataProviderType.OleDb
        '        Return New OleDbParameter()
        '    Case DataProviderType.Odbc
        '        Return New OdbcParameter()
        '    Case DataProviderType.Mysql
        '        Return New MySqlParameter()
        '    Case Else
        '        Return Nothing
        'End Select
    End Function

    Public Shared Function GetCommand(Optional ByVal providerType As DataProviderType = DataProviderType.Mysql) As DbCommand
        Return New MySqlCommand()
        'Select Case providerType
        '    Case DataProviderType.SqlServer
        '        Return New SqlCommand()
        '    Case DataProviderType.OleDb
        '        Return New OleDbCommand()
        '    Case DataProviderType.Odbc
        '        Return New OdbcCommand()
        '    Case DataProviderType.Mysql
        '        Return New MySqlCommand()
        '    Case Else
        '        Return Nothing
        'End Select
    End Function

    Public Shared Function GetCommandBuilder(Optional ByVal providerType As DataProviderType = DataProviderType.Mysql) As DbCommandBuilder
        Return New MySqlCommandBuilder()
        'Select Case providerType
        '    Case DataProviderType.SqlServer
        '        Return New SqlCommandBuilder()
        '    Case DataProviderType.OleDb
        '        Return New OleDbCommandBuilder()
        '    Case DataProviderType.Odbc
        '        Return New OdbcCommandBuilder()
        '    Case DataProviderType.Mysql
        '        Return New MySqlCommandBuilder()
        '    Case Else
        '        Return Nothing
        'End Select
    End Function

    Public Shared Function GetDataAdapter(Optional ByVal providerType As DataProviderType = DataProviderType.Mysql) As DbDataAdapter
        Return New MySqlDataAdapter()
        'Select Case providerType
        '    Case DataProviderType.SqlServer
        '        Return New SqlDataAdapter()
        '    Case DataProviderType.OleDb
        '        Return New OleDbDataAdapter()
        '    Case DataProviderType.Odbc
        '        Return New OdbcDataAdapter()
        '    Case DataProviderType.Mysql
        '        Return New MySqlDataAdapter()
        '    Case Else
        '        Return Nothing
        'End Select
    End Function
End Class
