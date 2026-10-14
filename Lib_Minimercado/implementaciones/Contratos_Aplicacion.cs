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
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Contratos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Contratos Borrar(Contratos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Contratos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Contratos> Consultar()
        {
            return this.conexion.Contratos!
                .ToList();
        }

        public Contratos Insertar(Contratos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Contratos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
