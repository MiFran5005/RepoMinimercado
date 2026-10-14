/*
CREATE DATABASE db_minimercado;
GO

USE db_minimercado;
GO


CREATE TABLE [Salarios] 
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Valor] INT NOT NULL
);

INSERT INTO [Salarios] ([Valor])
VALUES (2000000);

SELECT * FROM [Salarios];


CREATE TABLE [Horarios]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[HoraInicio] DATETIME NOT NULL,
	[HoraFinal] DATETIME NOT NULL,
	[Dia] NVARCHAR(20) NOT NULL,
	[Turno] NVARCHAR (20) NOT NULL
);

INSERT INTO [Horarios] ([HoraInicio], [HoraFinal], [Dia], [Turno])
VALUES ('2026-10-01 08:00:00', '2026-10-01 17:00:00', 'Lunes', 'Mañana');

SELECT * FROM [Horarios];


CREATE TABLE [Contratos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[FechaInicio] DATETIME NOT NULL,
	[FechaFin] DATETIME NOT NULL,
	[TipoContrato] NVARCHAR(20) NOT NULL,
	[Descripcion] NVARCHAR (MAX) NOT NULL
);

INSERT INTO [Contratos] ([FechaInicio], [FechaFin], [TipoContrato], [Descripcion])
VALUES ('2026-01-01 08:00:00', '2026-12-31 17:00:00', 'Indefinido', 'Contrato de empleado de tiempo completo');

SELECT * FROM [Contratos];


CREATE TABLE [Empleados]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(20) NOT NULL,
	[Cedula] NVARCHAR(14) UNIQUE NOT NULL,
	[Telefono] NVARCHAR(10) NOT NULL,
	[Carnet] NVARCHAR (MAX) NOT NULL
);

INSERT INTO [Empleados] ([Nombre], [Cedula], [Telefono], [Carnet])
VALUES ('Carlos Perez', '1001234567', '3001234567', 'CAR-001');

SELECT * FROM [Empleados];


CREATE TABLE [Vehiculos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(20) NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Placa] NVARCHAR(20) NOT NULL,
	[Tipo] NVARCHAR(50) NOT NULL
);

INSERT INTO [Vehiculos] ([Codigo], [Nombre], [Placa], [Tipo])
VALUES ('VEH-001', 'Moto Domicilios', 'ABC123', 'Motocicleta');

SELECT * FROM [Vehiculos];


CREATE TABLE [Estados]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[TipoEstado] NVARCHAR(50) NOT NULL,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Descripcion] NVARCHAR(MAX) NULL
);

INSERT INTO [Estados] ([TipoEstado], [Nombre], [Descripcion])
VALUES ('Pedido', 'Entregado', 'El pedido fue entregado correctamente');

SELECT * FROM [Estados];


CREATE TABLE [Metodos_Pagos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL
);

INSERT INTO [Metodos_Pagos] ([Nombre])
VALUES ('Efectivo');

SELECT * FROM [Metodos_Pagos];


CREATE TABLE [Proveedores]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(200) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Telefono] NVARCHAR(200) NOT NULL,
	[Direccion] NVARCHAR(200) NOT NULL
);

INSERT INTO [Proveedores] ([Codigo], [Nombre], [Telefono], [Direccion])
VALUES ('PROV-001', 'Coca Cola', '6041234567', 'Calle 10 # 20-30');

SELECT * FROM [Proveedores];


CREATE TABLE [Categorias]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Descripcion] NVARCHAR(200) NOT NULL
);

INSERT INTO [Categorias] ([Nombre], [Descripcion])
VALUES ('Bebidas', 'Bebidas gaseosas y refrescos');

SELECT * FROM [Categorias];


CREATE TABLE [Marcas]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Descripcion] NVARCHAR(200) NOT NULL
);

INSERT INTO [Marcas] ([Nombre], [Descripcion])
VALUES ('Coca Cola', 'Marca de bebidas gaseosas');

SELECT * FROM [Marcas];


CREATE TABLE [Inventarios]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Cantidad] INT NOT NULL,
	[Actualizacion] NVARCHAR(200) NOT NULL,
	[Minimo] INT NOT NULL,
	[Maximo] INT NOT NULL
);

INSERT INTO [Inventarios] ([Cantidad], [Actualizacion], [Minimo], [Maximo])
VALUES (50, '2026-10-01 10:00:00', 10, 100);

SELECT * FROM [Inventarios];


CREATE TABLE [Estantes]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(200) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Capacidad] INT NOT NULL,
	[Ubicacion] NVARCHAR(200) NOT NULL
);

INSERT INTO [Estantes] ([Codigo], [Nombre], [Capacidad], [Ubicacion])
VALUES ('EST-001', 'Estante Bebidas', 100, 'Pasillo 1');

SELECT * FROM [Estantes];


CREATE TABLE [Clientes]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] NVARCHAR(200) NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Cedula] NVARCHAR(200) NOT NULL,
	[Telefono] NVARCHAR(200) NOT NULL
);

INSERT INTO [Clientes] ([Codigo], [Nombre], [Cedula], [Telefono])
VALUES ('CLI-001', 'Juan Rodriguez', '1009876543', '3109876543');
INSERT INTO [Clientes] ([Codigo], [Nombre], [Cedula], [Telefono])
VALUES ('CLI-002', 'Ana Garcia', '1088291224', '3027669192');

SELECT * FROM [Clientes];


CREATE TABLE [Cargos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[TipoEmpleado] NVARCHAR(20) NOT NULL,
	[Salario] INT NOT NULL REFERENCES [Salarios](id),
	[Horario] INT NOT NULL REFERENCES [Horarios](id),
	[Descripcion] NVARCHAR (MAX) NOT NULL
);

INSERT INTO [Cargos] ([TipoEmpleado], [Salario], [Horario], [Descripcion])
VALUES ('Cajero', 1, 1, 'Empleado encargado de atender la caja y realizar cobros');

SELECT * FROM [Cargos];


CREATE TABLE [Empleados_Cargos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Cargo] INT NOT NULL REFERENCES [Cargos](id),
	[Empleado] INT NOT NULL REFERENCES [Empleados](id),
	[Contrato] INT NOT NULL REFERENCES [Contratos](id),
	[FechaAsignacion] DATETIME NOT NULL
);

INSERT INTO [Empleados_Cargos] ([Cargo], [Empleado], [Contrato], [FechaAsignacion])
VALUES (1, 1, 1, '2026-01-02 08:00:00');

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

INSERT INTO [Pedidos] ([Cantidad], [Total], [Empleado], [Proveedor], [Fecha])
VALUES (10, 500000.00, 1, 1, '2026-10-01 10:00:00');

SELECT * FROM [Pedidos];


CREATE TABLE [Productos]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Codigo] INT NOT NULL,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Precio] INT NOT NULL,
	[IVA] DECIMAL(4,2) NOT NULL,
	[Proveedor] INT NOT NULL REFERENCES [Proveedores]([id]),
	[Estante] INT NOT NULL REFERENCES [Estantes]([id]),
	[Inventario] INT NOT NULL REFERENCES [Inventarios]([id]),
	[Marca] INT NOT NULL REFERENCES [Marcas]([id]),
	[Categoria] INT NOT NULL REFERENCES [Categorias]([id])
);

INSERT INTO [Productos] ([Codigo], [Nombre], [Precio], [IVA], [Proveedor], [Estante], [Inventario], [Marca], [Categoria])
VALUES (1001, 'Coca Cola 3L', 12000, 19, 1, 1, 1, 1, 1);

SELECT * FROM [Productos];


CREATE TABLE [Domicilios]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Empleado] INT NOT NULL REFERENCES [Empleados](id),
	[Vehiculo] INT NOT NULL REFERENCES [Vehiculos](id),
	[Fecha] DATETIME NOT NULL,
	[Descripcion] NVARCHAR(MAX) NULL
);

INSERT INTO [Domicilios] ([Empleado], [Vehiculo], [Fecha], [Descripcion])
VALUES (1, 1, '2026-10-01 12:00:00', 'Domicilio de productos al cliente');

SELECT * FROM [Domicilios];


CREATE TABLE [Facturas]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Cantidad] INT NOT NULL,
	[Total] INT NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[Empleado] INT NOT NULL REFERENCES [Empleados](id)
);

INSERT INTO [Facturas] ([Cantidad], [Total], [Fecha], [Empleado])
VALUES (2, 24000, '2026-10-01 13:00:00', 1);

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

INSERT INTO [Detalles] ([Factura], [Producto], [Cliente], [Domicilio], [Estado], [Metodo_Pago])
VALUES (1, 1, 1, 1, 1, 1);

SELECT * FROM [Detalles];
*/