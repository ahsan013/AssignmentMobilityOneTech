Create DataBase MobilityOne_Dev
Go


USE [MobilityOne_Dev]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 22-Jan-21 3:06:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[PhoneNumber] [nvarchar](16) NOT NULL,
	[EmailAddress] [nvarchar](38) NOT NULL,
	[Password] [nvarchar](42) NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Suspended] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

