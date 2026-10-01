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

        public List<Empleados_Cargos> Empleados_Cargos { get; set; }
        public List<Pedidos> Pedidos { get; set; }
        public List<Domicilios> Domicilios { get; set; }
        public List<Facturas> Facturas { get; set; }
    }
}
