using Lib_Minimercado.entidades;

namespace Lib_Minimercado.interfaces
{
    public interface IRoles_Aplicacion
    {
        List<Roles> Consultar();
        List<Roles> Buscar(Roles entidad);
        Roles Insertar(Roles entidad);
        Roles Actualizar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}