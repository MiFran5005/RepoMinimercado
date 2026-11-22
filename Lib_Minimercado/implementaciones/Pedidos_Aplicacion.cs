using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Pedidos_Aplicacion : IPedidos_Aplicacion
    {
        private IConexion conexion;

        public Pedidos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Pedidos Actualizar(Pedidos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Pedidos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Pedidos Borrar(Pedidos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pedidos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Pedidos> Buscar(Pedidos entidad)
        {
            return this.conexion.Pedidos!
                .Where(x => x.Cantidad! >= entidad.Cantidad!)
                .ToList();
        }
        public List<Pedidos> Consultar()
        {
            return this.conexion.Pedidos!
                .ToList();
        }

        public Pedidos Insertar(Pedidos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Pedidos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Pedidos entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Total <= 0 ||
                entidad.Empleado <= 0 ||
                entidad.Proveedor <= 0 ||
                entidad.Fecha == null;
        }

    }
}
