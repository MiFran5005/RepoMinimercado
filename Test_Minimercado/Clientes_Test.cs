using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Clientes_Test
    {
        private Conexion conexion;
        private Clientes entidad;

        public Clientes_Test()
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
            entidad = new Clientes()
            {
                Codigo = "CLI001",
                Nombre = "Carlos Perez",
                Cedula = "1234567890",
                Telefono = "3101234567"
            };

            this.conexion.Clientes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_clientes = this.conexion.Clientes!.ToList();
            if (lista_clientes.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3209876543";

            var entry = this.conexion!.Entry<Clientes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Clientes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
