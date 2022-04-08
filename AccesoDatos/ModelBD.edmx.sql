
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/07/2022 21:28:19
-- Generated from EDMX file: C:\Users\joses\source\repos\JoseSabeckis\KosakoJean\AccesoDatos\ModelBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KosakoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TipoProductoProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_TipoProductoProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_ColegioProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_CajaDetalleCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCajas] DROP CONSTRAINT [FK_CajaDetalleCaja];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoProducto_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Pedidos] DROP CONSTRAINT [FK_ProductoProducto_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoProducto_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Pedidos] DROP CONSTRAINT [FK_PedidoProducto_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoProducto_Venta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Ventas] DROP CONSTRAINT [FK_ProductoProducto_Venta];
GO
IF OBJECT_ID(N'[dbo].[FK_Producto_VentaVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Ventas] DROP CONSTRAINT [FK_Producto_VentaVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_PedidoCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_VentaCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_VentaCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteCtaCte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CtasCtes] DROP CONSTRAINT [FK_ClienteCtaCte];
GO
IF OBJECT_ID(N'[dbo].[FK_TalleProducto_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Pedidos] DROP CONSTRAINT [FK_TalleProducto_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_TalleProducto_Venta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Ventas] DROP CONSTRAINT [FK_TalleProducto_Venta];
GO
IF OBJECT_ID(N'[dbo].[FK_Producto_PedidoProducto_Dato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto_Datos] DROP CONSTRAINT [FK_Producto_PedidoProducto_Dato];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteArreglo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Arreglos] DROP CONSTRAINT [FK_ClienteArreglo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[TipoProductos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoProductos];
GO
IF OBJECT_ID(N'[dbo].[Colegios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colegios];
GO
IF OBJECT_ID(N'[dbo].[Cajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cajas];
GO
IF OBJECT_ID(N'[dbo].[DetalleCajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCajas];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Producto_Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto_Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Ventas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ventas];
GO
IF OBJECT_ID(N'[dbo].[Producto_Ventas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto_Ventas];
GO
IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[CtasCtes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CtasCtes];
GO
IF OBJECT_ID(N'[dbo].[Talles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Talles];
GO
IF OBJECT_ID(N'[dbo].[Producto_Datos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto_Datos];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Negocios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Negocios];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Arreglos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Arreglos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Extras] nvarchar(max)  NOT NULL,
    [TipoProductoId] bigint  NOT NULL,
    [ColegioId] bigint  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [Stock] decimal(18,0)  NOT NULL,
    [Creacion] bit  NOT NULL
);
GO

-- Creating table 'TipoProductos'
CREATE TABLE [dbo].[TipoProductos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Colegios'
CREATE TABLE [dbo].[Colegios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Cajas'
CREATE TABLE [dbo].[Cajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TotalCaja] decimal(18,0)  NOT NULL,
    [MontoApertura] decimal(18,0)  NOT NULL,
    [MontoCierre] decimal(18,0)  NOT NULL,
    [FechaApertura] datetime  NOT NULL,
    [FechaCierre] nvarchar(max)  NOT NULL,
    [OpenClose] bigint  NOT NULL
);
GO

-- Creating table 'DetalleCajas'
CREATE TABLE [dbo].[DetalleCajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [CajaId] bigint  NOT NULL,
    [Fecha] nvarchar(max)  NOT NULL,
    [TipoPago] bigint  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [Adelanto] decimal(18,0)  NOT NULL,
    [FechaPedido] datetime  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Proceso] bigint  NOT NULL,
    [FechaEntrega] datetime  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [ApyNom] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [FechaRetirado] nvarchar(max)  NULL,
    [Horario] nvarchar(max)  NOT NULL,
    [DiasHastaRetiro] nvarchar(max)  NULL,
    [Cliente_Id] bigint  NULL
);
GO

-- Creating table 'Producto_Pedidos'
CREATE TABLE [dbo].[Producto_Pedidos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ProductoId] bigint  NOT NULL,
    [PedidoId] bigint  NOT NULL,
    [Estado] bigint  NOT NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [Talle] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [TalleId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Ventas'
CREATE TABLE [dbo].[Ventas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [Descuento] decimal(18,0)  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [Cliente_Id] bigint  NULL
);
GO

-- Creating table 'Producto_Ventas'
CREATE TABLE [dbo].[Producto_Ventas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ProductoId] bigint  NOT NULL,
    [VentaId] bigint  NULL,
    [Estado] bigint  NOT NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [Talle] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [TalleId] bigint  NOT NULL,
    [Venta_Id] bigint  NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [Principal] bit  NOT NULL,
    [Dni] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CtasCtes'
CREATE TABLE [dbo].[CtasCtes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [Debe] decimal(18,0)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [Estado] bigint  NOT NULL,
    [PedidoId] bigint  NOT NULL
);
GO

-- Creating table 'Talles'
CREATE TABLE [dbo].[Talles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Producto_Datos'
CREATE TABLE [dbo].[Producto_Datos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EstadoPorPedido] bigint  NOT NULL,
    [Producto_PedidoId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Bloqueado] bit  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Negocios'
CREATE TABLE [dbo].[Negocios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL,
    [Cuit] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Celular] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Imagen] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Image_Pedidos_Terminados] varbinary(max)  NOT NULL,
    [Image_Pedidos_Pendientes] varbinary(max)  NOT NULL,
    [Image_Pedidos_Listos] varbinary(max)  NOT NULL,
    [Image_Pedido_Guardado] varbinary(max)  NOT NULL,
    [Image_Pedido_Entregado] varbinary(max)  NOT NULL,
    [Image_Para_Hacer] varbinary(max)  NOT NULL,
    [Image_Productos] varbinary(max)  NOT NULL,
    [Image_Clientes] varbinary(max)  NOT NULL,
    [Image_Cobrar] varbinary(max)  NOT NULL,
    [Image_CtaCte] varbinary(max)  NOT NULL,
    [Image_Caja] varbinary(max)  NOT NULL,
    [Image_Logo_Principal] varbinary(max)  NOT NULL,
    [Image_Arreglos] varbinary(max)  NOT NULL,
    [Image_Pedido_Venta] varbinary(max)  NOT NULL,
    [Image_Info] varbinary(max)  NOT NULL,
    [Image_Esperando] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Arreglos'
CREATE TABLE [dbo].[Arreglos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [FechaPedido] datetime  NOT NULL,
    [FechaEntrega] datetime  NOT NULL,
    [Estado] bigint  NOT NULL,
    [Horario] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [Adelanto] decimal(18,0)  NOT NULL,
    [FechaRetirado] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoProductos'
ALTER TABLE [dbo].[TipoProductos]
ADD CONSTRAINT [PK_TipoProductos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Colegios'
ALTER TABLE [dbo].[Colegios]
ADD CONSTRAINT [PK_Colegios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [PK_Cajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleCajas'
ALTER TABLE [dbo].[DetalleCajas]
ADD CONSTRAINT [PK_DetalleCajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Producto_Pedidos'
ALTER TABLE [dbo].[Producto_Pedidos]
ADD CONSTRAINT [PK_Producto_Pedidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [PK_Ventas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Producto_Ventas'
ALTER TABLE [dbo].[Producto_Ventas]
ADD CONSTRAINT [PK_Producto_Ventas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CtasCtes'
ALTER TABLE [dbo].[CtasCtes]
ADD CONSTRAINT [PK_CtasCtes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Talles'
ALTER TABLE [dbo].[Talles]
ADD CONSTRAINT [PK_Talles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Producto_Datos'
ALTER TABLE [dbo].[Producto_Datos]
ADD CONSTRAINT [PK_Producto_Datos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Negocios'
ALTER TABLE [dbo].[Negocios]
ADD CONSTRAINT [PK_Negocios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Arreglos'
ALTER TABLE [dbo].[Arreglos]
ADD CONSTRAINT [PK_Arreglos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TipoProductoId] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_TipoProductoProducto]
    FOREIGN KEY ([TipoProductoId])
    REFERENCES [dbo].[TipoProductos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoProductoProducto'
CREATE INDEX [IX_FK_TipoProductoProducto]
ON [dbo].[Productos]
    ([TipoProductoId]);
GO

-- Creating foreign key on [ColegioId] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_ColegioProducto]
    FOREIGN KEY ([ColegioId])
    REFERENCES [dbo].[Colegios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioProducto'
CREATE INDEX [IX_FK_ColegioProducto]
ON [dbo].[Productos]
    ([ColegioId]);
GO

-- Creating foreign key on [CajaId] in table 'DetalleCajas'
ALTER TABLE [dbo].[DetalleCajas]
ADD CONSTRAINT [FK_CajaDetalleCaja]
    FOREIGN KEY ([CajaId])
    REFERENCES [dbo].[Cajas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CajaDetalleCaja'
CREATE INDEX [IX_FK_CajaDetalleCaja]
ON [dbo].[DetalleCajas]
    ([CajaId]);
GO

-- Creating foreign key on [ProductoId] in table 'Producto_Pedidos'
ALTER TABLE [dbo].[Producto_Pedidos]
ADD CONSTRAINT [FK_ProductoProducto_Pedido]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoProducto_Pedido'
CREATE INDEX [IX_FK_ProductoProducto_Pedido]
ON [dbo].[Producto_Pedidos]
    ([ProductoId]);
GO

-- Creating foreign key on [PedidoId] in table 'Producto_Pedidos'
ALTER TABLE [dbo].[Producto_Pedidos]
ADD CONSTRAINT [FK_PedidoProducto_Pedido]
    FOREIGN KEY ([PedidoId])
    REFERENCES [dbo].[Pedidos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoProducto_Pedido'
CREATE INDEX [IX_FK_PedidoProducto_Pedido]
ON [dbo].[Producto_Pedidos]
    ([PedidoId]);
GO

-- Creating foreign key on [ProductoId] in table 'Producto_Ventas'
ALTER TABLE [dbo].[Producto_Ventas]
ADD CONSTRAINT [FK_ProductoProducto_Venta]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoProducto_Venta'
CREATE INDEX [IX_FK_ProductoProducto_Venta]
ON [dbo].[Producto_Ventas]
    ([ProductoId]);
GO

-- Creating foreign key on [Venta_Id] in table 'Producto_Ventas'
ALTER TABLE [dbo].[Producto_Ventas]
ADD CONSTRAINT [FK_Producto_VentaVenta]
    FOREIGN KEY ([Venta_Id])
    REFERENCES [dbo].[Ventas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_VentaVenta'
CREATE INDEX [IX_FK_Producto_VentaVenta]
ON [dbo].[Producto_Ventas]
    ([Venta_Id]);
GO

-- Creating foreign key on [Cliente_Id] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_PedidoCliente]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoCliente'
CREATE INDEX [IX_FK_PedidoCliente]
ON [dbo].[Pedidos]
    ([Cliente_Id]);
GO

-- Creating foreign key on [Cliente_Id] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [FK_VentaCliente]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentaCliente'
CREATE INDEX [IX_FK_VentaCliente]
ON [dbo].[Ventas]
    ([Cliente_Id]);
GO

-- Creating foreign key on [ClienteId] in table 'CtasCtes'
ALTER TABLE [dbo].[CtasCtes]
ADD CONSTRAINT [FK_ClienteCtaCte]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCtaCte'
CREATE INDEX [IX_FK_ClienteCtaCte]
ON [dbo].[CtasCtes]
    ([ClienteId]);
GO

-- Creating foreign key on [TalleId] in table 'Producto_Pedidos'
ALTER TABLE [dbo].[Producto_Pedidos]
ADD CONSTRAINT [FK_TalleProducto_Pedido]
    FOREIGN KEY ([TalleId])
    REFERENCES [dbo].[Talles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TalleProducto_Pedido'
CREATE INDEX [IX_FK_TalleProducto_Pedido]
ON [dbo].[Producto_Pedidos]
    ([TalleId]);
GO

-- Creating foreign key on [TalleId] in table 'Producto_Ventas'
ALTER TABLE [dbo].[Producto_Ventas]
ADD CONSTRAINT [FK_TalleProducto_Venta]
    FOREIGN KEY ([TalleId])
    REFERENCES [dbo].[Talles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TalleProducto_Venta'
CREATE INDEX [IX_FK_TalleProducto_Venta]
ON [dbo].[Producto_Ventas]
    ([TalleId]);
GO

-- Creating foreign key on [Producto_PedidoId] in table 'Producto_Datos'
ALTER TABLE [dbo].[Producto_Datos]
ADD CONSTRAINT [FK_Producto_PedidoProducto_Dato]
    FOREIGN KEY ([Producto_PedidoId])
    REFERENCES [dbo].[Producto_Pedidos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_PedidoProducto_Dato'
CREATE INDEX [IX_FK_Producto_PedidoProducto_Dato]
ON [dbo].[Producto_Datos]
    ([Producto_PedidoId]);
GO

-- Creating foreign key on [ClienteId] in table 'Arreglos'
ALTER TABLE [dbo].[Arreglos]
ADD CONSTRAINT [FK_ClienteArreglo]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteArreglo'
CREATE INDEX [IX_FK_ClienteArreglo]
ON [dbo].[Arreglos]
    ([ClienteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------