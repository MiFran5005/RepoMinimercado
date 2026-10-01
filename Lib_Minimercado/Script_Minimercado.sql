CREATE DATABASE db_minimercado;
GO
USE db_minimercado;
GO

CREATE TABLE [Salarios] 
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[valor] DECIMAL(20, 2) NOT NULL
);

SELECT * FROM [Salarios];


CREATE TABLE [Horarios]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[horaInicio] DATETIME NOT NULL,
	[horaFinal] DATETIME NOT NULL,
	[dia] NVARCHAR(20) NOT NULL,
	[turno] NVARCHAR (20) NOT NULL
);

SELECT * FROM [Horarios];


CREATE TABLE [Contratos]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[fechaInicio] DATETIME NOT NULL,
	[fechaFin] DATETIME NOT NULL,
	[tipoContrato] NVARCHAR(20) NOT NULL,
	[descripcion] NVARCHAR (MAX) NOT NULL
);

SELECT * FROM [Contratos];


CREATE TABLE [Empleados]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[nombre] NVARCHAR(20) NOT NULL,
	[cedula] NVARCHAR(14) UNIQUE NOT NULL,
	[telefono] NVARCHAR(10) NOT NULL,
	[carnet] NVARCHAR (MAX) NOT NULL
);

SELECT * FROM [Empleados];


CREATE TABLE [Vehiculos]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[codigo] NVARCHAR(20) NOT NULL,
	[nombre] NVARCHAR(100) NOT NULL,
	[placa] NVARCHAR(20) NOT NULL,
	[tipo] NVARCHAR(50) NOT NULL
);

SELECT * FROM [Vehiculos];


CREATE TABLE [Estados]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[tipoEstado] NVARCHAR(50) NOT NULL,
	[nombre] NVARCHAR(50) NOT NULL,
	[descripcion] NVARCHAR(MAX) NULL
);

SELECT * FROM [Estados];


CREATE TABLE [Metodos_Pagos]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[nombre] NVARCHAR(100) NOT NULL
);

SELECT * FROM [Metodos_Pagos];


CREATE TABLE [Proveedores]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[codigo] NVARCHAR(200) NOT NULL,
[nombre] NVARCHAR(200) NOT NULL,
[telefono] NVARCHAR(200) NOT NULL,
[direccion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Proveedores];


CREATE TABLE [Categorias]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[nombre] NVARCHAR(200) NOT NULL,
[descripcion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Categorias];


CREATE TABLE [Marcas]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[nombre] NVARCHAR(200) NOT NULL,
[descripcion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Marcas];


CREATE TABLE [Inventarios]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[cantidad] INT NOT NULL,
[actualizacion] NVARCHAR(200) NOT NULL,
[minimo] INT NOT NULL,
[maximo] INT NOT NULL
);

SELECT * FROM [Inventarios];


CREATE TABLE [Estantes]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[codigo] NVARCHAR(200) NOT NULL,
[nombre] NVARCHAR(200) NOT NULL,
[capacidad] INT NOT NULL,
[ubicacion] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Estantes];


CREATE TABLE [Clientes]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[codigo] NVARCHAR(200) NOT NULL,
[nombre] NVARCHAR(200) NOT NULL,
[cedula] NVARCHAR(200) NOT NULL,
[telefono] NVARCHAR(200) NOT NULL
);

SELECT * FROM [Clientes];


CREATE TABLE [Cargos]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[tipoEmpleado] NVARCHAR(20) NOT NULL,
	[salario] INT NOT NULL REFERENCES [Salarios](id),
	[horario] INT NOT NULL REFERENCES [Horarios](id),
	[descripcion] NVARCHAR (MAX) NOT NULL
);

SELECT * FROM [Cargos];


CREATE TABLE [Empleados_Cargos]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[cargo] INT NOT NULL REFERENCES [Cargos](id),
	[empleado] INT NOT NULL REFERENCES [Empleados](id),
	[contrato] INT NOT NULL REFERENCES [Contratos](id),
	[fechaAsignacion] DATETIME NOT NULL
);

SELECT * FROM [Empleados_Cargos];


CREATE TABLE [Pedidos]
(
	[id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[cantidad] INT NOT NULL,
	[total] DECIMAL(20, 2) NOT NULL,
	[empleado] INT NOT NULL REFERENCES [Empleados](id),
	[proveedor] INT NOT NULL REFERENCES [Proveedores](id),
	[fecha] DATETIME NOT NULL
);

SELECT * FROM [Pedidos];


CREATE TABLE [Productos]
(
[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[codigo] INT NOT NULL,
[nombre] NVARCHAR(200) NOT NULL,
[precio] INT NOT NULL,
[IVA] INT NOT NULL,
[provedor] INT NOT NULL REFERENCES [Proveedores]([id]),
[estante] INT NOT NULL REFERENCES [Estantes]([id]),
[inventario] INT NOT NULL REFERENCES [Inventarios]([id]),
[marca] INT NOT NULL REFERENCES [Marcas]([id]),
[categoria] INT NOT NULL REFERENCES [Categorias]([id])
);

SELECT * FROM [Productos];


CREATE TABLE [Domicilios]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[empleado] INT NOT NULL REFERENCES [Empleados](id),
	[vehiculo] INT NOT NULL REFERENCES [Vehiculos](id),
	[fecha] DATETIME NOT NULL,
	[descripcion] NVARCHAR(MAX) NULL
);

SELECT * FROM [Domicilios];


CREATE TABLE [Facturas]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[cantidad] INT NOT NULL,
	[total] INT NOT NULL,
	[fecha] DATETIME NOT NULL,
	[empleado] INT NOT NULL REFERENCES [Empleados](id)
);

SELECT * FROM [Facturas];


CREATE TABLE [Detalles]
(
	[id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[factura] INT NOT NULL REFERENCES [Facturas](id),
	[producto] INT NOT NULL REFERENCES [Productos](id),
	[cliente] INT NOT NULL REFERENCES [Clientes](id),
	[domicilio] INT NULL REFERENCES [Domicilios](id),
	[estado] INT NOT NULL REFERENCES [Estados](id),
	[metodoPago] INT NOT NULL REFERENCES [Metodos_Pagos](id)
);

SELECT * FROM [Detalles];