using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.Nucleo;

namespace Test_Minimercado
{
    [TestClass]
    public class Auditorias_Test
    {
        private Conexion conexion;
        private Roles rol;
        private Usuarios usuario;
        private Auditorias entidad;

        public Auditorias_Test()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datos_Generales.ObtenerStringConexion();
        }

        [TestMethod]
        public void Ejecutar()
        {
            Insertar();
            Consultar();
            Borrar();
        }

        private void Insertar()
        {
            rol = new Roles() { Nombre = "Rol auditorias prueba", Descripcion = "Prueba" };
            this.conexion.Roles!.Add(this.rol);
            this.conexion.SaveChanges();

            usuario = new Usuarios()
            {
                NombreUsuario = "usuario_auditoria",
                Contrasena = "hash_de_prueba",
                Rol = this.rol.Id
            };
            this.conexion.Usuarios!.Add(this.usuario);
            this.conexion.SaveChanges();

            entidad = new Auditorias()
            {
                Usuario = this.usuario.Id,
                Accion = "Insertar",
                Entidad = "Productos",
                Detalle = "Registro de prueba",
                Fecha = DateTime.Now
            };
            this.conexion.Auditorias!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Auditorias!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Borrar()
        {
            this.conexion.Auditorias!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Usuarios!.Remove(this.usuario!);
            this.conexion.SaveChanges();

            this.conexion.Roles!.Remove(this.rol!);
            this.conexion.SaveChanges();
        }
    }
}