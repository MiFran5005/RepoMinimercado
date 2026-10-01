using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Detalles
    {
        public int Id { get; set; }
        public int Factura { get; set; }
        public int Producto { get; set; }
        public int Cliente { get; set; }
        public int Domicilio { get; set; }
        public int Estado { get; set; }
        public int Metodo_Pago { get; set; }

        [ForeignKey("Factura")] public Facturas? _Factura { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Domicilio")] public Domicilios? _Domicilio { get; set; }
        [ForeignKey("Estado")] public Estados? _Estado { get; set; }
        [ForeignKey("Metodo_Pago")] public Metodos_Pagos? _Metodo_Pago { get; set; }
    }
}
