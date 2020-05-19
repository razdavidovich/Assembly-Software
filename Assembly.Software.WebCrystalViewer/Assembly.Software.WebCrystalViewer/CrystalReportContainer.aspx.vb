Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Linq
Imports CrystalDecisions.Shared
Imports Assembly.Software.Utilities
Imports System.Collections.Generic


Public Class CrystalReportContainer
    Inherits System.Web.UI.Page



#Region "Class Definitions"

    Enum ReportFormat
        HTML
        PDF
        EXCEL
    End Enum

#End Region

#Region "Class memebr variables"

    Private m_strReprotType As String = String.Empty
    Private m_strReportPath As String = String.Empty
    Private m_strReportApplication As String = String.Empty
    Private m_eReportFormat As ReportFormat

#End Region

    ''' <summary>
    ''' Analyze the QueryString and extract the report paramteters into a Hashtable.
    ''' Each report should at least contain:  ReportType, ReportFormat and ReportApplication
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objReportParamKeys As List(Of Object)

        Try


            ' Get report type
            If Not (Request.QueryString("ReportType") Is Nothing) Then
                m_strReprotType = Request.QueryString("ReportType")
            Else
                Throw New Exception("URL Line must contain a value for ReportType")
            End If

            ' Get report output format
            If Not (Request.QueryString("ReportFormat") Is Nothing) Then

                m_eReportFormat = CType([Enum].Parse(GetType(ReportFormat), Request.QueryString("ReportFormat")), ReportFormat)
            Else
                m_eReportFormat = ReportFormat.HTML

            End If

            ' Get report application
            If Not (Request.QueryString("ReportApplication") Is Nothing) Then

                m_strReportApplication = Request.QueryString("ReportApplication")
            Else
                Throw New Exception("URL Line must contain a value for ReportApplication")

            End If

            clsApplicationLogFile.LogFileName = LogFileName()
            clsApplicationLogFile.LogFilePath = LogFilePath()
            clsApplicationLogFile.WriteLog("page load ")

            ' Get all the keys of the non-type paramaters - These are the acctual parameters that should be passed to the crystal report
            objReportParamKeys = (From t In Request.QueryString.Keys _
                                    Where (Not t.ToString().Equals("ReportType")) And _
                                            Not (t.ToString().Equals("ReportFormat")) And _
                                            Not (t.ToString().Equals("ReportApplication")) _
                                    Select t).ToList()
            ' Load the reports
            LoadReport(Request.QueryString, objReportParamKeys)
            ' clsApplicationLogFile.WriteLog("after load ")
        Catch ex As Exception
            Throw ex
        End Try



    End Sub
    ''' <summary>
    ''' Loads the report files into the ReportDocument object.
    ''' Sets the reports paramteres from the URL Line.
    ''' Sets up database credentials from the config files
    ''' Creates a memory stream and exports to the requested format.
    ''' </summary>
    ''' <param name="objURLParmas"></param>
    ''' <param name="objKeys"></param>
    ''' <remarks></remarks>
    Private Sub LoadReport(ByVal objURLParmas As NameValueCollection, ByVal objKeys As List(Of Object))

        Dim l_objParam As New ParameterDiscreteValue()
        Dim l_objValues As New ParameterValues()
        Dim l_objReportdocument As ReportDocument
        Dim l_strReportPath As String = String.Empty
        Dim l_strServerName As String = String.Empty
        Dim l_strDatabaseName As String = String.Empty
        Dim l_strUserName As String = String.Empty
        Dim l_strPassword As String = String.Empty
        Dim l_strContentType As String = String.Empty
        Try


            ' load report into crReport Document
            l_objReportdocument = New ReportDocument()
            l_strReportPath = Config.ReadASPConfigValue("ReportPath", m_strReportApplication)
            l_objReportdocument.Load(l_strReportPath + m_strReprotType + ".rpt")
            clsApplicationLogFile.WriteLog("m_strReprotType " + m_strReprotType)
            ' set parameters
            For Each key As String In objKeys

                Try

                    l_objParam.Value = objURLParmas(key)
                    l_objValues.Add(l_objParam)

                    'Add the parameter
                    l_objReportdocument.DataDefinition.ParameterFields.Item(key).ApplyCurrentValues(l_objValues)

                Catch ex As Exception

                End Try
            Next



            'Get the report login parameters from the application configuration file
            l_strServerName = Config.ReadASPConfigValue("ServerName", m_strReportApplication)
            l_strDatabaseName = Config.ReadASPConfigValue("DatabaseName", m_strReportApplication)
            l_strUserName = Config.ReadASPConfigValue("UserName", m_strReportApplication)
            l_strPassword = clsHashEncrypt.DecodeString(Config.ReadASPConfigValue("Password", m_strReportApplication))

            clsApplicationLogFile.WriteLog(l_strServerName)

            ' set database credentials
            SetReportConnectionInfo(l_objReportdocument, l_strServerName, l_strDatabaseName, l_strUserName, l_strPassword)

            'Set the CR viewer report source to the report document 
            CrystalReportViewerMain.ReportSource = l_objReportdocument

            ' Check Report Type and handle accordingly. For HTML, no need to do anything
            If m_eReportFormat <> ReportFormat.HTML Then

                Response.Clear()
                Response.ClearHeaders()
                Response.Buffer = True

                ' Check if Excel
                If m_eReportFormat = ReportFormat.EXCEL Then

                    ' Create Excel options and define stream
                    Dim objExcelOptions As ExcelFormatOptions = New ExcelFormatOptions
                    objExcelOptions.ExcelAreaGroupNumber = 1
                    objExcelOptions.ExcelAreaType = AreaSectionKind.Detail
                    objExcelOptions.ExcelTabHasColumnHeadings = True
                    objExcelOptions.ExcelUseConstantColumnWidth = False
                    l_objReportdocument.ExportOptions.FormatOptions = objExcelOptions
                    l_objReportdocument.ExportToHttpResponse(ExportFormatType.Excel, Response, False, "Exported Report")
                Else ' PDF option
                    l_objReportdocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "Exported Report")
                End If

                ' write stream
                Response.End()


            End If

        Catch ex As Exception
            Throw ex
        Finally ' Cleanup

        End Try

    End Sub

    Private Sub SetReportConnectionInfo(ByRef cr As ReportDocument, ByVal strServerName As String, ByVal strDatabaseName As String, ByVal strUsername As String, ByVal strPassword As String)
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
                .UserID = strUserName
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
            clsApplicationLogFile.WriteLog("end of loop crSections")
        Catch ex As Exception
            Throw New Exception("clsCrystalReports SetReportConnectionInfo " + vbCrLf + ex.ToString())
        End Try
    End Sub

    Private ReadOnly Property LogFileName() As String
        Get
            Dim strConn As String = String.Empty
            Dim sb As StringBuilder

            Try
                sb = New StringBuilder()
                sb.Append(Assembly.Software.Utilities.Config.ReadASPConfigValue("LogFileName", "appSettings").ToString())
                strConn = sb.ToString()
            Catch ex As Exception
                '  Loger.writeToLog(System.Reflection.MethodBase.GetCurrentMethod.Name, "Error Description", ex.Message)
            Finally
                sb = Nothing
            End Try
            Return strConn
        End Get
    End Property

    Private ReadOnly Property LogFilePath() As String
        Get
            Dim strConn As String = String.Empty
            Dim sb As StringBuilder

            Try
                sb = New StringBuilder()
                sb.Append(Assembly.Software.Utilities.Config.ReadASPConfigValue("LogFilePath", "appSettings").ToString())
                strConn = sb.ToString()
            Catch ex As Exception
                '  Loger.writeToLog(System.Reflection.MethodBase.GetCurrentMethod.Name, "Error Description", ex.Message)
            Finally
                sb = Nothing
            End Try
            Return strConn
        End Get
    End Property


End Class