using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IContratos_Presentacion
    {
        Contratos Insertar(Contratos entidad);
        List<Contratos> Consultar();
        Contratos Actualizar(Contratos entidad);
        Contratos Borrar(Contratos entidad);
        List<Contratos> Buscar(Contratos entidad);
    }
}
