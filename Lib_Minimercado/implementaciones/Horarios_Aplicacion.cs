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
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Horarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Horarios Borrar(Horarios entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Horarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Horarios> Consultar()
        {
            return this.conexion.Horarios!
                .ToList();
        }

        public Horarios Insertar(Horarios entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Horarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
