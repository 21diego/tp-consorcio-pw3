USE [master]
GO
/****** Object:  Database [PW3_TP_20202C]    Script Date: 9/29/2020 10:34:09 PM ******/
CREATE DATABASE [PW3_TP_20202C]

GO
USE [PW3_TP_20202C]
GO
/****** Object:  Table [dbo].[Consorcio]    Script Date: 9/29/2020 10:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consorcio](
	[IdConsorcio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[IdProvincia] [int] NOT NULL,
	[Ciudad] [nvarchar](200) NOT NULL,
	[Calle] [nvarchar](200) NOT NULL,
	[Altura] [int] NOT NULL,
	[DiaVencimientoExpensas] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdUsuarioCreador] [int] NULL,
 CONSTRAINT [PK_Consorcio] PRIMARY KEY CLUSTERED 
(
	[IdConsorcio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gasto]    Script Date: 9/29/2020 10:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gasto](
	[IdGasto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[IdConsorcio] [int] NOT NULL,
	[IdTipoGasto] [int] NOT NULL,
	[FechaGasto] [datetime] NOT NULL,
	[AnioExpensa] [int] NOT NULL,
	[MesExpensa] [int] NOT NULL,
	[ArchivoComprobante] [nvarchar](500) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdUsuarioCreador] [int] NOT NULL,
 CONSTRAINT [PK_Gasto] PRIMARY KEY CLUSTERED 
(
	[IdGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 9/29/2020 10:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[IdProvincia] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoGasto]    Script Date: 9/29/2020 10:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoGasto](
	[IdTipoGasto] [int] NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_TipoGasto] PRIMARY KEY CLUSTERED 
(
	[IdTipoGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 9/29/2020 10:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad](
	[IdUnidad] [int] IDENTITY(1,1) NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[NombrePropietario] [nvarchar](200) NULL,
	[ApellidoPropietario] [nvarchar](200) NULL,
	[EmailPropietario] [nvarchar](500) NULL,
	[Superficie] [int] NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdUsuarioCreador] [int] NOT NULL,
 CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED 
(
	[IdUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/29/2020 10:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 9/29/2020 11:51:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](300) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FechaRegistracion] [datetime] NOT NULL,
	[FechaUltLogin] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaRegistracion]  DEFAULT (getdate()) FOR [FechaRegistracion]
GO


GO
ALTER TABLE [dbo].[Consorcio] ADD  CONSTRAINT [DF_Consorcio_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Gasto] ADD  CONSTRAINT [DF_Gasto_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Unidad] ADD  CONSTRAINT [DF_Unidad_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Consorcio]  WITH CHECK ADD  CONSTRAINT [FK_Consorcio_Consorcio] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([IdProvincia])
GO
ALTER TABLE [dbo].[Consorcio] CHECK CONSTRAINT [FK_Consorcio_Consorcio]
GO
ALTER TABLE [dbo].[Consorcio]  WITH CHECK ADD  CONSTRAINT [FK_Consorcio_Usuario] FOREIGN KEY([IdUsuarioCreador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Consorcio] CHECK CONSTRAINT [FK_Consorcio_Usuario]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_Consorcio] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[Consorcio] ([IdConsorcio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_Consorcio]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_TipoGasto] FOREIGN KEY([IdTipoGasto])
REFERENCES [dbo].[TipoGasto] ([IdTipoGasto])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_TipoGasto]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_Usuario] FOREIGN KEY([IdUsuarioCreador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_Usuario]
GO
ALTER TABLE [dbo].[Unidad]  WITH CHECK ADD  CONSTRAINT [FK_Unidad_Consorcio] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[Consorcio] ([IdConsorcio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Unidad] CHECK CONSTRAINT [FK_Unidad_Consorcio]
GO
ALTER TABLE [dbo].[Unidad]  WITH CHECK ADD  CONSTRAINT [FK_Unidad_Usuario] FOREIGN KEY([IdUsuarioCreador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Unidad] CHECK CONSTRAINT [FK_Unidad_Usuario]
GO


--DATOS--
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([IdUsuario], [Email], [Password], [FechaRegistracion], [FechaUltLogin]) VALUES (1, N'pnsanchez@unlam.edu.ar', N'Test1234!', convert(datetime,'2020-09-29 22:45:36.567', 20), convert(datetime,'2020-09-29 22:05:36.567', 20))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Email], [Password], [FechaRegistracion], [FechaUltLogin]) VALUES (2, N'mpaz@unlam.edu.ar', N'Test1234!',  convert(datetime,'2020-09-29 22:45:36.567', 20), convert(datetime,'2020-09-29 22:55:36.567', 20))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Email], [Password], [FechaRegistracion], [FechaUltLogin]) VALUES (3, N'mjuiz@unlam.edu.ar', N'Test1234!',  convert(datetime,'2020-09-29 22:45:36.567', 20), NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (1, N'Buenos Aires')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (2, N'CABA')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (3, N'Catamarca')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (4, N'Chaco')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (5, N'Chubut')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (6, N'Córdoba')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (7, N'Corrientes')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (8, N'Entre Ríos')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (9, N'Formosa')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (10, N'Jujuy')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (11, N'La Pampa')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (12, N'La Rioja')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (13, N'Mendoza')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (14, N'Misiones')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (15, N'Neuquén')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (16, N'Río Negro')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (17, N'Salta')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (18, N'San Juan')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (19, N'San Luis')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (20, N'Santa Cruz')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (21, N'Santa Fe')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (22, N'Santiago del Estero')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (23, N'Tierra del Fuego')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (24, N'Tucumán')
GO
SET IDENTITY_INSERT [dbo].[Consorcio] ON 

GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (1, N'Edificio Godoy Cruz', 2, N'CABA', N'Godoy Cruz', 2369, 6,  convert(datetime,'2020-09-29 22:50:00.837', 20), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (2, N'Edificio Arieta', 1, N'San Justo', N'Arieta', 2748, 12,  convert(datetime,'2020-09-29 22:50:48.663', 20), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (3, N'Edificio Alberdi', 2, N'CABA', N'Alberdi', 2387, 1,  convert(datetime,'2020-09-29 22:51:37.607', 20), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (4, N'Torres Florencia', 1, N'Ramos Mejia', N'Dr. Gabriel Ardoino', 364, 5,  convert(datetime,'2020-09-29 22:51:56.580', 20), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (5, N'Vilanova', 1, N'Ramos Mejia', N'Tacuari', 620, 21,  convert(datetime,'2020-09-29 22:53:31.700', 20), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (6, N'Altos de Gandara', 1, N'Haedo', N'Juez de la Gandara', 851, 2, convert(datetime,'2020-09-29 22:58:32.020', 20), NULL)
GO
SET IDENTITY_INSERT [dbo].[Consorcio] OFF
GO
SET IDENTITY_INSERT [dbo].[Unidad] ON 

GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (1, 1, N'1A', N'Pepe', N'Argento', N'pepeargento@test.com', NULL,  convert(datetime,'2020-09-29 23:36:43.727', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (2, 1, N'1B', N'Dardo', N'Fuseneco', N'dardo@test.com', NULL,  convert(datetime,'2020-09-29 23:37:11.970', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (4, 1, N'1C', N'Fatiga', N'Argento', N'fatiga@test.com', NULL,  convert(datetime,'2020-09-29 23:37:40.170', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (5, 1, N'2A', N'Edna', N'Krabappel', N'edna@test.com', NULL,  convert(datetime,'2020-09-29 23:38:10.270', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (7, 1, N'2B', N'Ned', N'Flanders', N'neddy@test.com', NULL,  convert(datetime,'2020-09-29 23:40:15.133', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (8, 1, N'2C', N'Moe', N'Szyslak', N'moe@test.com', NULL,  convert(datetime,'2020-09-29 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (9, 1, N'3A', N'Franco', N'Milazzo', N'franco@test.com', NULL,  convert(datetime,'2020-09-29 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (10, 1, N'3B', N'Emilio', N'Ravenna', N'ravenna@test.com', NULL,  convert(datetime,'2020-09-29 23:42:25.980', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (11, 1, N'3C', N'Gabriel', N'Medina', N'gmedina@test.com', NULL,  convert(datetime,'2020-09-29 23:42:50.507', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (12, 1, N'4A', N'Jack', N'Shepard', N'jackperdido@test.com', NULL,  convert(datetime,'2020-09-29 23:43:41.887', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (13, 1, N'4B', N'Desmond', N'Hume', N'desmond@test.com', NULL,  convert(datetime,'2020-09-29 23:44:27.130', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (14, 1, N'4C', N'Kate', N'Austen', N'kate@test.com', NULL,  convert(datetime,'2020-09-29 23:45:21.017', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (15, 2, N'1A', N'Michael', N'Scofield', N'michael@test.com', NULL,  convert(datetime,'2020-09-29 23:46:12.093', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (16, 2, N'1B', N'T', N'Bag', N'tbag@test.com', NULL,  convert(datetime,'2020-09-29 23:46:25.593', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (17, 2, N'1C', N'Sara', N'Tancredi', N'sara@test.com', NULL,  convert(datetime,'2020-09-29 23:47:03.817', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (19, 3, N'Unidad 1', N'Tokio', NULL, N'tokio@test.com', NULL,  convert(datetime,'2020-09-29 23:47:53.770', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (20, 3, N'Unidad 2', N'Berlin', NULL, N'berlin@test.com', NULL,  convert(datetime,'2020-09-29 23:48:07.327', 20), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (21, 3, N'Unidad 3', N'Denver', NULL, N'denver@test.com', NULL,  convert(datetime,'2020-09-29 23:48:26.127', 20), 1)
GO
SET IDENTITY_INSERT [dbo].[Unidad] OFF
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (1, N'Sueldos')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (2, N'Servicios')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (3, N'Cargas Sociales')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (4, N'Seguros')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (5, N'Mantenimiento Gral')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (6, N'Reparacion Unidad')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (7, N'Compras Limpieza')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (8, N'Extraordinario')
GO
SET IDENTITY_INSERT [dbo].[Gasto] ON 

GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (1, N'Fumigacion de Unidades', N'Se fumigaron todas las unidades excepto la unidad 10 y 12', 1, 5,  convert(datetime,'2020-08-12 00:00:00.000', 20), 2020, 8, N'/Gastos/fumigacion-20200812.pdf', CAST(25000.00 AS Decimal(18, 2)),  convert(datetime,'2020-08-13 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (2, N'Restauracion SUM', NULL, 1, 5,  convert(datetime,'2020-08-22 00:00:00.000', 20), 2020, 8, N'/Gastos/Sum08.pdf', CAST(125000.00 AS Decimal(18, 2)),  convert(datetime,'2020-08-23 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (3, N'Compra productos de limpieza', N'Detalle:
1. Balde de 12 litros
2. Pala Cepillo VP2
3. Escoba topacio con cabo
4. Secador de piso con cabo art 1125
5. Cepillo Multiuso Mathilde
6. Secador Multiuso
7. Escobillon Diamante V2 Diamante', 1, 7,  convert(datetime,'2020-09-02 00:00:00.000', 20), 2020, 9, N'/Gastos/Limpieza-2020-09-02.pdf', CAST(40000.00 AS Decimal(18, 2)),  convert(datetime,'2020-09-02 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (4, N'Reparacion humeadad unidad 1A', N'Habia manchas en el techo, se impermiabilizo y se volvio a pintar', 1, 6,  convert(datetime,'2020-09-12 00:00:00.000', 20), 2020, 9, N'/Gastos/Reparacion-2020-09-12.pdf', CAST(30000.00 AS Decimal(18, 2)),  convert(datetime,'2020-09-12 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (5, N'Fumigacion de Unidades', N'Se fumigaron todas las unidades', 1, 5,  convert(datetime,'2020-09-20 00:00:00.000', 20), 2020, 9, N'/Gastos/fumigacion-2020-09-20.pdf', CAST(25000.00 AS Decimal(18, 2)),  convert(datetime,'2020-09-28 00:00:00.000', 20), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (6, N'Sueldos Agosto', N'Se abonaron los sueldos de los 3 encargados', 1, 1,  convert(datetime,'2020-08-30 00:00:00.000', 20), 2020, 8, N'/Gastos/liquidacion-sueldos-2020-08.pdf', CAST(150000.00 AS Decimal(18, 2)),  convert(datetime,'2020-09-01 00:00:00.000', 20), 1)
GO
SET IDENTITY_INSERT [dbo].[Gasto] OFF
GO


-- CREACION DE STORED PROCEDURE PARA OBTENER EXPENSAS DE UN CONSORCIO --

CREATE PROC GetExpensasDeConsorcio(@consorcio int)
AS
BEGIN
	declare @Expensas table(
		IdExpensas int identity(1,1),
        AnioExpensa int,
        MesExpensa int,
        Unidades int,
        GastoTotal decimal(18,2),
        MontoExpensa decimal(18,2))

	declare @GastoTemp table(id int identity(1,1),AnioExpensa int, MesExpensa int, MontoTotal decimal(18,2))
	insert into @GastoTemp(AnioExpensa, MesExpensa, montoTotal) 
	select AnioExpensa,MesExpensa,Sum(Monto) as MontoTotal from [dbo].[Gasto] as G where G.IdConsorcio = @consorcio
	group by MesExpensa,AnioExpensa;

	declare @unidades int = (select Count(*) from [dbo].[Unidad] as U where U.IdConsorcio = @consorcio);

	DECLARE @count int = (SELECT COUNT(*) FROM @GastoTemp)
	while @count > 0
	begin
		declare @id int = (select top(1) id from @GastoTemp order by id)
		declare @AnioExpensa int = (select top(1) AnioExpensa from @GastoTemp order by id)
		declare @MesExpensa int = (select top(1) MesExpensa from @GastoTemp order by id)
		declare @GastoTotal decimal(18,2) = (select top(1) MontoTotal from @GastoTemp order by id)

		declare @MontoExpensa decimal(18,2) = @GastoTotal / @unidades

		insert into @Expensas (AnioExpensa,MesExpensa,Unidades,GastoTotal,MontoExpensa)
		values (@AnioExpensa,@MesExpensa,@Unidades,@GastoTotal,@MontoExpensa)

		delete @GastoTemp where id = @id
		set @count  = (SELECT COUNT(*) FROM @GastoTemp)
	end
	
	select * from @Expensas
	order by AnioExpensa desc, MesExpensa desc
	
END

EXEC GetExpensasDeConsorcio 1

SET IDENTITY_INSERT [dbo].[Gasto] OFF

INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador])
VALUES (10, N'Compra productos de limpieza', N'Detalle:
				1. Balde de 12 litros
				2. Pala Cepillo VP2
				3. Escoba topacio con cabo
				4. Secador de piso con cabo art 1125
				5. Cepillo Multiuso Mathilde
				6. Secador Multiuso
				7. Escobillon Diamante V2 Diamante',
				1,
				7,
				convert(datetime,'2020-09-02 00:00:00.000', 20),
				2020,
				11,
				N'/Gastos/Limpieza-2020-09-02.pdf',
				CAST(40000.00 AS Decimal(18, 2)),
				convert(datetime,'2020-09-02 00:00:00.000', 20), 1)