using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IProductos_Aplicacion
    {
        Productos Insertar(Productos entidad);
        List<Productos> Consultar();
        Productos Actualizar(Productos entidad);
        Productos Borrar(Productos entidad);
        List<Productos> Buscar(Productos entidad);
    }
}
