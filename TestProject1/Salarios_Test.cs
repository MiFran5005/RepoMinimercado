using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    [TestClass]
    public class Salarios_Test
    {
        private Conexion conexion;
        private Salarios entidad;

        public Salarios_Test()
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
            entidad = new Salarios()
            {
                Valor = 1000000
            };

            this.conexion.Salarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_salarios = this.conexion.Salarios!.ToList();
            if (lista_salarios.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Valor = 500000;

            var entry = this.conexion!.Entry<Salarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Salarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
