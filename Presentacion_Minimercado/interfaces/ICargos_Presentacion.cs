using Lib_Minimercado.entidades;


namespace Presentacion_Minimercado.implementaciones
{
    public interface ICargos_Presentacion
    {
        Cargos Insertar (Cargos entidad);
        List<Cargos> Consultar ();
        Cargos Actualizar (Cargos entidad);
        Cargos Borrar (Cargos entidad);
        List<Cargos> Buscar(Cargos entidad);
    }
}
