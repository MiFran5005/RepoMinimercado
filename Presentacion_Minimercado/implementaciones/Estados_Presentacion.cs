using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Estados_Presentacion : IEstados_Presentacion
    {
            private IComunicaciones IComunicaciones;

            public Estados_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Estados Actualizar(Estados entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Estados>(
                    "Estados/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Estados Borrar(Estados entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Estados>(
                    "Estados/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Estados> Buscar(Estados entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Estados>>(
                    "Estados/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Estados> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Estados>>(
                    "Estados/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Estados Insertar(Estados entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Estados>(
                    "Estados/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Estados entidad)
        {
            return string.IsNullOrEmpty(entidad.TipoEstado) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
