Imports System.Web.UI.WebControls
Imports Assembly.Software.Utilities
Imports Assembly.Software.DB
Imports System.Data.SqlClient

''' <summary>
''' The class is used for all database access in the new part of the web application
''' </summary>
''' <remarks>
''' Written by: Raz davidovich
''' </remarks>
Public Class clsDBAccess

    ''' <summary>
    ''' This function is generating the connection string from the application configuration file (web.config)
    ''' </summary>
    ''' <returns>The built connection string from the configuration file</returns>
    ''' <remarks>
    ''' Written by: Raz Davidovich
    ''' </remarks>
    Private Shared Function GetConnectionStringFromConfig() As String
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
        strConnectionString += ";Initial Catalog=" & Config.ReadASPConfigValue("Database", "Database")
        strConnectionString += ";uid=" & Config.ReadASPConfigValue("UserID", "Database")
        strConnectionString += ";Pwd=" & clsHashEncrypt.DecodeString(Config.ReadASPConfigValue("Password", "Database"))

        Return strConnectionString

    End Function

    Public Shared Function Fill_LO_DropDownLists(ByVal ddlCombobox As DropDownList, ByVal intMenuDay As Integer, ByVal intTypeID As Integer) As Boolean
        '*************************************************************************
        '* Function Name:   Fill_LO_DropDownLists
        '* Description:     This function is accessing the database and filling the
        '*                  given drop down list with the list items that matches
        '*                  the supplied item type
        '* Created by:      Raz Davidovich
        '* Created date:    11/11/2008
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Get the connection string from the config
        Dim dtsDataTable As DataTable
        Dim strConnectionString = GetConnectionStringFromConfig()

        Try


            Dim objDBHelper As New DBHelper(strConnectionString, DBHelper.Connection_Type.SQL_Server)
            dtsDataTable = objDBHelper.FillDataTableFromSP("dbo.LO_GetDishComboBoxData_Sp", _
                                    New SqlParameter() _
                                    {New SqlParameter("@intMenuDay", SqlDbType.Int), _
                                    New SqlParameter("@intLang", SqlDbType.Int)}, _
                                    New Object() {intMenuDay, intTypeID})

        Catch ex As Exception
            'Write To Log File
            clsApplicationLogFile.WriteLog(System.Reflection.MethodBase.GetCurrentMethod.Name & _
                          vbCrLf + ex.Message + vbCrLf + "*********************************************" & vbCrLf)
            Throw ex

        End Try

        'Loop and add the items to the drop down list
        For Each dtrRow As DataRow In dtsDataTable.Rows
            ddlCombobox.Items.Add(dtrRow.Item(0).ToString)
        Next

    End Function

End Class
