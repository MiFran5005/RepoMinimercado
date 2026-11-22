using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class PermisosModel : PageModel
    {
        private IPermisos_Presentacion IPermisos_Presentacion;
        private IRoles_Presentacion IRoles_Presentacion;

        public PermisosModel(IPermisos_Presentacion IPermisos_Presentacion,
                             IRoles_Presentacion IRoles_Presentacion)
        {
            this.IPermisos_Presentacion = IPermisos_Presentacion;
            this.IRoles_Presentacion = IRoles_Presentacion;
            this.Filtro = new Permisos();
        }

        [BindProperty] public List<Permisos> Lista { get; set; } = new();
        [BindProperty] public Permisos? Filtro { get; set; }
        [BindProperty] public Permisos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;


        public List<Roles> ListaRoles { get; set; } = new();

        public void OnGet() { OnPostBtBuscar(); }

        private void CargarListas()
        {
            ListaRoles = this.IRoles_Presentacion.Consultar();
        }

        public void OnPostBtBuscar()
        {
            try
            {
                CargarListas();
                this.Filtro!.Nombre = this.Filtro!.Nombre ?? "";
                Lista = this.IPermisos_Presentacion.Consultar();
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
                OnPostBtBuscar();
                Formulario = true;
                this.Actual = new Permisos();
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
                    this.Actual = this.IPermisos_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IPermisos_Presentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                Formulario = true;
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
                this.Actual = this.IPermisos_Presentacion.Borrar(this.Actual!);
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