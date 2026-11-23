using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using Presentacion_Minimercado.interfaces;

namespace Front_Minimercado.Pages.Ventanas
{
    public class ProductosModel : PageModel
    {
        private IProductos_Presentacion IProductos_Presentacion;
        private IProveedores_Presentacion IProveedores_Presentacion;
        private IEstantes_Presentacion IEstantes_Presentacion;
        private IInventarios_Presentacion IInventarios_Presentacion;
        private IMarcas_Presentacion IMarcas_Presentacion;
        private ICategorias_Presentacion ICategorias_Presentacion;

        public ProductosModel(IProductos_Presentacion IProductos_Presentacion,
            IProveedores_Presentacion IProveedores_Presentacion,
            IEstantes_Presentacion IEstantes_Presentacion,
            IInventarios_Presentacion IInventarios_Presentacion,
            IMarcas_Presentacion IMarcas_Presentacion,
            ICategorias_Presentacion ICategorias_Presentacion)
        {
            this.IProductos_Presentacion = IProductos_Presentacion;
            this.IProveedores_Presentacion = IProveedores_Presentacion;
            this.IEstantes_Presentacion = IEstantes_Presentacion;
            this.IInventarios_Presentacion = IInventarios_Presentacion;
            this.IMarcas_Presentacion = IMarcas_Presentacion;
            this.ICategorias_Presentacion = ICategorias_Presentacion;
            this.Filtro = new Productos();
        }
       public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Proveedores> Proveedores { get; set; }
        [BindProperty] public List<Estantes> Estantes { get; set; }
        [BindProperty] public List<Inventarios> Inventarios { get; set; }
        [BindProperty] public List<Marcas> Marcas { get; set; }
        [BindProperty] public List<Categorias> Categorias { get; set; }
        [BindProperty] public List<Productos> Lista { get; set; }
        [BindProperty] public Productos? Filtro { get; set; }   
        [BindProperty] public Productos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                this.Filtro!.Nombre = this.Filtro!.Nombre ?? "";
                Lista = this.IProductos_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Productos();
                this.Proveedores = this.IProveedores_Presentacion.Consultar();
                this.Estantes = this.IEstantes_Presentacion.Consultar();
                this.Inventarios = this.IInventarios_Presentacion.Consultar();
                this.Marcas = this.IMarcas_Presentacion.Consultar();
                this.Categorias = this.ICategorias_Presentacion.Consultar();
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
                this.Actual!.IVA = Math.Round(this.Actual.Precio * 0.19m, 2);

                if (FormFile != null)
                {
                    if (FormFile.Length > 1024 * 1024)
                        throw new Exception("La imagen no puede pesar más de 1 MB");
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    Actual!.Imagen = Convert.ToBase64String(memoryStream.ToArray());
                    memoryStream.Dispose();
                }
                if (this.Actual!.Id == 0)
                    this.Actual = this.IProductos_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IProductos_Presentacion.Actualizar(this.Actual!);
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
                this.Proveedores = this.IProveedores_Presentacion.Consultar();
                this.Estantes = this.IEstantes_Presentacion.Consultar();
                this.Inventarios = this.IInventarios_Presentacion.Consultar();
                this.Marcas = this.IMarcas_Presentacion.Consultar();
                this.Categorias = this.ICategorias_Presentacion.Consultar();
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
                this.Actual = this.IProductos_Presentacion.Borrar(this.Actual!);
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

