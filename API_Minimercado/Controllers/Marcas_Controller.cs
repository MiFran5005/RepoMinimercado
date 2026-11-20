using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Marcas_Controller : ControllerBase
    {
        private IMarcas_Aplicacion IMarcasAplicacion;

        public Marcas_Controller(IMarcas_Aplicacion IMarcasAplicacion)
        {
            this.IMarcasAplicacion = IMarcasAplicacion;
        }

        [HttpPost]
        public List<Marcas> Consultar()
        {
            return this.IMarcasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Marcas> Buscar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Marcas Insertar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Marcas Actualizar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Marcas Borrar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Borrar(entidad);
        }
    }
}
