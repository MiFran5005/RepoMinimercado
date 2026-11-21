using Lib_Minimercado.entidades;

namespace Presentacion_Minimercado.interfaces
{
    public interface IUsuarios_Presentacion
    {
        Usuarios Actualizar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
        List<Usuarios> Buscar(Usuarios entidad);
        List<Usuarios> Consultar();
        Usuarios Insertar(Usuarios entidad);
        Usuarios Login(Usuarios entidad);
    }
}