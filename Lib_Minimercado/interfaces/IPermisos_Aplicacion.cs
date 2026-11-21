using Lib_Minimercado.entidades;

namespace Lib_Minimercado.interfaces
{
    public interface IPermisos_Aplicacion
    {
        List<Permisos> Consultar();
        List<Permisos> Buscar(Permisos entidad);
        Permisos Insertar(Permisos entidad);
        Permisos Actualizar(Permisos entidad);
        Permisos Borrar(Permisos entidad);
    }
}
