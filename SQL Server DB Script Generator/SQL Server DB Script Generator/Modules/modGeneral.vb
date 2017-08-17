Imports System.Data.SqlClient
Imports Assembly.Software.DB

Imports System.Xml
Module modGeneral
    '***************************************************************************
    '* This module handles all specific function for using the SSSG
    '***************************************************************************

#Region " Application constants declarations "
    Public Const MSGBOX_RTL = MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading
#End Region

    Public Function GetFieldsForTables(ByVal strTableName As String) As DataTable
        '*************************************************************************
        '* Function Name:   GetFieldsForTables
        '* Description:     This function gets a list of fields for a given
        '*                  tables name
        '* Created by:      Raz Davidovich
        '* Created date:    06/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim objDB As New DBHelper(General.SelectedDBConnectionString, DBHelper.Connection_Type.SQL_Server)
        Dim dtlDataTable As New DataTable

        'Return the filled dataset
        Try
            dtlDataTable = objDB.FillDataTableFromSP("dbo.sp_columns", _
                                    New SqlParameter() _
                                    {New SqlParameter("@table_name", SqlDbType.NVarChar, 384)}, _
                                    New Object() {strTableName})

        Catch ex As Exception
            General.DisplayMessageBox(5)
        Finally
            'Clear the all objects
            objDB = Nothing
        End Try

        Return dtlDataTable

    End Function

    Public Function GetKeyFieldsForTables(ByVal strTableName As String) As DataTable
        '*************************************************************************
        '* Function Name:   GetKeyFieldsForTables
        '* Description:     This function gets a list of key fields for a given
        '*                  Project ID and tables ID
        '* Created by:      Raz Davidovich
        '* Created date:    10/08/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim objDB As New DBHelper(General.SelectedDBConnectionString, DBHelper.Connection_Type.SQL_Server)
        Dim dtlDataTable As New DataTable

        Try
            'Return the filled dataset
            dtlDataTable = objDB.FillDataTableFromSP("dbo.sp_pkeys", _
                                    New SqlParameter() _
                                    {New SqlParameter("@table_name", SqlDbType.NVarChar, 128)}, _
                                    New Object() {strTableName})

        Catch ex As Exception
            General.DisplayMessageBox(5)
        Finally
            'Clear the all objects
            objDB = Nothing
        End Try

        Return dtlDataTable

    End Function

    Public Function GenerateTableObject(ByVal strTableName As String, Optional ByVal blnHeader As Boolean = True, _
        Optional ByVal blnDropCommand As Boolean = True, Optional ByVal blnGenerateTablesKeys As Boolean = True) As clsTableObject
        '*************************************************************************
        '* Function Name:   GenerateTableObject
        '* Description:     This function a project ID and table ID and returns
        '*                  a populated table object
        '* Created by:      Raz Davidovich
        '* Created date:    26/09/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim dtlTableFields As DataTable
        Dim dtlTableKeys As DataTable
        Dim strScriptObjectOwner As String = Config.ReadConfigValue("ScriptObjectOwner", "Settings", "Application")
        Dim objFields As Object(,)
        Dim I As Integer = 0

        'Get the table fields
        dtlTableFields = GetFieldsForTables(strTableName)
        dtlTableKeys = GetKeyFieldsForTables(strTableName)

        'Load the fields to the object array
        For Each tmpRow As DataRow In dtlTableFields.Rows
            ReDim Preserve objFields(5, I)
            objFields(0, I) = I                                             'Table number in the collection
            objFields(1, I) = tmpRow.Item(3)                                'Field name
            objFields(2, I) = GetFieldType(tmpRow.Item(5))                  'Field type
            objFields(3, I) = tmpRow.Item(7)                                'Field Size
            objFields(4, I) = IsPrimeryKey(dtlTableKeys, tmpRow.Item(3))    'Is Primary key
            objFields(5, I) = IsIdentity(tmpRow.Item(5))                    'Is Identity field

            I += 1
        Next

        'Create the table object
        Dim objTable As New clsTableObject("Table", strTableName, strScriptObjectOwner, blnHeader, blnDropCommand, blnGenerateTablesKeys, objFields)

        'Return the table object
        Return objTable

    End Function

    Public Function GenerateBaseTableObject(ByVal strTableName As String, Optional ByVal blnHeader As Boolean = True, _
        Optional ByVal blnDropCommand As Boolean = True, Optional ByVal blnGenerateTablesKeys As Boolean = True) As clsBaseTableObject
        '*************************************************************************
        '* Function Name:   GenerateTableObject
        '* Description:     This function a project ID and table ID and returns
        '*                  a populated table object
        '* Created by:      Raz Davidovich
        '* Created date:    26/09/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim dtlTableFields As DataTable
        Dim dtlTableKeys As DataTable
        Dim strScriptObjectOwner As String = Config.ReadConfigValue("ScriptObjectOwner", "Settings", "Application")
        Dim objFields As Object(,)
        Dim I As Integer = 0

        'Get the table fields
        dtlTableFields = GetFieldsForTables(strTableName)
        dtlTableKeys = GetKeyFieldsForTables(strTableName)

        'Load the fields to the object array
        For Each tmpRow As DataRow In dtlTableFields.Rows
            ReDim Preserve objFields(5, I)
            objFields(0, I) = I                                             'Table number in the collection
            objFields(1, I) = tmpRow.Item(3)                                'Field name
            objFields(2, I) = GetFieldType(tmpRow.Item(5))                  'Field type
            objFields(3, I) = tmpRow.Item(7)                                'Field Size
            objFields(4, I) = IsPrimeryKey(dtlTableKeys, tmpRow.Item(3))    'Is Primary key
            objFields(5, I) = IsIdentity(tmpRow.Item(5))                    'Is Identity field

            I += 1
        Next

        'Create the table object
        Dim objBaseTableSP As New clsBaseTableObject("Procedure", strTableName, strScriptObjectOwner, blnHeader, blnDropCommand, blnGenerateTablesKeys, objFields)

        'Return the table object
        Return objBaseTableSP

    End Function

    Public Function FilterTables(ByVal dtlDataTable As DataTable, ByVal strSearch As String, ByVal strFilter As String) As DataView
        '*************************************************************************
        '* Function Name:  FilterTables 
        '* Description:    Return Table View according recieved data 
        '* Created by:      Raz Davidovich
        '* Created date:    25/08/2005
        '* Last Modifyer:   Emma Grimberg
        '*************************************************************************

        'Get the matched rows
        Dim dtvDataView As New DataView(dtlDataTable, strSearch, strFilter, DataViewRowState.CurrentRows)

        'Return the data view
        Return dtvDataView

    End Function

    Public Function IsPrimeryKey(ByVal dtlKeysTable As DataTable, ByVal strFieldName As String) As String
        '*************************************************************************
        '* Function Name:   IsPrimeryKey
        '* Description:     This function is checking if the given field name is
        '*                  part of the keys collection for the table (Y=Yes,N=No)
        '* Created by:      Raz Davidovich
        '* Created date:    07/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        Dim dtvDataTableView As DataView = FilterTables(dtlKeysTable, "COLUMN_NAME = '" + strFieldName + "'", "COLUMN_NAME")

        'Check for a matching field
        If dtvDataTableView.Count > 0 Then
            Return "Y"
        Else
            Return "N"
        End If

    End Function

    Public Function GetFieldType(ByVal strFieldTypeDescription As String) As String
        '*************************************************************************
        '* Function Name:   GetFieldType
        '* Description:     This function process and returns the DB field type
        '*                  
        '* Created by:      Raz Davidovich
        '* Created date:    07/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        Dim intStartIndex As Integer = strFieldTypeDescription.LastIndexOf(" ")

        If intStartIndex > 0 Then
            Return strFieldTypeDescription.Remove(intStartIndex)
        Else
            Return strFieldTypeDescription
        End If

    End Function

    Public Function IsIdentity(ByVal strFieldTypeDescription As String) As String
        '*************************************************************************
        '* Function Name:   IsPrimeryKey
        '* Description:     This function is checking if the given field name is
        '*                  part of the keys collection for the table (Y=Yes,N=No)
        '* Created by:      Raz Davidovich
        '* Created date:    07/12/2007
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Check for a matching field
        If strFieldTypeDescription.ToUpper.Contains("IDENTITY") Then
            Return "Y"
        Else
            Return "N"
        End If

    End Function

End Module

