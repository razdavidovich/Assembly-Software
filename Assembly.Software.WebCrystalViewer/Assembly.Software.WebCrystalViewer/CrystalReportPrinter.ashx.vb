Imports System.IO
Imports System.Web
Imports System.Web.Services
Imports Assembly.Software.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class CrystalReportPrinter
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            context.Response.ContentType = "text/json"

            Dim strJson As String = New StreamReader(context.Request.InputStream).ReadToEnd()

            Dim crystalReportPrinterRequestJson As CrystalReportPrinterRequestJson = JsonConvert.DeserializeObject(Of CrystalReportPrinterRequestJson)(strJson)

            LoadReport(context, crystalReportPrinterRequestJson)

            context.Response.Write("")
            context.Response.StatusCode = 200

        Catch ex As Exception
            clsApplicationLogFile.WriteLog("CrystalReportPrinter ProcessRequest " + vbCrLf + ex.ToString())

            context.Response.StatusCode = 400
            context.Response.StatusDescription = ex.Message
            Dim crystalReportPrinterError As CrystalReportPrinterError = New CrystalReportPrinterError With {
                .ErrorMessage = ex.ToString()
            }
            context.Response.Write(JsonConvert.SerializeObject(crystalReportPrinterError))
        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Private Sub LoadReport(ByVal httpContext As HttpContext, ByVal crystalReportPrinterRequestJson As CrystalReportPrinterRequestJson)
        Try

            Dim clsCrystalReport As ClsCrystalReport = New ClsCrystalReport()
            Dim CrystalReportViewerMainPrinter As CrystalDecisions.Web.CrystalReportViewer = New CrystalDecisions.Web.CrystalReportViewer()

            Dim l_strReportPath As String = Nothing
            Dim l_strReprotType As String = Nothing
            Dim l_strPrinterName As String = Nothing

            Dim l_objParam As New ParameterDiscreteValue()
            Dim l_objValues As New ParameterValues()
            Dim l_objReportdocument As ReportDocument = New ReportDocument()

            ' Get report application
            If Not crystalReportPrinterRequestJson.ReportApplication Is Nothing Then
                l_strReportPath = Config.ReadASPConfigValue("ReportPath", crystalReportPrinterRequestJson.ReportApplication)
                If l_strReportPath Is Nothing Then
                    Throw New Exception("Invalid Report Application")
                End If
            Else
                Throw New Exception("Invalid Report Application")
            End If

            ' Get report type
            If Not crystalReportPrinterRequestJson.ReportTypeName Is Nothing Then
                l_strReprotType = crystalReportPrinterRequestJson.ReportTypeName
            Else
                Throw New Exception("Invalid Report Type")
            End If

            If Not crystalReportPrinterRequestJson.PrinterName Is Nothing Then
                If Not String.IsNullOrEmpty(crystalReportPrinterRequestJson.PrinterName) Then
                    l_strPrinterName = crystalReportPrinterRequestJson.PrinterName
                Else
                    l_strPrinterName = Config.ReadASPConfigValue("PrinterName", crystalReportPrinterRequestJson.ReportApplication)
                End If
            Else
                l_strPrinterName = Config.ReadASPConfigValue("PrinterName", crystalReportPrinterRequestJson.ReportApplication)
            End If

            If l_strPrinterName Is Nothing Then
                Throw New Exception("Invalid Printer Name")
            End If

            l_objReportdocument.Load(l_strReportPath + l_strReprotType + ".rpt")

            For Each parameters As JProperty In crystalReportPrinterRequestJson.ReportParameters.Properties()
                Try

                    l_objParam.Value = DirectCast(parameters.Value, JValue).Value
                    l_objValues.Add(l_objParam)

                    'Add the parameter
                    l_objReportdocument.DataDefinition.ParameterFields.Item(parameters.Name).ApplyCurrentValues(l_objValues)

                Catch ex As Exception
                    Throw New Exception("Invalid Report Parameters")
                End Try
            Next

            Dim l_strServerName As String = Config.ReadASPConfigValue("ServerName", crystalReportPrinterRequestJson.ReportApplication)
            Dim l_strDatabaseName As String = Config.ReadASPConfigValue("DatabaseName", crystalReportPrinterRequestJson.ReportApplication)
            Dim l_strUserName As String = Config.ReadASPConfigValue("UserName", crystalReportPrinterRequestJson.ReportApplication)
            Dim l_strPassword As String = clsHashEncrypt.DecodeString(Config.ReadASPConfigValue("Password", crystalReportPrinterRequestJson.ReportApplication))

            clsApplicationLogFile.WriteLog(l_strServerName)

            ' set database credentials
            clsCrystalReport.SetReportConnectionInfo(l_objReportdocument, l_strServerName, l_strDatabaseName, l_strUserName, l_strPassword)

            'Set the CR viewer report source to the report document 
            CrystalReportViewerMainPrinter.ReportSource = l_objReportdocument

            l_objReportdocument.PrintOptions.PrinterName = Config.ReadASPConfigValue("PrinterName", l_strPrinterName)
            l_objReportdocument.PrintToPrinter(1, False, 0, 0)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class

Public Class CrystalReportPrinterRequestJson
    Public Property ReportApplication As String
    Public Property ReportTypeName As String
    Public Property ReportParameters As JObject()
    Public Property PrinterName As String = Nothing

End Class

Public Class CrystalReportPrinterError
    Public Property ErrorMessage As String
End Class



