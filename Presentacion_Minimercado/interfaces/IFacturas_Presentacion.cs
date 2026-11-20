using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IFacturas_Presentacion
    {
        Facturas Insertar(Facturas entidad);
        List<Facturas> Consultar();
        Facturas Actualizar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
        List<Facturas> Buscar(Facturas entidad);
    }
}
