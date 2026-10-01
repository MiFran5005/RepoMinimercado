using System;
using System.Collections.Generic;
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

        public Salarios? _salario { get; set; }
        public Horarios? _horario { get; set; }

        public List<Empleados_Cargos> empleados_cargos { get; set; }
    }
}
