USE [master]
GO
/****** Object:  Database [Hotel_7]    Script Date: 6/11/2019 9:06:45 p. m. ******/
CREATE DATABASE [Hotel_7]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotel_7', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hotel_7.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hotel_7_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hotel_7_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Hotel_7] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotel_7].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotel_7] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotel_7] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotel_7] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotel_7] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotel_7] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotel_7] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hotel_7] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotel_7] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotel_7] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotel_7] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotel_7] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotel_7] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotel_7] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotel_7] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotel_7] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hotel_7] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotel_7] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotel_7] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotel_7] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotel_7] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotel_7] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hotel_7] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotel_7] SET RECOVERY FULL 
GO
ALTER DATABASE [Hotel_7] SET  MULTI_USER 
GO
ALTER DATABASE [Hotel_7] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotel_7] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotel_7] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotel_7] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hotel_7] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Hotel_7', N'ON'
GO
ALTER DATABASE [Hotel_7] SET QUERY_STORE = OFF
GO
USE [Hotel_7]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 6/11/2019 9:06:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](8) NULL,
	[nombre] [nvarchar](100) NULL,
	[observacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categoria_IdCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[NoDocumento] [nvarchar](45) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[primerApellido] [nvarchar](45) NULL,
	[segundoApellido] [nvarchar](45) NULL,
	[telefonoFijo] [nvarchar](45) NULL,
	[celular] [nvarchar](45) NULL,
	[correo] [nvarchar](200) NULL,
	[fechaNacimiento] [varchar](100) NULL,
	[noTarjetaCredito] [nvarchar](45) NULL,
	[clienteId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Clientes_NoDocumento] PRIMARY KEY CLUSTERED 
(
	[NoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsumoMiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsumoMiniBar](
	[IdConsumoMiniBar] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NULL,
	[valor] [decimal](10, 0) NULL,
	[Reserva] [int] NOT NULL,
	[MiniBarxHabitacion_IdMiniBarxHabitacion] [int] NOT NULL,
 CONSTRAINT [PK_ConsumoMiniBar_IdConsumoMiniBar] PRIMARY KEY CLUSTERED 
(
	[IdConsumoMiniBar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitaciones]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[IdHabitaciones] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](8) NULL,
	[precio] [decimal](18, 2) NULL,
	[estado] [varchar](2) NULL,
	[Categoria_IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Habitaciones_IdHabitaciones] PRIMARY KEY CLUSTERED 
(
	[IdHabitaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Huspedes]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Huspedes](
	[idHuesped] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[primerApellido] [nvarchar](45) NULL,
	[segundoApellido] [nvarchar](45) NULL,
	[noDocumento] [nvarchar](45) NULL,
	[telefonoFijo] [nvarchar](45) NULL,
	[celular] [nvarchar](45) NULL,
	[correo] [nvarchar](200) NULL,
	[fechaNacimiento] [varchar](30) NULL,
 CONSTRAINT [PK_Huspedes_idHuesped] PRIMARY KEY CLUSTERED 
(
	[idHuesped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaMobiliario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaMobiliario](
	[IdListaMobiliario] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](8) NULL,
	[nombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_ListaMobiliario_IdListaMobiliario] PRIMARY KEY CLUSTERED 
(
	[IdListaMobiliario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiniBar](
	[IdMiniBar] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](8) NULL,
	[nombre] [nvarchar](100) NULL,
	[cantidad] [int] NULL,
	[precio] [decimal](10, 0) NULL,
 CONSTRAINT [PK_MiniBar_IdMiniBar] PRIMARY KEY CLUSTERED 
(
	[IdMiniBar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiniBarxHabitacion]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiniBarxHabitacion](
	[IdMiniBarxHabitacion] [int] NOT NULL,
	[cantidad] [nvarchar](45) NULL,
	[valorTotal] [decimal](10, 0) NULL,
	[Habitaciones_IdHabitaciones] [int] NOT NULL,
	[MiniBar_IdMiniBar] [int] NOT NULL,
 CONSTRAINT [PK_MiniBarxHabitacion_IdMiniBarxHabitacion] PRIMARY KEY CLUSTERED 
(
	[IdMiniBarxHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MobiliarioxHabitaciones]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobiliarioxHabitaciones](
	[IdMobiliarioxHabitaciones] [int] IDENTITY(1,1) NOT NULL,
	[ListaMobiliario_IdListaMobiliario] [int] NOT NULL,
	[Habitaciones_IdHabitaciones] [int] NOT NULL,
 CONSTRAINT [PK_MobiliarioxHabitaciones_IdMobiliarioxHabitaciones] PRIMARY KEY CLUSTERED 
(
	[IdMobiliarioxHabitaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[IdPagos] [int] IDENTITY(1,1) NOT NULL,
	[totalNoches] [nvarchar](45) NULL,
	[totalConsumoMiniBar] [decimal](10, 0) NULL,
	[totalServicios] [decimal](10, 0) NULL,
	[total] [decimal](10, 0) NULL,
	[Reserva_IdReserva] [int] NOT NULL,
 CONSTRAINT [PK_Pagos_IdPagos] PRIMARY KEY CLUSTERED 
(
	[IdPagos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[fechaInicio] [varchar](30) NULL,
	[fechaFin] [varchar](30) NULL,
	[estado] [nvarchar](45) NULL,
	[Habitaciones_Categoria] [int] NOT NULL,
	[Habitaciones_IdHabitaciones] [int] NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
	[Servicios_idServicios] [int] NOT NULL,
	[Huspedes_idHuesped] [int] NOT NULL,
	[Clientes_NoDocumento] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Reserva_IdReserva] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[idServicios] [int] NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[valor] [decimal](10, 0) NULL,
 CONSTRAINT [PK_Servicios_idServicios] PRIMARY KEY CLUSTERED 
(
	[idServicios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[identificacion] [nvarchar](45) NULL,
	[nombre] [nvarchar](45) NULL,
	[usuarios] [nvarchar](45) NULL,
	[clave] [nvarchar](300) NULL,
	[estado] [nvarchar](45) NULL,
	[perfil] [varchar](30) NULL,
	[correo] [nchar](200) NULL,
 CONSTRAINT [PK_Usuario_idUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCategoria]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCategoria]
 @ID INT,
 @CODIGO VARCHAR(8),
 @NOMBRE VARCHAR(100),
 @OBSERVACION TEXT
AS
UPDATE Categoria SET codigo = @CODIGO,
 nombre = @NOMBRE, Observacion = @OBSERVACION
WHERE IdCategoria = @ID
GO
/****** Object:  StoredProcedure [dbo].[ActualizarClientes]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarClientes]
 @ID VARCHAR(10),
 @NOMBRE VARCHAR(100),
 @PRIMERAPELLIDO VARCHAR(8),
 @SEGUNDOAPELLIDO VARCHAR(100),
 @TELEFONOFIJO VARCHAR(100),
 @CELULAR VARCHAR(100),
 @CORREO VARCHAR(100),
 @FECHANACIMIENTO VARCHAR(100),
 @NOTARJETACREDITO VARCHAR(100)
AS
UPDATE Clientes SET nombre = @NOMBRE,
 primerApellido = @PRIMERAPELLIDO, segundoApellido = @SEGUNDOAPELLIDO,
 telefonoFijo = @TELEFONOFIJO, celular = @CELULAR, correo = @CORREO,
 fechaNacimiento = @FECHANACIMIENTO, noTarjetaCredito = @NOTARJETACREDITO 

WHERE NoDocumento = @ID
GO
/****** Object:  StoredProcedure [dbo].[ActualizarHabitaciones]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarHabitaciones]
 @ID INT,
 @CODIGO VARCHAR(45),
 @PRECIO decimal(10,0),
 @ESTADO VARCHAR(2),
 @CATEGORIAID INT
AS
UPDATE Habitaciones SET codigo = @CODIGO,
 precio = @PRECIO, estado = @ESTADO, Categoria_IdCategoria = @CATEGORIAID
WHERE IdHabitaciones = @ID
GO
/****** Object:  StoredProcedure [dbo].[ActualizarHuesped]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarHuesped]
 @ID INT,
 @NOMBRE VARCHAR(45),
 @PRIMERAPELLIDO VARCHAR(20),
 @SEGUNDOAPELLIDO VARCHAR(20),
 @NODOCUMENTO VARCHAR(20),
 @TELEFONOFIJO VARCHAR(20),
 @CELULAR VARCHAR(20),
 @CORREO VARCHAR(20),
 @FECHANACIMIENTO VARCHAR(20)
AS
UPDATE Huspedes SET 
 nombre = @NOMBRE, primerApellido = @PRIMERAPELLIDO, segundoApellido = @SEGUNDOAPELLIDO,
 noDocumento=@NODOCUMENTO,telefonoFijo =@TELEFONOFIJO,celular=@CELULAR,correo=@CORREO,
 fechaNacimiento = @FECHANACIMIENTO
WHERE idHuesped = @ID
GO
/****** Object:  StoredProcedure [dbo].[ActualizarListaMobiliario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarListaMobiliario]
 @ID INT,
 @CODIGO VARCHAR(8),
 @NOMBRE VARCHAR(100)
AS
UPDATE ListaMobiliario  SET codigo = @CODIGO,
 nombre = @NOMBRE
WHERE IdListaMobiliario = @ID
GO
/****** Object:  StoredProcedure [dbo].[ActualizarMiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarMiniBar]
 @ID INT,
 @CODIGO VARCHAR(8),
 @NOMBRE VARCHAR(100),
 @CANTIDAD int,
 @PRECIO float
AS
UPDATE MiniBar  SET codigo = @CODIGO,
 nombre = @NOMBRE, cantidad = @CANTIDAD,precio = @PRECIO
WHERE IdMiniBar = @ID
GO
/****** Object:  StoredProcedure [dbo].[ActualizarReserva]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarReserva]
 @Id int,
 @FECHAINICIO VARCHAR(100),
 @FechaFin VARCHAR(8),
 @Estado VARCHAR(100),
 @Habitaciones_Categoria int,
 @Habitaciones_IdHabitaciones int,
 @Usuario_idUsuario int,
 @Servicios_idServicioS int,
 @Huspedes_idHuesped int,
 @Clientes_NoDocumento VARCHAR(50)



AS
UPDATE Reserva SET fechaInicio = @FECHAINICIO,
 fechaFin = @FechaFin, estado = @Estado,
 Habitaciones_Categoria = @Habitaciones_Categoria, Habitaciones_IdHabitaciones = @Habitaciones_IdHabitaciones,
 Usuario_idUsuario = @Usuario_idUsuario, Servicios_idServicios = @Servicios_idServicioS,
  Huspedes_idHuesped = @Huspedes_idHuesped, Clientes_NoDocumento = @Clientes_NoDocumento 
WHERE IdReserva = @Id
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarUsuario]
 @ID INT,
 @IDENTIFICACION VARCHAR(45),
 @NOMBRE VARCHAR(45),
 @USUARIOS VARCHAR(45),
 @CLAVE VARCHAR(45),
 @PERFIL VARCHAR(45),
 @ESTADO VARCHAR(10),
 @CORREO VARCHAR(45)
AS
UPDATE Usuario SET identificacion = @IDENTIFICACION,
 nombre = @NOMBRE, usuarios = @USUARIOS,
 clave = @CLAVE, perfil = @PERFIL,
 estado = @ESTADO, correo = @CORREO 

WHERE IdUsuario = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCategoria]
 @ID INT
AS
DELETE FROM Categoria
WHERE IdCategoria = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarClientes]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarClientes]
 @ID varchar(10)
AS
DELETE FROM Clientes
WHERE NoDocumento = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarHabitaciones]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarHabitaciones]
 @ID INT
AS
DELETE FROM Habitaciones
WHERE IdHabitaciones = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarHuesped]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarHuesped]
 @ID int
AS
DELETE FROM Huspedes
WHERE idHuesped = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarListaMobiliario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarListaMobiliario]
 @ID INT
AS
DELETE FROM ListaMobiliario
WHERE IdListaMobiliario = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarMiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EliminarMiniBar]
 @ID INT
AS
DELETE FROM MiniBar
WHERE IdMiniBar = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarReserva]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarReserva]
 @ID int
AS
DELETE FROM Reserva
WHERE IdReserva = @ID
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EliminarUsuario]
 @ID INT
AS
DELETE FROM Usuario
WHERE IdUsuario = @ID


GO
/****** Object:  StoredProcedure [dbo].[InsertarCategoria]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCategoria]
 @CODIGO VARCHAR(8),
 @NOMBRE VARCHAR(100),
 @OBSERVACION TEXT
AS
INSERT INTO Categoria(codigo,nombre,observacion)
VALUES(@CODIGO,@NOMBRE,@OBSERVACION)
GO
/****** Object:  StoredProcedure [dbo].[InsertarClientes]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarClientes]
 @NODOCUMENTO varchar(100),
 @NOMBRE VARCHAR(100),
 @PRIMERAPELLIDO VARCHAR(8),
 @SEGUNDOAPELLIDO VARCHAR(100),
 @TELEFONOFIJO VARCHAR(100),
 @CELULAR VARCHAR(100),
 @CORREO VARCHAR(100),
 @FECHANACIMIENTO VARCHAR(100),
 @NOTARJETACREDITO VARCHAR(100)
AS
INSERT INTO Clientes(noDocumento,nombre,primerApellido,segundoApellido,telefonoFijo,celular,correo,fechaNacimiento,noTarjetaCredito)
VALUES(@NODOCUMENTO,@NOMBRE,@PRIMERAPELLIDO,@SEGUNDOAPELLIDO,@TELEFONOFIJO,@CELULAR,@CORREO,@FECHANACIMIENTO,@NOTARJETACREDITO)
GO
/****** Object:  StoredProcedure [dbo].[InsertarHabitaciones]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarHabitaciones]
@codigo  VARCHAR(8),
@precio  decimal(10,0),
@estado  varchar(2),
@Categoria_IdCategoria  int
AS
INSERT INTO Habitaciones(codigo,precio,estado,Categoria_IdCategoria)
VALUES(@codigo, @precio, @estado, @Categoria_IdCategoria)
GO
/****** Object:  StoredProcedure [dbo].[InsertarHuesped]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarHuesped]
 @NOMBRE VARCHAR(45),
 @PRIMERAPELLIDO VARCHAR(20),
 @SEGUNDOAPELLIDO VARCHAR(20),
 @NODOCUMENTO VARCHAR(20),
 @TELEFONOFIJO VARCHAR(20),
 @CELULAR VARCHAR(20),
 @CORREO VARCHAR(20),
 @FECHANACIMIENTO VARCHAR(20)
AS
INSERT INTO Huspedes(nombre,primerApellido,segundoApellido,noDocumento,telefonoFijo,celular,correo,fechaNacimiento)
VALUES(@NOMBRE,@PRIMERAPELLIDO,@SEGUNDOAPELLIDO,@NODOCUMENTO,@TELEFONOFIJO,@CELULAR,@CORREO,@FECHANACIMIENTO)
GO
/****** Object:  StoredProcedure [dbo].[InsertarListaMobiliario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarListaMobiliario]
 @CODIGO VARCHAR(8),
 @NOMBRE VARCHAR(100)
AS
INSERT INTO ListaMobiliario(codigo,nombre)
VALUES(@CODIGO,@NOMBRE)
GO
/****** Object:  StoredProcedure [dbo].[InsertarMiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarMiniBar]
 @CODIGO VARCHAR(8),
 @NOMBRE VARCHAR(100),
 @CANTIDAD int,
 @PRECIO float
AS
INSERT INTO MiniBar(codigo,nombre,cantidad,precio)
VALUES(@CODIGO,@NOMBRE,@CANTIDAD,@PRECIO)
GO
/****** Object:  StoredProcedure [dbo].[InsertarReserva]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertarReserva]
 @FECHAINICIO VARCHAR(100),
 @FECHAFIN VARCHAR(8),
 @ESTADO VARCHAR(100),
 @HABITACIONES_CATEGORIA int,
 @HABITACIONES_IDHABITACIONES int,
 @USUARIO_IDUSUARIO int,
 @SERVICIOS_IDSERVICIOS int,
 @HUESPEDES_IDHUESPEDES int,
 @CLIENTES_NODOCUMENTO VARCHAR(50)
AS
INSERT INTO Reserva(fechaInicio,fechaFin,estado,Habitaciones_Categoria,Habitaciones_IdHabitaciones,Usuario_idUsuario,Servicios_idServicios,Huspedes_idHuesped,Clientes_NoDocumento)
VALUES(@FECHAINICIO,@FECHAFIN,@ESTADO,@HABITACIONES_CATEGORIA,@HABITACIONES_IDHABITACIONES,@USUARIO_IDUSUARIO,@SERVICIOS_IDSERVICIOS,@HUESPEDES_IDHUESPEDES,@CLIENTES_NODOCUMENTO)
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarUsuario]
 @IDENTIFICACION VARCHAR(8),
 @NOMBRE VARCHAR(100),
 @USUARIOS VARCHAR(100),
 @CLAVE VARCHAR(100),
 @PERFIL VARCHAR(100),
 @ESTADO VARCHAR(100),
 @CORREO VARCHAR(100)

AS
INSERT INTO Usuario(identificacion,nombre,usuarios,clave,perfil,estado,correo)
VALUES(@IDENTIFICACION,@NOMBRE,@USUARIOS,@CLAVE,@PERFIL,@ESTADO,@CORREO)
GO
/****** Object:  StoredProcedure [dbo].[ListarCategorias]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCategorias]
AS
SELECT IdCategoria [Id],
 ISNULL(codigo,'') [codigo],
 ISNULL(nombre,'')[nombre],
 ISNULL(observacion,'')[observacion]
FROM Categoria
GO
/****** Object:  StoredProcedure [dbo].[ListarClientes]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarClientes]
AS
SELECT NoDocumento [Id],
ISNULL(nombre,'')[nombre],
 ISNULL(primerApellido,'') [primerApellido],
 ISNULL(segundoApellido,'') [segundoApellido],
 ISNULL(telefonoFijo,'')[telefonoFijo],
 ISNULL(celular,'')[celular],
 ISNULL(correo,'')[correo],
 ISNULL(fechaNacimiento,'')[fechaNacimiento],
 ISNULL(noTarjetaCredito,'')[noTarjetaCredito]
FROM Clientes
GO
/****** Object:  StoredProcedure [dbo].[ListarHabitaciones]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarHabitaciones]
AS
SELECT 
IdHabitaciones [IdHabitaciones],
isnull(codigo,'') [Codigo],
isnull (precio,0) [Precio],
isnull(estado,'') [Estado],
Categoria_IdCategoria [Categoria_IdCategoria]
FROM Habitaciones;



-- EXEC [ListarHabitaciones]
GO
/****** Object:  StoredProcedure [dbo].[ListarHuesped]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarHuesped]
AS
SELECT idHuesped [Id],
ISNULL(nombre,'')[nombre],
 ISNULL(primerApellido,'') [primerApellido],
 ISNULL(segundoApellido,'') [segundoApellido],
 ISNULL(noDocumento,'')[noDocumento],
 ISNULL(telefonoFijo,'')[telefonoFijo],
 ISNULL(celular,'')[celular],
 ISNULL(correo,'')[correo],
 ISNULL(fechaNacimiento,'')[fechaNacimiento]
FROM Huspedes
GO
/****** Object:  StoredProcedure [dbo].[ListarListaMobiliario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarListaMobiliario]
AS
SELECT IdListaMobiliario [Id],
 ISNULL(codigo,'') [codigo],
 ISNULL(nombre,'')[nombre]
 FROM ListaMobiliario
GO
/****** Object:  StoredProcedure [dbo].[ListarMiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarMiniBar]
AS
SELECT IdMinibar [Id],
 ISNULL(codigo,'') [codigo],
 ISNULL(nombre,'')[nombre],
 ISNULL(cantidad,0)[cantidad]
 --ISNULL(precio,0)[precio]
FROM MiniBar
GO
/****** Object:  StoredProcedure [dbo].[ListarReserva]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarReserva]
AS
SELECT IdReserva [Id],
 ISNULL(fechaInicio,'')[fechaInicio],
 ISNULL(fechaFin,'') [fechaFin],
 ISNULL(estado,'') [estado],
 ISNULL(Habitaciones_Categoria,0)[Habitaciones_Categoria],
 ISNULL(Habitaciones_IdHabitaciones,0)[Habitaciones_IdHabitaciones],
 ISNULL(Usuario_idUsuario,0)[Usuario_idUsuario],
 ISNULL(Servicios_idServicios,0)[Servicios_idServicios],
 ISNULL(Huspedes_idHuesped,0)[Huspedes_idHuesped],
 ISNULL(Clientes_NoDocumento,'')[Clientes_NoDocumento]
FROM Reserva
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarUsuario]
AS
SELECT IdUsuario [Id],
 ISNULL(identificacion,'') [identificacion],
 ISNULL(nombre,'')[nombre],
 ISNULL(usuarios,'')[usuarios],
 ISNULL(clave,'')[clave],
 ISNULL(perfil,'')[perfil],
 ISNULL(estado,'')[estado],
 ISNULL(correo,'')[correo]
FROM Usuario
GO
/****** Object:  StoredProcedure [dbo].[TraerCategoriaPorId]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TraerCategoriaPorId]
@ID int
AS
SELECT IdCategoria [Id],
 ISNULL(codigo,'') [codigo],
 ISNULL(nombre,'')[nombre],
 ISNULL(observacion,'')[observacion]
FROM Categoria
WHERE IdCategoria = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerCHuespedPorId]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCHuespedPorId]
@ID int
AS
SELECT idHuesped [Id],
ISNULL(nombre,'')[nombre],
 ISNULL(primerApellido,'') [primerApellido],
 ISNULL(segundoApellido,'') [segundoApellido],
 ISNULL(noDocumento,'')[noDocumento],
 ISNULL(telefonoFijo,'')[telefonoFijo],
 ISNULL(celular,'')[celular],
 ISNULL(correo,'')[correo],
 ISNULL(fechaNacimiento,'')[fechaNacimiento]
FROM Huspedes
WHERE idHuesped = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerClientesPorId]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TraerClientesPorId]
@ID varchar(10)
AS
SELECT NoDocumento [Id],
 ISNULL(nombre,'')[nombre],
 ISNULL(primerApellido,'') [primerApellido],
 ISNULL(segundoApellido,'') [segundoApellido],
 ISNULL(telefonoFijo,'')[telefonoFijo],
 ISNULL(celular,'')[celular],
 ISNULL(correo,'')[correo],
 ISNULL(fechaNacimiento,'')[fechaNacimiento],
 ISNULL(noTarjetaCredito,'')[noTarjetaCredito]
FROM Clientes
WHERE NoDocumento = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerHabitacionPorId]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerHabitacionPorId]
@ID int
AS
SELECT Categoria_IdCategoria [Id],
 ISNULL(codigo,'') [codigo],
 ISNULL(precio,0)[precio],
 ISNULL(estado,'')[estado]
FROM Habitaciones
WHERE Categoria_IdCategoria = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerListaMobiliario]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[TraerListaMobiliario]
@ID int
AS
SELECT IdListaMobiliario [Id],
ISNULL(codigo,'') [codigo],
 ISNULL(nombre,'')[nombre]
FROM ListaMobiliario
WHERE IdListaMobiliario = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerMiniBar]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerMiniBar]
@ID int
AS
SELECT IdMinibar [Id],
ISNULL(codigo,'') [codigo],
 ISNULL(nombre,'')[nombre],
 ISNULL(cantidad,0)[cantidad]
 --ISNULL(precio,0)[precio]
FROM MiniBar
WHERE IdMinibar = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerReservaPorId]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerReservaPorId]
@ID varchar(10)
AS
SELECT IdReserva [Id],
 ISNULL(fechaInicio,'')[fechaInicio],
 ISNULL(fechaFin,'') [fechaFin],
 ISNULL(estado,'') [estado],
 ISNULL(Habitaciones_Categoria,0)[Habitaciones_Categoria],
 ISNULL(Habitaciones_IdHabitaciones,0)[Habitaciones_IdHabitaciones],
 ISNULL(Usuario_idUsuario,0)[Usuario_idUsuario],
 ISNULL(Servicios_idServicios,0)[Servicios_idServicios],
 ISNULL(Huspedes_idHuesped,0)[Huspedes_idHuesped],
 ISNULL(Clientes_NoDocumento,'')[Clientes_NoDocumento]
FROM Reserva
WHERE IdReserva = @ID
GO
/****** Object:  StoredProcedure [dbo].[TraerUsuarioPorId]    Script Date: 6/11/2019 9:06:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerUsuarioPorId]
@ID int
AS
SELECT IdUsuario [Id],
 ISNULL(identificacion,'') [identificacion],
 ISNULL(nombre,'')[nombre],
 ISNULL(usuarios,'')[usuarios],
 ISNULL(clave,'')[clave],
 ISNULL(perfil,'')[perfil],
 ISNULL(estado,'')[estado],
 ISNULL(correo,'')[correo]
FROM Usuario
WHERE IdUsuario = @ID
GO
USE [master]
GO
ALTER DATABASE [Hotel_7] SET  READ_WRITE 
GO
