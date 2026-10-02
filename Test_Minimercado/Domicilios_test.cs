using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class DomiciliosTest
    {
        private Conexion conexion;
        private Domicilios entidad;

        public DomiciliosTest()
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
            entidad = new Domicilios()
            {
                Empleado = 1,
                Vehiculo = 1,
                Fecha = DateTime.Now,
                Descripcion = "Calle 43 cr 15, por la vuelta de don tito"
            };
            this.conexion.Domicilios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_domicilios = this.conexion.Domicilios!.ToList();
            if (lista_domicilios.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Descripcion = "Calle 69 cr 67, antes de llegar al parque";

            var entry = this.conexion!.Entry<Domicilios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Domicilios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}