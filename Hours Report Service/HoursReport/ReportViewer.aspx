<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportViewer.aspx.vb" Inherits="HoursReport.ReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmReport" runat="server">
    <div>
        <rsweb:ReportViewer ID="RSReportViewer" runat="server" Height="100%" 
            Width="100%">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
