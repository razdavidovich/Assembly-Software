Imports Assembly.Software.Base.Tables
Imports Assembly.Software.Utilities
Imports System.Data.SqlClient


Public Class frmMain

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        General.ConnectionString = GetConnectionString()

        Dim prmSQLParams As SqlParameter() = {New SqlParameter("@intOrganizationID", SqlDbType.Int, 4)}
        Dim objValues As Object() = New Object() {10}

        Dim frm As New frmBaseTables(General.ConnectionString, prmSQLParams, objValues)

        frm.Show()

    End Sub

    Public Function GetConnectionString() As String
        '*************************************************************************************
        '* NAME:        GetConnectionString
        '* DESCRIPTION: Function Generates connection string according to Config File
        '*                                                                                   
        '*                                                                                       
        '* WRITTEN BY:  Zvika Oscar                                                              
        '* DATE:        28/01/2008                                                               
        '************************************************************************************

        Dim strResult As String
        Try
            'Get the configuration information from the App.Config file
            'and generate the database connection string


            'Set the connection string
            strResult = GenerateConnectionString(Config.ReadConfigValue("ServerName", "Settings", "Database"), _
                                Config.ReadConfigValue("Database", "Settings", "Database"), _
                                Config.ReadConfigValue("UserID", "Settings", "Database"), _
                                clsHashEncrypt.DecodeString(Config.ReadConfigValue("Password", "Settings", "Database")))

            Return strResult

        Catch ex As Exception
            'Pass the exception to the caller
            Throw ex
        End Try

    End Function

    Private Function GenerateConnectionString(ByVal strServerName As String, ByVal strDatabaseName As String, _
                                              ByVal strUserName As String, ByVal strDecodedPassword As String) As String
        '*************************************************************************************
        '* NAME:        GenerateConnectionString
        '* DESCRIPTION: Function Generates connection string according to given params
        '*                                                                                   
        '*                                                                                       
        '* WRITTEN BY:  Zvika Oscar                                                              
        '* DATE:        30/01/2008                                                               
        '************************************************************************************

        Dim sb As New System.Text.StringBuilder

        'Get the configuration information from the App.Config file
        'and generate the database connection string
        sb.Append("Data Source=" + strServerName)
        sb.Append(";Initial Catalog=" + strDatabaseName)
        sb.Append(";User ID=" + strUserName)
        sb.Append(";Password=" + strDecodedPassword)

        'Set the connection string
        Return sb.ToString

    End Function
End Class
