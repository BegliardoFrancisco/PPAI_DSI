
CREATE DATABASE PPAI_DSI

USE [PPAI_DSI]
GO
/****** Object:  Table [dbo].[Acciones]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acciones](
	[id_accion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_accion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambiosEstado]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambiosEstado](
	[id_cambio_estado] [int] IDENTITY(1,1) NOT NULL,
	[id_estado] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NULL,
	[id_llamada] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cambio_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nro_orden] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[nro_celular] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC,
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[nombre_estado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Llamadas]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Llamadas](
	[id_llamada] [int] IDENTITY(1,1) NOT NULL,
	[fecha_hora_inicio] [date] NOT NULL,
	[descripcion_operador] [varchar](100) NULL,
	[detalle_accion_requerida] [varchar](50) NULL,
	[duracion] [int] NULL,
	[id_accion] [int] NULL,
	[id_cliente] [int] NULL,
	[dni] [int] NULL,
	[id_subopcion] [int] NULL,
	[id_opcion_llamada] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_llamada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpcionesLlamada]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpcionesLlamada](
	[id_opcion_llamada] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[nro_orden] [int] NOT NULL,
	[id_categoria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_opcion_llamada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpcionesValidaciones]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpcionesValidaciones](
	[id_opcion_validacion] [int] IDENTITY(1,1) NOT NULL,
	[id_validacion] [int] NOT NULL,
	[es_correcta] [bit] NOT NULL,
	[nombre] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_opcion_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubOpcionesLlamada]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubOpcionesLlamada](
	[id_subopcion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[nro_orden] [int] NOT NULL,
	[id_opcion_llamada] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_subopcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Validaciones]    Script Date: 28/11/2023 20:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Validaciones](
	[id_validacion] [int] IDENTITY(1,1) NOT NULL,
	[nro_orden] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[mensaje_validacion] [varchar](50) NULL,
	[id_opcion_llamada] [int] NOT NULL,
	[id_subopcion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Acciones] ON 

INSERT [dbo].[Acciones] ([id_accion], [descripcion]) VALUES (16, N'Comunicar saldo')
INSERT [dbo].[Acciones] ([id_accion], [descripcion]) VALUES (17, N'Dar de baja la tarjeta')
INSERT [dbo].[Acciones] ([id_accion], [descripcion]) VALUES (18, N'Denunciar robo')
SET IDENTITY_INSERT [dbo].[Acciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([id_categoria], [nro_orden], [nombre]) VALUES (14, 3, N'Finalizar llamada')
INSERT [dbo].[Categorias] ([id_categoria], [nro_orden], [nombre]) VALUES (15, 2, N'Tarjeta Bloqueada')
INSERT [dbo].[Categorias] ([id_categoria], [nro_orden], [nombre]) VALUES (16, 1, N'Informar robo')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Estados] ON 

INSERT [dbo].[Estados] ([id_estado], [nombre_estado]) VALUES (9, N'Iniciada')
INSERT [dbo].[Estados] ([id_estado], [nombre_estado]) VALUES (10, N'EnCurso')
INSERT [dbo].[Estados] ([id_estado], [nombre_estado]) VALUES (11, N'Finalizada')
SET IDENTITY_INSERT [dbo].[Estados] OFF
GO
ALTER TABLE [dbo].[CambiosEstado]  WITH CHECK ADD  CONSTRAINT [FK_ESTADO] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estados] ([id_estado])
GO
ALTER TABLE [dbo].[CambiosEstado] CHECK CONSTRAINT [FK_ESTADO]
GO
ALTER TABLE [dbo].[CambiosEstado]  WITH CHECK ADD  CONSTRAINT [FK_LLAMADA] FOREIGN KEY([id_llamada])
REFERENCES [dbo].[Llamadas] ([id_llamada])
GO
ALTER TABLE [dbo].[CambiosEstado] CHECK CONSTRAINT [FK_LLAMADA]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_ACCION_LLAMADA] FOREIGN KEY([id_accion])
REFERENCES [dbo].[Acciones] ([id_accion])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_ACCION_LLAMADA]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_LLAMADA] FOREIGN KEY([id_cliente], [dni])
REFERENCES [dbo].[Clientes] ([id_cliente], [dni])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_CLIENTE_LLAMADA]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_OPCIONLLAMADA_LLAMADA] FOREIGN KEY([id_opcion_llamada])
REFERENCES [dbo].[OpcionesLlamada] ([id_opcion_llamada])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_OPCIONLLAMADA_LLAMADA]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_SUBOPCION] FOREIGN KEY([id_subopcion])
REFERENCES [dbo].[SubOpcionesLlamada] ([id_subopcion])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_SUBOPCION]
GO
ALTER TABLE [dbo].[OpcionesLlamada]  WITH CHECK ADD  CONSTRAINT [FK_CATEGORIA] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categorias] ([id_categoria])
GO
ALTER TABLE [dbo].[OpcionesLlamada] CHECK CONSTRAINT [FK_CATEGORIA]
GO
ALTER TABLE [dbo].[OpcionesValidaciones]  WITH CHECK ADD  CONSTRAINT [FK_VALIDACION] FOREIGN KEY([id_validacion])
REFERENCES [dbo].[Validaciones] ([id_validacion])
GO
ALTER TABLE [dbo].[OpcionesValidaciones] CHECK CONSTRAINT [FK_VALIDACION]
GO
ALTER TABLE [dbo].[SubOpcionesLlamada]  WITH CHECK ADD  CONSTRAINT [FK_OPCION_LLAMADA] FOREIGN KEY([id_opcion_llamada])
REFERENCES [dbo].[OpcionesLlamada] ([id_opcion_llamada])
GO
ALTER TABLE [dbo].[SubOpcionesLlamada] CHECK CONSTRAINT [FK_OPCION_LLAMADA]
GO
ALTER TABLE [dbo].[Validaciones]  WITH CHECK ADD  CONSTRAINT [FK_OPCION_LLAMADA_VALIDACIONES] FOREIGN KEY([id_opcion_llamada])
REFERENCES [dbo].[OpcionesLlamada] ([id_opcion_llamada])
GO
ALTER TABLE [dbo].[Validaciones] CHECK CONSTRAINT [FK_OPCION_LLAMADA_VALIDACIONES]
GO
ALTER TABLE [dbo].[Validaciones]  WITH CHECK ADD  CONSTRAINT [FK_validaciones_subopcion] FOREIGN KEY([id_subopcion])
REFERENCES [dbo].[SubOpcionesLlamada] ([id_subopcion])
GO
ALTER TABLE [dbo].[Validaciones] CHECK CONSTRAINT [FK_validaciones_subopcion]
GO
