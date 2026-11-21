using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Roles_Presentacion : IRoles_Presentacion
    {
        private IComunicaciones IComunicaciones;

        public Roles_Presentacion(IComunicaciones Comunicaciones)
        {
            this.IComunicaciones = Comunicaciones;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Roles/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Roles/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
