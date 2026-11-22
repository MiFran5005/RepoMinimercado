using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Productos_Aplicacion : IProductos_Aplicacion
    {
        private IConexion conexion;

        public Productos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Productos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Productos> Buscar(Productos entidad)
        {
            return this.conexion.Productos!
                .Include(x => x._Proveedor)
                .Include(x => x._Estante)
                .Include(x => x._Inventario)
                .Include(x => x._Marca)
                .Include(x => x._Categoria)
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Productos> Consultar()
        {
            return this.conexion.Productos!
                .Include(x => x._Proveedor)
                .Include(x => x._Estante)
                .Include(x => x._Inventario)
                .Include(x => x._Marca)
                .Include(x => x._Categoria)
                .ToList();
        }

        public Productos Insertar(Productos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Productos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Productos entidad)
        {
            return entidad.Codigo <= 0 ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Precio <= 0 ||
                entidad.IVA <= 0 ||
                entidad.Proveedor <= 0 ||
                entidad.Estante <= 0 ||
                entidad.Inventario <= 0 ||
                entidad.Inventario <= 0 ||
                entidad.Categoria <= 0;
        }
    }
}
