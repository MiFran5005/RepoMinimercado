using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IDetalles_Presentacion
    {
        Detalles Insertar(Detalles entidad);
        List<Detalles> Consultar();
        Detalles Actualizar(Detalles entidad);
        Detalles Borrar(Detalles entidad);
        List<Detalles> Buscar(Detalles entidad);
    }
}
