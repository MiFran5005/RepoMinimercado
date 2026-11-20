using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IEstados_Presentacion
    {
        Estados Insertar(Estados entidad);
        List<Estados> Consultar();
        Estados Actualizar(Estados entidad);
        Estados Borrar(Estados entidad);
        List<Estados> Buscar(Estados entidad);
    }
}
