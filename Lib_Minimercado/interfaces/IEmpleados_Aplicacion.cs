using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IEmpleados_Aplicacion
    {
        Empleados Insertar(Empleados entidad);
        List<Empleados> Consultar();
        Empleados Actualizar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
