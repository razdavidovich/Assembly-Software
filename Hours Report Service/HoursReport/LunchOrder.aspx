<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LunchOrder.aspx.vb" Inherits="HoursReport.LunchOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>טופס להזמנת ארוחת צהרים</title>
</head>
<body>
    <form id="frmLunchOrder" runat="server">
    <div>
    <table width="100%" border="0" dir="rtl">
        <tr>
            <td>מנה עיקרית</td>
            <td width="50%"><asp:dropdownlist id="ddlMainDish" runat="server" Width="100%">
				<asp:ListItem Value="-1" Selected="True">=== בחר מנה עיקרית ===</asp:ListItem>
			</asp:dropdownlist></td>
            <td rowspan="5" align="left">
			<asp:calendar id="cdrActionDate" 
				tabIndex="5" runat="server" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" CellSpacing="1"
				ForeColor="Black" BackColor="White" NextPrevFormat="ShortMonth" BorderStyle="Solid" Width="330px"
				Height="250px">
				<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
				<DayStyle BackColor="#CCCCCC"></DayStyle>
				<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
				<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
				<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
				<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" 
                    BackColor="#333399" BorderStyle="Solid"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
			</asp:calendar></td>
        </tr>
        <tr>
            <td>תוספת</td>
            <td><asp:dropdownlist id="ddlSideDish1" runat="server" Width="100%">
				<asp:ListItem Value="-1" Selected="True">=== בחר תוספת ===</asp:ListItem>
			</asp:dropdownlist></td>
        </tr>
        <tr>
            <td>ירק חם</td>
            <td><asp:dropdownlist id="ddlSideDish2" runat="server" Width="100%">
				<asp:ListItem Value="-1" Selected="True">=== בחר ירק חם ===</asp:ListItem>
			</asp:dropdownlist></td>
        </tr>
        <tr>
            <td>סלט 1</td>
            <td><asp:dropdownlist id="ddlSalad1" runat="server" Width="100%">
				<asp:ListItem Value="-1" Selected="True">=== בחר סלט 1 ===</asp:ListItem>
			</asp:dropdownlist></td>
        </tr>
        <tr>
            <td>סלט 2</td>
            <td><asp:dropdownlist id="ddlSalad2" runat="server" Width="100%">
				<asp:ListItem Value="-1" Selected="True">=== בחר סלט 2 ===</asp:ListItem>
			</asp:dropdownlist></td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td><asp:button id="btnSave" runat="server" Font-Names="David" Font-Size="Larger" ForeColor="#00C000" Width="130px" Height="37px" Font-Bold="True" CommandName="Save" Text="שמור"></asp:button></td>
            <td></td>
            <td align="left"><asp:button id="btnBackToMain" runat="server" Font-Names="David" Font-Size="Larger" Width="130px" Height="37px" Font-Bold="True" CommandName="BackToMain" Text="חזור למסך ראשי" CausesValidation="False"></asp:button></td>
        </tr>
        <tr>
            <td colspan="3">
			    <HR width="100%" size="2">
			</td>
        </tr>
        <tr>
            <td colspan="3">
			<asp:Label id="Label2" runat="server" ForeColor="Red" Width="57px" Height="16px" Font-Bold="True" Font-Underline="True">שים לב</asp:Label>
			</td>
        </tr>
            <td colspan="3">
			    <asp:Label id="Label8" runat="server"
				ForeColor="Green" Width="753px" Height="16px" Font-Bold="True">אם בזמן לחיצה על שמירת דיווח מופיעה כוכבית אדומה (*) השדה שמשמאל לכוכבית הנו שדה חובה למילוי</asp:Label>			    
			</td>
    </table>
    </div>
    </form>
</body>
</html>
