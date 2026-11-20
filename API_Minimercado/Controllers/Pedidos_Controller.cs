using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Pedidos_Controller : ControllerBase
    {
        private IPedidos_Aplicacion IPedidosAplicacion;

        public Pedidos_Controller(IPedidos_Aplicacion IPedidosAplicacion)
        {
            this.IPedidosAplicacion = IPedidosAplicacion;
        }

        [HttpPost]
        public List<Pedidos> Consultar()
        {
            return this.IPedidosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Pedidos> Buscar(Pedidos entidad)
        {
            return this.IPedidosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Pedidos Insertar(Pedidos entidad)
        {
            return this.IPedidosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Pedidos Actualizar(Pedidos entidad)
        {
            return this.IPedidosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Pedidos Borrar(Pedidos entidad)
        {
            return this.IPedidosAplicacion.Borrar(entidad);
        }
    }
}
