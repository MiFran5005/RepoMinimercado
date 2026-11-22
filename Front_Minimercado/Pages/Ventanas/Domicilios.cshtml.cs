using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class DomiciliosModel : PageModel
    {
        private IDomicilios_Presentacion IDomicilios_Presentacion;
        private IEmpleados_Presentacion IEmpleados_Presentacion;
        private IVehiculos_Presentacion IVehiculos_Presentacion;
        public DomiciliosModel(IDomicilios_Presentacion IDomicilios_Presentacion,
                                IEmpleados_Presentacion IEmpleados_Presentacion,
                                IVehiculos_Presentacion IVehiculos_Presentacion)
        {
            this.IDomicilios_Presentacion = IDomicilios_Presentacion;
            this.IEmpleados_Presentacion = IEmpleados_Presentacion;
            this.IVehiculos_Presentacion = IVehiculos_Presentacion;
            this.Filtro = new Domicilios();
        }
        [BindProperty] public List<Empleados> Empleados { get; set; }
        [BindProperty] public List<Vehiculos> Vehiculos { get; set; }
        [BindProperty] public List<Domicilios> Lista { get; set; }
        [BindProperty] public Domicilios? Filtro { get; set; }
        [BindProperty] public Domicilios? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                this.Filtro!.Descripcion = this.Filtro!.Descripcion ?? "";
                Lista = this.IDomicilios_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Domicilios();
                this.Empleados = this.IEmpleados_Presentacion.Buscar(new Empleados());
                this.Vehiculos = this.IVehiculos_Presentacion.Buscar(new Vehiculos());
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
                    this.Actual = this.IDomicilios_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDomicilios_Presentacion.Actualizar(this.Actual!);
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
                this.Empleados = this.IEmpleados_Presentacion.Buscar(new Empleados());
                this.Vehiculos = this.IVehiculos_Presentacion.Buscar(new Vehiculos());
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
                this.Actual = this.IDomicilios_Presentacion.Borrar(this.Actual!);
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

