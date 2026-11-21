using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Usuarios_Test
    {
        private Conexion conexion;
        private Roles rol;
        private Usuarios entidad;

        public Usuarios_Test()
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
            rol = new Roles() { Nombre = "Rol usuarios prueba", Descripcion = "Prueba" };
            this.conexion.Roles!.Add(this.rol);
            this.conexion.SaveChanges();

            entidad = new Usuarios()
            {
                NombreUsuario = "usuario_prueba",
                Contrasena = "hash_de_prueba",
                Rol = this.rol.Id
            };

            this.conexion.Usuarios!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Usuarios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.NombreUsuario = "usuario_modificado";

            var entry = this.conexion!.Entry<Usuarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Usuarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Roles!.Remove(this.rol!);
            this.conexion.SaveChanges();
        }
    }
}