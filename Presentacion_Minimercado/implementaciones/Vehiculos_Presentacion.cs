using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;

namespace Presentacion_Minimercado.implementaciones
{
    public class Vehiculos_Presentacion : IVehiculos_Presentacion
    {
       
            private IComunicaciones IComunicaciones;

            public Vehiculos_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Vehiculos Actualizar(Vehiculos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Vehiculos>(
                    "Vehiculos/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Vehiculos Borrar(Vehiculos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Vehiculos>(
                    "Vehiculos/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Vehiculos> Buscar(Vehiculos entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Vehiculos>>(
                    "Vehiculos/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Vehiculos> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Vehiculos>>(
                    "Vehiculos/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Vehiculos Insertar(Vehiculos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Vehiculos>(
                    "Vehiculos/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Vehiculos entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Placa) ||
                string.IsNullOrEmpty(entidad.Tipo);
        }
    }
}
