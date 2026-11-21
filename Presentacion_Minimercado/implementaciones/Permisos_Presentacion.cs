using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Permisos_Presentacion : IPermisos_Presentacion
    {
        private IComunicaciones IComunicaciones;

        public Permisos_Presentacion(IComunicaciones Comunicaciones)
        {
            this.IComunicaciones = Comunicaciones;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Permisos>>(
                "Permisos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Permisos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Permisos>>(
                "Permisos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Permisos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Descripcion) ||
                   entidad.Rol <= 0;
        }
    }
}