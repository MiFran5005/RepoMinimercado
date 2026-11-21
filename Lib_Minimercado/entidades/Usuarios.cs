using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public String? NombreUsuario { get; set; }
        public String? Contrasena { get; set; }    
        public int Rol { get; set; }
        public int? Empleado { get; set; }        
        public int? Cliente { get; set; }          

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

        public List<Auditorias> Auditorias { get; set; }
    }
}