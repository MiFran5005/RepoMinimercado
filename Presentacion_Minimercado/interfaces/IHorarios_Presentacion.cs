using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IHorarios_Presentacion
    {
        Horarios Insertar(Horarios entidad);
        List<Horarios> Consultar();
        Horarios Actualizar(Horarios entidad);
        Horarios Borrar(Horarios entidad);
        List<Horarios> Buscar(Horarios entidad);
    }
}
