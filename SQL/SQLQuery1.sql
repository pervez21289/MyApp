USE [MyApp]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSupplierCode]    Script Date: 13-10-2023 12.14.47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetSupplierCode] ()
RETURNS varchar(10)
AS
BEGIN
	DECLARE @Number INT=IDENT_CURRENT('Supplier');;
	DECLARE @Result VARCHAR(10);
	DECLARE @Prefix VARCHAR(5) = 'SUP-';
	DECLARE @NumberString VARCHAR(20) = CAST(@Number AS VARCHAR(20));
	DECLARE @Length INT = LEN(@NumberString);



	-- Insert the values
	IF @Length < 3
		SET @Result = @Prefix + RIGHT('000' + CAST(@Number AS VARCHAR(3)), 3)
	ELSE
		SET @Result = @Prefix + RIGHT('000' + CAST(@Number AS VARCHAR), @Length)

	RETURN @Result;
END;
GO
/****** Object:  Table [dbo].[Logger]    Script Date: 13-10-2023 12.14.47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logger](
	[LogId] [bigint] IDENTITY(1,1) NOT NULL,
	[LogType] [varchar](255) NULL,
	[LogResponse] [varchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
	[Dated] [datetime] NULL,
 CONSTRAINT [PK_Logger] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Logger] ADD  CONSTRAINT [DF_Logger_Dated]  DEFAULT (getutcdate()) FOR [Dated]
GO
/****** Object:  StoredProcedure [dbo].[SP_SaveLogger]    Script Date: 13-10-2023 12.14.47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_SaveLogger]
(
	@LogType varchar(255),
	@LogResponse varchar(max),
	@UserId nvarchar(450)
)
as
begin
INSERT INTO [dbo].[Logger]
           ([LogType]
           ,[LogResponse]
           ,[UserId]
           )
     VALUES
           (@LogType 
			,@LogResponse 
			 ,@UserId 
           )
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SaveSupplier]    Script Date: 13-10-2023 12.14.47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SaveSupplier]
(
	@UserId nvarchar(450),
	@SupplierCode nvarchar (20)=null,
	@SupplierName nvarchar (256),
	@CountryId int = NULL,
	@CityId int =NULL,
	@CompanyName nvarchar(256),
	@Website nvarchar(256)=  NULL,
	@Address nvarchar(max)=  NULL,
	@TelephoneNo nvarchar(256)=  NULL,
	@MobileNumber nvarchar(256)=  NULL,
	@SkypeId nvarchar(256)=  NULL,
	@CurrencyId int = NULL,
	@Designation nvarchar(256)=  NULL,
	@LoginEmailId nvarchar(256)=  NULL,
	@BookingEmailId nvarchar(max)= NULL,
	@IsApproved bit =NULL,
	@CreatedBy Varchar(500)=null,  
    @UpdatedBy Varchar(500)=null  
)
as
begin
INSERT INTO [dbo].[Supplier]
           (
 UserId
,SupplierCode
,SupplierName
,CountryId
,CityId

,CompanyName
,Website
,[Address]
,TelephoneNo
,MobileNumber

,SkypeId
,CurrencyId
,Designation
,LoginEmailId
,BookingEmailId

,IsApproved
,[Status]
,CreatedBy
,UpdatedBy)
     VALUES
           (
		   @UserId
		   ,dbo.GetSupplierCode() 
	,@SupplierName 
	,@CountryId  
	,@CityId
	
	,@CompanyName  
	,@Website 
	,@Address 
	,@TelephoneNo  
	,@MobileNumber 

	,@SkypeId  
	,@CurrencyId  
	,@Designation  
	,@LoginEmailId 
	,@BookingEmailId

	,@IsApproved 
	,1
	,@CreatedBy  
    ,@UpdatedBy )
end
GO
