using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Cargos/[action]")]
    public class Cargos_Controller : ControllerBase
    {
        private ICargos_Aplicacion ICargosAplicacion;

        public Cargos_Controller(ICargos_Aplicacion ICargosAplicacion)
        {
            this.ICargosAplicacion = ICargosAplicacion;
        }

        [HttpPost]
        public List<Cargos> Consultar()
        {
            return this.ICargosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Cargos> Buscar(Cargos entidad)
        {
            return this.ICargosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Cargos Insertar(Cargos entidad)
        {
            return this.ICargosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Cargos Actualizar(Cargos entidad)
        {
            return this.ICargosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Cargos Borrar(Cargos entidad)
        {
            return this.ICargosAplicacion.Borrar(entidad);
        }
    }
}
