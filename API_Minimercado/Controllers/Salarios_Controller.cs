using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Salarios_Controller : ControllerBase
    {
        private ISalarios_Aplicacion ISalariosAplicacion;

        public Salarios_Controller(ISalarios_Aplicacion ISalariosAplicacion)
        {
            this.ISalariosAplicacion = ISalariosAplicacion;
        }

        [HttpPost]
        public List<Salarios> Consultar()
        {
            return this.ISalariosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Salarios> Buscar(Salarios entidad)
        {
            return this.ISalariosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Salarios Insertar(Salarios entidad)
        {
            return this.ISalariosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Salarios Actualizar(Salarios entidad)
        {
            return this.ISalariosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Salarios Borrar(Salarios entidad)
        {
            return this.ISalariosAplicacion.Borrar(entidad);
        }
    }
}
