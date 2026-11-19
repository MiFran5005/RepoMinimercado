using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IEstantes_Aplicacion
    {
        Estantes Insertar(Estantes entidad);
        List<Estantes> Consultar();
        Estantes Actualizar(Estantes entidad);
        Estantes Borrar(Estantes entidad);
        List<Estantes> Buscar(Estantes entidad);
    }
}
