using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Estantes_Aplicacion : IEstantes_Aplicacion
    {
        private IConexion conexion;

        public Estantes_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Estantes Actualizar(Estantes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Estantes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Estantes Borrar(Estantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Estantes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Estantes> Buscar(Estantes entidad)
        {
            return this.conexion.Estantes!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Estantes> Consultar()
        {
            return this.conexion.Estantes!
                .ToList();
        }

        public Estantes Insertar(Estantes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Estantes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Estantes entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Capacidad <= 0 ||
                string.IsNullOrEmpty(entidad.Ubicacion);
        }
    }
}
