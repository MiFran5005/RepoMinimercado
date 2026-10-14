using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Empleados_Aplicacion : IEmpleados_Aplicacion
    {
        private IConexion conexion;

        public Empleados_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Empleados Actualizar(Empleados entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Empleados Borrar(Empleados entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Empleados!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Consultar()
        {
            return this.conexion.Empleados!
                .ToList();
        }

        public Empleados Insertar(Empleados entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Empleados!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
