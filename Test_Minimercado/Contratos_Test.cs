using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Contratos_Test
    {
        private Conexion conexion;
        private Contratos entidad;

        public Contratos_Test()
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
            entidad = new Contratos()
            {
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now,
                TipoContrato = "Termino indefinido",
                Descripcion = "No haga sino trabajar"
            };

            this.conexion.Contratos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_horarios = this.conexion.Contratos!.ToList();
            if (lista_horarios.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.TipoContrato = "Termino fijo";

            var entry = this.conexion!.Entry<Contratos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Contratos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
