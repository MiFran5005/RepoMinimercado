using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Horarios_Presentacion : IHorarios_Presentacion
    {
            private IComunicaciones IComunicaciones;

            public Horarios_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Horarios Actualizar(Horarios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Horarios>(
                    "Horarios/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Horarios Borrar(Horarios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Horarios>(
                    "Horarios/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Horarios> Buscar(Horarios entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Horarios>>(
                    "Horarios/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Horarios> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Horarios>>(
                    "Horarios/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Horarios Insertar(Horarios entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Horarios>(
                    "Horarios/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Horarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Turno) ||
                entidad.HoraInicio == null ||
                entidad.HoraFinal == null;
        }
    }
}
