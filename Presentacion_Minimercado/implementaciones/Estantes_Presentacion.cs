using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Estantes_Presentacion : IEstantes_Presentacion
    {
        
            private IComunicaciones IComunicaciones;

            public Estantes_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Estantes Actualizar(Estantes entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Estantes>(
                    "Estantes/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Estantes Borrar(Estantes entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Estantes>(
                    "Estantes/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Estantes> Buscar(Estantes entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Estantes>>(
                    "Estantes/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Estantes> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Estantes>>(
                    "Estantes/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Estantes Insertar(Estantes entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Estantes>(
                    "Estantes/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Estantes entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Capacidad <= 0 ||
                string.IsNullOrEmpty(entidad.Ubicacion);
        }
    }
}
