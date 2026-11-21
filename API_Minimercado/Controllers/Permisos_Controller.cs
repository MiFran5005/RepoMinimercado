using Lib_Minimercado.entidades;
using Lib_Minimercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("Permisos/[action]")]
    public class Permisos_Controller : ControllerBase
    {
        private IPermisos_Aplicacion IPermisosAplicacion;

        public Permisos_Controller(IPermisos_Aplicacion IPermisosAplicacion)
        {
            this.IPermisosAplicacion = IPermisosAplicacion;
        }

        [HttpPost]
        public List<Permisos> Consultar()
        {
            return this.IPermisosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Permisos Insertar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Permisos Actualizar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Permisos Borrar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Borrar(entidad);
        }
    }
}
