using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public int Empleado { get; set; }
        public int Proveedor { get; set; }
        public DateTime Fecha { get; set; }

        public Empleados? _empleados { get; set; }
        public Proveedores? _proveedores { get; set; }
    }
}
