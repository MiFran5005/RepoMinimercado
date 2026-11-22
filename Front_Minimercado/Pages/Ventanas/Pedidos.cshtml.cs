using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class PedidosModel : PageModel
    {
        private IPedidos_Presentacion IPedidos_Presentacion;
        private IEmpleados_Presentacion IEmpleados_Presentacion;
        private IProveedores_Presentacion IProveedores_Presentacion;

        public PedidosModel(IPedidos_Presentacion IPedidos_Presentacion,
            IEmpleados_Presentacion IEmpleados_Presentacion,
            IProveedores_Presentacion IProveedores_Presentacion)
        {
            this.IPedidos_Presentacion = IPedidos_Presentacion;
            this.IEmpleados_Presentacion = IEmpleados_Presentacion;
            this.IProveedores_Presentacion = IProveedores_Presentacion;
            this.Filtro = new Pedidos();
        }
        [BindProperty] public List<Empleados> Empleados { get; set; }
        [BindProperty] public List<Proveedores> Proveedores { get; set; }
        [BindProperty] public List<Pedidos> Lista { get; set; }
        [BindProperty] public Pedidos? Filtro { get; set; }
        [BindProperty] public Pedidos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                Lista = this.IPedidos_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Pedidos();
                this.Empleados = this.IEmpleados_Presentacion.Consultar();
                this.Proveedores = this.IProveedores_Presentacion.Consultar();
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
                    this.Actual = this.IPedidos_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IPedidos_Presentacion.Actualizar(this.Actual!);
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
                this.Empleados = this.IEmpleados_Presentacion.Consultar();
                this.Proveedores = this.IProveedores_Presentacion.Consultar();
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
                this.Actual = this.IPedidos_Presentacion.Borrar(this.Actual!);
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

