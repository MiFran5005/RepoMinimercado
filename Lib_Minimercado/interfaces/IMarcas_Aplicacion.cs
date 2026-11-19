using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IMarcas_Aplicacion
    {
        Marcas Insertar(Marcas entidad);
        List<Marcas> Consultar();
        Marcas Actualizar(Marcas entidad);
        Marcas Borrar(Marcas entidad);
        List<Marcas> Buscar(Marcas entidad);
    }
}
