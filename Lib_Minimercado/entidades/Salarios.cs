using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Salarios
    {
        public int Id { get; set; }
        public int Valor { get; set; }

        public List<Cargos> Cargos { get; set; }
    }
}
