using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Vehiculos
    {
        public int Id { get; set; }
        public String? Codigo { get; set; }
        public String? Nombre { get; set; }
        public String? Placa { get; set; }
        public String? Tipo { get; set; }


        public List<Domicilios> domicilios { get; set; }
    }
}
