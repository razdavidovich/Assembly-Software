<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReportsFilter.aspx.vb" Inherits="HoursReport.ReportsFilter"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN">
<html>
	<HEAD>
		<title>דוח שעות לעובד</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		<!--

			function GenerateReport(intEmployeeID)
			 //*************************************************************************
			//* Function Name:	ShowDate
			//* Description:	this function open the date picker for the supllied object
			//* Created by:     Adir Sharabi
			//* Created date:   17/08/2004
			//* Last Modifyer:  Adir Sharabi
			//*************************************************************************
			{
				// Set the constant string 
				var strNvigationCommand = "http://assemblysrv/ReportServer/Pages/ReportViewer.aspx?%2fHours+Analisys%2f";
				
				
				strNvigationCommand += Form1.elements[5].value;
				// Check which report was selected by the user
/*				
				if (Form1.ReportType[0].checked)
				{
					strNvigationCommand += "EmployeeMonthlyDetailedReport";
				}
				else
				{
					strNvigationCommand += "EmployeeMonthlyShortReport";
				}
*/				
				// Set the rest of the report parameters
				strNvigationCommand += "&rs:Command=Render";
				strNvigationCommand += "&intAbcenseCode=0"; 
				strNvigationCommand += "&intTaskCode=0";
				strNvigationCommand += "&intEmployee="+ intEmployeeID
				strNvigationCommand += "&intReportYear=" + Form1.cmbReportYear.value;
				strNvigationCommand += "&intReportMonth=" + Form1.cmbReportMonth.value;
				strNvigationCommand += "&rc:Parameters=false";
					
				// Navigate the reports frame to the report
				top.frames[1].location = strNvigationCommand;
				
				return true;
			}
			
			//___________________________________________________________________
						
			//___________________________________________________________________
						
			
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td width="10%"><asp:button id="btnBack" runat="server" Width="130px" Height="24px" 
                            Text="דיווח שעות" CausesValidation="False"
							CommandName="Clear" Font-Bold="True" Font-Names="David" Font-Size="Larger" ForeColor="Black" 
                            TabIndex="4"></asp:button></td>
					<td width="10%"><asp:button id="btnGenerateReport" runat="server" Width="130px" 
                            Height="24px" Text='הפק דו"ח'
							CausesValidation="False" CommandName="Clear" Font-Bold="True" Font-Names="David" Font-Size="Larger"
							ForeColor="Green" TabIndex="3"></asp:button></td>
					<td width="10%"><asp:dropdownlist id="cmbReportYear" dir="rtl" tabIndex="2" runat="server" Width="100%"></asp:dropdownlist></td>
					<td width="10%"><asp:dropdownlist id="cmbReportMonth" dir="rtl" tabIndex="1" 
                            runat="server" Width="100%">
							<asp:ListItem Value="1">ינואר</asp:ListItem>
							<asp:ListItem Value="2">פברואר</asp:ListItem>
							<asp:ListItem Value="3">מרץ</asp:ListItem>
							<asp:ListItem Value="4">אפריל</asp:ListItem>
							<asp:ListItem Value="5">מאי</asp:ListItem>
							<asp:ListItem Value="6">יוני</asp:ListItem>
							<asp:ListItem Value="7">יולי</asp:ListItem>
							<asp:ListItem Value="8">אוגוסט</asp:ListItem>
							<asp:ListItem Value="9">ספטמבר</asp:ListItem>
							<asp:ListItem Value="10">אוקטובר</asp:ListItem>
							<asp:ListItem Value="11">נובמבר</asp:ListItem>
							<asp:ListItem Value="12">דצמבר</asp:ListItem>
						</asp:dropdownlist></td>
					<td align="right" width="20%"><asp:dropdownlist id="cmbReportToExecute" dir="rtl" 
                            runat="server" Width="100%"></asp:dropdownlist></td>
					
				</tr>
			</table>
			&nbsp;
		</form>
	</body>
</html>
