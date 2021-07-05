<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AbsenceReport.aspx.vb" Inherits="HoursReport.AbsenceReport" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN">
<html dir="rtl">
	<HEAD>
		<title>דיווח העדרות באינטרנט</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="True">
		<META http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Calendar id="cdrActionDate" style="Z-INDEX: 112; LEFT: 96px; POSITION: absolute; TOP: 24px"
				tabIndex="5" runat="server" Height="221px" Width="339px" BorderStyle="Solid" NextPrevFormat="ShortMonth"
				BackColor="White" ForeColor="Black" CellSpacing="1" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black">
				<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
				<DayStyle BackColor="#CCCCCC"></DayStyle>
				<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
				<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
				<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
				<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="#333399"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
			</asp:Calendar>
			<asp:DropDownList id="ddlHoursToReport" style="Z-INDEX: 101; LEFT: 669px; POSITION: absolute; TOP: 80px"
				tabIndex="1" runat="server">
				<asp:ListItem Value="0.5">0.5</asp:ListItem>
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="1.5">1.5</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="2.5">2.5</asp:ListItem>
				<asp:ListItem Value="3">3</asp:ListItem>
				<asp:ListItem Value="3.5">3.5</asp:ListItem>
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="4.5">4.5</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="5.5">5.5</asp:ListItem>
				<asp:ListItem Value="6">6</asp:ListItem>
				<asp:ListItem Value="6.5">6.5</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
				<asp:ListItem Value="7.5">7.5</asp:ListItem>
				<asp:ListItem Value="8">8</asp:ListItem>
				<asp:ListItem Value="8.5">8.5</asp:ListItem>
				<asp:ListItem Value="9" Selected="True">9</asp:ListItem>
				<asp:ListItem Value="9.5">9.5</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="10.5">10.5</asp:ListItem>
				<asp:ListItem Value="11">11</asp:ListItem>
				<asp:ListItem Value="11.5">11.5</asp:ListItem>
				<asp:ListItem Value="12">12</asp:ListItem>
				<asp:ListItem Value="12.5">12.5</asp:ListItem>
				<asp:ListItem Value="13">13</asp:ListItem>
				<asp:ListItem Value="13.5">13.5</asp:ListItem>
				<asp:ListItem Value="14">14</asp:ListItem>
				<asp:ListItem Value="14.5">14.5</asp:ListItem>
				<asp:ListItem Value="15">15</asp:ListItem>
				<asp:ListItem Value="15.5">15.5</asp:ListItem>
				<asp:ListItem Value="16">16</asp:ListItem>
				<asp:ListItem Value="16.5">16.5</asp:ListItem>
				<asp:ListItem Value="17">17</asp:ListItem>
				<asp:ListItem Value="17.5">17.5</asp:ListItem>
				<asp:ListItem Value="18">18</asp:ListItem>
				<asp:ListItem Value="18.5">18.5</asp:ListItem>
				<asp:ListItem Value="19">19</asp:ListItem>
				<asp:ListItem Value="19.5">19.5</asp:ListItem>
				<asp:ListItem Value="20">20</asp:ListItem>
				<asp:ListItem Value="20.5">20.5</asp:ListItem>
				<asp:ListItem Value="21">21</asp:ListItem>
				<asp:ListItem Value="21.5">21.5</asp:ListItem>
				<asp:ListItem Value="22">22</asp:ListItem>
				<asp:ListItem Value="22.5">22.5</asp:ListItem>
				<asp:ListItem Value="23">23</asp:ListItem>
				<asp:ListItem Value="23.5">23.5</asp:ListItem>
				<asp:ListItem Value="24">24</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="Label3" style="Z-INDEX: 102; LEFT: 739px; POSITION: absolute; TOP: 81px" runat="server"
				Width="95px">שעות העדרות</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 103; LEFT: 735px; POSITION: absolute; TOP: 121px" runat="server"
				Width="99px">סוג העדרות</asp:Label>
			<asp:DropDownList id="ddlAbsenceType" style="Z-INDEX: 104; LEFT: 545px; POSITION: absolute; TOP: 120px"
				tabIndex="2" runat="server" Width="175px">
				<asp:ListItem Value="-1" Selected="True">=== בחר סוג העדרות ===</asp:ListItem>
			</asp:DropDownList>
			<asp:Button id="btnSaveTask" style="Z-INDEX: 105; LEFT: 728px; POSITION: absolute; TOP: 335px"
				runat="server" Height="37px" Width="130px" ForeColor="#00C000" Font-Size="Larger" Font-Names="David"
				Font-Bold="True" Text="שמור את הדיווח"></asp:Button>
			<asp:Button id="btnClearForm" style="Z-INDEX: 106; LEFT: 440px; POSITION: absolute; TOP: 335px"
				runat="server" Height="37px" Width="130px" ForeColor="Red" Font-Size="Larger" Font-Names="David"
				Font-Bold="True" Text="נקה טופס" CausesValidation="False"></asp:Button>
			<asp:Button id="btnBackToMain" style="Z-INDEX: 107; LEFT: 96px; POSITION: absolute; TOP: 335px"
				runat="server" Height="37px" Width="130px" Font-Size="Larger" Font-Names="David" Font-Bold="True"
				Text="חזור למסך ראשי" CausesValidation="False"></asp:Button>
			<asp:Label id="lblUserName" style="Z-INDEX: 108; LEFT: 494px; POSITION: absolute; TOP: 32px"
				runat="server" Width="344px" ForeColor="Green" Font-Size="Larger" Font-Bold="True">שלום רז דודוביץ</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 109; LEFT: 739px; POSITION: absolute; TOP: 162px" runat="server"
				Width="96px">תאור העדרות</asp:Label>
			<asp:TextBox id="txtAbsenceDescription" style="Z-INDEX: 110; LEFT: 473px; POSITION: absolute; TOP: 160px"
				tabIndex="4" runat="server" Width="247px" MaxLength="100" Height="85px"></asp:TextBox>
			<asp:Button id="cmdAbsenceReport" style="Z-INDEX: 111; LEFT: 584px; POSITION: absolute; TOP: 335px"
				runat="server" Height="37px" Width="130px" ForeColor="RoyalBlue" Font-Size="Larger" Font-Names="David"
				Font-Bold="True" Text="דיווח שעות" CausesValidation="False"></asp:Button>
			<asp:Label id="Label2" style="Z-INDEX: 113; LEFT: 792px; POSITION: absolute; TOP: 427px" runat="server"
				ForeColor="Red" Width="57px" Height="16px" Font-Bold="True" Font-Underline="True">שים לב</asp:Label>
			<asp:Label id="Label8" style="Z-INDEX: 114; LEFT: 96px; POSITION: absolute; TOP: 451px" runat="server"
				ForeColor="Green" Width="753px" Height="16px" Font-Bold="True">אם בזמן לחיצה על שמירת דיווח מופיעה כוכבית אדומה (*) השדה שמשמאל לכוכבית הנו שדה חובה למילוי</asp:Label>
			<HR style="Z-INDEX: 115; LEFT: 88px; WIDTH: 83.24%; POSITION: absolute; TOP: 403px; HEIGHT: 2px"
				width="83.24%" noShade SIZE="2">
			<asp:label id="lblErrorDescription" style="Z-INDEX: 116; LEFT: 545px; POSITION: absolute; TOP: 296px"
				runat="server" ForeColor="Red" Width="305px" Height="24px" Font-Bold="True" Visible="False">חובה למלא את כל השדות המסומנים בכוכבית !!!</asp:label>
			<asp:RequiredFieldValidator id="vldAbsenceDescription" style="Z-INDEX: 117; LEFT: 847px; POSITION: absolute; TOP: 163px"
				runat="server" Width="11px" Height="22px" Font-Bold="True" ControlToValidate="txtAbsenceDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
			<asp:RangeValidator id="vldAbsenceType" style="Z-INDEX: 118; LEFT: 849px; POSITION: absolute; TOP: 116px"
				runat="server" Width="9px" Height="24px" Font-Bold="True" ControlToValidate="ddlAbsenceType" ErrorMessage="*"
				MinimumValue="0" MaximumValue="9999"></asp:RangeValidator>
			<asp:button id="btnReports" style="Z-INDEX: 126; LEFT: 296px; POSITION: absolute; TOP: 336px"
				runat="server" Font-Names="David" Font-Size="Larger" ForeColor="CadetBlue" Width="130px"
				Height="37px" Text="דוחות" Font-Bold="True" CausesValidation="False" CommandName="Clear"></asp:button>
		</form>
	</body>
</html>
