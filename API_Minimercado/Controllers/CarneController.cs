using Lib_carniceria.entidades;
using Lib_carniceria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_carniceria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarneController : ControllerBase
    {
        private ICarneAplicacion ICarneAplicacion;

        public CarneController(ICarneAplicacion ICarneAplicacion)
        {
            this.ICarneAplicacion = ICarneAplicacion;
        }

        [HttpPost]
        public List<Carne> Consultar()
        {
            return this.ICarneAplicacion.Consultar();
        }

        [HttpPost]
        public List<Carne> Buscar(Carne entidad)
        {
            return this.ICarneAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Carne Insertar(Carne entidad)
        {
            return this.ICarneAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Carne Actualizar(Carne entidad)
        {
            return this.ICarneAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Carne Borrar(Carne entidad)
        {
            return this.ICarneAplicacion.Borrar(entidad);
        }
    }
}
