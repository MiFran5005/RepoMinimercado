using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Contratos/[action]")]
    public class Contratos_Controller : ControllerBase
    {
        private IContratos_Aplicacion IContratosAplicacion;

        public Contratos_Controller(IContratos_Aplicacion IContratosAplicacion)
        {
            this.IContratosAplicacion = IContratosAplicacion;
        }

        [HttpPost]
        public List<Contratos> Consultar()
        {
            return this.IContratosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Contratos> Buscar(Contratos entidad)
        {
            return this.IContratosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Contratos Insertar(Contratos entidad)
        {
            return this.IContratosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Contratos Actualizar(Contratos entidad)
        {
            return this.IContratosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Contratos Borrar(Contratos entidad)
        {
            return this.IContratosAplicacion.Borrar(entidad);
        }
    }
}
