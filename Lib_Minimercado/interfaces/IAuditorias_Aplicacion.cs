using Lib_Minimercado.entidades;

namespace Lib_Minimercado.interfaces
{
    public interface IAuditorias_Aplicacion
    {
        List<Auditorias> Consultar();
        List<Auditorias> Buscar(Auditorias entidad);
        Auditorias Insertar(Auditorias entidad);
    }
}