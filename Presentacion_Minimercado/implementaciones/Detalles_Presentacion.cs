using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Detalles_Presentacion : IDetalles_Presentacion
    {
            private IComunicaciones IComunicaciones;

            public Detalles_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Detalles Actualizar(Detalles entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Detalles>(
                    "Detalles/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Detalles Borrar(Detalles entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Detalles>(
                    "Detalles/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Detalles> Buscar(Detalles entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Detalles>>(
                    "Detalles/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Detalles> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Detalles>>(
                    "Detalles/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Detalles Insertar(Detalles entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Detalles>(
                    "Detalles/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Detalles entidad)
        {
            return entidad.Factura <= 0 ||
                entidad.Producto <= 0 ||
                entidad.Cliente <= 0 ||
                entidad.Domicilio <= 0 ||
                entidad.Estado <= 0 ||
                entidad.Metodo_Pago <= 0;
        }
    }
}
