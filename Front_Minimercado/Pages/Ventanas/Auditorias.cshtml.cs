using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class AuditoriasModel : PageModel
    {
        private IAuditorias_Presentacion IAuditorias_Presentacion;
        private IUsuarios_Presentacion IUsuarios_Presentacion;

        public AuditoriasModel(IAuditorias_Presentacion IAuditorias_Presentacion,
                               IUsuarios_Presentacion IUsuarios_Presentacion)
        {
            this.IAuditorias_Presentacion = IAuditorias_Presentacion;
            this.IUsuarios_Presentacion = IUsuarios_Presentacion;
            this.Filtro = new Auditorias();
        }

        [BindProperty] public List<Auditorias> Lista { get; set; } = new();
        [BindProperty] public Auditorias? Filtro { get; set; }

        
        public List<Usuarios> ListaUsuarios { get; set; } = new();

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                ListaUsuarios = this.IUsuarios_Presentacion.Consultar();

                this.Filtro!.Accion = this.Filtro!.Accion ?? "";
                this.Filtro!.Entidad = this.Filtro!.Entidad ?? "";
                Lista = this.IAuditorias_Presentacion.Buscar(this.Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}