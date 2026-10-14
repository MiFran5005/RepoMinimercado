using Lib_Minimercado.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

         DbSet<Cargos>? Cargos { get; set; }
         DbSet<Categorias>? Categorias { get; set; }
         DbSet<Clientes>? Clientes { get; set; }
         DbSet<Contratos>? Contratos { get; set; }
         DbSet<Detalles>? Detalles { get; set; }
         DbSet<Domicilios>? Domicilios { get; set; }
         DbSet<Empleados>? Empleados { get; set; }
         DbSet<Empleados_Cargos>? Empleados_Cargos { get; set; }
         DbSet<Estados>? Estados { get; set; }
         DbSet<Estantes>? Estantes { get; set; }
         DbSet<Facturas>? Facturas { get; set; }
         DbSet<Horarios>? Horarios { get; set; }
         DbSet<Inventarios>? Inventarios { get; set; }
         DbSet<Marcas>? Marcas { get; set; }
         DbSet<Metodos_Pagos>? Metodos_Pagos { get; set; }
         DbSet<Pedidos>? Pedidos { get; set; }
         DbSet<Productos>? Productos { get; set; }
         DbSet<Proveedores>? Proveedores { get; set; }
         DbSet<Salarios>? Salarios { get; set; }
         DbSet<Vehiculos>? Vehiculos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
