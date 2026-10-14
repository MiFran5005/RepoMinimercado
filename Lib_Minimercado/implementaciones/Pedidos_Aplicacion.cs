using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Pedidos_Aplicacion : IPedidos_Aplicacion
    {
        private IConexion conexion;

        public Pedidos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Pedidos Actualizar(Pedidos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Pedidos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Pedidos Borrar(Pedidos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pedidos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Pedidos> Consultar()
        {
            return this.conexion.Pedidos!
                .ToList();
        }

        public Pedidos Insertar(Pedidos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pedidos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
