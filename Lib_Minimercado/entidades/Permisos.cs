using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }        
        public String? Descripcion { get; set; }
        public int Rol { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
    }
}