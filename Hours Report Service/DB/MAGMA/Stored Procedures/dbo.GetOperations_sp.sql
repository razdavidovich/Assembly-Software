SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetOperations_sp]
/**********************************************************************
SP Name:		GetOperations_sp
Description:	This SP returns all the operations		
Writen By:		Raz Davidovich
Write Date:		06/05/2003
***********************************************************************/
AS
	SET NOCOUNT ON
	
	SELECT * FROM dbo.ActionType_Ta
                      
	RETURN 
GO
GRANT EXECUTE ON  [dbo].[GetOperations_sp] TO [public]
GO
