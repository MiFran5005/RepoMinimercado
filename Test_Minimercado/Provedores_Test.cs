using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Provedores_Test
    {
        private Conexion conexion;
        private Provedores entidad;

        public Provedores_Test()
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
            entidad = new Provedores()
            {
               Codigo = 1,
               Nombre = "Postobon",
               Telefono = "123456789",
               Direccion = "Calle 123",
            };

            this.conexion.Provedores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_provedores = this.conexion.Provedores!.ToList();
            if (lista_provedores.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Coca-Cola";

            var entry = this.conexion!.Entry<Provedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Provedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
