using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Inventarios_Presentacion : IInventarios_Aplicacion
    {
            private IComunicaciones IComunicaciones;

            public Inventarios_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Inventarios Actualizar(Inventarios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Inventarios>(
                    "Inventarios/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Inventarios Borrar(Inventarios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Inventarios>(
                    "Inventarios/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Inventarios> Buscar(Inventarios entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Inventarios>>(
                    "Inventarios/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Inventarios> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Inventarios>>(
                    "Inventarios/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Inventarios Insertar(Inventarios entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Inventarios>(
                    "Inventarios/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Inventarios entidad)
        {
            return entidad.Cantidad <= 0 ||
                string.IsNullOrEmpty(entidad.Actualizacion)||
                entidad.Minimo <= 0 ||
                entidad.Maximo <= 0;
        }
    }
}
