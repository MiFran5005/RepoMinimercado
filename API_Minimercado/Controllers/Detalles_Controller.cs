using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Detalles/[action]")]
    public class Detalles_Controller : ControllerBase
    {
        private IDetalles_Aplicacion IDetallesAplicacion;

        public Detalles_Controller(IDetalles_Aplicacion IDetallesAplicacion)
        {
            this.IDetallesAplicacion = IDetallesAplicacion;
        }

        [HttpPost]
        public List<Detalles> Consultar()
        {
            return this.IDetallesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Detalles> Buscar(Detalles entidad)
        {
            return this.IDetallesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Detalles Insertar(Detalles entidad)
        {
            return this.IDetallesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Detalles Actualizar(Detalles entidad)
        {
            return this.IDetallesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Detalles Borrar(Detalles entidad)
        {
            return this.IDetallesAplicacion.Borrar(entidad);
        }
    }
}
