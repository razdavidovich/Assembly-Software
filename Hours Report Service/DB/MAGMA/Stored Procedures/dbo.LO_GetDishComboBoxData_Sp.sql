SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[LO_GetDishComboBoxData_Sp]
-----------------------------------------------------------------------------------------------------------------------------------------------------
-- PROCEDURE NAME:		LO_GetDishComboBoxData_Sp
-- WRITEN BY:			Raz Davidovich
-- WRITE DATE:			26/10/2008
-- LAST MOFYED AT:		26/10/2008
-- LAST MODIFYER:		Raz Davidovich
-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	@intMenuDay		INT,	-- Get the menu for this day
	@intDishType	INT		-- Get the menu for this dish type
	
AS
	/* SET NOCOUNT ON */
	
	SELECT     dbo.LO_Dishes_Ta.intDishID, dbo.LO_Dishes_Ta.vchDishDescription
	FROM         dbo.LO_Menu_Ta INNER JOIN
						  dbo.LO_Dishes_Ta ON dbo.LO_Menu_Ta.intDishID = dbo.LO_Dishes_Ta.intDishID
	WHERE     (dbo.LO_Dishes_Ta.intDishTypeID = @intDishType) AND (dbo.LO_Menu_Ta.intDayID = @intMenuDay)	

	RETURN
GO
