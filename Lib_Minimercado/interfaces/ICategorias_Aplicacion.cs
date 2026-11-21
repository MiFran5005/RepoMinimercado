using Lib_Minimercado.entidades;
using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface ICategorias_Aplicacion
    {
        Categorias Insertar (Categorias entidad);
        List<Categorias> Consultar ();
        Categorias Actualizar (Categorias entidad);
        Categorias Borrar (Categorias entidad);
        List<Categorias> Buscar(Categorias entidad);
    }
}
