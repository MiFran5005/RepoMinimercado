using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Estados_Aplicacion : IEstados_Aplicacion
    {
        private IConexion conexion;

        public Estados_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Estados Actualizar(Estados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Estados>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Estados Borrar(Estados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Estados!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Estados> Buscar(Estados entidad)
        {
            return this.conexion.Estados!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Estados> Consultar()
        {
            return this.conexion.Estados!
                .ToList();
        }

        public Estados Insertar(Estados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Estados!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Estados entidad)
        {
            return string.IsNullOrEmpty(entidad.TipoEstado) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
