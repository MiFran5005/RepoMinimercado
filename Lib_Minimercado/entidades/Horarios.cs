using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Horarios
    {
        public int Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public String? Dia { get; set; }
        public String? Turno { get; set; }

        public List<Cargos> Cargos { get; set; }
    }
}
