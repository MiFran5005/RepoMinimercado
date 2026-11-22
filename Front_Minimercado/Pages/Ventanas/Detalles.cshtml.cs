using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class DetallesModel : PageModel
    {
        private IDetalles_Presentacion IDetalles_Presentacion;
        private IFacturas_Presentacion IFacturas_Presentacion;
        private IProductos_Presentacion IProductos_Presentacion;
        private IClientes_Presentacion IClientes_Presentacion;
        private IDomicilios_Presentacion IDomicilios_Presentacion;
        private IEstados_Presentacion IEstados_Presentacion;
        private IMetodos_Pagos_Presentacion IMetodos_Pagos_Presentacion;

        public DetallesModel(IDetalles_Presentacion IDetalles_Presentacion, IFacturas_Presentacion iFacturas_Presentacion,
            IProductos_Presentacion iProductos_Presentacion,
            IClientes_Presentacion iClientes_Presentacion,
            IDomicilios_Presentacion iDomicilios_Presentacion,
            IEstados_Presentacion iEstados_Presentacion,
            IMetodos_Pagos_Presentacion iMetodos_Pagos_Presentacion)
        {
            this.IDetalles_Presentacion = IDetalles_Presentacion;
            this.Filtro = new Detalles();
            IFacturas_Presentacion = iFacturas_Presentacion;
            IProductos_Presentacion = iProductos_Presentacion;
            IClientes_Presentacion = iClientes_Presentacion;
            IDomicilios_Presentacion = iDomicilios_Presentacion;
            IEstados_Presentacion = iEstados_Presentacion;
            IMetodos_Pagos_Presentacion = iMetodos_Pagos_Presentacion;
        }
        [BindProperty] public List<Facturas> Facturas { get; set; }
        [BindProperty] public List<Productos> Productos { get; set; }
        [BindProperty] public List<Clientes> Clientes { get; set; }
        [BindProperty] public List<Domicilios> Domicilios { get; set; }
        [BindProperty] public List<Estados> Estados { get; set; }
        [BindProperty] public List<Metodos_Pagos> Metodos_Pagos { get; set; }
        [BindProperty] public List<Detalles> Lista { get; set; }
        [BindProperty] public Detalles? Filtro { get; set; }
        [BindProperty] public Detalles? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                Lista = this.IDetalles_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Detalles();
                this.Facturas = this.IFacturas_Presentacion!.Consultar();
                this.Productos = this.IProductos_Presentacion!.Consultar();
                this.Clientes = this.IClientes_Presentacion!.Consultar();
                this.Domicilios = this.IDomicilios_Presentacion!.Consultar();
                this.Estados = this.IEstados_Presentacion!.Consultar();
                this.Metodos_Pagos = this.IMetodos_Pagos_Presentacion!.Consultar();
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
                    this.Actual = this.IDetalles_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDetalles_Presentacion.Actualizar(this.Actual!);
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
                this.Facturas = this.IFacturas_Presentacion!.Consultar();
                this.Productos = this.IProductos_Presentacion!.Consultar();
                this.Clientes = this.IClientes_Presentacion!.Consultar();
                this.Domicilios = this.IDomicilios_Presentacion!.Consultar();
                this.Estados = this.IEstados_Presentacion!.Consultar();
                this.Metodos_Pagos = this.IMetodos_Pagos_Presentacion!.Consultar();
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
                this.Actual = this.IDetalles_Presentacion.Borrar(this.Actual!);
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

