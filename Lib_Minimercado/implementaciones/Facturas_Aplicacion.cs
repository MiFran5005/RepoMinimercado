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

            this.conexion.Facturas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.conexion!.Facturas!
            .Include(x => x._Empleado)
            .Where(x => x.Total >= entidad.Total)
            .ToList();
        }
        public List<Facturas> Consultar()
        {
            return this.conexion!.Facturas!
            .Include(x => x._Empleado)
             .ToList();
        }

        public Facturas Insertar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Facturas!.Add(entidad!);
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
