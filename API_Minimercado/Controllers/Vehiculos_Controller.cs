using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Vehiculos/[action]")]
    public class Vehiculos_Controller : ControllerBase
    {
        private IVehiculos_Aplicacion IVehiculosAplicacion;

        public Vehiculos_Controller(IVehiculos_Aplicacion IVehiculosAplicacion)
        {
            this.IVehiculosAplicacion = IVehiculosAplicacion;
        }

        [HttpPost]
        public List<Vehiculos> Consultar()
        {
            return this.IVehiculosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Vehiculos> Buscar(Vehiculos entidad)
        {
            return this.IVehiculosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Vehiculos Insertar(Vehiculos entidad)
        {
            return this.IVehiculosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Vehiculos Actualizar(Vehiculos entidad)
        {
            return this.IVehiculosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Vehiculos Borrar(Vehiculos entidad)
        {
            return this.IVehiculosAplicacion.Borrar(entidad);
        }
    }
}
