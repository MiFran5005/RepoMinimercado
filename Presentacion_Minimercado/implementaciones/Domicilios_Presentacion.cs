using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Domicilios_Presentacion : IDomicilios_Presentacion
    {

            private IComunicaciones IComunicaciones;

            public Domicilios_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Domicilios Actualizar(Domicilios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Domicilios>(
                    "Domicilios/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Domicilios Borrar(Domicilios entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Domicilios>(
                    "Domicilios/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Domicilios> Buscar(Domicilios entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Domicilios>>(
                    "Domicilios/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Domicilios> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Domicilios>>(
                    "Domicilios/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Domicilios Insertar(Domicilios entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Domicilios>(
                    "Domicilios/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Domicilios entidad)
        {
            return entidad.Empleado <= 0 ||
                entidad.Vehiculo <= 0 ||
                entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
