USE [master]
GO
/****** Object:  Database [campo]    Script Date: 03/11/2022 20:37:47 ******/
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
/****** Object:  UserDefinedTableType [dbo].[tabla]    Script Date: 03/11/2022 20:37:48 ******/
CREATE TYPE [dbo].[tabla] AS TABLE(
	[id_idioma] [int] NOT NULL,
	[key] [nvarchar](128) NULL,
	[traduccion] [nvarchar](128) NULL
)
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[brands]    Script Date: 03/11/2022 20:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brands](
	[Id_Brand] [nchar](10) NOT NULL,
	[Brand_Desc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[colors]    Script Date: 03/11/2022 20:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[colors](
	[Id_Color] [nchar](10) NOT NULL,
	[Color_Desc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distruibuidores]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[idioma]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[Machines]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[permiso]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[permiso_permiso]    Script Date: 03/11/2022 20:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_permiso](
	[id_permiso_padre] [int] NOT NULL,
	[id_permiso_hijo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reparador]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[Stock]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[traduccion]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[usuario_data]    Script Date: 03/11/2022 20:37:48 ******/
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
/****** Object:  Table [dbo].[usuario_tipo]    Script Date: 03/11/2022 20:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_tipo](
	[Id_tipo] [nchar](10) NOT NULL,
	[Tipo_desc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios_permisos]    Script Date: 03/11/2022 20:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_permisos](
	[id_usuario] [int] NOT NULL,
	[id_permiso] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (3, 27, N'12/10/22', N'06:49:37', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (4, 27, N'12/10/22', N'06:51:23', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (5, 28, N'12/10/22', N'06:52:29', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (6, 27, N'02/11/22', N'23:35:15', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (7, 27, N'03/11/22', N'00:57:39', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (8, 27, N'03/11/22', N'01:01:22', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (9, 27, N'03/11/22', N'01:03:52', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (10, 27, N'03/11/22', N'01:04:25', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (11, 27, N'03/11/22', N'01:08:53', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (12, 27, N'03/11/22', N'01:12:05', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (13, 27, N'03/11/22', N'01:14:24', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (14, 27, N'03/11/22', N'19:31:44', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (15, 27, N'03/11/22', N'19:49:12', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (16, 27, N'03/11/22', N'19:50:48', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (17, 27, N'03/11/22', N'20:03:44', N'El usuario se logueo correctamente', N'Log-in')
INSERT [dbo].[Bitacora] ([ID], [User_ID], [Date], [Time], [Info], [Activity]) VALUES (18, 27, N'03/11/22', N'20:12:49', N'El usuario se logueo correctamente', N'Log-in')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'1         ', N'Lusqtoff')
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'2         ', N'Sommer')
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'3         ', N'Sap')
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'4         ', N'CTec')
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'5         ', N'USA')
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'6         ', N'AirT')
INSERT [dbo].[brands] ([Id_Brand], [Brand_Desc]) VALUES (N'7         ', N'BranC')
GO
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'1         ', N'Rojo')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'2         ', N'Azul')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'3         ', N'Verde')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'4         ', N'Amarillo')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'5         ', N'Naranja')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'6         ', N'Violeta')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'7         ', N'Marron')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'8         ', N'Celeste')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'9         ', N'Negro')
INSERT [dbo].[colors] ([Id_Color], [Color_Desc]) VALUES (N'10        ', N'Blanco')
GO
SET IDENTITY_INSERT [dbo].[idioma] ON 

INSERT [dbo].[idioma] ([id], [name]) VALUES (1, N'Español')
INSERT [dbo].[idioma] ([id], [name]) VALUES (6, N'English')
INSERT [dbo].[idioma] ([id], [name]) VALUES (7, N'Italiano')
INSERT [dbo].[idioma] ([id], [name]) VALUES (8, N'Portuges')
SET IDENTITY_INSERT [dbo].[idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Machines] ON 

INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (1, N'Lusqtoff', N'LF 250', N'4         ', N'Falta la tapa', N'No trajo nada', N'12321kl3j23', N'La apago y no volvio a prender', 1, 1, 1, N'28        ', N'29        ', N'Imposible arreglar', N'5         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (2, N'Lusqtoff', N'LF 350', N'5         ', N'Impecable', N'Porta y Maza', N'kkkasl213ipom', N'No sabe', 1, 1, 1, N'55        ', N'29        ', N'Cambiar bobina de tig', N'14        ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (7, N'Pek', N'001T', N'8         ', N'Sin bobina de primario', N'Nada', N'lafoto', N'necesita rebobinar el primario', 1, 1, 1, N'35        ', N'29        ', N'Cambiar bobina del primario', N'12        ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (8, N'TIZ', N'3', N'4         ', N'La torcha esta sin cabeza', N'Torcha', N'lafoto', N'No puntea', 1, 1, 1, N'35        ', N'29        ', N'Hay que cambiarle la cabeza a la torcha', N'5         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (33, N'Txt Engine', N'TTFS', N'6         ', N'Trajo rollo de cobre 1.5', N'Rollo', N'lafoto', N'No gira el motor', 1, 1, 1, N'60        ', N'59        ', N'El tiristor de la placa estaba quemadisimo', N'9         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (49, N'Lusqtoff', N'250 TS', N'3         ', N'Plastico roto', N'Nada', N'lafoto', N'No entiende nada el cliente', 1, 1, 1, N'28        ', N'29        ', N'Imposible arreglar', N'3         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (50, N'Sommer', N'SM 300', N'1         ', N'Esta muy rayada la tapa y le falta la manija', N'Porta unicamente', N'lafoto', N'Segun el cliente se apago y nunca volvio a prender. hizo un ruido raro la ultima vez que la uso', 1, 1, 1, N'28        ', N'29        ', N'1. Hay que cambiarle la ficha de entrada y el cooler.', N'7         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (51, N'Sommer', N'SM 250', N'1         ', N'1', N'1', N'lafoto', N'1', 1, 1, 1, N'35        ', N'29        ', N'1. Le cambie el interlock porque estaba roto', N'7         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (52, N'Tag', N'TG 200 RC', N'6         ', N'No trajo las ruedas', N'Pelada', N'lafoto', N'Quiere cambiar las ruedas', 1, 1, 1, N'28        ', N'29        ', N'Cambiar las 4 ruedas', N'13        ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (83, N'TT Tek', N'TT02', N'4         ', N'Punteras rotas', N'Torcha y Maza', N'lafoto', N'No hace arco', 1, 1, 1, N'28        ', N'29        ', N'Cambiar tiristor', N'9         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (84, N'FLX', N'FL V', N'7         ', N'Test', N'Test', N'lafoto', N'Test', 1, 1, 1, N'60        ', N'29        ', N'Test', N'3         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (85, N'Marca A', N'ACcme', N'4         ', N'Mswuins ', N'trajo algo', N'lafoto', N'no anda', 1, 1, 0, N'55        ', N'59        ', N'No andaba la pantalla', N'7         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (1085, N'Simantec', N'SIM 700', N'6         ', N'Soldadora de arco vieja', N'Nada, sin chapas', N'lafoto', N'No hace arco pero tiene salida', 0, 0, 0, N'55        ', N'29        ', N'No se reviso', N'0         ')
INSERT [dbo].[Machines] ([Id_Machine], [Id_Brand], [Id_Model], [Id_Color], [Description], [Elements], [Picture], [Failure], [isRevisada], [possibleToRepair], [isApproved], [Id_User], [Id_Client], [Reparation], [Hours]) VALUES (1086, N'Gustavo', N'Cerati', N'4         ', N'Bajan', N'La noche', N'lafoto', N'Se oculta la voz', 0, 0, 0, N'55        ', N'59        ', N'No se reviso', N'0         ')
SET IDENTITY_INSERT [dbo].[Machines] OFF
GO
SET IDENTITY_INSERT [dbo].[permiso] ON 

INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'AprobarMaquina', 17, N'AprobarMaquina', N'Menu de aprobaciones')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'Asignacion', 24, N'Asignacion', N'Menu de asignaciones')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'CrearUsuario', 23, N'CrearUsuario', N'Menu para crear usuarios')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'Default', 3, N'Default', N'Este permiso lo tienen todos los usuarios')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'IngresarMaquina', 19, N'IngresarMaquina', N'Menu de ingresos')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'MenuConfig', 10, N'MenuConfig', N'Menu de configuraciones')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'ModificarIdioma', 21, N'ModificarIdiomas', N'Permite modificar los idiomas')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'NuevaFamilia1', 20, NULL, NULL)
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'PatentesFamilias', 4, N'PatentesFamilias', N'Menu Patentes y familias')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'PatentesUsuarios', 5, N'PatentesUsuarios', N'Menu Patentes de Usuarios')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'Pozi', 14, N'Default', N'Test')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'Prespuestar', 18, N'Presupuestar', N'Menu de presupuesto')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'Super User', 11, N'Todo', N'Full')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'Test3', 22, NULL, NULL)
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'testasd', 25, NULL, NULL)
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'UsuarioCliente', 7, NULL, N'Menu cliente')
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'UsuarioEmpleado', 2, NULL, NULL)
INSERT [dbo].[permiso] ([nombre], [id], [permiso], [descripcion]) VALUES (N'UsuarioGerente', 8, NULL, NULL)
SET IDENTITY_INSERT [dbo].[permiso] OFF
GO
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (1, 3)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (2, 7)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 5)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 10)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 4)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (11, 2)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (11, 8)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (1, 12)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (13, 11)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (13, 12)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 10)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 4)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 10)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 4)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 5)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 2)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 5)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 7)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (2, 18)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (2, 19)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 18)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 19)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 17)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (2, 24)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 21)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 24)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (8, 23)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (20, 22)
GO
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'28                            ', N'8                             ', N'5                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'28                            ', N'1                             ', N'5                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'28                            ', N'49                            ', N'3                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'28                            ', N'50                            ', N'7                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'35                            ', N'2                             ', N'14                            ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'35                            ', N'51                            ', N'7                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'60                            ', N'84                            ', N'3                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'35                            ', N'7                             ', N'12                            ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'28                            ', N'83                            ', N'9                             ')
INSERT [dbo].[reparador] ([Id_User], [Id_Maquina], [Horas]) VALUES (N'60                            ', N'33                            ', N'9                             ')
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (1, N'IGBT60G600', N'Transistor igbt 60A 600V', 30, 30, 10)
INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (2, N'IGBT40G600', N'Transistor igbt 40A 600V', 22, 30, 12)
INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (3, N'DIODO30A120', N'Diodo 30A 1200V', 8, 30, 20)
INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (4, N'POTE10KB', N'Potenciometro 10K Lineal', 21, 30, 10)
INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (5, N'POTE100KB', N'Potenciometro 100K Lineal', 12, 30, 10)
INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (6, N'RES1W4X200R', N'Resistencia 025Watt 200Ohm', 120, 30, 10)
INSERT [dbo].[Stock] ([ID], [Name], [Description], [Quantity], [StockLimit], [MiniumStock]) VALUES (7, N'CAP2200UF50V', N'Capacitor 2200uF x 50V', 2, 30, 5)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AAgregarFamiliasTitulo', N'Asignar familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AAgregarPatentesTitulo', N'Asignar patente')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AAsignarButton', N'Asignar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AAsignarButton2', N'Asignar ')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AConfigurarButton', N'Configurar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AEliminarButton', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AEliminarButton2', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AGuardarButton', N'Guardar cambios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AIdioma', N'1. A. Usuarios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AReiniciarPasswordButton', N'Reiniciar contraseña')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1ATodosUsuariosTitulo', N'Todos los usuarios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1AUsuariosTitulo', N'Usuarios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BAgregarButton', N'Agregar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BAgregarButton2', N'Agregar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BConfigurarButton', N'Configurar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BConfigurarFamiliaTitulo', N'Configurar familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BDescripcionTitulo', N'Descripcion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BFamiliasTitulo', N'Familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BGuardarButton', N'Guardar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BGuardarFamilia', N'Guardar familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BNombreTitulo', N'Nombre de la familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BNuevaFamiliaTitulo', N'Nueva familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BPatentesTitulo', N'Patentes')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BPatentesyFamilias', N'1. B. Patentes y Familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BRemoverButton', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BRemoverButton2', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BTodasFamiliasTitulo', N'Todas las familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1BTodasPatentesTitulo', N'Todas las patentes')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1CCrearButton', N'Crear')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1CGuardarButton', N'Guardar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1CIdiomas', N'1. C. Idiomas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1CLenguageTitulo', N'Idioma')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1Configuracion', N'1. Configuracion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DApellidoTitulo', N'Apellido')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DContraseniaTitulo', N'Contraseña')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DCorreoTitulo', N'Correo electronico')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DCrearUsuario', N'1. D. Crear Usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DCrearUsuarioButton', N'Crear usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DDireccionTitulo', N'Direccion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DDNITitulo', N'DNI')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DIdiomaTitulo', N'Idioma principal')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DNombreTitulo', N'Nombre')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DNombreUsuarioTitulo', N'Nombre de usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DTelefonoTitulo', N'Telefono')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'1DTipoTitulo', N'Tipo de usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AClienteTitulo', N'Cliente')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AColorTitulo', N'Color')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2ADescripcionTitulo', N'Descripcion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AElementosTitulo', N'Elementos incluidos')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AFallaTitulo', N'Falla presentada')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AFecha', N'Fecha de ingreso')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AIngresarButton', N'Ingresar maquina')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AIngresos', N'2. A. Ingresos')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AMarcaTitulo', N'Marca original')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2AModelo', N'Modelo')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2ARemitoButton', N'Crear remito')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2ASoldaduraTitulo', N'Tipo de soldadura')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BCantidadTitulo', N'Cantidad de horas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BMaquinasTitulo', N'Maquina')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BNoRepararButton', N'Imposible reparar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BPresupuestar', N'Presupuestar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BReparaciones', N'2. B. Reparaciones')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BReparacionesTitulo', N'Reparaciones hechas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BRevalidarButton', N'Re-validar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2BRevisadaCheck', N'Esta revisada?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CAprobaciones', N'2. C. Aprobaciones')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CAprobarButton', N'Aprobar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CMaquinasTitulo', N'Maquina')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CReparaciones', N'A reparar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CReprobarButton', N'Revocar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CRevalidarButton', N'Re-validar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2CValidadaCheck', N'Esta validada?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2DAsignaciones', N'2. D. Asignaciones')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2DHorasTitulo', N'Cantidad de horas asignadas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2DMaquinasTitulo', N'Maquinas asignadas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2DReparador', N'Reparador')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2EAprobacionTitulo', N'Maquinas sin aprobar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2EDashboard', N'2. E. Dashboard')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2ERevisarTitulo', N'Maquinas sin revision')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2FCalculadora', N'2. F. Calculadora')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2FCalcularButton', N'Calcular')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2FCostoTitulo', N'Costo aproximado')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2FDolarTitulo', N'Precio del dolar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2FHorasTitulo', N'Cantidad de horas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'2Maquinas', N'2. Maquinas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'3Salir', N'3. Salir')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (1, N'4CambiarIdioma', N'4. Cambiar Idioma')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AAgregarFamiliasTitulo', N'Assing family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AAgregarPatentesTitulo', N'Assing patent')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AAsignarButton', N'Assing')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AAsignarButton2', N'Assing')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AConfigurarButton', N'Configurate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AEliminarButton', N'Remove')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AEliminarButton2', N'Remove')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AGuardarButton', N'Save changes')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AIdioma', N'1. A. Users settings')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AReiniciarPasswordButton', N'Reset password')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1ATodosUsuariosTitulo', N'All users')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1AUsuariosTitulo', N'Users')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BAgregarButton', N'Add')
GO
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BAgregarButton2', N'Add')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BConfigurarButton', N'Configurate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BConfigurarFamiliaTitulo', N'Configurate family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BDescripcionTitulo', N'Description')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BFamiliasTitulo', N'Family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BGuardarButton', N'Save')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BGuardarFamilia', N'Save family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BNombreTitulo', N'Name of the family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BNuevaFamiliaTitulo', N'New family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BPatentesTitulo', N'Patents')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BPatentesyFamilias', N'1. B. Families and Patents')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BRemoverButton', N'Remove')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BRemoverButton2', N'Remove')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BTodasFamiliasTitulo', N'All families')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1BTodasPatentesTitulo', N'All patents')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1CCrearButton', N'Create')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1CGuardarButton', N'Save')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1CIdiomas', N'1. C. Languages')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1CLenguageTitulo', N'Language')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1Configuracion', N'1. Configuration')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DApellidoTitulo', N'Surename')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DContraseniaTitulo', N'Password')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DCorreoTitulo', N'E-Mail')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DCrearUsuario', N'1. D. Create user')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DCrearUsuarioButton', N'Create user')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DDireccionTitulo', N'Address')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DDNITitulo', N'Personal ID')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DIdiomaTitulo', N'Principal language')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DNombreTitulo', N'Name')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DNombreUsuarioTitulo', N'User name')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DTelefonoTitulo', N'Phone')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'1DTipoTitulo', N'User type')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AClienteTitulo', N'Client')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AColorTitulo', N'Color')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2ADescripcionTitulo', N'Description')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AElementosTitulo', N'Elements included')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AFallaTitulo', N'Failure described')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AFecha', N'Date of arrival?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AIngresarButton', N'Setup machine')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AIngresos', N'2. A.Machines setup')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AMarcaTitulo', N'Brand')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2AModelo', N'Model')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2ARemitoButton', N'Generate remito')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2ASoldaduraTitulo', N'Welding type')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BCantidadTitulo', N'Hour quantity')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BMaquinasTitulo', N'Machine')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BNoRepararButton', N'Impossible to repair')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BPresupuestar', N'Pass revision')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BReparaciones', N'2. B. Repairs')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BReparacionesTitulo', N'Repairs done')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BRevalidarButton', N'Re-validate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2BRevisadaCheck', N'Is reviewed?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CAprobaciones', N'2. C. Approvals')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CAprobarButton', N'Approve')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CMaquinasTitulo', N'Machine')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CReparaciones', N'To repair')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CReprobarButton', N'Revoke')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CRevalidarButton', N'Re-validate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2CValidadaCheck', N'Is validated?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2DAsignaciones', N'2.D. Assignations')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2DHorasTitulo', N'Hours quantity')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2DMaquinasTitulo', N'Assigned machines')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2DReparador', N'Fixer')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2EAprobacionTitulo', N'Not approved')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2EDashboard', N'2. E. Dashboard')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2ERevisarTitulo', N'Not reviewd')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2FCalculadora', N'2. F. Calculator')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2FCalcularButton', N'Calculate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2FCostoTitulo', N'Aproximated cost')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2FDolarTitulo', N'Conversion rate USD')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2FHorasTitulo', N'Hours quantity')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'2Maquinas', N'2. Machines')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'3Salir', N'3. Exit')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (6, N'4CambiarIdioma', N'4. Change language')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AAgregarFamiliasTitulo', N'Asigare famile')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AAgregarPatentesTitulo', N'Asignare patenti')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AAsignarButton', N'Asignare')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AAsignarButton2', N'Asignare')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AConfigurarButton', N'Configuratti')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AEliminarButton', N'Removi')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AEliminarButton2', N'Removi')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AGuardarButton', N'Guardare cambie')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AIdioma', N'1. A. Lingua')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AReiniciarPasswordButton', N'Reiniciali password')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1ATodosUsuariosTitulo', N'Todi usuais')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1AUsuariosTitulo', N'Usuari')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BAgregarButton', N'Agreggatti')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BAgregarButton2', N'Aggregatti')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BConfigurarButton', N'Configuratte')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BConfigurarFamiliaTitulo', N'Configurate family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BDescripcionTitulo', N'Description')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BFamiliasTitulo', N'Family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BGuardarButton', N'Save')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BGuardarFamilia', N'Save family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BNombreTitulo', N'Name of the family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BNuevaFamiliaTitulo', N'New family')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BPatentesTitulo', N'Patents')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BPatentesyFamilias', N'1. B. Famile')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BRemoverButton', N'Remove')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BRemoverButton2', N'Remove')
GO
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BTodasFamiliasTitulo', N'All families')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1BTodasPatentesTitulo', N'All patents')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1CCrearButton', N'Create')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1CGuardarButton', N'Save')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1CIdiomas', N'1. C. Linguas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1CLenguageTitulo', N'Language')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1Configuracion', N'1. Configurazione')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DApellidoTitulo', N'Surename')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DContraseniaTitulo', N'Password')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DCorreoTitulo', N'E-Mail')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DCrearUsuario', N'1. D. Create user')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DCrearUsuarioButton', N'Create user')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DDireccionTitulo', N'Address')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DDNITitulo', N'Personal ID')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DIdiomaTitulo', N'Principal language')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DNombreTitulo', N'Name')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DNombreUsuarioTitulo', N'User name')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DTelefonoTitulo', N'Phone')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'1DTipoTitulo', N'User type')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AClienteTitulo', N'Client')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AColorTitulo', N'Color')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2ADescripcionTitulo', N'Description')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AElementosTitulo', N'Elements included')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AFallaTitulo', N'Failure described')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AFecha', N'Date of arrival?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AIngresarButton', N'Setup machine')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AIngresos', N'2. A.Machines setup')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AMarcaTitulo', N'Brand')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2AModelo', N'Model')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2ARemitoButton', N'Generate remito')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2ASoldaduraTitulo', N'Welding type')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BCantidadTitulo', N'Hour quantity')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BMaquinasTitulo', N'Machine')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BNoRepararButton', N'Impossible to repair')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BPresupuestar', N'Pass revision')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BReparaciones', N'2. B. Repairs')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BReparacionesTitulo', N'Repairs done')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BRevalidarButton', N'Re-validate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2BRevisadaCheck', N'Is reviewed?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CAprobaciones', N'2. C. Approvals')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CAprobarButton', N'Approve')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CMaquinasTitulo', N'Machine')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CReparaciones', N'To repair')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CReprobarButton', N'Revoke')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CRevalidarButton', N'Re-validate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2CValidadaCheck', N'Is validated?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2DAsignaciones', N'2.D. Assignations')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2DHorasTitulo', N'Hours quantity')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2DMaquinasTitulo', N'Assigned machines')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2DReparador', N'Fixer')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2EAprobacionTitulo', N'Machines without approval')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2EDashboard', N'2. E. Dashboard')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2ERevisarTitulo', N'Machines without review')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2FCalculadora', N'2. F. Calculator')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2FCalcularButton', N'Calculate')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2FCostoTitulo', N'Aproximated cost')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2FDolarTitulo', N'Dollar conversion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2FHorasTitulo', N'Hours quantity')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'2Maquinas', N'2. Maquini')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'3Salir', N'3. Esite')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (7, N'4CambiarIdioma', N'4. Cambiare lingua')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AAgregarFamiliasTitulo', N'Asignar familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AAgregarPatentesTitulo', N'Asignar patente')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AAsignarButton', N'Asignar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AAsignarButton2', N'Asignar ')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AConfigurarButton', N'Configurar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AEliminarButton', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AEliminarButton2', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AGuardarButton', N'Guardar cambios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AIdioma', N'1. A. Usuarios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AReiniciarPasswordButton', N'Reiniciar contraseña')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1ATodosUsuariosTitulo', N'Todos los usuarios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1AUsuariosTitulo', N'Usuarios')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BAgregarButton', N'Agregar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BAgregarButton2', N'Agregar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BConfigurarButton', N'Configurar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BConfigurarFamiliaTitulo', N'Configurar familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BDescripcionTitulo', N'Descripcion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BFamiliasTitulo', N'Familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BGuardarButton', N'Guardar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BGuardarFamilia', N'Guardar familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BNombreTitulo', N'Nombre de la familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BNuevaFamiliaTitulo', N'Nueva familia')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BPatentesTitulo', N'Patentes')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BPatentesyFamilias', N'1. B. Patentes y Familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BRemoverButton', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BRemoverButton2', N'Remover')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BTodasFamiliasTitulo', N'Todas las familias')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1BTodasPatentesTitulo', N'Todas las patentes')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1CCrearButton', N'Crear')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1CGuardarButton', N'Guardar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1CIdiomas', N'1. C. Idiomas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1CLenguageTitulo', N'Idioma')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1Configuracion', N'1. Configuracao')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DApellidoTitulo', N'Apellido')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DContraseniaTitulo', N'Contraseña')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DCorreoTitulo', N'Correo electronico')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DCrearUsuario', N'1. D. Crear Usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DCrearUsuarioButton', N'Crear usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DDireccionTitulo', N'Direccion')
GO
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DDNITitulo', N'DNI')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DIdiomaTitulo', N'Idioma principal')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DNombreTitulo', N'Nombre')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DNombreUsuarioTitulo', N'Nombre de usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DTelefonoTitulo', N'Telefono')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'1DTipoTitulo', N'Tipo de usuario')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AClienteTitulo', N'Cliente')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AColorTitulo', N'Color')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2ADescripcionTitulo', N'Descripcion')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AElementosTitulo', N'Elementos incluidos')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AFallaTitulo', N'Falla presentada')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AFecha', N'Fecha de ingreso')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AIngresarButton', N'Ingresar maquina')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AIngresos', N'2. A. Ingresos')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AMarcaTitulo', N'Marca original')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2AModelo', N'Modelo')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2ARemitoButton', N'Crear remito')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2ASoldaduraTitulo', N'Tipo de soldadura')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BCantidadTitulo', N'Cantidad de horas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BMaquinasTitulo', N'Maquina')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BNoRepararButton', N'Imposible reparar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BPresupuestar', N'Presupuestar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BReparaciones', N'2. B. Reparaciones')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BReparacionesTitulo', N'Reparaciones hechas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BRevalidarButton', N'Re-validar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2BRevisadaCheck', N'Esta revisada?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CAprobaciones', N'2. C. Aprobaciones')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CAprobarButton', N'Aprobar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CMaquinasTitulo', N'Maquina')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CReparaciones', N'A reparar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CReprobarButton', N'Revocar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CRevalidarButton', N'Re-validar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2CValidadaCheck', N'Esta validada?')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2DAsignaciones', N'2. D. Asignaciones')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2DHorasTitulo', N'Cantidad de horas asignadas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2DMaquinasTitulo', N'Maquinas asignadas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2DReparador', N'Reparador')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2EAprobacionTitulo', N'Maquinas sin aprobar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2EDashboard', N'2. E. Dashboard')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2ERevisarTitulo', N'Maquinas sin revision')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2FCalculadora', N'2. F. Calculadora')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2FCalcularButton', N'Calcular')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2FCostoTitulo', N'Costo aproximado')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2FDolarTitulo', N'Precio del dolar')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2FHorasTitulo', N'Cantidad de horas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'2Maquinas', N'2. Maquinas')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'3Salir', N'3. Salir')
INSERT [dbo].[traduccion] ([id_idioma], [key], [traduccion]) VALUES (8, N'4CambiarIdioma', N'4. Cambiar Idioma')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (27, N'admin', N'MyQce23+1e0=', N'julianlastra.kz@gmail.com', 1, 0, 0, N'0         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (72, N'diegopt', N'Yo/Jylr5VDs=', N'sss', 1, 0, 0, N'1         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (55, N'dummy', N'BJ+niKjBwaA=', N'false@email.com', 1, 1, 0, N'1         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (60, N'Fernando', N'IXFsOXzrutk=', N'fernando@gmail.com.es', 1, 0, 0, N'1         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (28, N'julian', N'MyQce23+1e0=', N'julian_b96@hotmail.com', 1, 0, 0, N'1         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (29, N'luis', N'MyQce23+1e0=', N'luis.centurion@gmail.com', 1, 0, 0, N'2         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (35, N'matias', N'MyQce23+1e0=', N'matias.gomez@gmail.com', 1, 0, 0, N'1         ', NULL, NULL)
INSERT [dbo].[Users] ([id_usuario], [UserName], [Password], [Email], [key_idioma], [Tries], [isBlocked], [id_tipo], [id_dv], [digitoverificador]) VALUES (59, N'Pedro', N'21345569A', N'pedro@cass.com', 1, 0, 0, N'2         ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (27, N'Julian', N'Lastra', N'1159363830', N'Tuvi 123', N'39430861')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (28, N'Julian', N'Lastra', N'1159363830', N'Tuvi 234', N'39430863')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (29, N'Luis', N'Centurion', N'1112346578', N'Quilmes 1542', N'4132987')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (35, N'Matias', N'Gomez', N'1178945321', N'Amorena 123', N'41875112')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (55, N'Dummy', N'Worker', N'1234123412', N'Dummy 123', N'9992345')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (59, N'Pedro', N'Casas', N'2399443', N'Dir 22', N'99923')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (60, N'Fernando', N'Lucia', N'42929212', N'Quinteros 994', N'39423213')
INSERT [dbo].[usuario_data] ([id_usuario], [nombre], [apellido], [telefono], [direccion], [dni]) VALUES (72, N'Diego', N'Pete', N'1234', N'asd', N'1234')
GO
INSERT [dbo].[usuario_tipo] ([Id_tipo], [Tipo_desc]) VALUES (N'1         ', N'Reparador')
INSERT [dbo].[usuario_tipo] ([Id_tipo], [Tipo_desc]) VALUES (N'2         ', N'Cliente')
INSERT [dbo].[usuario_tipo] ([Id_tipo], [Tipo_desc]) VALUES (N'0         ', N'Gerente')
GO
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (27, 24)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (27, 23)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (29, 7)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (28, 2)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (27, 11)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (27, 8)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (55, 14)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (55, 2)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (60, 2)
GO
/****** Object:  StoredProcedure [dbo].[InsertTable]    Script Date: 03/11/2022 20:37:48 ******/
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
