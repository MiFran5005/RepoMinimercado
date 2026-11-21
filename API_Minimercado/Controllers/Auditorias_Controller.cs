using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Auditorias/[action]")]
    public class Auditorias_Controller : ControllerBase
    {
        private IAuditorias_Aplicacion IAuditoriasAplicacion;

        public Auditorias_Controller(IAuditorias_Aplicacion IAuditoriasAplicacion)
        {
            this.IAuditoriasAplicacion = IAuditoriasAplicacion;
        }

        [HttpPost]
        public List<Auditorias> Consultar()
        {
            return this.IAuditoriasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Auditorias Insertar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Insertar(entidad);
        }
    }
}
