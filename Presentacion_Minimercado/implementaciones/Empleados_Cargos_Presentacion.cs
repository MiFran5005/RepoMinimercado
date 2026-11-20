using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Empleados_Cargos_Presentacion : IEmpleados_Cargos_Aplicacion
    {
       
            private IComunicaciones IComunicaciones;

            public Empleados_Cargos_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Empleados_Cargos Actualizar(Empleados_Cargos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Empleados_Cargos>(
                    "Empleados_Cargos/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Empleados_Cargos Borrar(Empleados_Cargos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Empleados_Cargos>(
                    "Empleados_Cargos/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Empleados_Cargos> Buscar(Empleados_Cargos entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Empleados_Cargos>>(
                    "Empleados_Cargos/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Empleados_Cargos> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Empleados_Cargos>>(
                    "Empleados_Cargos/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Empleados_Cargos Insertar(Empleados_Cargos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Empleados_Cargos>(
                    "Empleados_Cargos/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Empleados_Cargos entidad)
        {
            return (entidad.Cargo <= 0) ||
               (entidad.Empleado <= 0) ||
               (entidad.Contrato <= 0) ||
               (entidad.FechaAsignacion == null);
        }
    }
}
