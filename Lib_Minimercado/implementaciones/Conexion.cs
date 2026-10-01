using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Contratos>? Contratos { get; set; }
        public DbSet<Detalles>? Detalles { get; set; }
        public DbSet<Domicilios>? Domicilios { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Empleados_Cargos>? Empleados_Cargos { get; set; }
        public DbSet<Estados>? Estados { get; set; }
        public DbSet<Estantes>? Estantes { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Horarios>? Horarios { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Metodos_Pagos>? Metodos_Pagos { get; set; }
        public DbSet<Pedidos>? Pedidos { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Salarios>? Salarios { get; set; }
        public DbSet<Vehiculos>? Vehiculos { get; set; }
    }
}
