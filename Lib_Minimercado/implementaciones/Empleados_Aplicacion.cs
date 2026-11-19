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
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Empleados Borrar(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Empleados!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Empleados> Buscar(Empleados entidad)
        {
            return this.conexion.Empleados!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Empleados> Consultar()
        {
            return this.conexion.Empleados!
                .ToList();
        }

        public Empleados Insertar(Empleados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Empleados!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Empleados entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Cedula) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                string.IsNullOrEmpty(entidad.Carnet);
        }

        }
    }

