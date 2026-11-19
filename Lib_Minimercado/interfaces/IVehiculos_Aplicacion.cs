using Lib_Minimercado.entidades;

namespace Lib_Minimercado.implementaciones
{
    public interface IVehiculos_Aplicacion
    {
        Vehiculos Insertar(Vehiculos entidad);
        List<Vehiculos> Consultar();
        Vehiculos Actualizar(Vehiculos entidad);
        Vehiculos Borrar(Vehiculos entidad);
        List<Vehiculos> Buscar(Vehiculos entidad);
    }
}
