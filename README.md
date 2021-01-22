
# Documentation
This document caters the detail of Front End & Backend implementation in accordance with assignment.

#1: Data Base Implementation 
In the light of provided document, first of all, I created the database with the table name users because the data which I need to populate from the table and related to users. So moving to next step, the database will be created by following script.

--------------------------------------------------------------------------------------------------------------------------
Create DataBase MobilityOne_Dev
Go
After that I need to create the table for database and the table name is users. The following script will create the table in database with the following table structure
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
---------------------------------------------------------------------------------------











Users Table Structure:
Column Name	Type
Id	integer (auto-increment)
Name	string(32)
PhoneNumber	string(16)
EmailAddress	string(38)
Password	string(42)
LastLogin	datetime
CreateDate	datetime
Suspended	boolean

Insertion of one record in tables
Insert into Users (Name,PhoneNumber,EmailAddress,Password,LastLogin,CreateDate,Suspended)    values ('Ahsan','+923322431200','ahsan@gmail.com','2222','2020-01-22','2020-01-19',0)


# 2: Method for Restoring the Data base - AssignmentMobilityOneTech 
Creating Data Base
	Open MS SQL Management Studio.
	Connect to Local Server using (Windows Authentication or with SQL Server Authentication with username and password.)
	Click on Data Bases on left hand side at left side panel or alternatively just open object explorer and click on Data Bases.
	Then press Ctrl + N for opening new query file. 
	Then paste the following code and execute by pressing F5 or (fn + F5). 
# Execute Data Base Script
Create DataBase MobilityOne_Dev
Go
After that I need to create the table for database and the table name is users. The following script will create the table in database with the following table structure
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
---------------------------------------------------------------------------------------

insert into Users (Name,PhoneNumber,EmailAddress,Password,LastLogin,CreateDate,Suspended) values ('Ahsan','+923322431200','ahsan@gmail.com','2222','2020-01-22','2020-01-19',0)
--------------------------------------------------------------------------------------------------------------------------------------

After Execution of the above file the data base will be created.

Download Assignment Project from Git Hub
	Then download the project from https://github.com/ahsan013/AssignmentMobilityOneTech and open the project in Visual Studio 2019.
	When all project will be loaded, then open file Web.Config to set the connection string to the data base.
	 This Connection string is basically the bridge between Data Base and Code.
Search for <connectionStrings> tag in web.config file and set the data source(SQLSERVER NAME), Initial Catalog(Data Base Name), user id= sa and Password="SQLPasswrod". 
	After this hit ctrl + F5 to run the project. the project will be open in web browser and you will be able to see the list of users.
	The Assignment was to show the data from MS SQL data base to web page with add edit delete functionality using Web API with Json Results.

It has been completed and live demo can be browsed on the following link.
http://mobility.winstonandmacrec.com/
3: Web API Part
All CRUD Functionalities has been achieved with Restful Web API with JSON return.

Followings methods has been implemented in accordance with CRUD operation in UsersAPI
1.	List of Users – GetAllUsers()
This will return the user’s list in Json Format.
2.	Adding New User – AddUsers(Users users)
This method has been implemented to achieve the functionality of adding users.
3.	Get single user with ID – GetUserByID(int id)
This method has been implemented to achieve the functionality of for getting single user based on the ID.
4.	Update Users – UpdateUsers(Users users)
This method has been implemented to achieve the functionality for updating users.
5.	Delete Single User - SingleUserRemove(int id)
This method has been implemented to achieve the functionality of deleting users based on ID.

#Front End Implementation: 

In front End, I have implemented followings four views.
1.	Index.chtml – It will show the entire users list with pagination search implementations.
2.	LoadAddPopup.chtml – It will open to add a new user on the Index page.
3.	LoadEditPopup.chtml – It will open to update the existing user on the Index page.
4.	_Layout.chtml – It is implemented to serve as master UI page of the application.

All functionalities achieved by using JQuery. CSS design functionalities has been achieved by using bootstrap library.

#Calling WEB API
Web Api has been called by using the ajax and all the related code has been placed in users.js file which is placed in Scripts folder and it’s referenced was called to Index.cshtml. And Web API is placed in UsersAPI in controller’s folder.



