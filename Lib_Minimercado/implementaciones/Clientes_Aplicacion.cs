using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.EntityFrameworkCore;
namespace Lib_Minimercado.implementaciones
{
    public class Clientes_Aplicacion : IClientes_Aplicacion
    {
        private IConexion conexion;

        public Clientes_Aplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");
            this.conexion.Clientes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Clientes> Buscar(Clientes entidad)
        {
            return this.conexion.Clientes!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }
        public List<Clientes> Consultar()
        {
            return this.conexion.Clientes!
                .ToList();
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Clientes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        private bool Validar(Clientes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Cedula) ||
                string.IsNullOrEmpty(entidad.Telefono);
        }
    }
}
