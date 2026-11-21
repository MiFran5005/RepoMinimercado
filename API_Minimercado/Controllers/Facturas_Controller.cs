using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Facturas/[action]")]
    public class Facturas_Controller : ControllerBase
    {
        private IFacturas_Aplicacion IFacturasAplicacion;

        public Facturas_Controller(IFacturas_Aplicacion IFacturasAplicacion)
        {
            this.IFacturasAplicacion = IFacturasAplicacion;
        }

        [HttpPost]
        public List<Facturas> Consultar()
        {
            return this.IFacturasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Facturas Insertar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Facturas Actualizar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Facturas Borrar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Borrar(entidad);
        }
    }
}
