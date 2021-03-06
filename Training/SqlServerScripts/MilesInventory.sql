USE [MyDealership]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 4/27/2022 12:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Trim] [varchar](20) NOT NULL,
	[Color] [varchar](30) NOT NULL,
	[CurrentMileage] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Price] [money] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[HasWheels] [tinyint] NULL,
	[ModifiedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1000, N'Honda', N'Civic', N'SI', N'Grey', 234875, 2010, 24000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1001, N'Ferrari', N'Enzo', N'SI', N'Red', 20000, 2020, 100000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1002, N'Infiniti', N'QX70', N'AWD', N'Black', 85000, 2015, 34000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1003, N'Toyota', N'Camry', N'EX', N'Grey', 106843, 2010, 8000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1004, N'Hyundai', N'Palisade', N'SE', N'Silver', 5000, 2022, 46000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1005, N'Lamborghini', N'Murcielago', N'LP670-4 Coupe', N'Blue', 100000, 2010, 450000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1006, N'Bat Mobile', N'Vengance', N'Wayne', N'Black', 100000, 1939, 10000000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1007, N'Toyota', N'Corolla', N'Coupe', N'Black', 90000, 1996, 200.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1008, N'Volkswagon', N'LT 40', N'Mystery Machine', N'Tie Dye', 100000, 1978, 10000.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1009, N'DeLorean', N'DMC-12', N'FC', N'Silver', 52148, 1981, 69950.0000, CAST(N'2022-04-27T09:37:26.830' AS DateTime), 1, CAST(N'2022-04-27T09:37:26.830' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1010, N'Imperial', N'Death Star', N'Darth', N'Battleship Gray', 20000, 1977, 250000000000.0000, CAST(N'2022-04-27T10:02:49.593' AS DateTime), 0, CAST(N'2022-04-27T10:02:49.593' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1011, N'Invisible Boat Mobile', N'Bikini Bottom', N'none', N'none', 100, 2000, 1000.0000, CAST(N'2022-04-27T10:05:33.290' AS DateTime), 1, CAST(N'2022-04-27T10:05:33.290' AS DateTime))
INSERT [dbo].[Inventory] ([Id], [Make], [Model], [Trim], [Color], [CurrentMileage], [Year], [Price], [CreatedDate], [HasWheels], [ModifiedDate]) VALUES (1012, N'Bat Boat', N'Vengance', N'Wayne', N'Blue', 23485, 1966, 1000000.9900, CAST(N'2022-04-27T10:07:49.700' AS DateTime), 0, CAST(N'2022-04-27T10:07:49.700' AS DateTime))
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertVehicleWithoutWheels]    Script Date: 4/27/2022 12:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Miles Mixon
-- Create date: 4/27/2022
-- Description:	Insert into Inventory
-- =============================================
CREATE PROCEDURE [dbo].[InsertVehicleWithoutWheels] 
	-- Add the parameters for the stored procedure here
	@make varchar(50),
	@model varchar(50),
	@trim varchar(20),
	@color varchar(30), 
	@currentMileage int,
	@year int,
	@price money,
	@id int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Inventory (Make, Model, Trim, Color, CurrentMileage, Year, Price, CreatedDate, HasWheels, ModifiedDate)
		VALUES (@make, @model, @trim, @color, @currentMileage, @year, @price, GETDATE(), 0, GETDATE());
	SET @id = SCOPE_IDENTITY();
	RETURN @id;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVehicleWithWheels]    Script Date: 4/27/2022 12:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertVehicleWithWheels]
	-- Add the parameters for the stored procedure here
	@make varchar(50),
	@model varchar(50),
	@trim varchar(20),
	@color varchar(30), 
	@currentMileage int,
	@year int,
	@price money,
	@id int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Inventory (Make, Model, Trim, Color, CurrentMileage, Year, Price, CreatedDate, HasWheels, ModifiedDate)
		VALUES (@make, @model, @trim, @color, @currentMileage, @year, @price, GETDATE(), 1, GETDATE());
	SET @id = SCOPE_IDENTITY();
	RETURN @id;
END
GO
/****** Object:  StoredProcedure [dbo].[QuickViewInventory]    Script Date: 4/27/2022 12:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Miles Mixon
-- Create date: 4/27/2022
-- Description:	Select a subset of values from the Inventory table
-- =============================================
CREATE PROCEDURE [dbo].[QuickViewInventory] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id], [Year], [Make], [Model], [Color], [Price] from [dbo].[Inventory] order by Price DESC;
END
GO
