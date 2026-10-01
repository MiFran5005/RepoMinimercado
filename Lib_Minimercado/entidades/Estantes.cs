using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Estantes
    {
        public int Id { get; set; }
        public String? Codigo { get; set; }
        public String? Nombre { get; set; }
        public int Capacidad { get; set; }
        public String? Ubicacion { get; set; }

        public List<Productos> Productos { get; set; }
    }
}
