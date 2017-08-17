
Imports CrystalDecisions.Windows.Forms

Public Class frmReportViewer

    Public Sub New(ByVal cr As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        ' This call is required by the designer.
        InitializeComponent()

        crvCrystalReportViewer.ReportSource = cr
        crvCrystalReportViewer.Refresh()
    
    End Sub

End Class