using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IEmpleados_Cargos_Aplicacion
    {
        Empleados_Cargos Insertar(Empleados_Cargos entidad);
        List<Empleados_Cargos> Consultar();
        Empleados_Cargos Actualizar(Empleados_Cargos entidad);
        Empleados_Cargos Borrar(Empleados_Cargos entidad);
    }
}
