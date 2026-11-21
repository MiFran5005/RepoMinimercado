using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;

namespace Lib_Minimercado.implementaciones
{
    public class Auditorias_Aplicacion : IAuditorias_Aplicacion
    {
        private IConexion? conexion;

        public Auditorias_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Auditorias> Consultar()
        {
            return this.conexion!.Auditorias!
                .OrderByDescending(x => x.Fecha)
                .ToList();
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.conexion!.Auditorias!
                .Where(x => x.Accion!.Contains(entidad.Accion!)
                         && x.Entidad!.Contains(entidad.Entidad!))
                .OrderByDescending(x => x.Fecha)
                .ToList();
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            entidad.Fecha = DateTime.Now;
            this.conexion!.Auditorias!.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}