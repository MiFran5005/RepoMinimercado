using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
namespace Lib_Minimercado.implementaciones
{
    public class Cargos_Aplicacion : ICargos_Aplicacion
    {
        private IConexion conexion;

        public Cargos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Cargos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Cargos> Consultar()
        {
            return this.conexion.Cargos!
                .ToList();
        }

        public Cargos Insertar(Cargos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Cargos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
