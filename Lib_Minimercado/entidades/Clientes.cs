using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public String? Codigo { get; set; }
        public String? Nombre { get; set; }
        public String? Cedula { get; set; }
        public String? Telefono { get; set; }


        public List<Detalles> detalles { get; set; }
    }
}
