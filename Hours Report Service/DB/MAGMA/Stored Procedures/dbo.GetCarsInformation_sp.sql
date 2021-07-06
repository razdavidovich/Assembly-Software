SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetCarsInformation_sp]
/**********************************************************************
SP Name:		GetCarsInformation_sp
Description:	This SP returns all the cars information		
Writen By:		Raz Davidovich
Write Date:		06/05/2003
***********************************************************************/
AS
	SET NOCOUNT ON
	
	SELECT     dbo.Cars_Ta.CarID, dbo.Cars_Ta.CarNumber + N' (' + dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName + N')' AS CarDescription
	FROM         dbo.Cars_Ta INNER JOIN dbo.Employee_Ta ON dbo.Cars_Ta.Owner = dbo.Employee_Ta.ID
	WHERE	(ActiveCar = 1)
                      
	RETURN 
GO
GRANT EXECUTE ON  [dbo].[GetCarsInformation_sp] TO [public]
GO
