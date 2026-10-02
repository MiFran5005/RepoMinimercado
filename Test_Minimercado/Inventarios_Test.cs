using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Inventarios_Test
    {
        private Conexion conexion;
        private Inventarios entidad;

        public Inventarios_Test()
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
            entidad = new Inventarios()
            {
                Cantidad = 100,
                Actualizacion = DateTime.Now.ToString("yyyy-MM-dd"),
                Minimo = 10,
                Maximo = 500
            };

            this.conexion.Inventarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_inventarios = this.conexion.Inventarios!.ToList();
            if (lista_inventarios.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 200;

            var entry = this.conexion!.Entry<Inventarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Inventarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
