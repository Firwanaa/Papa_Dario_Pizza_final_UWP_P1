USE [Spring2021Exam]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 2021-08-06 12:13:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Drop  Tables <----------
--DROP TABLE [dbo].[Orders]
--GO
--DROP TABLE [dbo].[User]
--GO

CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pizza_size] [int] NULL,
	[toppings] [varchar](50) NULL,
	[addition] [varchar](50) NULL,
	[drinks] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2021-08-06 12:13:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[role] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[User]
           ([username]
           ,[email]
           ,[phone]
           ,[name]
           ,[password]
           ,[role])
     VALUES
           (
            'qq'
           ,'firwanaa@sheridancollege.ca'
           ,'6471231234'
           ,'Alqassam'
		   ,'qq'
           ,1)
INSERT INTO [dbo].[User]
           ([username]
           ,[email]
           ,[phone]
           ,[name]
           ,[password]
           ,[role])
     VALUES
           (
            'qq1'
           ,'qq1@sheridancollege.ca'
           ,'647111114'
           ,'Jack Ma'
		   ,'qq'
           ,0)
GO

USE [Spring2021Exam]
GO

INSERT INTO [dbo].[Orders]
           ([pizza_size]
           ,[toppings]
           ,[addition]
           ,[drinks]
           ,[username]
           ,[price])
     VALUES (
            '12'
          , 'Broccolini ,Potato,Olives'
          , 'Wings,Papa Sandwich,Poutine,Gulab Jamuns'
          , 'Soda,Water'
          , 'QQ'
          , '36.99')
GO
INSERT INTO [dbo].[Orders]
           ([pizza_size]
           ,[toppings]
           ,[addition]
           ,[drinks]
           ,[username]
           ,[price])
     VALUES (
            '12'
          , 'Potato'
          , 'Papa Sandwichs'
          , 'Water'
          , 'QQ'
          , '17.091')
GO

INSERT INTO [dbo].[Orders]
           ([pizza_size]
           ,[toppings]
           ,[addition]
           ,[drinks]
           ,[username]
           ,[price])
     VALUES (
            '24'
          , 'Broccolini ,Potato,Olives'
          , 'Papa Sandwichs'
          , 'Soda'
          , 'QQ'
          , '29.99')
GO

INSERT INTO [dbo].[Orders]
           ([pizza_size]
           ,[toppings]
           ,[addition]
           ,[drinks]
           ,[username]
           ,[price])
     VALUES (
            '12'
          , 'Broccolini ,Potato,Olives'
          , 'Wings,Papa Sandwich,Poutine,Gulab Jamuns'
          , 'Soda,Water'
          , 'QQ1'
          , '36.99')
GO
INSERT INTO [dbo].[Orders]
           ([pizza_size]
           ,[toppings]
           ,[addition]
           ,[drinks]
           ,[username]
           ,[price])
     VALUES (
            '12'
          , 'Potato'
          , 'Papa Sandwichs'
          , 'Water'
          , 'QQ1'
          , '17.091')
GO

INSERT INTO [dbo].[Orders]
           ([pizza_size]
           ,[toppings]
           ,[addition]
           ,[drinks]
           ,[username]
           ,[price])
     VALUES (
            '24'
          , 'Broccolini ,Potato,Olives'
          , 'Papa Sandwichs'
          , 'Soda'
          , 'QQ1'
          , '29.99')
GO

