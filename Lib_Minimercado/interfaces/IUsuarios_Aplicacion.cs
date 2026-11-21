using Lib_Minimercado.entidades;

namespace Lib_Minimercado.interfaces
{
    public interface IUsuarios_Aplicacion
    {
        List<Usuarios> Consultar();
        List<Usuarios> Buscar(Usuarios entidad);
        Usuarios Insertar(Usuarios entidad);
        Usuarios Actualizar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
        Usuarios Login(Usuarios entidad);
    }
}
