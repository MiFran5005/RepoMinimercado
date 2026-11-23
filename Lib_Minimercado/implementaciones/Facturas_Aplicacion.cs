using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Facturas_Aplicacion : IFacturas_Aplicacion
    {
        private IConexion conexion;

        public Facturas_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var detalles = this.conexion!.Detalles!
                .Where(d => d.Factura == entidad.Id)
                .ToList();
            this.conexion.Detalles!.RemoveRange(detalles);

            entidad._Empleado = null;
            entidad._Cliente = null;
            entidad._Metodo_Pago = null;
            entidad.Detalles = null!;

            this.conexion.Facturas!.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.conexion!.Facturas!
        .Include(x => x._Empleado)
        .Include(x => x._Cliente)
        .Include(x => x._Metodo_Pago)
        .Include(x => x.Detalles).
         ThenInclude(d => d._Producto)
        .ToList();
        }
        public List<Facturas> Consultar()
        {
            return this.conexion!.Facturas!
        .Include(x => x._Empleado)
        .Include(x => x._Cliente)
        .Include(x => x._Metodo_Pago)
        .Include(x => x.Detalles).
         ThenInclude(d => d._Producto)
        .ToList();
        }

        public Facturas Insertar(Facturas entidad)
        {
            entidad._Empleado = null;
            entidad._Cliente = null;
            entidad._Metodo_Pago = null;

            foreach (var d in entidad.Detalles)
            {
                var prod = this.conexion!.Productos!.Find(d.Producto)
           ?? throw new Exception("Producto no encontrado");

                d.Precio = prod.Precio;

                d.Cliente = entidad.Cliente;
                d.Metodo_Pago = entidad.Metodo_Pago;
                d.Domicilio = 1;
                d.Estado = 1; ;


                d._Producto = null;
                d._Cliente = null;
                d._Estado = null;
                d._Metodo_Pago = null;
                d._Domicilio = null;
                d._Factura = null;
            }
            entidad.Cantidad = entidad.Detalles.Sum(d => d.Cantidad);
            entidad.Total = entidad.Detalles.Sum(d => d.Precio * d.Cantidad);

            this.conexion!.Facturas!.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Facturas entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Total <= 0 ||
                entidad.Fecha == null ||
                entidad.Empleado <= 0;
        }
    }
}
