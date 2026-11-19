using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IFacturas_Aplicacion
    {
        Facturas Insertar(Facturas entidad);
        List<Facturas> Consultar();
        Facturas Actualizar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
        List<Facturas> Buscar(Facturas entidad);
    }
}
