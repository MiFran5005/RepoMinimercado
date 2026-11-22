using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Inventarios_Aplicacion : IInventarios_Aplicacion
    {
        private IConexion conexion;

        public Inventarios_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Inventarios Actualizar(Inventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Inventarios Borrar(Inventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Inventarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Inventarios> Buscar(Inventarios entidad)
        {
            return this.conexion.Inventarios!
                .Where(x => x.Actualizacion!.Contains(entidad.Actualizacion!))
                .ToList();
        }
        public List<Inventarios> Consultar()
        {
            return this.conexion.Inventarios!
                .ToList();
        }

        public Inventarios Insertar(Inventarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Inventarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Inventarios entidad)
        {
            return entidad.Cantidad <= 0 ||
                string.IsNullOrEmpty(entidad.Actualizacion)||
                entidad.Minimo <= 0 ||
                entidad.Maximo <= 0;
        }
    }
}
