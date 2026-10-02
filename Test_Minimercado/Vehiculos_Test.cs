using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class VehiculosTest
    {
        private Conexion conexion;
        private Vehiculos entidad;

        public VehiculosTest()
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
            entidad = new Vehiculos()
            {
                Codigo = "2187",
                Nombre = "Ferrari",
                Placa = "ABC-123",
                Tipo = "Deportivo"
            };
            this.conexion.Vehiculos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_vehiculos = this.conexion.Vehiculos!.ToList();
            if (lista_vehiculos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Pagani";

            var entry = this.conexion!.Entry<Vehiculos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Vehiculos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}