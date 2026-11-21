using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public String? Accion { get; set; }        
        public String? Entidad { get; set; }       
        public String? Detalle { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
