using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Metodos_Pagos/[action]")]
    public class Metodos_Pagos_Controller : ControllerBase
    {
        private IMetodos_Pagos_Aplicacion IMetodos_PagosAplicacion;

        public Metodos_Pagos_Controller(IMetodos_Pagos_Aplicacion IMetodos_PagosAplicacion)
        {
            this.IMetodos_PagosAplicacion = IMetodos_PagosAplicacion;
        }

        [HttpPost]
        public List<Metodos_Pagos> Consultar()
        {
            return this.IMetodos_PagosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Metodos_Pagos> Buscar(Metodos_Pagos entidad)
        {
            return this.IMetodos_PagosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Metodos_Pagos Insertar(Metodos_Pagos entidad)
        {
            return this.IMetodos_PagosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Metodos_Pagos Actualizar(Metodos_Pagos entidad)
        {
            return this.IMetodos_PagosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Metodos_Pagos Borrar(Metodos_Pagos entidad)
        {
            return this.IMetodos_PagosAplicacion.Borrar(entidad);
        }
    }
}
