SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetUserInfo_sp]
/**********************************************************************
SP Name:		GetUserInfo_sp
Description:	This SP returns the user id and user full name in 2
				output parameters
Writen By:		Raz Davidovich
Write Date:		02/05/2003
***********************************************************************/
	
	@strDomainUserName	Varchar(30),
	@intUserID			int				OUTPUT,
	@vchFullUserName	Varchar(50)		OUTPUT
	
AS

	SET NOCOUNT ON
	
	SELECT     @intUserID = ID, @vchFullUserName = (FirstName + N' ' + LastName) 
	FROM         dbo.Employee_Ta
	WHERE     (DomainUserName = @strDomainUserName)
	
	RETURN
GO
GRANT EXECUTE ON  [dbo].[GetUserInfo_sp] TO [public]
GO
