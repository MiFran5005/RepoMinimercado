/*
CREATE DATABASE db_minimercado;
GO
USE db_minimercado;
GO

CREATE TABLE [Salarios] 
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Valor] DECIMAL(20, 2) NOT NULL
);

SELECT * FROM [Salarios];


CREATE TABLE [Horarios]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[HoraInicio] DATETIME NOT NULL,
	[HoraFinal] DATETIME NOT NULL,
	[Dia] NVARCHAR(20) NOT NULL,
	[Turno] NVARCHAR (20) NOT NULL
);

SELECT * FROM [Horarios];


CREATE TABLE [Contratos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[FechaInicio] DATETIME NOT NULL,
	[FechaFin] DATETIME NOT NULL,
	[TipoContrato] NVARCHAR(20) NOT NULL,
	[Descripcion] NVARCHAR (MAX) NOT NULL
);

SELECT * FROM [Contratos];


CREATE TABLE [Empleados]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(20) NOT NULL,
	[Cedula] NVARCHAR(14) UNIQUE NOT NULL,
	[Telefono] NVARCHAR(10) NOT NULL,
	[Carnet] NVARCHAR (MAX) NOT NULL
);

SELECT * FROM [Empleados];


CREATE TABLE [Vehiculos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(20) NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Placa] NVARCHAR(20) NOT NULL,
	[Tipo] NVARCHAR(50) NOT NULL
);

SELECT * FROM [Vehiculos];


CREATE TABLE [Estados]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[TipoEstado] NVARCHAR(50) NOT NULL,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Descripcion] NVARCHAR(MAX) NULL
);

SELECT * FROM [Estados];


CREATE TABLE [Metodos_Pagos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL
);

SELECT * FROM [Metodos_Pagos];


CREATE TABLE [Proveedores]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(200) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Telefono] NVARCHAR(200) NOT NULL,
	[Direccion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Proveedores];


CREATE TABLE [Categorias]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Descripcion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Categorias];


CREATE TABLE [Marcas]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Descripcion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Marcas];


CREATE TABLE [Inventarios]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Cantidad] INT NOT NULL,
	[Actualizacion] NVARCHAR(200) NOT NULL,
	[Minimo] INT NOT NULL,
	[Maximo] INT NOT NULL
);

SELECT * FROM [Inventarios];


CREATE TABLE [Estantes]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(200) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Capacidad] INT NOT NULL,
	[Ubicacion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Estantes];


CREATE TABLE [Clientes]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(200) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Cedula] NVARCHAR(200) NOT NULL,
	[Telefono] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Clientes];


CREATE TABLE [Cargos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[TipoEmpleado] NVARCHAR(20) NOT NULL,
	[Salario] INT NOT NULL REFERENCES [Salarios](id),
	[Horario] INT NOT NULL REFERENCES [Horarios](id),
	[Descripcion] NVARCHAR (MAX) NOT NULL
);

SELECT * FROM [Cargos];


CREATE TABLE [Empleados_Cargos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Cargo] INT NOT NULL REFERENCES [Cargos](id),
	[Empleado] INT NOT NULL REFERENCES [Empleados](id),
	[Contrato] INT NOT NULL REFERENCES [Contratos](id),
	[FechaAsignacion] DATETIME NOT NULL
);

SELECT * FROM [Empleados_Cargos];


CREATE TABLE [Pedidos]
(
	[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[Cantidad] INT NOT NULL,
	[Total] DECIMAL(20, 2) NOT NULL,
	[Empleado] INT NOT NULL REFERENCES [Empleados](id),
	[Proveedor] INT NOT NULL REFERENCES [Proveedores](id),
	[Fecha] DATETIME NOT NULL
);

SELECT * FROM [Pedidos];


CREATE TABLE [Productos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] INT NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Precio] INT NOT NULL,
	[IVA] INT NOT NULL,
	[Proveedor] INT NOT NULL REFERENCES [Proveedores]([id]),
	[Estante] INT NOT NULL REFERENCES [Estantes]([id]),
	[Inventario] INT NOT NULL REFERENCES [Inventarios]([id]),
	[Marca] INT NOT NULL REFERENCES [Marcas]([id]),
	[Categoria] INT NOT NULL REFERENCES [Categorias]([id])
);

SELECT * FROM [Productos];


CREATE TABLE [Domicilios]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Empleado] INT NOT NULL REFERENCES [Empleados](id),
	[Vehiculo] INT NOT NULL REFERENCES [Vehiculos](id),
	[Fecha] DATETIME NOT NULL,
	[Descripcion] NVARCHAR(MAX) NULL
);

SELECT * FROM [Domicilios];


CREATE TABLE [Facturas]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Cantidad] INT NOT NULL,
	[Total] INT NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[Empleado] INT NOT NULL REFERENCES [Empleados](id)
);

SELECT * FROM [Facturas];


CREATE TABLE [Detalles]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Factura] INT NOT NULL REFERENCES [Facturas](id),
	[Producto] INT NOT NULL REFERENCES [Productos](id),
	[Cliente] INT NOT NULL REFERENCES [Clientes](id),
	[Domicilio] INT NULL REFERENCES [Domicilios](id),
	[Estado] INT NOT NULL REFERENCES [Estados](id),
	[Metodo_Pago] INT NOT NULL REFERENCES [Metodos_Pagos](id)
);

SELECT * FROM [Detalles];
*/