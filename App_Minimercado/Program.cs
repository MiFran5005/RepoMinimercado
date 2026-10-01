using Lib_Minimercado.implementaciones;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = "server=localhost\\DEV;database=db_minimercado;Integrated Security=True;TrustServerCertificate=true;";
    var lista_cargos = conexion.Salarios!.ToList();
    var lista_servicios = conexion.Cargos!
        .Include(x => x._salario)
        .ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("Consola Deportes");