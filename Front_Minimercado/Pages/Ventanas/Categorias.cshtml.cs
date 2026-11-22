using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class CategoriasModel : PageModel
    {
        private ICategorias_Presentacion ICategorias_Presentacion;

        public CategoriasModel(ICategorias_Presentacion ICategorias_Presentacion)
        {
            this.ICategorias_Presentacion = ICategorias_Presentacion;
            this.Filtro = new Categorias();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Categorias> Lista { get; set; }
        [BindProperty] public Categorias? Filtro { get; set; }
        [BindProperty] public Categorias? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                this.Filtro!.Nombre = this.Filtro!.Nombre ?? "";
                this.Filtro!.Descripcion = this.Filtro!.Descripcion ?? "";
                Lista = this.ICategorias_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Categorias();
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
                    this.Actual = this.ICategorias_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICategorias_Presentacion.Actualizar(this.Actual!);
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
                this.Actual = this.ICategorias_Presentacion.Borrar(this.Actual!);
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

