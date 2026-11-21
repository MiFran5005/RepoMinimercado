using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Horarios/[action]")]
    public class Horarios_Controller : ControllerBase
    {
        private IHorarios_Aplicacion IHorariosAplicacion;

        public Horarios_Controller(IHorarios_Aplicacion IHorariosAplicacion)
        {
            this.IHorariosAplicacion = IHorariosAplicacion;
        }

        [HttpPost]
        public List<Horarios> Consultar()
        {
            return this.IHorariosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Horarios> Buscar(Horarios entidad)
        {
            return this.IHorariosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Horarios Insertar(Horarios entidad)
        {
            return this.IHorariosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Horarios Actualizar(Horarios entidad)
        {
            return this.IHorariosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Horarios Borrar(Horarios entidad)
        {
            return this.IHorariosAplicacion.Borrar(entidad);
        }
    }
}
