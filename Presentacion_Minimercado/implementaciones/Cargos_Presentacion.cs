using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Cargos_Presentacion : ICargos_Presentacion
    {
        private IComunicaciones IComunicaciones;

        public Cargos_Presentacion(IComunicaciones Comunicaciones)
        {
            this.IComunicaciones = Comunicaciones;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cargos Borrar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cargos> Buscar(Cargos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Cargos>>(
                "Cargos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cargos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cargos>>(
                "Cargos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Cargos Insertar(Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }
        private bool Validar(Cargos entidad)
        {
            return string.IsNullOrEmpty(entidad.TipoEmpleado) ||
                entidad.Salario <= 0 ||
                entidad.Horario <= 0 ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
