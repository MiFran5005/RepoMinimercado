using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Cedula { get; set; }
        public String? Telefono { get; set; }
        public String? Carnet { get; set; }

        public List<Empleados_Cargos> empleados_cargos { get; set; }
        public List<Pedidos> pedidos { get; set; }
        public List<Domicilios> domicilios { get; set; }
        public List<Facturas> facturas { get; set; }
    }
}
