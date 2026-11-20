using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Estados_Controller : ControllerBase
    {
        private IEstados_Aplicacion IEstadosAplicacion;

        public Estados_Controller(IEstados_Aplicacion IEstadosAplicacion)
        {
            this.IEstadosAplicacion = IEstadosAplicacion;
        }

        [HttpPost]
        public List<Estados> Consultar()
        {
            return this.IEstadosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Estados> Buscar(Estados entidad)
        {
            return this.IEstadosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Estados Insertar(Estados entidad)
        {
            return this.IEstadosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Estados Actualizar(Estados entidad)
        {
            return this.IEstadosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Estados Borrar(Estados entidad)
        {
            return this.IEstadosAplicacion.Borrar(entidad);
        }
    }
}
