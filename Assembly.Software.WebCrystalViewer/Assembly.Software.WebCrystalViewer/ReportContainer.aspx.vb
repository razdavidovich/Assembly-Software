Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Linq
Imports CrystalDecisions.Shared
Imports Assembly.Software.Utilities



Public Class ReportContainer
    Inherits System.Web.UI.Page


#Region "Class Definitions"

    Enum ReportFormat
        HTML
        PDF
    End Enum

#End Region

#Region "Class memebr variables"

    ' CR variables


    Dim dataDef As FieldDefinition
    Dim paramField As ParameterFieldDefinition
    Dim crSections As Sections
    Dim crSection As Section
    Dim crReportObjects As ReportObjects
    Dim crReportObject As ReportObject
    Dim crSubreportObject As SubreportObject
    Dim oStream As MemoryStream  ' using for export to pdf, excel
    ' Define Crystal Reports variables
    'Dim crExportOptions As ExportOptions
    'Dim crDiskFileDestinationOptions As DiskFileDestinationOptions
    Private m_strReprotType As String = String.Empty
    Private m_htReportParameters As Hashtable = Nothing
    Private m_strReportPath As String = String.Empty
    Private m_strReportApplication As String = String.Empty

    'Dim ServerName As String
    'Dim UserID As String
    'Dim Pass As String
    'Dim HomeDir As String
    'Dim DataBaseName As String
    'Dim stringConnection As String
    Dim m_eReportFormat As ReportFormat

#End Region

    ''' <summary>
    ''' Analyze the QueryString and extract the report paramteters into a Hashtable.
    ''' Each report should at least contain:  ReportType, ReportFormat and ReportApplication
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            m_htReportParameters = New Hashtable()

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
                Throw New Exception("URL Line must contain a value for ReportType")

            End If

            ' Get report application
            If Not (Request.QueryString("ReportApplication") Is Nothing) Then

                m_strReportApplication = Request.QueryString("ReportApplication")
            Else
                Throw New Exception("URL Line must contain a value for ReportApplication")

            End If

            ' Get all report parameters
            For Each key As String In Request.QueryString.Keys

                If key <> "ReportType" And key <> "ReportFormat" Then
                    m_htReportParameters.Add(key, Request.QueryString(key))
                End If

            Next

            ' Load the reports
            LoadReport()

        Catch ex As Exception
            Throw ex
        End Try



    End Sub

    Private Sub LoadReport()

        Dim l_objParam As New ParameterDiscreteValue()
        Dim l_objValues As New ParameterValues()
        Dim l_objReportdocument As ReportDocument

        Try

            'Put user code to initialize the page here

            ''GetConfigValues()

            ' load report into crReport Document
            l_objReportdocument = New ReportDocument()
            l_objReportdocument.Load(m_strReportPath + m_strReprotType + ".rpt")

            ' set parametsr
            For Each key As String In m_htReportParameters.Keys

                Try
                    l_objParam.Value = m_htReportParameters(key)
                    l_objValues.Add(l_objParam)

                    'Add the parameter
                    l_objReportdocument.DataDefinition.ParameterFields.Item(key).ApplyCurrentValues(l_objValues)

                Catch ex As Exception

                End Try
            Next

            ' set database credentials
            SetReportConnectionInfo(l_objReportdocument, m_strReportApplication)

            'Set the CR viewer report source to the report document 
            CrystalReportViewerMain.ReportSource = l_objReportdocument

            If m_eReportFormat = ReportFormat.PDF Then
                oStream = l_objReportdocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/pdf"
                Response.BinaryWrite(oStream.ToArray())
                Response.End()
            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cr"></param>
    ''' <remarks></remarks>
    Private Sub SetReportConnectionInfo(ByRef cr As ReportDocument, ByVal strApplicationName As String)
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

        'Server Login information for the report
        Dim strServerName As String
        Dim strDatabaseName As String
        Dim strUserName As String
        Dim strPassword As String

        'Get the report login parameters from the application configuration file
        strServerName = Config.ReadASPConfigValue("ServerName", strApplicationName)
        strDatabaseName = Config.ReadASPConfigValue("DatabaseName", strApplicationName)
        strUserName = Config.ReadASPConfigValue("UserName", strApplicationName)
        strPassword = clsHashEncrypt.DecodeString(Config.ReadASPConfigValue("Password", strApplicationName))

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

    End Sub
End Class