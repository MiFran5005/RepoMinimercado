using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Lib_Minimercado.implementaciones
{
    public class Usuarios_Aplicacion : IUsuarios_Aplicacion
    {
        private IConexion? conexion;

        public Usuarios_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        private static string Hash(string texto)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
            return Convert.ToHexString(bytes);
        }

        public List<Usuarios> Consultar()
        {
            var lista = this.conexion!.Usuarios!.ToList();
            lista.ForEach(x => x.Contrasena = null);   
            return lista;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            var lista = this.conexion!.Usuarios!
                .Include(x => x._Rol)
                .Include(x => x._Empleado)
                .Include(x => x._Cliente)
                .Where(x => x.NombreUsuario!.Contains(entidad.NombreUsuario!))
                .ToList();
            lista.ForEach(x => x.Contrasena = null);
            return lista;
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            entidad.Contrasena = Hash(entidad.Contrasena!);
            this.conexion!.Usuarios!.Add(entidad);
            this.conexion.SaveChanges();
            entidad.Contrasena = null;
            return entidad;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

           
            if (string.IsNullOrEmpty(entidad.Contrasena))
                entidad.Contrasena = this.conexion!.Usuarios!
                    .First(x => x.Id == entidad.Id).Contrasena;
            else
                entidad.Contrasena = Hash(entidad.Contrasena);

            var entry = this.conexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
            entidad.Contrasena = null;
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.conexion!.Usuarios!.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public Usuarios Login(Usuarios entidad)
        {
            var hash = Hash(entidad.Contrasena ?? "");

            var usuario = this.conexion!.Usuarios!
                .FirstOrDefault(x => x.NombreUsuario == entidad.NombreUsuario
                                  && x.Contrasena == hash);

            if (usuario == null)
                return new Usuarios();


            var rol = this.conexion.Roles!.First(x => x.Id == usuario.Rol);
            usuario._Rol = new Roles { Id = rol.Id, Nombre = rol.Nombre };
            usuario.Contrasena = null;
            return usuario;
        }
    }
}