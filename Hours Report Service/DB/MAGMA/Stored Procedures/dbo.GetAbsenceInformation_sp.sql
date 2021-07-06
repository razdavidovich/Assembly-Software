SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetAbsenceInformation_sp]
/**********************************************************************
SP Name:		GetAbsenceInformation_sp
Description:	This SP returns all the absence information		
Writen By:		Raz Davidovich
Write Date:		22/06/2003
***********************************************************************/
AS
	SET NOCOUNT ON
	
	SELECT * FROM Absence_Ta
                      
	RETURN 
GO
GRANT EXECUTE ON  [dbo].[GetAbsenceInformation_sp] TO [public]
GO
