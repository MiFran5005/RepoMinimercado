using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Domicilios
    {
        public  int Id { get; set; }
        public  int Empleado { get; set; }
        public  int Vehiculo { get; set; }
        public  DateTime Fecha { get; set; }
        public  String? Descripcion { get; set; }

        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Vehiculo")] public Vehiculos? _Vehiculo { get; set; }
        public List<Detalles> Detalles { get; set; }
    }
}
