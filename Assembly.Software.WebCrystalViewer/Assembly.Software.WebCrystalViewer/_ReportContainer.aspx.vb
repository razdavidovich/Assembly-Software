
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.IO
Imports Assembly.Software.Utilities



Partial Class ReportContainer
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        'LoadReport()
    End Sub

#End Region

    ' CR variables
    Dim crReportdocument As ReportDocument
    Dim param As New ParameterDiscreteValue()
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Dim values As New ParameterValues()
    Dim dataDef As FieldDefinition
    Dim paramField As ParameterFieldDefinition
    Dim crSections As Sections
    Dim crSection As Section
    Dim crReportObjects As ReportObjects
    Dim crReportObject As ReportObject
    Dim crSubreportObject As SubreportObject
    Dim oStream As MemoryStream  ' using for export to pdf, excel
    ' Define Crystal Reports variables
    Dim crExportOptions As ExportOptions
    Dim crDiskFileDestinationOptions As DiskFileDestinationOptions


    Dim ServerName As String
    Dim UserID As String
    Dim Pass As String
    Dim HomeDir As String
    Dim DataBaseName As String
    Dim stringConnection As String
    Dim m_eReportFormat As ReportFormat


    Enum ReportFormat
        HTML
        PDF
    End Enum




    Dim Fname As String

    Private Sub LoadReport()
        'Put user code to initialize the page here

        GetConfigValues()

        ' load report
        crReportdocument = New ReportDocument
        crReportdocument.Load(HomeDir + m_strReprotType + ".rpt")

        ' set parametsr
        For Each key As String In m_htReportParameters.Keys

            Try
                param.Value = m_htReportParameters(key)
                values.Add(param)

                'Add the parameter
                crReportdocument.DataDefinition.ParameterFields.Item(key).ApplyCurrentValues(values)

            Catch ex As Exception

            End Try


        Next

        ' set database credentials
        crReportdocument.SetDatabaseLogon(UserID, Pass)


        'Set the CR viewer report source to the report document 
        CrystalReportViewerMain.ReportSource = crReportdocument

        If m_eReportFormat = ReportFormat.PDF Then
            oStream = crReportdocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(oStream.ToArray())
            Response.End()
        End If

    End Sub

    Private m_strReprotType As String
    Private m_htReportParameters As New Hashtable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' SfolReportContainer.aspx?@nWOID=88&ReportType=WipParametersFilmReport
        ' SfolReportContainer.aspx?@sActiveWONumber=318186&@sNewWONumber=330245&ReportType=WipChangeReport

        m_htReportParameters = New Hashtable()

        For Each key As String In Request.QueryString.Keys

            If key <> "ReportType" And key <> "ReportFormat" Then
                m_htReportParameters.Add(key, Request.QueryString(key))
            End If

        Next

        If Not (Request.QueryString("ReportType") Is Nothing) Then
            m_strReprotType = Request.QueryString("ReportType")
        End If

        If Not (Request.QueryString("ReportFormat") Is Nothing) Then

            m_eReportFormat = CType([Enum].Parse(GetType(ReportFormat), Request.QueryString("ReportFormat")), ReportFormat)

        End If



        LoadReport()

    End Sub


    Private Sub GetConfigValues()

        ServerName = Config.ReadASPConfigValue("ServerName", "Database/Reports")
        HomeDir = Config.ReadASPConfigValue("HomeDir", "Database/Reports")
        UserID = Config.ReadASPConfigValue("UserName", "Database/Reports")
        Pass = clsHashEncrypt.DecodeString(Config.ReadASPConfigValue("Password", "Database/Reports"))
        DataBaseName = Config.ReadASPConfigValue("DatabaseName", "Database/Reports")
        stringConnection = ""

    End Sub

End Class


