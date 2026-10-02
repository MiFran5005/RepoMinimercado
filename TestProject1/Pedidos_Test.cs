using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    [TestClass]
    public class Pedidos_Test
    {
        private Conexion conexion;
        private Pedidos entidad;

        public Pedidos_Test()
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
            entidad = new Pedidos()
            {
                Cantidad = 30,
                Total = 123250.32m,
                Empleado =  1,
                Proveedor = 1,
                Fecha = DateTime.Now
            };

            this.conexion.Pedidos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_pedidos = this.conexion.Pedidos!.ToList();
            if (lista_pedidos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 3;

            var entry = this.conexion!.Entry<Pedidos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pedidos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
