using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedore { get; set; }
    }
}
