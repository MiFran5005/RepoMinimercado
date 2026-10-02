using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class DetallesTest
    {
        private Conexion conexion;
        private Detalles entidad;

        public DetallesTest()
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

        public void Insertar()
        {
            entidad = new Detalles()
            {
                Factura = 1,
                Producto = 1,
                Cliente = 1,
                Domicilio = 1,
                Estado = 1,
                Metodo_Pago = 1
            };
            this.conexion.Detalles!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_detalles = this.conexion.Detalles!.ToList();
            if (lista_detalles.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Producto = 2;

            var entry = this.conexion!.Entry<Detalles>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Detalles!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}