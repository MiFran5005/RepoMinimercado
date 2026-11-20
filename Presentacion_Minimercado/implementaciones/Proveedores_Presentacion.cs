using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Proveedores_Presentacion : IProveedores_Presentacion
    {

            private IComunicaciones IComunicaciones;

            public Proveedores_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Proveedores Actualizar(Proveedores entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Proveedores>(
                    "Proveedores/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Proveedores Borrar(Proveedores entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Proveedores>(
                    "Proveedores/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Proveedores> Buscar(Proveedores entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Proveedores>>(
                    "Proveedores/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Proveedores> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Proveedores>>(
                    "Proveedores/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Proveedores Insertar(Proveedores entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Proveedores>(
                    "Proveedores/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Proveedores entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                string.IsNullOrEmpty(entidad.Telefono);
        }
    }
}
