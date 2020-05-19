<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportContainer.aspx.vb" Inherits="Assembly.Software.WebCrystalViewer.Reportcontainer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmReportContainer" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewerMain" runat="server" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				Width="350px" Height="50px" EnableDrillDown="False" 
                DisplayGroupTree="False" />
    </div>
    </form>
</body>
</html>
