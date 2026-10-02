using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Categorias_Test
    {
        private Conexion conexion;
        private Categorias entidad;

        public Categorias_Test()
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
            entidad = new Categorias()
            {
                Nombre = "Lacteos",
                Descripcion = "Productos derivados de la leche"
            };

            this.conexion.Categorias!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_categorias = this.conexion.Categorias!.ToList();
            if (lista_categorias.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Bebidas";

            var entry = this.conexion!.Entry<Categorias>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Categorias!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
