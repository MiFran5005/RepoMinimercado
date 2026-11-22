using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class UsuariosModel : PageModel
    {
        private IUsuarios_Presentacion IUsuarios_Presentacion;
        private IRoles_Presentacion IRoles_Presentacion;
        private IEmpleados_Presentacion IEmpleados_Presentacion;
        private IClientes_Presentacion IClientes_Presentacion;

        public UsuariosModel(IUsuarios_Presentacion IUsuarios_Presentacion,
                             IRoles_Presentacion IRoles_Presentacion,
                             IEmpleados_Presentacion IEmpleados_Presentacion,
                             IClientes_Presentacion IClientes_Presentacion)
        {
            this.IUsuarios_Presentacion = IUsuarios_Presentacion;
            this.IRoles_Presentacion = IRoles_Presentacion;
            this.IEmpleados_Presentacion = IEmpleados_Presentacion;
            this.IClientes_Presentacion = IClientes_Presentacion;
            this.Filtro = new Usuarios();
        }

        [BindProperty] public List<Usuarios> Lista { get; set; } = new();
        [BindProperty] public Usuarios? Filtro { get; set; }
        [BindProperty] public Usuarios? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<Roles> ListaRoles { get; set; } = new();
        public List<Empleados> ListaEmpleados { get; set; } = new();
        public List<Clientes> ListaClientes { get; set; } = new();

        public void OnGet() { OnPostBtBuscar(); }

        private void CargarListas()
        {
            ListaRoles = this.IRoles_Presentacion.Consultar();
            ListaEmpleados = this.IEmpleados_Presentacion.Consultar();
            ListaClientes = this.IClientes_Presentacion.Consultar();
        }

        public void OnPostBtBuscar()
        {
            try
            {
                CargarListas();
                this.Filtro!.NombreUsuario = this.Filtro!.NombreUsuario ?? "";
                Lista = this.IUsuarios_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Usuarios();
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
                if (this.Actual!.Empleado != null && this.Actual.Cliente != null)
                    throw new Exception("Un usuario es empleado o cliente, no ambos");

                if (this.Actual.Id == 0)
                    this.Actual = this.IUsuarios_Presentacion.Insertar(this.Actual);
                else
                    this.Actual = this.IUsuarios_Presentacion.Actualizar(this.Actual);
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
                this.Actual = this.IUsuarios_Presentacion.Borrar(this.Actual!);
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