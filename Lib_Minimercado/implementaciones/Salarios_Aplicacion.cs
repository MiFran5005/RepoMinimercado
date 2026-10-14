using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Salarios_Aplicacion : ISalarios_Aplicacion
    {
        private IConexion conexion;

        public Salarios_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Salarios Actualizar(Salarios entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Salarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Salarios Borrar(Salarios entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Salarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Salarios> Consultar()
        {
            return this.conexion.Salarios!
                .ToList();
        }

        public Salarios Insertar(Salarios entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Salarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
