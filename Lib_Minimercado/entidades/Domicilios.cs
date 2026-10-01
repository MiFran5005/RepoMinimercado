using System;
using System.Collections.Generic;
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

        public Empleados? _empleados { get; set; }
        public Vehiculos? _vehiculos { get; set; }
        public List<Detalles> detalles { get; set; }
    }
}
