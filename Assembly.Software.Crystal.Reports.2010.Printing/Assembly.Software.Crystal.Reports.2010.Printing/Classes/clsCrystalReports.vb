Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Assembly.Software.Utilities

'Imports Assembly.Software.Utilities

Module CrystalReports

    '***************************************************************************
    '* This module handles all crystal reports related procedures
    '***************************************************************************


    Public Function ExportToExcel(ByVal cr As ReportDocument, ByVal ReportParametersValue(,) As Object, ByVal strFilePath As String) As Boolean
        '*************************************************************************
        '* Function Name:   ExportToExcel
        '* Description:     This sub will export a Crystal Reports Report Object 
        '*                  to an Excel file
        '* Created by:      Raz Davidovich
        '* Created date:    25/07/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************

        'Verify the report loing information
        SetReportConnectionInfo(cr)

        'Set the report parameters
        SetReportParameters(cr, ReportParametersValue)

        ' Set the Excel export options 
        Dim excel As ExcelFormatOptions = New ExcelFormatOptions
        excel.ExcelUseConstantColumnWidth = False

        ' Use detail section one as a guideline to determine column width 
        excel.ExcelAreaGroupNumber = 1
        excel.ExcelAreaType = AreaSectionKind.Detail

        ' Set destination options 
        Dim disk As DiskFileDestinationOptions = New DiskFileDestinationOptions
        disk.DiskFileName = strFilePath

        ' Prepare exporting options 
        Dim export As ExportOptions = cr.ExportOptions
        export.FormatOptions = excel
        export.ExportFormatType = ExportFormatType.Excel
        export.ExportDestinationType = ExportDestinationType.DiskFile
        export.DestinationOptions = disk

        'Protect the Export procedure
        Try
            'Export the report to excel
            cr.Export()
        Catch ex As Exception
            'Diaply the error message to the user


            ' MessageBox.Show(ex.ToString() + vbCrLf + ex.Source, "תקלה ביצוא נתונים", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Throw ex
            'An error occurred, so return false
            Return False
        End Try

        'All Ok, so return true
        Return True

    End Function


    Public Sub SetReportConnectionInfo(ByRef cr As ReportDocument, ByVal strServerName As String, ByVal strDatabaseName As String, ByVal strUsername As String, ByVal strPassword As String)
        '*************************************************************************
        '* Function Name:   VerifyReportConnectionInfo
        '* Description:     This sub sets the loging information for a given
        '*                  Crystal Report Object referance
        '* Created by:      Raz Davidovich
        '* Created date:    01/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Dim crSections As Sections
        Dim crSection As Section
        Dim crReportObjects As ReportObjects
        Dim crReportObject As ReportObject
        Dim crSubreportObject As SubreportObject

        Dim crSubreportDocument As ReportDocument

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectioninfo As ConnectionInfo

        
        Try


            'Generate a new connection info object
            crConnectioninfo = New ConnectionInfo

            'pass the necessary parameters to the connectionInfo object
            With crConnectioninfo
                .ServerName = strServerName
                .DatabaseName = strDatabaseName
                .UserID = strUserName
                .Password = strPassword
            End With

            'set up the database and tables objects to refer to the current report
            crDatabase = cr.Database
            crTables = crDatabase.Tables

            'loop through all the tables and pass in the connection info
            For Each crTable In crTables
                crTableLogOnInfo = crTable.LogOnInfo
                crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                crTable.ApplyLogOnInfo(crTableLogOnInfo)

                'Reset the table location to the current server
                crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1)
            Next

            'set the crSections object to the current report's sections
            crSections = cr.ReportDefinition.Sections

            'loop through all the sections to find all the report objects
            For Each crSection In crSections
                crReportObjects = crSection.ReportObjects
                'loop through all the report objects to find all the subreports
                For Each crReportObject In crReportObjects
                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then
                        'you will need to typecast the reportobject to a subreport 
                        'object once you find it
                        crSubreportObject = CType(crReportObject, SubreportObject)

                        'open the subreport object
                        crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                        'set the database and tables objects to work with the subreport
                        crDatabase = crSubreportDocument.Database
                        crTables = crDatabase.Tables

                        'loop through all the tables in the subreport and 
                        'set up the connection info and apply it to the tables
                        For Each crTable In crTables
                            With crConnectioninfo
                                .ServerName = strServerName
                                .DatabaseName = strDatabaseName
                                .UserID = strUserName
                                .Password = strPassword
                            End With
                            crTableLogOnInfo = crTable.LogOnInfo
                            crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                            crTable.ApplyLogOnInfo(crTableLogOnInfo)

                            'Reset the table location to the current server
                            crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1)

                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            Throw New Exception("clsCrystalReports SetReportConnectionInfo " + vbCrLf + ex.ToString())
        End Try
    End Sub
    Public Sub SetReportConnectionInfo(ByRef cr As ReportDocument)
        ''Server Login information for the report
        Dim strServerName As String
        Dim strDatabaseName As String
        Dim strUserName As String
        Dim strPassword As String

        'Get the report login parameters from the application configuration file
        strServerName = My.Settings.Item("ODBCServerName")
        strDatabaseName = My.Settings.Item("Database")
        strUserName = My.Settings.Item("UserID")
        strPassword = clsHashEncrypt.DecodeString(My.Settings.Item("Password"))

        SetReportConnectionInfo(cr, strServerName, strDatabaseName, strUserName, strPassword)

    End Sub

    Public Sub SetReportParameters(ByRef cr As ReportDocument, ByVal ReportParametersValue(,) As Object)
        '*************************************************************************
        '* Function Name:   SetReportParameters
        '* Description:     This sub sets the  Crystal Report Object referance 
        '*                  parameters
        '* Created by:      Raz Davidovich
        '* Created date:    01/02/2004
        '* Last Modifyer:   Raz Davidovich
        '*************************************************************************
        Try


            'Set the main report parameter
            If Not ReportParametersValue Is Nothing Then
                'Get the array upperbound and loop to add the parameters
                Dim str As String = String.Empty

                For I As Integer = 0 To ReportParametersValue.GetUpperBound(0) '+ 1
                    str = ReportParametersValue(I, 0).ToString
                    str = str.Replace(" ", "")
                    'If ReportParametersValue(I, 2) Is Nothing Then
                    cr.SetParameterValue("@" + str, ReportParametersValue(I, 1))
                    'Else
                    'cr.SetParameterValue(ReportParametersValue(I, 0), ReportParametersValue(I, 1), ReportParametersValue(I, 2))
                    'End If
                Next I
            End If
        Catch ex As Exception
            Throw New Exception("clsCrystalReports SetReportParameters" + vbCrLf + ex.ToString())
        End Try

    End Sub

End Module

