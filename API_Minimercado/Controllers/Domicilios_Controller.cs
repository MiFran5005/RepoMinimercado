using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Domicilios/[action]")]
    public class Domicilios_Controller : ControllerBase
    {
        private IDomicilios_Aplicacion IDomiciliosAplicacion;

        public Domicilios_Controller(IDomicilios_Aplicacion IDomiciliosAplicacion)
        {
            this.IDomiciliosAplicacion = IDomiciliosAplicacion;
        }

        [HttpPost]
        public List<Domicilios> Consultar()
        {
            return this.IDomiciliosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Domicilios> Buscar(Domicilios entidad)
        {
            return this.IDomiciliosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Domicilios Insertar(Domicilios entidad)
        {
            return this.IDomiciliosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Domicilios Actualizar(Domicilios entidad)
        {
            return this.IDomiciliosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Domicilios Borrar(Domicilios entidad)
        {
            return this.IDomiciliosAplicacion.Borrar(entidad);
        }
    }
}
