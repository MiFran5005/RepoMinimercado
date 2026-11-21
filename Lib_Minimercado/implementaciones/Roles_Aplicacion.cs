using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Minimercado.implementaciones
{
    public class Roles_Aplicacion : IRoles_Aplicacion
    {
        private IConexion? conexion;

        public Roles_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Roles> Consultar()
        {
            return this.conexion!.Roles!.ToList();
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.conexion!.Roles!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            this.conexion!.Roles!.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var entry = this.conexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.conexion!.Roles!.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
