USE [master]
GO

IF DB_ID('SampleData') IS NOT NULL
	BEGIN
		ALTER DATABASE [SampleData] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE [SampleData]
	END

/****** Object:  Database [SampleData]    Script Date: 05/08/2021 20:39:44 ******/
CREATE DATABASE [SampleData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SampleData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SampleData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SampleData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SampleData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SampleData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SampleData] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SampleData] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SampleData] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SampleData] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SampleData] SET ARITHABORT OFF 
GO

ALTER DATABASE [SampleData] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SampleData] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SampleData] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SampleData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SampleData] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SampleData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SampleData] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SampleData] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SampleData] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SampleData] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SampleData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SampleData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SampleData] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SampleData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SampleData] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SampleData] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SampleData] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SampleData] SET RECOVERY FULL 
GO

ALTER DATABASE [SampleData] SET  MULTI_USER 
GO

ALTER DATABASE [SampleData] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SampleData] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SampleData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SampleData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SampleData] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SampleData] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SampleData] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SampleData] SET  READ_WRITE 
GO

USE [SampleData]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05/08/2021 20:39:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
USE [master]
GO
/****** Object:  Database [SampleData]    Script Date: 05/08/2021 20:39:24 ******/
DROP DATABASE [SampleData]
GO
/****** Object:  Database [SampleData]    Script Date: 05/08/2021 20:39:24 ******/
CREATE DATABASE [SampleData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SampleData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SampleData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SampleData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SampleData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SampleData] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SampleData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SampleData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SampleData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SampleData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SampleData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SampleData] SET ARITHABORT OFF 
GO
ALTER DATABASE [SampleData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SampleData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SampleData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SampleData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SampleData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SampleData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SampleData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SampleData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SampleData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SampleData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SampleData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SampleData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SampleData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SampleData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SampleData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SampleData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SampleData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SampleData] SET RECOVERY FULL 
GO
ALTER DATABASE [SampleData] SET  MULTI_USER 
GO
ALTER DATABASE [SampleData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SampleData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SampleData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SampleData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SampleData] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SampleData] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SampleData', N'ON'
GO
ALTER DATABASE [SampleData] SET QUERY_STORE = OFF
GO
USE [SampleData]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05/08/2021 20:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[UnitPrice] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (1, N'Roasted Peanuts', N'500g bag of dry roasted peanuts', 0.6900)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (2, N'Cashew Nuts', N'75g bag of cashew nuts', 0.7500)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (3, N'Milk (Whole)', N'2 litres of whole milk', 1.2500)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (4, N'Bread (50/50)', N'50% white and 50% wholemeal bread', 1.0000)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (5, N'Butter (Salted)', N'100g salted butter', 2.5000)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (6, N'Roast Chicken', N'5kg frozen roast chicken', 4.9900)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (7, N'Potatoes', N'5kg Maris variety potatoes', 1.7500)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (8, N'Roasting Vegetables', N'1kg bag of frozen roasting vegetables', 1.5000)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (9, N'Coffee', N'1kg of Arabic coffee', 2.9900)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (10, N'Demera Sugar', N'1kg bag of Demera sugar', 1.0000)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (11, N'Chicken Gravy', N'1 tub of chicken gravy granuals', 0.8900)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (12, N'Yorkshire Pudding', N'1 bag of 12 frozen Yorkshire puddings', 1.3500)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [UnitPrice]) VALUES (13, N'Sage and Onion Stuffing', N'1 box of sage and onion stuffing', 0.5900)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
USE [master]
GO
ALTER DATABASE [SampleData] SET  READ_WRITE 
GO

ALTER DATABASE [SampleData] SET MULTI_USER WITH NO_WAIT;
GO  