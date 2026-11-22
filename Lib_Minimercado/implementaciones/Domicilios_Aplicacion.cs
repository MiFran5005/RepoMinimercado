using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Domicilios_Aplicacion : IDomicilios_Aplicacion
    {
        private IConexion conexion;

        public Domicilios_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Domicilios Actualizar(Domicilios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Domicilios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Domicilios Borrar(Domicilios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Domicilios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Domicilios> Buscar(Domicilios entidad)
        {
            return this.conexion.Domicilios!
                .Include(x => x._Empleado)
                .Include(x => x._Vehiculo)
                .Where(x => x.Descripcion!.Contains(entidad.Descripcion!))
                .ToList();
        }
        public List<Domicilios> Consultar()
        {
            return this.conexion.Domicilios!
                .Include(x => x._Empleado)
                .Include(x => x._Vehiculo)
                .ToList();
        }

        public Domicilios Insertar(Domicilios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Domicilios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Domicilios entidad)
        {
            return entidad.Empleado <= 0 ||
                entidad.Vehiculo <= 0 ||
                entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
