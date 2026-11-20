using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IEmpleados_Presentacion
    {
        Empleados Insertar(Empleados entidad);
        List<Empleados> Consultar();
        Empleados Actualizar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
        List<Empleados> Buscar(Empleados entidad);
    }
}
