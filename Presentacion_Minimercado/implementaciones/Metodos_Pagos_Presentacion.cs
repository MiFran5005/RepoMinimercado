using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Metodos_Pagos_Presentacion : IMetodos_Pagos_Presentacion
    {
            private IComunicaciones IComunicaciones;

            public Metodos_Pagos_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Metodos_Pagos Actualizar(Metodos_Pagos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Metodos_Pagos>(
                    "Metodos_Pagos/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Metodos_Pagos Borrar(Metodos_Pagos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Metodos_Pagos>(
                    "Metodos_Pagos/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Metodos_Pagos> Buscar(Metodos_Pagos entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Metodos_Pagos>>(
                    "Metodos_Pagos/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Metodos_Pagos> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Metodos_Pagos>>(
                    "Metodos_Pagos/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Metodos_Pagos Insertar(Metodos_Pagos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Metodos_Pagos>(
                    "Metodos_Pagos/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Metodos_Pagos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre);
                
        }
    }
}
