using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IPedidos_Aplicacion
    {
        Pedidos Insertar(Pedidos entidad);
        List<Pedidos> Consultar();
        Pedidos Actualizar(Pedidos entidad);
        Pedidos Borrar(Pedidos entidad);
    }
}
