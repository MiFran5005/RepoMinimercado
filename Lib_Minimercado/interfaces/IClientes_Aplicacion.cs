using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public interface IClientes_Aplicacion
    {
        Clientes Insertar (Clientes entidad);
        List<Clientes> Consultar ();
        Clientes Actualizar (Clientes entidad);
        Clientes Borrar (Clientes entidad);
        List<Clientes> Buscar(Clientes entidad);
    }
}
