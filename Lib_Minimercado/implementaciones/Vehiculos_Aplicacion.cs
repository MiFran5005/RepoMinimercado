using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Minimercado.implementaciones
{
    public class Vehiculos_Aplicacion : IVehiculos_Aplicacion
    {
        private IConexion conexion;

        public Vehiculos_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Vehiculos Actualizar(Vehiculos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Vehiculos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Vehiculos Borrar(Vehiculos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Vehiculos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Vehiculos> Buscar(Vehiculos entidad)
        {
            return this.conexion.Vehiculos!
                .Where(x => x.Placa!.Contains(entidad.Placa!))
                .ToList();
        }
        public List<Vehiculos> Consultar()
        {
            return this.conexion.Vehiculos!
                .ToList();
        }

        public Vehiculos Insertar(Vehiculos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Vehiculos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Vehiculos entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Placa) ||
                string.IsNullOrEmpty(entidad.Tipo);
        }
    }
}
