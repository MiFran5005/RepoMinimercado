using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Roles/[action]")]
    public class Roles_Controller : ControllerBase
    {
        private IRoles_Aplicacion IRolesAplicacion;

        public Roles_Controller(IRoles_Aplicacion IRolesAplicacion)
        {
            this.IRolesAplicacion = IRolesAplicacion;
        }

        [HttpPost]
        public List<Roles> Consultar()
        {
            return this.IRolesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Roles> Buscar(Roles entidad)
        {
            return this.IRolesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Roles Insertar(Roles entidad)
        {
            return this.IRolesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Roles Actualizar(Roles entidad)
        {
            return this.IRolesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Roles Borrar(Roles entidad)
        {
            return this.IRolesAplicacion.Borrar(entidad);
        }
    }
}
