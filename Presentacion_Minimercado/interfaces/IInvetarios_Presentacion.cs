using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IInventarios_Aplicacion
    {
        Inventarios Insertar(Inventarios entidad);
        List<Inventarios> Consultar();
        Inventarios Actualizar(Inventarios entidad);
        Inventarios Borrar(Inventarios entidad);
        List<Inventarios> Buscar(Inventarios entidad);
    }
}
