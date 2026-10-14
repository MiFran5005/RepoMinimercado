using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IContratos_Aplicacion
    {
        Contratos Insertar(Contratos entidad);
        List<Contratos> Consultar();
        Contratos Actualizar(Contratos entidad);
        Contratos Borrar(Contratos entidad);
    }
}
