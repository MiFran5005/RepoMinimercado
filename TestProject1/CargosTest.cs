using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;

namespace TestProject1
{
    [TestClass]
    public sealed class CargosTest
    {
        [TestMethod]
        public class TestCargos
        {
            private Conexion conexion;
            private Cargos entidad;

            public TestCargos()
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
                this.entidad = new Cargos()
                {

                };
                this.conexion.Cargos!.Add(this.entidad!);
                this.conexion.SaveChanges();
            }

            public void Consultar()
            {
                var lista_cargos = this.conexion.Cargos!.ToList();
                if (lista_cargos.Count <= 0)
                    throw new Exception("Lista vacia");
            }

            private void Actualizar()
            {
                this.entidad!.Activa = true;

                var entry = this.conexion!.Entry<Cargos>(this.entidad);
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.conexion!.SaveChanges();
            }

            private void Borrar()
            {
                this.conexion.Cargos!.Remove(this.entidad!);
                this.conexion.SaveChanges();
            }
        }
    }
}
