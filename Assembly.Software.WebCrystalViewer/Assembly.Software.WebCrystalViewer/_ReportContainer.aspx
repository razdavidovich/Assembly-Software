<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportContainer.aspx.vb" Inherits="Assembly.Software.WebCrystalViewer.ReportContainer" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD dir="rtl">
		<title>reportContainer</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<form id="frmReportContainer" method="post" runat="server" dir="ltr">
            <cr:CrystalReportViewer ID="CrystalReportViewerMain" runat="server" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" Width="350px" Height="50px" EnableDrillDown="False" 
                DisplayGroupTree="False" />
		</form>
	</body>
</HTML>

