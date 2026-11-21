using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }      
        public String? Descripcion { get; set; }

        public List<Usuarios> Usuarios { get; set; }
        public List<Permisos> Permisos { get; set; }
    }
}