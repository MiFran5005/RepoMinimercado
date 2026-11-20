using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Empleados_Controller : ControllerBase
    {
        private IEmpleados_Aplicacion IEmpleadosAplicacion;

        public Empleados_Controller(IEmpleados_Aplicacion IEmpleadosAplicacion)
        {
            this.IEmpleadosAplicacion = IEmpleadosAplicacion;
        }

        [HttpPost]
        public List<Empleados> Consultar()
        {
            return this.IEmpleadosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Empleados> Buscar(Empleados entidad)
        {
            return this.IEmpleadosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Empleados Insertar(Empleados entidad)
        {
            return this.IEmpleadosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Empleados Actualizar(Empleados entidad)
        {
            return this.IEmpleadosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Empleados Borrar(Empleados entidad)
        {
            return this.IEmpleadosAplicacion.Borrar(entidad);
        }
    }
}
