<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ErrorMessage.aspx.vb" Inherits="HoursReport.ErrorMessage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN">
<html dir="rtl">
	<HEAD>
		<title>Error</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="BorderTable" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 64px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server" Width="608px" Height="48px" Font-Size="XX-Large" ForeColor="Red">שם משתמש לא מוכר במערכת !!!</asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="1">אנא נסה לסגור את הדפדפן ולהתחבר שוב לאתר החברה</TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="1">במידה והבעיה חוזרת על עצמה, אנא פנה למנהל המערכת על מנת 
						שיעדכן את פרופיל המשתמש שלך בבסיס הנתונים</TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="1">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="1">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="1">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="1"><INPUT onClick="javascipt:window.close()" TYPE="button" VALUE="סגור דפדפן" TITLE="לחץ לסגירת הדפדפן"
							NAME="CloseWindow" STYLE="FONT-WEIGHT:bold; FONT-SIZE:larger; FONT-FAMILY:Verdana, Arial, Helvetica"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</html>
