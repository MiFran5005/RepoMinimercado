using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Facturas_Presentacion : IFacturas_Presentacion
    {
  
            private IComunicaciones IComunicaciones;

            public Facturas_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Facturas Actualizar(Facturas entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Facturas>(
                    "Facturas/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Facturas Borrar(Facturas entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Facturas>(
                    "Facturas/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Facturas> Buscar(Facturas entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Facturas>>(
                    "Facturas/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Facturas> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Facturas>>(
                    "Facturas/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Facturas Insertar(Facturas entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Facturas>(
                    "Facturas/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Facturas entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Total <= 0 ||
                entidad.Fecha == null ||
                entidad.Empleado <= 0;
        }
    }
}
