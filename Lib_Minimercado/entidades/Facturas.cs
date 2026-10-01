using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
        public int Empleado { get; set; }

        public Empleados? _empleados { get; set; }
        public List<Detalles> detalles { get; set; }
    }
}
