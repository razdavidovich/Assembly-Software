Imports System.Data.SqlClient
Imports Assembly.Software.Utilities

Module General

    Public connObj As SqlConnection = New SqlConnection
    Public intEmployeeID As Integer = -1
    Public strFullUserName As String = vbNullString

    Public Function GetUserName(ByVal strUserName As String) As String
        '**********************************************************************
        '* NAME:        GetUserName                                           *
        '* DESCRIPTION: This function returns that real user name in hebrew   *
        '*              based on the authenticated user to the web site       *
        '* WRITEN BY:   Raz Davidovich                                        *
        '* DATE:        02/05/2003                                            *
        '********************************************************************** 
        Dim commObj As SqlCommand = New SqlCommand
        Dim param1 As SqlParameter

        'Get the real user name from the database
        'Get the user tasks from the stored procedure
        OpenConnectionToDatbase()

        commObj.Connection = connObj
        commObj.CommandText = "GetUserInfo_sp"
        commObj.CommandType = CommandType.StoredProcedure

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@strDomainUserName", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = strUserName
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@intUserID", SqlDbType.Int)
        param1.Direction = ParameterDirection.Output
        commObj.Parameters.Add(param1)

        'Set the  parameter for the stored procedure.
        param1 = New SqlParameter("@vchFullUserName", SqlDbType.VarChar, 30)
        param1.Direction = ParameterDirection.Output
        commObj.Parameters.Add(param1)

        'Run the stored procedure
        Try
            'Run the SP
            commObj.ExecuteNonQuery()

            'Get the employee ID
            intEmployeeID = CInt(commObj.Parameters(1).Value)

            'Return the full user name and save it to a global variable
            strFullUserName = commObj.Parameters(2).Value.ToString
            GetUserName = strFullUserName

        Catch ex As Exception
            Return vbNullString

        Finally
            commObj = Nothing
            param1 = Nothing

        End Try

        'Close the connection to the database
        CloseConnectionToDatbase()

    End Function

    Function OpenConnectionToDatbase() As Boolean
        '********************************************************************
        '* NAME:        OpenConnectionToDatbase                             *
        '* DESCRIPTION: This Function connects to the database              *
        '* WRITEN BY:   Adir Saharabi                                       *
        '* DATE:        25/7/2002                                           *
        '********************************************************************

        'Check the connection status
        If (connObj.State = ConnectionState.Open) Or (connObj.State = ConnectionState.Executing) _
            Or (connObj.State = ConnectionState.Fetching) Then Return True

        Try
            Dim strConnection As String = GetConnectionStringFromConfig()

            'Try to open a connection to the database
            connObj.ConnectionString = strConnection
            connObj.Open()

            'All OK, return true
            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Function CloseConnectionToDatbase() As Boolean
        '********************************************************************
        '* NAME:        CloseConnectionToDatbase                            *
        '* DESCRIPTION: This Function close the connection to the database  *
        '* WRITEN BY:   Raz Davidovich                                      *
        '* DATE:        02/02/2003                                          *
        '********************************************************************

        Try
            'Try to close the connection
            connObj.Close()

            'All OK, return true
            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function GetConnectionStringFromConfig() As String
        '*************************************************************************
        '* Function Name:   GetConnectionStringFromConfig
        '* Description:     This function is generating the connection string from 
        '*                  the application configuration file (web.config)
        '* Created by:      Raz Davidovich
        '* Created date:    11/11/2008
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim strConnectionString As String = String.Empty

        strConnectionString = "Data Source=" & Config.ReadASPConfigValue("ServerName", "Database")
        strConnectionString += ";Initial Catalog=" & Config.ReadASPConfigValue("DatabaseName", "Database")
        strConnectionString += ";uid=" & Config.ReadASPConfigValue("UserID", "Database")
        strConnectionString += ";Pwd=" & clsHashEncrypt.DecodeString(Config.ReadASPConfigValue("Password", "Database"))

        Return strConnectionString

    End Function
End Module
