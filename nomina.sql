USE [master]
GO
/****** Object:  Database [Nomina]    Script Date: 10/7/2019 9:18:42 a. m. ******/
CREATE DATABASE [Nomina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nomina', FILENAME = N'E:\data_sql_dev_2012\Nomina.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Nomina_log', FILENAME = N'F:\log_sql_dev_2012\Nomina_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Nomina] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nomina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nomina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nomina] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nomina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nomina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nomina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nomina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nomina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nomina] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nomina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nomina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nomina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nomina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nomina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nomina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nomina] SET RECOVERY FULL 
GO
ALTER DATABASE [Nomina] SET  MULTI_USER 
GO
ALTER DATABASE [Nomina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nomina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nomina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nomina] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Nomina', N'ON'
GO
USE [Nomina]
GO
/****** Object:  Table [dbo].[Anticipo]    Script Date: 10/7/2019 9:18:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anticipo](
	[Id_Anticipo] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_Id] [int] NOT NULL,
	[Monto_Solicitado] [int] NOT NULL,
	[Monto_Aprobado] [int] NOT NULL,
	[Fecha_Solicitud] [date] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Fecha_Definicion] [date] NULL,
	[Observaciones] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Anticipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concepto](
	[Id_Concepto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Tipo] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](255) NOT NULL,
	[Apellidos] [varchar](255) NOT NULL,
	[Nro_Documento] [varchar](50) NOT NULL,
	[Direccion] [varchar](255) NULL,
	[Nro_Telefono] [varchar](20) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Fecha_Incorporacion] [date] NULL,
	[Imagen_Perfil] [varchar](1000) NULL,
	[Salario_Basico] [int] NOT NULL,
	[Turno_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado_Salario_Historico]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado_Salario_Historico](
	[Id_Salario_Historico] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_Id] [int] NOT NULL,
	[Salario_Basico_Anterior] [int] NOT NULL,
	[Salario_Basico_Nuevo] [int] NOT NULL,
	[Fecha_Hora] [datetime] NOT NULL,
	[Usuario_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Salario_Historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liquidacion_Mensual]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liquidacion_Mensual](
	[Id_Liquidacion] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [smallint] NOT NULL,
	[Anho] [smallint] NOT NULL,
	[Fecha_Generacion] [datetime] NOT NULL,
	[Usuario_Id] [int] NOT NULL,
	[Estado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Liquidacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liquidacion_Mensual_Detalle]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liquidacion_Mensual_Detalle](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Liquidacion_Id] [int] NOT NULL,
	[Empleado_Id] [int] NOT NULL,
	[Concepto_Id] [int] NOT NULL,
	[Monto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[Id_Permiso] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_Id] [int] NOT NULL,
	[Fecha_Desde] [date] NOT NULL,
	[Fecha_Hasta] [date] NOT NULL,
	[Motivo] [varchar](1000) NOT NULL,
	[Cantidad_Horas] [int] NOT NULL,
	[Fecha_Solicitud] [date] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Observaciones] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[Id_Turno] [int] IDENTITY(1,1) NOT NULL,
	[Hora_Entrada] [varchar](5) NOT NULL,
	[Hora_Salida] [varchar](5) NOT NULL,
	[Observaciones] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Password] [varchar](1000) NOT NULL,
	[Empleado_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacaciones]    Script Date: 10/7/2019 9:18:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacaciones](
	[Id_Vacaciones] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_Id] [int] NOT NULL,
	[Fecha_Desde] [date] NOT NULL,
	[Fecha_Hasta] [date] NOT NULL,
	[Fecha_Solicitud] [date] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Fecha_Definicion] [date] NOT NULL,
	[Observaciones] [varchar](1000) NULL,
 CONSTRAINT [PK_Vacaciones] PRIMARY KEY CLUSTERED 
(
	[Id_Vacaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Anticipo] ON 

INSERT [dbo].[Anticipo] ([Id_Anticipo], [Empleado_Id], [Monto_Solicitado], [Monto_Aprobado], [Fecha_Solicitud], [Estado], [Fecha_Definicion], [Observaciones]) VALUES (1, 4, 500000, 500000, CAST(N'2019-01-01' AS Date), N'Rechazado', CAST(N'2019-01-01' AS Date), N'nose')
INSERT [dbo].[Anticipo] ([Id_Anticipo], [Empleado_Id], [Monto_Solicitado], [Monto_Aprobado], [Fecha_Solicitud], [Estado], [Fecha_Definicion], [Observaciones]) VALUES (2, 5, 750000, 750000, CAST(N'2019-01-01' AS Date), N'Aprobado', CAST(N'2019-01-01' AS Date), N'ni ides')
INSERT [dbo].[Anticipo] ([Id_Anticipo], [Empleado_Id], [Monto_Solicitado], [Monto_Aprobado], [Fecha_Solicitud], [Estado], [Fecha_Definicion], [Observaciones]) VALUES (7, 6, 1000000, 1000000, CAST(N'2019-06-06' AS Date), N'Aprobado', CAST(N'2019-06-06' AS Date), N'solicitud de adelanto')
SET IDENTITY_INSERT [dbo].[Anticipo] OFF
SET IDENTITY_INSERT [dbo].[Concepto] ON 

INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (3, N'Llegada Tardia', N'1')
INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (4, N'Nuevo', N'O')
INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (5, N'Nuevo', N'O')
INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (6, N'Salario Basico', N'F')
INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (8, N'IPS', N'F')
INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (9, N'Otros Descuentos', N'F')
INSERT [dbo].[Concepto] ([Id_Concepto], [Descripcion], [Tipo]) VALUES (10, N'Anticipos', N'F')
SET IDENTITY_INSERT [dbo].[Concepto] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Id_Empleado], [Nombres], [Apellidos], [Nro_Documento], [Direccion], [Nro_Telefono], [Fecha_Nacimiento], [Fecha_Incorporacion], [Imagen_Perfil], [Salario_Basico], [Turno_Id]) VALUES (4, N'Juan Minta', N'Arguello', N'23423', N'afasd', N'adas', CAST(N'2019-05-14' AS Date), CAST(N'2019-05-01' AS Date), N'file:///C:/Users/ajvsoporte/Desktop/BK/Presentation/Nop.Web/Content/Images/Thumbs/0000007_hamburguesa-con-queso.jpeg', 31312, 1)
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombres], [Apellidos], [Nro_Documento], [Direccion], [Nro_Telefono], [Fecha_Nacimiento], [Fecha_Incorporacion], [Imagen_Perfil], [Salario_Basico], [Turno_Id]) VALUES (5, N'Juan Manuel', N'Arguello', N'23423', N'afasd', N'adas', CAST(N'2019-05-14' AS Date), CAST(N'2019-05-01' AS Date), N'file:///C:/Users/ajvsoporte/Desktop/BK/Presentation/Nop.Web/Content/Images/Thumbs/0000007_hamburguesa-con-queso.jpeg', 313126565, 3)
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombres], [Apellidos], [Nro_Documento], [Direccion], [Nro_Telefono], [Fecha_Nacimiento], [Fecha_Incorporacion], [Imagen_Perfil], [Salario_Basico], [Turno_Id]) VALUES (6, N'gonza', N'arguello', N'5952', N'asd', N'09222', CAST(N'2019-06-26' AS Date), CAST(N'2019-06-26' AS Date), N'file:///C:/Users/ajvsoporte/Desktop/BK/Presentation/Nop.Web/Content/Images/Thumbs/0000004_hamburguesa.jpg', 5000000, 1)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
SET IDENTITY_INSERT [dbo].[Empleado_Salario_Historico] ON 

INSERT [dbo].[Empleado_Salario_Historico] ([Id_Salario_Historico], [Empleado_Id], [Salario_Basico_Anterior], [Salario_Basico_Nuevo], [Fecha_Hora], [Usuario_Id]) VALUES (1, 6, 0, 5000000, CAST(N'2019-06-26T10:35:14.463' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[Empleado_Salario_Historico] OFF
SET IDENTITY_INSERT [dbo].[Liquidacion_Mensual] ON 

INSERT [dbo].[Liquidacion_Mensual] ([Id_Liquidacion], [Mes], [Anho], [Fecha_Generacion], [Usuario_Id], [Estado]) VALUES (2, 1, 2016, CAST(N'2019-07-09T16:22:12.177' AS DateTime), 4, N'A')
INSERT [dbo].[Liquidacion_Mensual] ([Id_Liquidacion], [Mes], [Anho], [Fecha_Generacion], [Usuario_Id], [Estado]) VALUES (3, 6, 2019, CAST(N'2019-07-09T22:40:58.057' AS DateTime), 4, N'A')
SET IDENTITY_INSERT [dbo].[Liquidacion_Mensual] OFF
SET IDENTITY_INSERT [dbo].[Liquidacion_Mensual_Detalle] ON 

INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (53, 3, 6, 4, 300000)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (54, 3, 6, 3, -250000)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (55, 3, 4, 6, 31312)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (56, 3, 4, 8, -2818)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (57, 3, 4, 10, 0)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (58, 3, 5, 6, 313126565)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (59, 3, 5, 8, 14768282)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (60, 3, 5, 10, 0)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (61, 3, 6, 6, 5000000)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (62, 3, 6, 8, -477000)
INSERT [dbo].[Liquidacion_Mensual_Detalle] ([Id_Detalle], [Liquidacion_Id], [Empleado_Id], [Concepto_Id], [Monto]) VALUES (63, 3, 6, 10, -1000000)
SET IDENTITY_INSERT [dbo].[Liquidacion_Mensual_Detalle] OFF
SET IDENTITY_INSERT [dbo].[Permisos] ON 

INSERT [dbo].[Permisos] ([Id_Permiso], [Empleado_Id], [Fecha_Desde], [Fecha_Hasta], [Motivo], [Cantidad_Horas], [Fecha_Solicitud], [Estado], [Observaciones]) VALUES (2, 4, CAST(N'2019-08-08' AS Date), CAST(N'2019-08-09' AS Date), N'nose', 40, CAST(N'2019-01-01' AS Date), N'Pendiente', N'nose')
INSERT [dbo].[Permisos] ([Id_Permiso], [Empleado_Id], [Fecha_Desde], [Fecha_Hasta], [Motivo], [Cantidad_Horas], [Fecha_Solicitud], [Estado], [Observaciones]) VALUES (3, 5, CAST(N'2019-08-08' AS Date), CAST(N'2019-08-09' AS Date), N'ni idea', 30, CAST(N'2019-01-01' AS Date), N'Pendiente', N'ni idea')
SET IDENTITY_INSERT [dbo].[Permisos] OFF
SET IDENTITY_INSERT [dbo].[Turno] ON 

INSERT [dbo].[Turno] ([Id_Turno], [Hora_Entrada], [Hora_Salida], [Observaciones]) VALUES (1, N'08:00', N'18:00', N'Lun - Vier')
INSERT [dbo].[Turno] ([Id_Turno], [Hora_Entrada], [Hora_Salida], [Observaciones]) VALUES (3, N'07:30', N'17:30', N'Lun - Vier')
SET IDENTITY_INSERT [dbo].[Turno] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id_Usuario], [Usuario], [Password], [Empleado_Id]) VALUES (4, N'juanma', N'juanma', 4)
INSERT [dbo].[Usuario] ([Id_Usuario], [Usuario], [Password], [Empleado_Id]) VALUES (8, N'clau', N'clau', 5)
INSERT [dbo].[Usuario] ([Id_Usuario], [Usuario], [Password], [Empleado_Id]) VALUES (9, N'gonza', N'gonza', 6)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[Vacaciones] ON 

INSERT [dbo].[Vacaciones] ([Id_Vacaciones], [Empleado_Id], [Fecha_Desde], [Fecha_Hasta], [Fecha_Solicitud], [Estado], [Fecha_Definicion], [Observaciones]) VALUES (1, 4, CAST(N'2019-01-06' AS Date), CAST(N'2019-01-16' AS Date), CAST(N'2019-01-01' AS Date), N'Rechazado', CAST(N'2019-01-01' AS Date), N'niose')
INSERT [dbo].[Vacaciones] ([Id_Vacaciones], [Empleado_Id], [Fecha_Desde], [Fecha_Hasta], [Fecha_Solicitud], [Estado], [Fecha_Definicion], [Observaciones]) VALUES (2, 5, CAST(N'2019-01-06' AS Date), CAST(N'2019-01-16' AS Date), CAST(N'2019-01-01' AS Date), N'Aprobado', CAST(N'2019-01-01' AS Date), N'mose')
SET IDENTITY_INSERT [dbo].[Vacaciones] OFF
/****** Object:  Index [UQ_Liquidacion]    Script Date: 10/7/2019 9:18:43 a. m. ******/
ALTER TABLE [dbo].[Liquidacion_Mensual] ADD  CONSTRAINT [UQ_Liquidacion] UNIQUE NONCLUSTERED 
(
	[Mes] ASC,
	[Anho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Det_Liquidacion]    Script Date: 10/7/2019 9:18:43 a. m. ******/
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle] ADD  CONSTRAINT [UQ_Det_Liquidacion] UNIQUE NONCLUSTERED 
(
	[Liquidacion_Id] ASC,
	[Empleado_Id] ASC,
	[Concepto_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UC_Empleado]    Script Date: 10/7/2019 9:18:43 a. m. ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [UC_Empleado] UNIQUE NONCLUSTERED 
(
	[Empleado_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Anticipo]  WITH CHECK ADD  CONSTRAINT [FK_Anticipo_Empleado] FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Anticipo] CHECK CONSTRAINT [FK_Anticipo_Empleado]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([Turno_Id])
REFERENCES [dbo].[Turno] ([Id_Turno])
GO
ALTER TABLE [dbo].[Empleado_Salario_Historico]  WITH CHECK ADD FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Empleado_Salario_Historico]  WITH CHECK ADD FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Empleado_Salario_Historico]  WITH CHECK ADD FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Empleado_Salario_Historico]  WITH CHECK ADD FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual]  WITH CHECK ADD FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual]  WITH CHECK ADD FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle]  WITH CHECK ADD FOREIGN KEY([Concepto_Id])
REFERENCES [dbo].[Concepto] ([Id_Concepto])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle]  WITH CHECK ADD FOREIGN KEY([Concepto_Id])
REFERENCES [dbo].[Concepto] ([Id_Concepto])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle]  WITH CHECK ADD FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle]  WITH CHECK ADD FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle]  WITH CHECK ADD FOREIGN KEY([Liquidacion_Id])
REFERENCES [dbo].[Liquidacion_Mensual] ([Id_Liquidacion])
GO
ALTER TABLE [dbo].[Liquidacion_Mensual_Detalle]  WITH CHECK ADD FOREIGN KEY([Liquidacion_Id])
REFERENCES [dbo].[Liquidacion_Mensual] ([Id_Liquidacion])
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Empleado] FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Empleado]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Usuario] FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Empleado_Usuario]
GO
ALTER TABLE [dbo].[Vacaciones]  WITH CHECK ADD  CONSTRAINT [FK_Vacaciones_Empleado] FOREIGN KEY([Empleado_Id])
REFERENCES [dbo].[Empleado] ([Id_Empleado])
GO
ALTER TABLE [dbo].[Vacaciones] CHECK CONSTRAINT [FK_Vacaciones_Empleado]
GO
USE [master]
GO
ALTER DATABASE [Nomina] SET  READ_WRITE 
GO
