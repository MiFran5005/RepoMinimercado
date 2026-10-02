using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Estantes_Test
    {
        private Conexion conexion;
        private Estantes entidad;

        public Estantes_Test()
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
            entidad = new Estantes()
            {
                Codigo = "EST001",
                Nombre = "Estante Principal",
                Capacidad = 50,
                Ubicacion = "Pasillo 1"
            };

            this.conexion.Estantes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_estantes = this.conexion.Estantes!.ToList();
            if (lista_estantes.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Capacidad = 100;

            var entry = this.conexion!.Entry<Estantes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Estantes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
