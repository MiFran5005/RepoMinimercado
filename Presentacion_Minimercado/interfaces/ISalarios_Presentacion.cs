using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface ISalarios_Presentacion
    {
        Salarios Insertar(Salarios entidad);
        List<Salarios> Consultar();
        Salarios Actualizar(Salarios entidad);
        Salarios Borrar(Salarios entidad);
        List<Salarios> Buscar(Salarios entidad);
    }
}
