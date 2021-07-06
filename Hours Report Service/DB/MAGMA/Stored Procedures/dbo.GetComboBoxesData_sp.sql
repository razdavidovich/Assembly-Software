SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
/****** Object:  Stored Procedure dbo.spGetComboBoxesData    Script Date: 18/11/2002 14:18:30 ******/
CREATE PROCEDURE [dbo].[GetComboBoxesData_sp]
-----------------------------------------------------------------------------------------------------------------------------------------------------
-- PROCEDURE NAME:		GetComboBoxesData_sp
-- WRITEN BY:			Raz Davidovich
-- WRITE DATE:		04/04/2002
-- LAST MOFYED AT:		28/05/2002
-- LAST MODIFYER:		Eyal Levin
-----------------------------------------------------------------------------------------------------------------------------------------------------
	@intComboID int

as

	If @intComboID>18 AND @intComboID<30	--Get the available clients according to the company
		SELECT CompName as Code, CompName FROM Task_Ta
		WHERE CompanyCode=@intComboID
		Group by CompName

	If @intComboID=31				--Get the urgencies
		SELECT     Code, Description
		FROM         dbo.ArgentCode_Ta

	If @intComboID=32				--Get the Employees names and numbers
		SELECT     ID, FirstName + N' ' + LastName AS Name
		FROM         dbo.Employee_Ta
		WHERE     (ActiveEmployee = - 1)

	If @intComboID=33				--Get the statuses
		SELECT     Code, MainStatus
		FROM         dbo.Status_Ta
	
	If @intComboID=34				--Get the companies
		SELECT CompanyCode, CompanyName
		FROM dbo.company_ta

	If @intComboID=35				--Get the Reports 
		SELECT vchReportFileName , vchReport_Name
		FROM dbo.Reports_Ta
GO
GRANT EXECUTE ON  [dbo].[GetComboBoxesData_sp] TO [public]
GO
