using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Proveedores_Aplicacion : IProveedores_Aplicacion
    {
        private IConexion conexion;

        public Proveedores_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Proveedores Actualizar(Proveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Proveedores!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Proveedores> Buscar(Proveedores entidad)
        {
            return this.conexion.Proveedores!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Proveedores> Consultar()
        {
            return this.conexion.Proveedores!
                .ToList();
        }

        public Proveedores Insertar(Proveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Proveedores!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Proveedores entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                string.IsNullOrEmpty(entidad.Telefono);
        }
    }
}
