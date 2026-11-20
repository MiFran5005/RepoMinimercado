using Lib_Minimercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Minimercado.implementaciones
{
    public interface IClientes_Presentacion
    {
        Clientes Insertar (Clientes entidad);
        List<Clientes> Consultar ();
        Clientes Actualizar (Clientes entidad);
        Clientes Borrar (Clientes entidad);
        List<Clientes> Buscar(Clientes entidad);
    }
}
