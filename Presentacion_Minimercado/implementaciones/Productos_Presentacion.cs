using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Productos_Presentacion : IProductos_Presentacion
    {
            private IComunicaciones IComunicaciones;

            public Productos_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Productos Actualizar(Productos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

               

            if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Productos>(
                    "Productos/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Productos Borrar(Productos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Productos>(
                    "Productos/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Productos> Buscar(Productos entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                    "Productos/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Productos> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                    "Productos/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Productos Insertar(Productos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Productos>(
                    "Productos/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Productos entidad)
        {
            return entidad.Codigo <= 0 ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Precio <= 0 ||
                entidad.IVA <= 0 ||
                entidad.Proveedor <= 0 ||
                entidad.Estante <= 0 ||
                entidad.Inventario <= 0 ||
                entidad.Inventario <= 0 ||
                entidad.Categoria <= 0;
        }
    }
}
