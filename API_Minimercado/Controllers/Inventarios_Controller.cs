using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Inventarios_Controller : ControllerBase
    {
        private IInventarios_Aplicacion IInventariosAplicacion;

        public Inventarios_Controller(IInventarios_Aplicacion IInventariosAplicacion)
        {
            this.IInventariosAplicacion = IInventariosAplicacion;
        }

        [HttpPost]
        public List<Inventarios> Consultar()
        {
            return this.IInventariosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Inventarios> Buscar(Inventarios entidad)
        {
            return this.IInventariosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Inventarios Insertar(Inventarios entidad)
        {
            return this.IInventariosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Inventarios Actualizar(Inventarios entidad)
        {
            return this.IInventariosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Inventarios Borrar(Inventarios entidad)
        {
            return this.IInventariosAplicacion.Borrar(entidad);
        }
    }
}
