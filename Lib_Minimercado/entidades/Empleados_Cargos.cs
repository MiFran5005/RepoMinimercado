using System;
using System.Collections.Generic;
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

        public Cargos? _cargos { get; set; }
        public Empleados? _empleados { get; set; }
        public Contratos? _contratos { get; set; }
    }
}
