using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace API_Minimercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Empleados_Cargos_Controller : ControllerBase
    {
        private IEmpleados_Cargos_Aplicacion IEmpleados_CargosAplicacion;

        public Empleados_Cargos_Controller(IEmpleados_Cargos_Aplicacion IEmpleados_CargosAplicacion)
        {
            this.IEmpleados_CargosAplicacion = IEmpleados_CargosAplicacion;
        }

        [HttpPost]
        public List<Empleados_Cargos> Consultar()
        {
            return this.IEmpleados_CargosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Empleados_Cargos> Buscar(Empleados_Cargos entidad)
        {
            return this.IEmpleados_CargosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Empleados_Cargos Insertar(Empleados_Cargos entidad)
        {
            return this.IEmpleados_CargosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Empleados_Cargos Actualizar(Empleados_Cargos entidad)
        {
            return this.IEmpleados_CargosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Empleados_Cargos Borrar(Empleados_Cargos entidad)
        {
            return this.IEmpleados_CargosAplicacion.Borrar(entidad);
        }
    }
}
