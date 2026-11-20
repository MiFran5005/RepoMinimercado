using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Pedidos_Presentacion : IPedidos_Presentacion
    {
      
            private IComunicaciones IComunicaciones;

            public Pedidos_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Pedidos Actualizar(Pedidos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Pedidos>(
                    "Pedidos/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Pedidos Borrar(Pedidos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Pedidos>(
                    "Pedidos/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Pedidos> Buscar(Pedidos entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Pedidos>>(
                    "Pedidos/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Pedidos> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Pedidos>>(
                    "Pedidos/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Pedidos Insertar(Pedidos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Pedidos>(
                    "Pedidos/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Pedidos entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Total <= 0 ||
                entidad.Empleado <= 0 ||
                entidad.Proveedor <= 0 ||
                entidad.Fecha == null;
        }

    }
}
