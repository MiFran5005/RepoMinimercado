using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Contratos_Presentacion : IContratos_Presentacion
    {
       
            private IComunicaciones IComunicaciones;

            public Contratos_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Contratos Actualizar(Contratos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Contratos>(
                    "Contratos/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Contratos Borrar(Contratos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Contratos>(
                    "Contratos/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Contratos> Buscar(Contratos entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Contratos>>(
                    "Contratos/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Contratos> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Contratos>>(
                    "Contratos/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Contratos Insertar(Contratos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Contratos>(
                    "Contratos/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Contratos entidad)
        {
            return entidad.FechaInicio == null ||
                entidad.FechaFin == null ||
                string.IsNullOrEmpty(entidad.TipoContrato) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
