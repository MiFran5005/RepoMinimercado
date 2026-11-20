using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface ICategorias_Presentacion
    {
        Categorias Insertar (Categorias entidad);
        List<Categorias> Consultar ();
        Categorias Actualizar (Categorias entidad);
        Categorias Borrar (Categorias entidad);
        List<Categorias> Buscar(Categorias entidad);
    }
}
