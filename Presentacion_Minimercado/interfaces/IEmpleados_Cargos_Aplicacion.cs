using Lib_Minimercado.entidades;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IEmpleados_Cargos_Aplicacion
    {
        Empleados_Cargos Insertar(Empleados_Cargos entidad);
        List<Empleados_Cargos> Consultar();
        Empleados_Cargos Actualizar(Empleados_Cargos entidad);
        Empleados_Cargos Borrar(Empleados_Cargos entidad);
        List<Empleados_Cargos> Buscar(Empleados_Cargos entidad);
    }
}
