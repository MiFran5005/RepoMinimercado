using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        public List<Detalles> Detalles { get; set; }
    }
}
