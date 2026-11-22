using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Contratos_Aplicacion : IContratos_Aplicacion
    {
        private IConexion conexion;

        public Contratos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Contratos Actualizar(Contratos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Contratos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Contratos Borrar(Contratos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Contratos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Contratos> Buscar(Contratos entidad)
        {
            return this.conexion.Contratos!
                .Where(x => x.TipoContrato!.Contains(entidad.TipoContrato!))
                .ToList();
        }
        public List<Contratos> Consultar()
        {
            return this.conexion.Contratos!
                .ToList();
        }

        public Contratos Insertar(Contratos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");
            this.conexion.Contratos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Contratos entidad)
        {
            return entidad.FechaInicio == null ||
                entidad.FechaFin == null ||
                string.IsNullOrEmpty(entidad.TipoContrato) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
