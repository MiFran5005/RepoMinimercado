using Lib_Minimercado.entidades;
using Presentacion_Minimercado.interfaces;


namespace Presentacion_Minimercado.implementaciones
{
    public class Marcas_Presentacion : IMarcas_Presentacion
    {
       
            private IComunicaciones IComunicaciones;

            public Marcas_Presentacion(IComunicaciones Comunicaciones)
            {
                this.IComunicaciones = Comunicaciones;
            }

            public Marcas Actualizar(Marcas entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Marcas>(
                    "Marcas/Actualizar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public Marcas Borrar(Marcas entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se ha guardo");

                var task = this.IComunicaciones.Ejecutar<Marcas>(
                    "Marcas/Borrar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Marcas> Buscar(Marcas entidad)
            {
                var task = this.IComunicaciones.Ejecutar<List<Marcas>>(
                    "Marcas/Buscar",
                    entidad);
                task.Wait();
                return task.Result;
            }

            public List<Marcas> Consultar()
            {
                var task = this.IComunicaciones.Ejecutar<List<Marcas>>(
                    "Marcas/Consultar",
                    null);
                task.Wait();
                return task.Result;
            }

            public Marcas Insertar(Marcas entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                if (Validar(entidad))
                    throw new Exception("Falta informacion");

                var task = this.IComunicaciones.Ejecutar<Marcas>(
                    "Marcas/Insertar",
                    entidad);
                task.Wait();
                return task.Result;
            }
            private bool Validar(Marcas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
