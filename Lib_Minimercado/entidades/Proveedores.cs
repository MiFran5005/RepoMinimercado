using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public String? Codigo { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Direccion { get; set; }

        public List<Pedidos> Pedidos { get; set; }
        public List<Productos> Productos { get; set; }
    }
}
