using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Auditorias_Presentacion : IAuditorias_Presentacion
    {
        private IComunicaciones IComunicaciones;

        public Auditorias_Presentacion(IComunicaciones Comunicaciones)
        {
            this.IComunicaciones = Comunicaciones;
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Auditorias>>(
                "Auditorias/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Auditorias> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Auditorias>>(
                "Auditorias/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Auditorias>(
                "Auditorias/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Auditorias entidad)
        {
            return entidad.Usuario <= 0 ||
                   string.IsNullOrEmpty(entidad.Accion) ||
                   string.IsNullOrEmpty(entidad.Entidad);
        }
    }
}