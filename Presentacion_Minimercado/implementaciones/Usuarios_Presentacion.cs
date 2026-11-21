using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Usuarios_Presentacion : IUsuarios_Presentacion
    {
        private IComunicaciones IComunicaciones;

        public Usuarios_Presentacion(IComunicaciones Comunicaciones)
        {
            this.IComunicaciones = Comunicaciones;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

           
            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Usuarios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Usuarios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Usuarios>>(
                "Usuarios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Usuarios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Usuarios>>(
                "Usuarios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");


            if (Validar(entidad) || string.IsNullOrEmpty(entidad.Contrasena))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Usuarios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Usuarios Login(Usuarios entidad)
        {
            if (string.IsNullOrEmpty(entidad.NombreUsuario) ||
                string.IsNullOrEmpty(entidad.Contrasena))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Usuarios/Login",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Usuarios entidad)
        {
            return string.IsNullOrEmpty(entidad.NombreUsuario) ||
                   entidad.Rol <= 0;
        }
    }
}