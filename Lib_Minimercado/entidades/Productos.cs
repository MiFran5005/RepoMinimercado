using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
        [ForeignKey("Estante")] public Estantes? _Estante { get; set; }
        [ForeignKey("Inventario")] public Inventarios? _Inventario { get; set; }
        [ForeignKey("Marca")] public Marcas? _Marca { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }

        public List<Detalles> Detalles { get; set; }
    }
}
