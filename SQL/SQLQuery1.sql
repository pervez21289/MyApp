USE [MyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_ApproveSupplier]    Script Date: 12-10-2023 9.08.09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_ApproveSupplier]
(
	@UserId nvarchar(450),
	@IsApproved bit =NULL
)
as
begin
	update Supplier set IsApproved=@IsApproved where UserId=@UserId;
	
		   	SELECT 'Status updated successfully' AS [Message]
			,1 AS IsSuccess
			,@UserId;
end
GO


