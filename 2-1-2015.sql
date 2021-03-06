USE [master]
GO
/****** Object:  Database [StudentInfo]    Script Date: 02/01/2015 04:02:28 PM ******/
CREATE DATABASE [StudentInfo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentInfo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StudentInfo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentInfo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StudentInfo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentInfo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentInfo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentInfo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentInfo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StudentInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentInfo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentInfo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentInfo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentInfo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentInfo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentInfo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentInfo] SET  MULTI_USER 
GO
ALTER DATABASE [StudentInfo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentInfo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentInfo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentInfo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StudentInfo]
GO
/****** Object:  Table [dbo].[t_Department]    Script Date: 02/01/2015 04:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Student]    Script Date: 02/01/2015 04:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[dept_no] [int] NOT NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[t_Department] ON 

INSERT [dbo].[t_Department] ([id], [name]) VALUES (1, N'CSE')
INSERT [dbo].[t_Department] ([id], [name]) VALUES (2, N'EEE')
INSERT [dbo].[t_Department] ([id], [name]) VALUES (3, N'ETE')
SET IDENTITY_INSERT [dbo].[t_Department] OFF
SET IDENTITY_INSERT [dbo].[t_Student] ON 

INSERT [dbo].[t_Student] ([id], [name], [dept_no], [email]) VALUES (5, N'Amena', 1, NULL)
INSERT [dbo].[t_Student] ([id], [name], [dept_no], [email]) VALUES (6, N'Tasneem', 2, NULL)
INSERT [dbo].[t_Student] ([id], [name], [dept_no], [email]) VALUES (7, N'Aleem', 1, NULL)
INSERT [dbo].[t_Student] ([id], [name], [dept_no], [email]) VALUES (12, N'Sabith', 1, N'sa@d.com')
INSERT [dbo].[t_Student] ([id], [name], [dept_no], [email]) VALUES (13, N'Emu', 2, N'e@g.com')
SET IDENTITY_INSERT [dbo].[t_Student] OFF
ALTER TABLE [dbo].[t_Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_t_Department] FOREIGN KEY([dept_no])
REFERENCES [dbo].[t_Department] ([id])
GO
ALTER TABLE [dbo].[t_Student] CHECK CONSTRAINT [FK_Student_t_Department]
GO
USE [master]
GO
ALTER DATABASE [StudentInfo] SET  READ_WRITE 
GO
