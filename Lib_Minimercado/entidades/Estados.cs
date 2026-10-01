using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Estados
    {
        public int Id { get; set; }
        public String? TipoEstado { get; set; }
        public String? Nombre { get; set; }
        public String? Descripcion { get; set; }

        public List<Detalles> detalles { get; set; }
    }
}
