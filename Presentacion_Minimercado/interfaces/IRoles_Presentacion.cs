using Lib_Minimercado.entidades;

namespace Presentacion_Minimercado.interfaces
{
    public interface IRoles_Presentacion
    {
        Roles Actualizar(Roles entidad);
        Roles Borrar(Roles entidad);
        List<Roles> Buscar(Roles entidad);
        List<Roles> Consultar();
        Roles Insertar(Roles entidad);
    }
}
