using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Minimercado.implementaciones
{
    public class Permisos_Aplicacion : IPermisos_Aplicacion
    {
        private IConexion? conexion;

        public Permisos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Permisos> Consultar()
        {
            return this.conexion!.Permisos!.ToList();
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.conexion!.Permisos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            this.conexion!.Permisos!.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var entry = this.conexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.conexion!.Permisos!.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}