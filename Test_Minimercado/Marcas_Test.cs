using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Marcas_Test
    {
        private Conexion conexion;
        private Marcas entidad;

        public Marcas_Test()
        {
            this.conexion.StringConexion = Datos_Generales.ObtenerStringConexion();
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
            entidad = new Marcas()
            {
                Nombre = "Cremelado",
                Descripcion = "Helado"
            };

            this.conexion.Marcas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_marcas = this.conexion.Marcas!.ToList();
            if (lista_marcas.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Nestle";
            

            var entry = this.conexion!.Entry<Marcas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Marcas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
