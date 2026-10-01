using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Contratos
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String? TipoContrato { get; set; }
        public String? Descripcion { get; set; }

        public List<Empleados_Cargos> empleados_cargos { get; set; }
    }
}
