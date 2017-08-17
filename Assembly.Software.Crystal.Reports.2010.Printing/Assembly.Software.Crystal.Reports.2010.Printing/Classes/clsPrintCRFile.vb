
'Imports Assembly.Software.Utilities
Imports Assembly.Software.Utilities

<Serializable()> _
Public Class clsPrintCRFile

    Public Sub PrintCRFile(ByVal strPathAndReportName As String, _
                 ByVal strPrinter As String, _
                 ByVal ReportParametersValue(,) As Object, _
                       Optional ByVal strReportPaperOrientation As String = "Portrait", Optional ByVal strServerName As String = "", Optional ByVal strDatabaseName As String = "", Optional ByVal strUsername As String = "", Optional ByVal strPassword As String = "")
        '*************************************************************************
        '* Function Name:print
        '* Description:   Prints Label
        '*
        '* Created by:   Liat Kompas
        '* Created date: 19.4.10 
        '*************************************************************************



        Try
            Dim cr As CrystalDecisions.CrystalReports.Engine.ReportDocument
            cr = SetReport(strPathAndReportName, strPrinter, ReportParametersValue, strServerName, strDatabaseName, strUsername, strPassword)

            'set pronter
            cr.PrintOptions.PrinterName = strPrinter
            'set paper orantation
            If strReportPaperOrientation = "Landscape" Then
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            Else '.Portrait
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            End If

            If cr.PrintOptions.PrinterName = String.Empty Then
                Throw New Exception("cannot print to printer " + strPrinter)
            End If

            cr.PrintToPrinter(1, False, 0, 0)

        Catch ex As Exception
            Throw New Exception("error to print  " + ex.Message + strPrinter)
        End Try

    End Sub


    Private Function SetReport(ByVal strPathAndReportName As String, _
                 ByVal strPrinter As String, _
                 ByVal ReportParametersValue(,) As Object, ByVal strServerName As String, _
                               ByVal strDatabaseName As String, ByVal strUsername As String, ByVal strPassword As String) As CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim strFunctionName As String = System.Reflection.MethodBase.GetCurrentMethod.Name
        Dim cr As New CrystalDecisions.CrystalReports.Engine.ReportDocument


        'Dim strReportPath As String

        'strReportPath = My.Settings.ReportPath

        Try
            'Adding The Report FileName
            'strReportPath += "\" + strReportName

            If strPathAndReportName = String.Empty Or strPathAndReportName Is Nothing Then

                Throw New Exception(strFunctionName + ": Cannot load report")

            End If

            'load crystal report parameters
            cr.Load(strPathAndReportName)
        Catch ex As Exception
            Throw New Exception(strFunctionName + ": error to load file " + strPathAndReportName + " " + ex.Message)
        End Try

        Try
            'send parameters to the report
            If String.IsNullOrEmpty(strServerName) Then
                SetReportConnectionInfo(cr)
            Else
                SetReportConnectionInfo(cr, strServerName, strDatabaseName, strUsername, strPassword)
            End If


        Catch ex As Exception
            Throw New Exception(strFunctionName + ":error set error connection " + ex.Message)
        End Try

        Try
            SetReportParameters(cr, ReportParametersValue)
        Catch ex As Exception
            Throw New Exception(strFunctionName + ": error update reports parameters " + ex.Message)
        End Try

        Return cr


    End Function

    Public Sub ViewCR(ByVal strPathAndReportName As String, _
                ByVal strPrinter As String, _
                ByVal ReportParametersValue(,) As Object, _
                      Optional ByVal strReportPaperOrientation As String = "Portrait", Optional ByVal strServerName As String = "", Optional ByVal strDatabaseName As String = "", Optional ByVal strUsername As String = "", Optional ByVal strPassword As String = "")


        Try
            Dim cr As CrystalDecisions.CrystalReports.Engine.ReportDocument
            cr = SetReport(strPathAndReportName, strPrinter, ReportParametersValue, strServerName, strDatabaseName, strUsername, strPassword)

            Dim objReportViewer = New frmReportViewer(cr)
            objReportViewer.ShowDialog()
        Catch ex As Exception
            Throw New Exception("error to print  " + ex.Message + strPrinter)
        End Try
    End Sub

End Class
