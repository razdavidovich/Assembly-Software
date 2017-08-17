Imports System.Data.SqlClient

Friend Class Connection

    Private Shared Conn As SqlConnection
    Private Shared strConnectionString As String

    ''' <summary>
    ''' Default shared class constructor
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub New()
        Dim sb As New System.Text.StringBuilder
        Try
            'Get the configuration information from the App.Config file
            'and generate the database connection string
            sb.Append(Config.ReadConfigValue("ConnectionString", "Settings", "Database"))
            sb.Append(";uid=" + Config.ReadConfigValue("UserID", "Settings", "Database"))
            sb.Append(";Pwd=" + clsHashEncrypt.DecodeString(Config.ReadConfigValue("Password", "Settings", "Database")))

            'Set the connection string
            strConnectionString = sb.ToString

            Conn = New SqlConnection
            Conn.ConnectionString = strConnectionString

        Catch ex As Exception
            'Pass the exception to the caller
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' This method is used for opening a connection to the database, based on the local connection string
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub OpenConnection()
        Try
            'Check the objects connection state
            If Conn.State = ConnectionState.Closed Then
                'Open the connection
                Conn.Open()
            End If
        Catch ex As Exception
            'Pass the exception to the caller
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' This method is used for closing the database connection
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CloseConnection()
        Try
            'Close the connection
            Conn.Close()
        Catch ex As Exception
            'Pass the exception to the caller
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' This method is checking if an open connection is availible, if not, it trys to open and return an open connection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConnection() As SqlConnection
        'Check the objects connection state
        If Conn.State = ConnectionState.Closed Then
            'Open a connection to the datbase
            Try
                OpenConnection()
            Catch ex As Exception
                Throw ex
            End Try
        End If

        'Return the connection
        Return Conn

    End Function

#Region " Class shared properties"

    ''' <summary>
    ''' This read only property returns the current connection string that has been extracted from the configuration file.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ConnectionString() As String
        Get
            'Return the connection string
            Return strConnectionString
        End Get
        Set(ByVal value As String)
            strConnectionString = value
            Conn.ConnectionString = strConnectionString
        End Set
    End Property

#End Region

End Class
