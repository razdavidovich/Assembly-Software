Imports Assembly.Software.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ClsCrystalReport

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

            clsApplicationLogFile.WriteLog("start " + "server: " + strServerName + "DB: " + strDatabaseName + "usr: " + strUsername)

            'pass the necessary parameters to the connectionInfo object
            With crConnectioninfo
                .ServerName = strServerName
                .DatabaseName = strDatabaseName
                .UserID = strUsername
                .Password = strPassword
            End With

            'set up the database and tables objects to refer to the current report
            crDatabase = cr.Database
            crTables = crDatabase.Tables

            clsApplicationLogFile.WriteLog(" reportDoc: " + cr.ToString())
            'loop through all the tables and pass in the connection info

            For Each crTable In crTables
                clsApplicationLogFile.WriteLog(" count: " + crTables.Count().ToString())

                crTableLogOnInfo = crTable.LogOnInfo
                crTableLogOnInfo.ConnectionInfo = crConnectioninfo

                crTable.ApplyLogOnInfo(crTableLogOnInfo)

                'Reset the table location to the current server
                crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1)
            Next
            clsApplicationLogFile.WriteLog("end of loop crTables")
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
                                .UserID = strUsername
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
            clsApplicationLogFile.WriteLog("end of loop crSections")
        Catch ex As Exception
            Throw New Exception("clsCrystalReports SetReportConnectionInfo " + vbCrLf + ex.ToString())
        End Try
    End Sub

End Class
