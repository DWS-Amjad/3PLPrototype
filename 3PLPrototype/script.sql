USE [master]
GO
/****** Object:  Database [STEInterfaces]    Script Date: 7/13/2018 11:19:40 AM ******/
CREATE DATABASE [STEInterfaces]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STEInterfaces', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\STEInterfaces.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'STEInterfaces_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\STEInterfaces_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [STEInterfaces] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STEInterfaces].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STEInterfaces] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STEInterfaces] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STEInterfaces] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STEInterfaces] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STEInterfaces] SET ARITHABORT OFF 
GO
ALTER DATABASE [STEInterfaces] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STEInterfaces] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STEInterfaces] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STEInterfaces] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STEInterfaces] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STEInterfaces] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STEInterfaces] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STEInterfaces] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STEInterfaces] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STEInterfaces] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STEInterfaces] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STEInterfaces] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STEInterfaces] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STEInterfaces] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STEInterfaces] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STEInterfaces] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STEInterfaces] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STEInterfaces] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [STEInterfaces] SET  MULTI_USER 
GO
ALTER DATABASE [STEInterfaces] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STEInterfaces] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STEInterfaces] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STEInterfaces] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [STEInterfaces] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [STEInterfaces] SET QUERY_STORE = OFF
GO
USE [STEInterfaces]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [STEInterfaces]
GO
/****** Object:  Table [dbo].[ApplicationEventMaster]    Script Date: 7/13/2018 11:19:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationEventMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ApplicationEventMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationLog]    Script Date: 7/13/2018 11:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationLog](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[ApplicationEventId] [int] NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ApplicationLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationMaster]    Script Date: 7/13/2018 11:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ConfigFilePath] [nvarchar](255) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ApplicationMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorInboundData]    Script Date: 7/13/2018 11:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorInboundData](
	[Id] [uniqueidentifier] NOT NULL,
	[ErrorType] [nvarchar](50) NOT NULL,
	[DataType] [nvarchar](50) NOT NULL,
	[DataKey] [nvarchar](50) NOT NULL,
	[DataValue] [nvarchar](50) NOT NULL,
	[DataPath] [nvarchar](255) NOT NULL,
	[SysErrorMsg] [nvarchar](255) NOT NULL,
	[CustomErrorMsg] [nvarchar](255) NOT NULL,
	[IsRectifiable] [bit] NOT NULL,
	[ErrorXmlId] [uniqueidentifier] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorInboundData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorSuggestion]    Script Date: 7/13/2018 11:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorSuggestion](
	[Id] [uniqueidentifier] NOT NULL,
	[ErrorInboundDataId] [uniqueidentifier] NOT NULL,
	[Suggestion] [nvarchar](50) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorSuggestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorXml]    Script Date: 7/13/2018 11:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorXml](
	[Id] [uniqueidentifier] NOT NULL,
	[Client_Code] [nvarchar](50) NOT NULL,
	[Warehouse_Code] [nvarchar](50) NOT NULL,
	[XmlContent] [xml] NOT NULL,
	[DocumentUniqueId] [nvarchar](50) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorXml] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApplicationLog] ADD  CONSTRAINT [DF_ApplicationLog_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ErrorInboundData] ADD  CONSTRAINT [DF_ErrorInboundData_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ErrorSuggestion] ADD  CONSTRAINT [DF_ErrorSuggestion_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ErrorXml] ADD  CONSTRAINT [DF_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ApplicationLog]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationLog_ApplicationEventMaster] FOREIGN KEY([ApplicationEventId])
REFERENCES [dbo].[ApplicationEventMaster] ([Id])
GO
ALTER TABLE [dbo].[ApplicationLog] CHECK CONSTRAINT [FK_ApplicationLog_ApplicationEventMaster]
GO
ALTER TABLE [dbo].[ApplicationLog]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationLog_ApplicationMaster] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[ApplicationMaster] ([Id])
GO
ALTER TABLE [dbo].[ApplicationLog] CHECK CONSTRAINT [FK_ApplicationLog_ApplicationMaster]
GO
ALTER TABLE [dbo].[ErrorInboundData]  WITH CHECK ADD  CONSTRAINT [FK_ErrorInboundData_ErrorXml] FOREIGN KEY([ErrorXmlId])
REFERENCES [dbo].[ErrorXml] ([Id])
GO
ALTER TABLE [dbo].[ErrorInboundData] CHECK CONSTRAINT [FK_ErrorInboundData_ErrorXml]
GO
ALTER TABLE [dbo].[ErrorSuggestion]  WITH CHECK ADD  CONSTRAINT [FK_ErrorSuggestion_ErrorInboundData] FOREIGN KEY([ErrorInboundDataId])
REFERENCES [dbo].[ErrorInboundData] ([Id])
GO
ALTER TABLE [dbo].[ErrorSuggestion] CHECK CONSTRAINT [FK_ErrorSuggestion_ErrorInboundData]
GO
USE [master]
GO
ALTER DATABASE [STEInterfaces] SET  READ_WRITE 
GO
