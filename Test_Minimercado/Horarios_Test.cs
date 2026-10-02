using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Horarios_Test
    {
        private Conexion conexion;
        private Horarios entidad;

        public Horarios_Test()
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
            entidad = new Horarios()
            {
                HoraInicio = DateTime.Now,
                HoraFinal = DateTime.Now,
                Dia = "Lunes",
                Turno = "Noche"
            };

            this.conexion.Horarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_horarios = this.conexion.Horarios!.ToList();
            if (lista_horarios.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Turno = "Dia";

            var entry = this.conexion!.Entry<Horarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Horarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
