using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Empleados_Cargos_Aplicacion : IEmpleados_Cargos_Aplicacion
    {
        private IConexion conexion;

        public Empleados_Cargos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Empleados_Cargos Actualizar(Empleados_Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Empleados_Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Empleados_Cargos Borrar(Empleados_Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Empleados_Cargos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Empleados_Cargos> Buscar(Empleados_Cargos entidad)
        {
            return this.conexion.Empleados_Cargos!
                .Where(x => x.Cargo! >= entidad.Cargo!)
                .ToList();
        }
        public List<Empleados_Cargos> Consultar()
        {
            return this.conexion.Empleados_Cargos!
                .ToList();
        }

        public Empleados_Cargos Insertar(Empleados_Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Empleados_Cargos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Empleados_Cargos entidad)
        {
            return (entidad.Cargo <= 0) ||
               (entidad.Empleado <= 0) ||
               (entidad.Contrato <= 0) ||
               (entidad.FechaAsignacion == null);
        }
    }
}
