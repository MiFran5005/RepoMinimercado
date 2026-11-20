using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IProveedores_Presentacion
    {
        Proveedores Insertar(Proveedores entidad);
        List<Proveedores> Consultar();
        Proveedores Actualizar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
        List<Proveedores> Buscar(Proveedores entidad);
    }
}
