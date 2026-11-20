using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Estantes_Controller : ControllerBase
    {
        private IEstantes_Aplicacion IEstantesAplicacion;

        public Estantes_Controller(IEstantes_Aplicacion IEstantesAplicacion)
        {
            this.IEstantesAplicacion = IEstantesAplicacion;
        }

        [HttpPost]
        public List<Estantes> Consultar()
        {
            return this.IEstantesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Estantes> Buscar(Estantes entidad)
        {
            return this.IEstantesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Estantes Insertar(Estantes entidad)
        {
            return this.IEstantesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Estantes Actualizar(Estantes entidad)
        {
            return this.IEstantesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Estantes Borrar(Estantes entidad)
        {
            return this.IEstantesAplicacion.Borrar(entidad);
        }
    }
}
