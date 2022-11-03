USE [master]
GO
/****** Object:  Database [campo]    Script Date: 03/11/2022 20:16:00 ******/
CREATE DATABASE [campo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'campo', FILENAME = N'C:\SQL2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\campo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'campo_log', FILENAME = N'C:\SQL2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\campo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [campo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [campo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [campo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [campo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [campo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [campo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [campo] SET ARITHABORT OFF 
GO
ALTER DATABASE [campo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [campo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [campo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [campo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [campo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [campo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [campo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [campo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [campo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [campo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [campo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [campo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [campo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [campo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [campo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [campo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [campo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [campo] SET RECOVERY FULL 
GO
ALTER DATABASE [campo] SET  MULTI_USER 
GO
ALTER DATABASE [campo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [campo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [campo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [campo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [campo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [campo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [campo] SET QUERY_STORE = OFF
GO
USE [campo]
GO
/****** Object:  UserDefinedTableType [dbo].[tabla]    Script Date: 03/11/2022 20:16:00 ******/
CREATE TYPE [dbo].[tabla] AS TABLE(
	[id_idioma] [int] NOT NULL,
	[key] [nvarchar](128) NULL,
	[traduccion] [nvarchar](128) NULL
)
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[Time] [nvarchar](50) NOT NULL,
	[Info] [text] NOT NULL,
	[Activity] [text] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[brands]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brands](
	[Id_Brand] [nchar](10) NOT NULL,
	[Brand_Desc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[colors]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[colors](
	[Id_Color] [nchar](10) NOT NULL,
	[Color_Desc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distruibuidores]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distruibuidores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CUIT] [int] NOT NULL,
	[Telephone] [int] NOT NULL,
 CONSTRAINT [PK_Distruibuidores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idioma]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machines](
	[Id_Machine] [int] IDENTITY(1,1) NOT NULL,
	[Id_Brand] [nvarchar](50) NOT NULL,
	[Id_Model] [nvarchar](50) NOT NULL,
	[Id_Color] [nchar](10) NOT NULL,
	[Description] [ntext] NOT NULL,
	[Elements] [ntext] NOT NULL,
	[Picture] [nvarchar](50) NOT NULL,
	[Failure] [ntext] NOT NULL,
	[isRevisada] [bit] NOT NULL,
	[possibleToRepair] [bit] NOT NULL,
	[isApproved] [bit] NOT NULL,
	[Id_User] [nchar](10) NOT NULL,
	[Id_Client] [nchar](10) NOT NULL,
	[Reparation] [ntext] NOT NULL,
	[Hours] [nchar](10) NULL,
 CONSTRAINT [PK_Machines] PRIMARY KEY CLUSTERED 
(
	[Id_Machine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso](
	[nombre] [varchar](100) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[permiso] [varchar](50) NULL,
	[descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso_permiso]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_permiso](
	[id_permiso_padre] [int] NOT NULL,
	[id_permiso_hijo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reparador]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reparador](
	[Id_User] [nchar](30) NOT NULL,
	[Id_Maquina] [nchar](30) NOT NULL,
	[Horas] [nchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[StockLimit] [int] NULL,
	[MiniumStock] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traduccion]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traduccion](
	[id_idioma] [int] NOT NULL,
	[key] [varchar](100) NOT NULL,
	[traduccion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_traduccion] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC,
	[key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[key_idioma] [int] NOT NULL,
	[Tries] [int] NOT NULL,
	[isBlocked] [bit] NOT NULL,
	[id_tipo] [nchar](10) NOT NULL,
	[id_dv] [nchar](10) NULL,
	[digitoverificador] [text] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_data]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_data](
	[id_usuario] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[telefono] [varchar](100) NULL,
	[direccion] [varchar](300) NULL,
	[dni] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuario_data] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_tipo]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_tipo](
	[Id_tipo] [nchar](10) NOT NULL,
	[Tipo_desc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios_permisos]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_permisos](
	[id_usuario] [int] NOT NULL,
	[id_permiso] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertTable]    Script Date: 03/11/2022 20:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTable]
    @tabla tabla readonly
AS
BEGIN
    insert into [dbo].traduccion select * from @tabla 
END
GO
USE [master]
GO
ALTER DATABASE [campo] SET  READ_WRITE 
GO
