using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface ISalarios_Aplicacion
    {
        Salarios Insertar(Salarios entidad);
        List<Salarios> Consultar();
        Salarios Actualizar(Salarios entidad);
        Salarios Borrar(Salarios entidad);
    }
}
