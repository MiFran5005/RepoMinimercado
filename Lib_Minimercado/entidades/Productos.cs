using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Precio { get; set; }
        public int IVA { get; set; }
        public int Proveedor { get; set; }
        public int Estante { get; set; }
        public int Inventario { get; set; }
        public int Marca { get; set; }
        public int Categoria { get; set; }

        public Proveedores? _proveedores { get; set; }
        public Estantes? _estantes { get; set; }
        public Inventarios? _inventarios { get; set; }
        public Marcas? _marcas { get; set; }
        public Categorias? _categorias { get; set; }

        public List<Detalles> detalles { get; set; }
    }
}
