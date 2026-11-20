using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Salarios_Presentacion : ISalarios_Presentacion
    {

            private IComunicaciones IComunicaciones;

            public Salarios_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Salarios Actualizar(Salarios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Salarios>(
                    "Salarios/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Salarios Borrar(Salarios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Salarios>(
                    "Salarios/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Salarios> Buscar(Salarios entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Salarios>>(
                    "Salarios/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Salarios> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Salarios>>(
                    "Salarios/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Salarios Insertar(Salarios entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Salarios>(
                    "Salarios/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Salarios entidad)
        {
            return entidad.Valor <= 0;
                
        }
    }
}
