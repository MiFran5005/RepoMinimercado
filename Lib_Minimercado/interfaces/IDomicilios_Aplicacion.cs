using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IDomicilios_Aplicacion
    {
        Domicilios Insertar(Domicilios entidad);
        List<Domicilios> Consultar();
        Domicilios Actualizar(Domicilios entidad);
        Domicilios Borrar(Domicilios entidad);
        List<Domicilios> Buscar(Domicilios entidad);
    }
}
