using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Cargos
    {
        public int Id { get; set; }
        public String? TipoEmpleado { get; set; }
        public int Salario { get; set; }
        public int Horario { get; set; }
        public String? Descripcion { get; set; }

        [ForeignKey("Salario")] public Salarios? _Salario { get; set; }
        [ForeignKey("Horario")] public Horarios? _Horario { get; set; }

        public List<Empleados_Cargos> Empleados_Cargos { get; set; }
    }
}
