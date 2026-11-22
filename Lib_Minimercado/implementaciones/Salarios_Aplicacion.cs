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
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Salarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Salarios Borrar(Salarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Salarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Salarios> Buscar(Salarios entidad)
        {
            return this.conexion.Salarios!
                .Where(x => x.Valor! >= entidad.Valor!)
                .ToList();
        }
        public List<Salarios> Consultar()
        {
            return this.conexion.Salarios!
                .ToList();
        }

        public Salarios Insertar(Salarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Salarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Salarios entidad)
        {
            return entidad.Valor <= 0;
                
        }
    }
}
