using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Detalles_Aplicacion : IDetalles_Aplicacion
    {
        private IConexion conexion;

        public Detalles_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Detalles Actualizar(Detalles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Detalles>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Detalles Borrar(Detalles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Detalles!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Detalles> Buscar(Detalles entidad)
        {
            return this.conexion.Detalles!
                .Include(x => x._Factura)
                .Include(x => x._Producto)
                .Include(x => x._Cliente)
                .Include(x => x._Domicilio)
                .Include(x => x._Estado)
                .Include(x => x._Metodo_Pago)
                .Where(x => x.Factura! >= entidad.Factura!)
                .ToList();
        }
        public List<Detalles> Consultar()
        {
            return this.conexion.Detalles!
                .Include(x => x._Factura)
                .Include(x => x._Producto)
                .Include(x => x._Cliente)
                .Include(x => x._Domicilio)
                .Include(x => x._Estado)
                .Include(x => x._Metodo_Pago)
                .ToList();
                
        }

        public Detalles Insertar(Detalles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Detalles!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Detalles entidad)
        {
            return entidad.Factura <= 0 ||
                entidad.Producto <= 0 ||
                entidad.Cliente <= 0 ||
                entidad.Domicilio <= 0 ||
                entidad.Estado <= 0 ||
                entidad.Metodo_Pago <= 0;
        }
    }
}
