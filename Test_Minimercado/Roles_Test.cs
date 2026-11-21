using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Roles_Test
    {
        private Conexion conexion;
        private Roles entidad;

        public Roles_Test()
        {
            this.conexion = new Conexion();
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
            entidad = new Roles()
            {
                Nombre = "Rol de prueba",
                Descripcion = "Rol creado por el test"
            };

            this.conexion.Roles!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Roles!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Rol modificado";

            var entry = this.conexion!.Entry<Roles>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Roles!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}