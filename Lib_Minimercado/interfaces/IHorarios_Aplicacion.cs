using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IHorarios_Aplicacion
    {
        Horarios Insertar(Horarios entidad);
        List<Horarios> Consultar();
        Horarios Actualizar(Horarios entidad);
        Horarios Borrar(Horarios entidad);
    }
}
