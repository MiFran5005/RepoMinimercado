using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class Empleados_CargosModel : PageModel
    {
        private IEmpleados_Cargos_Presentacion IEmpleados_Cargos_Presentacion;
        private ICargos_Presentacion ICargos_Presentacion;
        private IEmpleados_Presentacion IEmpleados_Presentacion;
        private IContratos_Presentacion IContratos_Presentacion;

        public Empleados_CargosModel(IEmpleados_Cargos_Presentacion IEmpleados_Cargos_Presentacion,
            ICargos_Presentacion iCargos_Presentacion,
            IEmpleados_Presentacion iEmpleados_Presentacion,
            IContratos_Presentacion iContratos_Presentacion)
        {
            this.IEmpleados_Cargos_Presentacion = IEmpleados_Cargos_Presentacion;
            this.Filtro = new Empleados_Cargos();
            ICargos_Presentacion = iCargos_Presentacion;
            IEmpleados_Presentacion = iEmpleados_Presentacion;
            IContratos_Presentacion = iContratos_Presentacion;
        }
        [BindProperty] public List<Cargos> Cargos { get; set; }
        [BindProperty] public List<Empleados> Empleados { get; set; }
        [BindProperty] public List<Contratos> Contratos { get; set; }
        [BindProperty] public List<Empleados_Cargos> Lista { get; set; }
        [BindProperty] public Empleados_Cargos? Filtro { get; set; }
        [BindProperty] public Empleados_Cargos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                Lista = this.IEmpleados_Cargos_Presentacion.Buscar(this.Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Empleados_Cargos();
                this.Cargos = this.ICargos_Presentacion.Buscar(new Cargos());
                this.Empleados = this.IEmpleados_Presentacion.Buscar(new Empleados());
                this.Contratos = this.IContratos_Presentacion.Buscar(new Contratos());
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IEmpleados_Cargos_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IEmpleados_Cargos_Presentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtBuscar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtBuscar();
                Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                this.Cargos = this.ICargos_Presentacion.Buscar(new Cargos());
                this.Empleados = this.IEmpleados_Presentacion.Buscar(new Empleados());
                this.Contratos = this.IContratos_Presentacion.Buscar(new Contratos());
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtBuscar();
                Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IEmpleados_Cargos_Presentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtBuscar();
            }
        }

    }
}

