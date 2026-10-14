using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface ICargos_Aplicacion
    {
        Cargos Insertar (Cargos entidad);
        List<Cargos> Consultar ();
        Cargos Actualizar (Cargos entidad);
        Cargos Borrar (Cargos entidad);
    }
}
