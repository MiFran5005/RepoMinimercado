using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Marcas_Aplicacion : IMarcas_Aplicacion
    {
        private IConexion conexion;

        public Marcas_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Marcas Actualizar(Marcas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Marcas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Marcas Borrar(Marcas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Marcas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Marcas> Buscar(Marcas entidad)
        {
            return this.conexion.Marcas!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Marcas> Consultar()
        {
            return this.conexion.Marcas!
                .ToList();
        }

        public Marcas Insertar(Marcas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Marcas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Marcas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
