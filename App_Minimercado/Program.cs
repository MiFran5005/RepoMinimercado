using Lib_Minimercado.implementaciones;
using Lib_Minimercado.interfaces;
using Lib_Minimercado.Nucleo;


try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = Datos_Generales.ObtenerStringConexion();
    var lista_cargos = conexion.Cargos!.ToList();
    var lista_categorias = conexion.Categorias!.ToList();
    var lista_clientes = conexion.Clientes!.ToList();
    var lista_contratos = conexion.Contratos!.ToList();
    var lista_detalles = conexion.Detalles!.ToList();
    var lista_domicilios = conexion.Domicilios!.ToList();
    var lista_empleados = conexion.Empleados!.ToList();
    var lista_empleados_cargos = conexion.Empleados_Cargos!.ToList();
    var lista_estados = conexion.Estados!.ToList();
    var lista_estantes = conexion.Estantes!.ToList();
    var lista_facturas = conexion.Facturas!.ToList();
    var lista_horarios = conexion.Horarios!.ToList();
    var lista_inventarios = conexion.Inventarios!.ToList();
    var lista_marcas = conexion.Marcas!.ToList();
    var lista_metodos_pagos = conexion.Metodos_Pagos!.ToList();
    var lista_pedidos = conexion.Pedidos!.ToList();
    var lista_productos = conexion.Productos!.ToList();
    var lista_proveedores = conexion.Proveedores!.ToList();
    var lista_salarios = conexion.Salarios!.ToList();
    var lista_vehiculos = conexion.Vehiculos!.ToList();
    var lista_roles = conexion.Roles!.ToList();
    var lista_permisos = conexion.Permisos!.ToList();
    var lista_usuarios = conexion.Usuarios!.ToList();
    var lista_auditorias = conexion.Auditorias!.ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("Presentacion Minimercado");