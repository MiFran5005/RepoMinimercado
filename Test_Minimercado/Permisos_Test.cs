using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Permisos_Test
    {
        private Conexion conexion;
        private Roles rol;
        private Permisos entidad;

        public Permisos_Test()
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
            rol = new Roles() { Nombre = "Rol permisos prueba", Descripcion = "Prueba" };
            this.conexion.Roles!.Add(this.rol);
            this.conexion.SaveChanges();

            entidad = new Permisos()
            {
                Nombre = "VerSalarios",
                Descripcion = "Permite ver los salarios",
                Rol = this.rol.Id
            };

            this.conexion.Permisos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Permisos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "BorrarProductos";

            var entry = this.conexion!.Entry<Permisos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Permisos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Roles!.Remove(this.rol!);
            this.conexion.SaveChanges();
        }
    }
}