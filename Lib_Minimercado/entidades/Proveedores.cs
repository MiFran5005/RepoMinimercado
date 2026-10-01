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
        public String? Descripcion { get; set; }

        public List<Pedidos> pedidos { get; set; }
        public List<Productos> productos { get; set; }
    }
}
