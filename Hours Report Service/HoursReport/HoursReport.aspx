<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HoursReport.aspx.vb" Inherits="HoursReport.HoursReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
	<head>
		<title>דיווח שעות באינטרנט</title>
		<meta content="False" name="vs_snapToGrid"/>
		<meta content="True" name="vs_showGrid"/>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255"/>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
	</head>
	<body leftMargin="30" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:calendar id="cdrActionDate" style="Z-INDEX: 100; LEFT: 96px; POSITION: absolute; TOP: 14px"
				tabIndex="5" runat="server" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" CellSpacing="1"
				ForeColor="Black" BackColor="White" NextPrevFormat="ShortMonth" BorderStyle="Solid" Width="339px"
				Height="221px">
				<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
				<DayStyle BackColor="#CCCCCC"></DayStyle>
				<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
				<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
				<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
				<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="#333399"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
			</asp:calendar><asp:radiobuttonlist id="rblOrderBySelector" style="Z-INDEX: 101; LEFT: 482px; POSITION: absolute; TOP: 101px"
				tabIndex="6" runat="server" BorderStyle="Groove" Width="376px" Height="134px" AutoPostBack="True">
				<asp:ListItem Value="0" Selected="True">מיין לפי מספר פרוייקט</asp:ListItem>
				<asp:ListItem Value="1">מיין לפי לקוח</asp:ListItem>
				<asp:ListItem Value="2">מיין לפי שם פרוייקט</asp:ListItem>
			</asp:radiobuttonlist><asp:label id="Label1" style="Z-INDEX: 102; LEFT: 752px; POSITION: absolute; TOP: 262px" runat="server"
				Width="95px">פרוייקט לדיווח</asp:label><asp:dropdownlist id="ddlTaskPerformed" style="Z-INDEX: 103; LEFT: 96px; POSITION: absolute; TOP: 259px"
				runat="server" Width="643px">
				<asp:ListItem Value="-1" Selected="True">=== בחר פרוייקט לדיווח ===</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlHoursToReport" style="Z-INDEX: 104; LEFT: 688px; POSITION: absolute; TOP: 297px"
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
			</asp:dropdownlist><asp:label id="Label3" style="Z-INDEX: 105; LEFT: 768px; POSITION: absolute; TOP: 297px" runat="server"
				Width="78px">שעות לדיווח</asp:label><asp:label id="Label4" style="Z-INDEX: 106; LEFT: 536px; POSITION: absolute; TOP: 297px" runat="server"
				Width="93px">פעולה שבוצעה</asp:label><asp:dropdownlist id="ddlActionPerformed" style="Z-INDEX: 107; LEFT: 384px; POSITION: absolute; TOP: 297px"
				tabIndex="2" runat="server" Width="139px">
				<asp:ListItem Value="-1" Selected="True">=== בחר פעולה ===</asp:ListItem>
			</asp:dropdownlist><asp:label id="Label5" style="Z-INDEX: 108; LEFT: 288px; POSITION: absolute; TOP: 297px" runat="server"
				Width="44px">נסיעה</asp:label><asp:dropdownlist id="ddlCarReport" style="Z-INDEX: 109; LEFT: 96px; POSITION: absolute; TOP: 297px"
				tabIndex="3" runat="server" Width="180px">
				<asp:ListItem Value="-1" Selected="True">=== לא בוצעה נסיעה ===</asp:ListItem>
			</asp:dropdownlist><asp:label id="Label6" style="Z-INDEX: 110; LEFT: 480px; POSITION: absolute; TOP: 61px" runat="server"
				Font-Size="X-Large" ForeColor="Blue" Width="372px" Height="40px" Font-Bold="True">בחר מיון עבור איתור הפרוייקט</asp:label><asp:button id="btnSaveTask" style="Z-INDEX: 111; LEFT: 728px; POSITION: absolute; TOP: 408px"
				runat="server" Font-Names="David" Font-Size="Larger" ForeColor="#00C000" Width="130px" Height="37px" Font-Bold="True" CommandName="Save" Text="שמור את הדיווח"></asp:button><asp:button id="btnClearForm" style="Z-INDEX: 113; LEFT: 440px; POSITION: absolute; TOP: 408px"
				runat="server" Font-Names="David" Font-Size="Larger" ForeColor="Red" Width="130px" Height="37px" Font-Bold="True" CommandName="Clear" Text="נקה טופס" CausesValidation="False"></asp:button><asp:button id="btnBackToMain" style="Z-INDEX: 114; LEFT: 96px; POSITION: absolute; TOP: 408px"
				runat="server" Font-Names="David" Font-Size="Larger" Width="130px" Height="37px" Font-Bold="True" CommandName="BackToMain" Text="חזור למסך ראשי" CausesValidation="False"></asp:button><asp:label id="lblUserName" style="Z-INDEX: 115; LEFT: 494px; POSITION: absolute; TOP: 20px"
				runat="server" Font-Size="Larger" ForeColor="Green" Width="344px" Font-Bold="True"> שלום אורח</asp:label><asp:label id="Label7" style="Z-INDEX: 116; LEFT: 764px; POSITION: absolute; TOP: 338px" runat="server"
				Width="81px">תאור פעולה</asp:label><asp:textbox id="txtOperationDescription" style="Z-INDEX: 117; LEFT: 96px; POSITION: absolute; TOP: 335px"
				tabIndex="4" runat="server" Width="646px" MaxLength="100"></asp:textbox><asp:button id="cmdAbsenceReport" style="Z-INDEX: 118; LEFT: 584px; POSITION: absolute; TOP: 408px"
				runat="server" Font-Names="David" Font-Size="Larger" ForeColor="RoyalBlue" Width="130px" Height="37px" Font-Bold="True" CommandName="Absence" Text="דיווח העדרות" CausesValidation="False"></asp:button><asp:requiredfieldvalidator id="vldTaskText" style="Z-INDEX: 119; LEFT: 856px; POSITION: absolute; TOP: 336px"
				runat="server" Width="9px" Height="24px" Font-Bold="True" ControlToValidate="txtOperationDescription" ErrorMessage="*"></asp:requiredfieldvalidator><asp:rangevalidator id="rvdTaskPerformed" style="Z-INDEX: 120; LEFT: 856px; POSITION: absolute; TOP: 256px"
				runat="server" Width="9px" Height="16px" Font-Bold="True" ControlToValidate="ddlTaskPerformed" ErrorMessage="*" Type="Integer" MaximumValue="9999" MinimumValue="0"></asp:rangevalidator><asp:label id="lblErrorDescription" style="Z-INDEX: 121; LEFT: 544px; POSITION: absolute; TOP: 368px"
				runat="server" ForeColor="Red" Width="305px" Height="24px" Font-Bold="True" Visible="False">חובה למלא את כל השדות המסומנים בכוכבית !!!</asp:label><asp:rangevalidator id="rvdActionPerformed" style="Z-INDEX: 122; LEFT: 636px; POSITION: absolute; TOP: 295px"
				runat="server" Width="12px" Height="27px" Font-Bold="True" ControlToValidate="ddlActionPerformed" ErrorMessage="*" Type="Integer" MaximumValue="9999" MinimumValue="0"></asp:rangevalidator>
			<asp:Label id="Label2" style="Z-INDEX: 123; LEFT: 800px; POSITION: absolute; TOP: 496px" runat="server"
				ForeColor="Red" Width="57px" Height="16px" Font-Bold="True" Font-Underline="True">שים לב</asp:Label>
			<asp:Label id="Label8" style="Z-INDEX: 124; LEFT: 104px; POSITION: absolute; TOP: 520px" runat="server"
				ForeColor="Green" Width="753px" Height="16px" Font-Bold="True">אם בזמן לחיצה על שמירת דיווח מופיעה כוכבית אדומה (*) השדה שמשמאל לכוכבית הנו שדה חובה למילוי</asp:Label>
			<hr style="Z-INDEX: 125; LEFT: 96px; WIDTH: 83.24%; POSITION: absolute; TOP: 472px; HEIGHT: 2px"
				width="83.24%" noShade SIZE="2"/>
			<asp:button id="btnReports" style="Z-INDEX: 126; LEFT: 296px; POSITION: absolute; TOP: 409px"
				runat="server" Height="37px" Width="130px" ForeColor="CadetBlue" Font-Size="Larger" Font-Names="David"
				Font-Bold="True" Text="ãåçåú" CommandName="Clear" CausesValidation="False"></asp:button>
		</form>
	</body>
</html>
