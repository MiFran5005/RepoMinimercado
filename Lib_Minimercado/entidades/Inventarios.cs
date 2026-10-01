using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public String? Actualizacion { get; set; }
        public int Minimo { get; set; }
        public int Maximo { get; set; }

        public List<Productos> productos { get; set; }
    }
}
