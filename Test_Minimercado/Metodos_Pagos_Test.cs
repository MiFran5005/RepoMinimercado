using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Metodos_PagosTest
    {
        private Conexion conexion;
        private Metodos_Pagos entidad;

        public Metodos_PagosTest()
        {
            this.conexion = new Conexion();
            conexion.StringConexion = "server=localhost\\DEV;database=db_minimercado;Integrated Security=True;TrustServerCertificate=true;";
        }
        [TestMethod]
        public void Ejecutar()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        private void Insertar()
        {
            entidad = new Metodos_Pagos()
            {
                Nombre = "Efectivo",
            };

            this.conexion.Metodos_Pagos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_metodos_pagos = this.conexion.Metodos_Pagos!.ToList();
            if (lista_metodos_pagos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Tarjeta";

            var entry = this.conexion!.Entry<Metodos_Pagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Metodos_Pagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}