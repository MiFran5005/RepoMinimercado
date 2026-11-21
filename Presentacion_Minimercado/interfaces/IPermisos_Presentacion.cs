using Lib_Minimercado.entidades;

namespace Presentacion_Minimercado.interfaces
{
    public interface IPermisos_Presentacion
    {
        Permisos Actualizar(Permisos entidad);
        Permisos Borrar(Permisos entidad);
        List<Permisos> Buscar(Permisos entidad);
        List<Permisos> Consultar();
        Permisos Insertar(Permisos entidad);
    }
}