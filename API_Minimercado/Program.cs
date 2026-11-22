using API_Minimercado;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o =>
{
    o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    o.Filters.Add<AuditoriaFilter>();
});
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<ICargos_Aplicacion, Cargos_Aplicacion>();
builder.Services.AddScoped<ICategorias_Aplicacion, Categorias_Aplicacion>();
builder.Services.AddScoped<IClientes_Aplicacion, Clientes_Aplicacion>();
builder.Services.AddScoped<IContratos_Aplicacion, Contratos_Aplicacion>();
builder.Services.AddScoped<IDetalles_Aplicacion, Detalles_Aplicacion>();
builder.Services.AddScoped<IDomicilios_Aplicacion, Domicilios_Aplicacion>();
builder.Services.AddScoped<IEmpleados_Aplicacion, Empleados_Aplicacion>();
builder.Services.AddScoped<IEmpleados_Cargos_Aplicacion, Empleados_Cargos_Aplicacion>();
builder.Services.AddScoped<IEstados_Aplicacion, Estados_Aplicacion>();
builder.Services.AddScoped<IEstantes_Aplicacion, Estantes_Aplicacion>();
builder.Services.AddScoped<IFacturas_Aplicacion, Facturas_Aplicacion>();
builder.Services.AddScoped<ICategorias_Aplicacion, Categorias_Aplicacion>();
builder.Services.AddScoped<IHorarios_Aplicacion, Horarios_Aplicacion>();
builder.Services.AddScoped<IInventarios_Aplicacion, Inventarios_Aplicacion>();
builder.Services.AddScoped<IMarcas_Aplicacion, Marcas_Aplicacion>();
builder.Services.AddScoped<IMetodos_Pagos_Aplicacion, Metodos_Pagos_Aplicacion>();
builder.Services.AddScoped<IPedidos_Aplicacion, Pedidos_Aplicacion>();
builder.Services.AddScoped<IProductos_Aplicacion, Productos_Aplicacion>();
builder.Services.AddScoped<IProveedores_Aplicacion, Proveedores_Aplicacion>();
builder.Services.AddScoped<ISalarios_Aplicacion, Salarios_Aplicacion>();
builder.Services.AddScoped<IVehiculos_Aplicacion, Vehiculos_Aplicacion>();
builder.Services.AddScoped<IRoles_Aplicacion, Roles_Aplicacion>();
builder.Services.AddScoped<IPermisos_Aplicacion, Permisos_Aplicacion>();
builder.Services.AddScoped<IUsuarios_Aplicacion, Usuarios_Aplicacion>();
builder.Services.AddScoped<IAuditorias_Aplicacion, Auditorias_Aplicacion>();



var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();

