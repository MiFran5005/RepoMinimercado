using System;
using System.Collections.Generic;
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

        public Facturas? _facturas { get; set; }
        public Productos? _productos { get; set; }
        public Clientes? _clientes { get; set; }
        public Domicilios? _domicilios { get; set; }
        public Estados? _estados{ get; set; }
        public Metodos_Pagos? _metodos_pagos{ get; set; }
    }
}
