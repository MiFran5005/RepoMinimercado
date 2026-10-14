using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Empleados_Cargos_Cargos_Aplicacion : IEmpleados_Cargos_Aplicacion
    {
        private IConexion conexion;

        public Empleados_Cargos_Cargos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Empleados_Cargos Actualizar(Empleados_Cargos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Empleados_Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Empleados_Cargos Borrar(Empleados_Cargos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Empleados_Cargos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Empleados_Cargos> Consultar()
        {
            return this.conexion.Empleados_Cargos!
                .ToList();
        }

        public Empleados_Cargos Insertar(Empleados_Cargos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Empleados_Cargos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
