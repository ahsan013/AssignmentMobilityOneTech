# AssignmentMobilityOneTech - How to run the Assignment Successfully.


# Creating Data Base.


Open MS SQL Management Studio

Connect to Local Server using (Windows Authentication or with SQL Server Authentication with username and password.)

Click on DataBases on left hand side at left side panel or alternattively just open object explorer and click on Data Bases.

Then press Ctrl + N for opening new query file. 

the paste the following code and execute by pressing F5 or (fn + F5). 

# Execute Data Base Script
---------------------------------------------------------------------

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

----------------------------------------------------------------------------
# Data Base Script Ends Here.

After Execution of the above file the the data base will be created.

# Download Assignment Project from GitHub

Then download the project from https://github.com/ahsan013/AssignmentMobilityOneTech and open the project in Visual Studio 2019.

When all project will be loaded, then open file Web.Config to set the connection string to the data base. This Connection string is basically the bridge between Data Base
and Code.

Search for <connectionStrings> tag in web.config file and set the data source(SQLSERVER NAME), Initial Catalog(Data Base Name), user id= sa and Password="SQLPasswrod". 

After this hit ctrl + F5 to run the project. the project will be open in web browser and you will be able to see the list of users.

The Assignment was to show the data from MS SQL data base to web page with add edit delete functionality using Web API with Json Results.

It has been completed and live demo can be browsed on the following link.

http://mobility.winstonandmacrec.com/

Thank You.
Ahsan Aftab
+65 9473 1886



