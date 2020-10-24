<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CrystalReportContainer.aspx.vb" Inherits="Assembly.Software.WebCrystalViewer.CrystalReportContainer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crystal reports Viewer</title>
</head>
<body id="CrystalReportViewerMainBody">
    <form id="frmReportContainer" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewerMain" runat="server" AutoDataBind="true" HasCrystalLogo="True" HasDrillUpButton="True" HasToggleGroupTreeButton="True" HasToggleParameterPanelButton="True" ToolPanelView="None"/>
    </div>
    </form>
</body>
</html>
