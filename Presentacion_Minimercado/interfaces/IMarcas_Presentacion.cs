using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IMarcas_Presentacion
    {
        Marcas Insertar(Marcas entidad);
        List<Marcas> Consultar();
        Marcas Actualizar(Marcas entidad);
        Marcas Borrar(Marcas entidad);
        List<Marcas> Buscar(Marcas entidad);
    }
}
