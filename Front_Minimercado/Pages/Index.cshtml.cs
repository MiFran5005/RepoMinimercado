using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Lib_Minimercado.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuarios_Presentacion IUsuarios_Presentacion;

        public IndexModel(IUsuarios_Presentacion IUsuarios_Presentacion)
        {
            this.IUsuarios_Presentacion = IUsuarios_Presentacion;
        }

        [BindProperty] public string? NombreUsuario { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        public bool EstaLogueado { get; set; }

        public void OnGet()
        {
            LeerSesion();
        }

        public void OnPostBtClean()
        {
            NombreUsuario = null;
            Contrasena = null;
            LeerSesion();
        }

        public void OnPostBtEnter()
        {
            try
            {
                var entidad = new Usuarios()
                {
                    NombreUsuario = this.NombreUsuario,
                    Contrasena = this.Contrasena
                };

                var usuario = this.IUsuarios_Presentacion.Login(entidad);

                HttpContext.Session.SetString("Usuario", usuario.NombreUsuario!);
                HttpContext.Session.SetString("Rol", usuario._Rol!.Nombre!);
                HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            LeerSesion();
        }

        public void OnPostBtClose()
        {
            HttpContext.Session.Clear();
            LeerSesion();
        }

        private void LeerSesion()
        {
            EstaLogueado = HttpContext.Session.GetString("Rol") != null;
        }
    }
}

