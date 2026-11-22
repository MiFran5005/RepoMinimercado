using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Horarios_Aplicacion : IHorarios_Aplicacion
    {
        private IConexion conexion;

        public Horarios_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Horarios Actualizar(Horarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Horarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Horarios Borrar(Horarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Horarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Horarios> Buscar(Horarios entidad)
        {
            return this.conexion.Horarios!
                .Where(x => x.Turno!.Contains(entidad.Turno!))
                .ToList();
        }
        public List<Horarios> Consultar()
        {
            return this.conexion.Horarios!
                .ToList();
        }

        public Horarios Insertar(Horarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Horarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Horarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Turno) ||
                entidad.HoraInicio == null ||
                entidad.HoraFinal == null;
        }
    }
}
