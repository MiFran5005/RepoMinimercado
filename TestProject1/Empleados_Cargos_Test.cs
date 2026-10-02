using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    [TestClass]
    public class Empleados_Cargos_Test
    {
        private Conexion conexion;
        private Empleados_Cargos entidad;

        public Empleados_Cargos_Test()
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
            entidad = new Empleados_Cargos()
            {
                Cargo = 1,
                Empleado = 1,
                Contrato = 1,
                FechaAsignacion = DateTime.Now
            };

            this.conexion.Empleados_Cargos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_empleados_cargos = this.conexion.Empleados_Cargos!.ToList();
            if (lista_empleados_cargos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.FechaAsignacion = DateTime.Now;

            var entry = this.conexion!.Entry<Empleados_Cargos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Empleados_Cargos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
