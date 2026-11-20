using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IMetodos_Pagos_Presentacion
    {
        Metodos_Pagos Insertar(Metodos_Pagos entidad);
        List<Metodos_Pagos> Consultar();
        Metodos_Pagos Actualizar(Metodos_Pagos entidad);
        Metodos_Pagos Borrar(Metodos_Pagos entidad);
        List<Metodos_Pagos> Buscar(Metodos_Pagos entidad);
    }
}
