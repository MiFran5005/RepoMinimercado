using Lib_Minimercado.implementaciones;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();

builder.Services.AddScoped<ICargos_Presentacion, Cargos_Presentacion>();
builder.Services.AddScoped<ICategorias_Presentacion, Categorias_Presentacion>();
builder.Services.AddScoped<IClientes_Presentacion, Clientes_Presentacion>();
builder.Services.AddScoped<IContratos_Presentacion, Contratos_Presentacion>();
builder.Services.AddScoped<IDetalles_Presentacion, Detalles_Presentacion>();
builder.Services.AddScoped<IDomicilios_Presentacion, Domicilios_Presentacion>();
builder.Services.AddScoped<IEmpleados_Presentacion, Empleados_Presentacion>();
builder.Services.AddScoped<IEmpleados_Cargos_Presentacion, Empleados_Cargos_Presentacion>();
builder.Services.AddScoped<IEstados_Presentacion, Estados_Presentacion>();
builder.Services.AddScoped<IEstantes_Presentacion, Estantes_Presentacion>();
builder.Services.AddScoped<IFacturas_Presentacion, Facturas_Presentacion>();
builder.Services.AddScoped<ICategorias_Presentacion, Categorias_Presentacion>();
builder.Services.AddScoped<IHorarios_Presentacion, Horarios_Presentacion>();
builder.Services.AddScoped<IInventarios_Presentacion, Inventarios_Presentacion>();
builder.Services.AddScoped<IMarcas_Presentacion, Marcas_Presentacion>();
builder.Services.AddScoped<IMetodos_Pagos_Presentacion, Metodos_Pagos_Presentacion>();
builder.Services.AddScoped<IPedidos_Presentacion, Pedidos_Presentacion>();
builder.Services.AddScoped<IProductos_Presentacion, Productos_Presentacion>();
builder.Services.AddScoped<IProveedores_Presentacion, Proveedores_Presentacion>();
builder.Services.AddScoped<ISalarios_Presentacion, Salarios_Presentacion>();
builder.Services.AddScoped<IVehiculos_Presentacion, Vehiculos_Presentacion>();
builder.Services.AddScoped<IRoles_Presentacion, Roles_Presentacion>();
builder.Services.AddScoped<IPermisos_Presentacion, Permisos_Presentacion>();
builder.Services.AddScoped<IUsuarios_Presentacion, Usuarios_Presentacion>();
builder.Services.AddScoped<IAuditorias_Presentacion, Auditorias_Presentacion>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
app.Run();
