using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Cargos_Test
    {
        private Conexion conexion;
        private Cargos entidad;

        public Cargos_Test()
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
            entidad = new Cargos()
            {
                TipoEmpleado = "Domiciliario",
                Salario = 1,
                Horario = 1,
                Descripcion = "Entregar pedidos"
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
            this.entidad!.TipoEmpleado = "Cajero";

            var entry = this.conexion!.Entry<Cargos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Cargos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
