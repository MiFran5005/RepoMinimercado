using Lib_Minimercado.entidades;

namespace Presentacion_Minimercado.interfaces
{
    public interface IAuditorias_Presentacion
    {
        List<Auditorias> Buscar(Auditorias entidad);
        List<Auditorias> Consultar();
        Auditorias Insertar(Auditorias entidad);
    }
}