using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Metodos_Pagos_Aplicacion : IMetodos_Pagos_Aplicacion
    {
        private IConexion conexion;

        public Metodos_Pagos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Metodos_Pagos Actualizar(Metodos_Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Metodos_Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Metodos_Pagos Borrar(Metodos_Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Metodos_Pagos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Metodos_Pagos> Buscar(Metodos_Pagos entidad)
        {
            return this.conexion.Metodos_Pagos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Metodos_Pagos> Consultar()
        {
            return this.conexion.Metodos_Pagos!
                .ToList();
        }

        public Metodos_Pagos Insertar(Metodos_Pagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Metodos_Pagos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Metodos_Pagos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre);
                
        }
    }
}
