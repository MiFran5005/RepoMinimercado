using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Empleados_Cargos
    {
        public int Id { get; set; }
        public int Cargo { get; set; }
        public int Empleado { get; set; }
        public int Contrato { get; set; }
        public DateTime FechaAsignacion { get; set; }

        [ForeignKey("Cargo")] public Cargos? _Cargo { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Contrato")] public Contratos? _Contrato { get; set; }
    }
}
