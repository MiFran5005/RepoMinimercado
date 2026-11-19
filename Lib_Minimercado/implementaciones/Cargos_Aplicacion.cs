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
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Cargos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Cargos> Buscar(Cargos entidad)
        {
            return this.conexion.Cargos!
                .Where(x => x.TipoEmpleado!.Contains(entidad.TipoEmpleado!))
                .ToList();
        }
        public List<Cargos> Consultar()
        {
            return this.conexion.Cargos!
                .ToList();
        }

        public Cargos Insertar(Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Cargos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Cargos entidad)
        {
            return string.IsNullOrEmpty(entidad.TipoEmpleado) ||
                entidad.Salario <= 0 ||
                entidad.Horario <= 0 ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
