using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Metodos_Pagos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }

        public List<Detalles> detalles { get; set; }
    }
}
