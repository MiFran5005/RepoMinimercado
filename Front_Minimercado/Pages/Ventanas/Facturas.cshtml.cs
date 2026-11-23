using Lib_Minimercado.entidades;
using Lib_Minimercado.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Minimercado.implementaciones;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace Front_Minimercado.Pages.Ventanas
{
    public class FacturasModel : PageModel
    {
        private IFacturas_Presentacion IFacturas_Presentacion;
        private IEmpleados_Presentacion IEmpleados_Presentacion;
        private IClientes_Presentacion IClientes_Presentacion;
        private IMetodos_Pagos_Presentacion IMetodos_Pagos_Presentacion;
        private IProductos_Presentacion IProductos_Presentacion;

        public FacturasModel(IFacturas_Presentacion IFacturas_Presentacion,
            IEmpleados_Presentacion IEmpleados_Presentacion,
            IClientes_Presentacion IClientes_Presentacion,
            IMetodos_Pagos_Presentacion IMetodos_Pagos_Presentacion,
            IProductos_Presentacion IProductos_Presentacion)
        {
            this.IFacturas_Presentacion = IFacturas_Presentacion;
            this.IEmpleados_Presentacion = IEmpleados_Presentacion;
            this.IClientes_Presentacion = IClientes_Presentacion;
            this.IMetodos_Pagos_Presentacion = IMetodos_Pagos_Presentacion;
            this.IProductos_Presentacion = IProductos_Presentacion;
            this.Filtro = new Facturas();
        }
        [BindProperty] public List<Empleados> Empleados { get; set; }
        [BindProperty] public List<Clientes> Clientes { get; set; }
        [BindProperty] public List<Metodos_Pagos> Metodos_Pagos { get; set; }
        [BindProperty] public List<Productos> Productos { get; set; }
        [BindProperty] public List<Facturas> Lista { get; set; }
        [BindProperty] public Facturas? Filtro { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                Lista = IFacturas_Presentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
             private List<int> LeerCarrito()
        {
            var texto = HttpContext.Session.GetString("carrito") ?? "";
            return texto.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToList();
        }

        private void CargarListas()
        {
            Empleados = IEmpleados_Presentacion.Consultar();
            Clientes = IClientes_Presentacion.Consultar();
            Metodos_Pagos = IMetodos_Pagos_Presentacion.Consultar();
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                Actual = new Facturas { Fecha = DateTime.Now };
                CargarListas();

                var ids = LeerCarrito();
                Productos = IProductos_Presentacion.Consultar()
                    .Where(p => ids.Contains(p.Id)).ToList();
            }
            catch (Exception ex) { LogConversor.Log(ex, ViewData!); }
        }


        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.Id == 0)
                {
                    Actual.Detalles = LeerCarrito()
                        .GroupBy(id => id)
                        .Select(g => new Detalles { Producto = g.Key, Cantidad = g.Count() })
                        .ToList();

                    Actual = IFacturas_Presentacion.Insertar(Actual);
                    HttpContext.Session.Remove("carrito");
                }
                else
                    Actual = IFacturas_Presentacion.Actualizar(Actual);
            }
            catch (Exception ex) { LogConversor.Log(ex, ViewData!); }
            finally { OnPostBtBuscar(); }
        }

        public void OnPostBtVaciar()
        {
            HttpContext.Session.Remove("carrito");
            OnPostBtBuscar();
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtBuscar();
                Actual = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                CargarListas();
            }
            catch (Exception ex) { LogConversor.Log(ex, ViewData!); }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtBuscar();
                Actual = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex) { LogConversor.Log(ex, ViewData!); }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual!.Id == 0) return;
                Actual = IFacturas_Presentacion.Borrar(Actual);
            }
            catch (Exception ex) { LogConversor.Log(ex, ViewData!); }
            finally { OnPostBtBuscar(); }
        }

        public IActionResult OnPostBtPdf()
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                var datos = this.IFacturas_Presentacion!.Consultar();

                var pdf = Document.Create(contenedor =>
                {
                    contenedor.Page(pagina =>
                    {
                        pagina.Size(PageSizes.A4);
                        pagina.Margin(30);
                        pagina.DefaultTextStyle(x => x.FontSize(11));

                        pagina.Header().Column(col =>
                        {
                            col.Item().Text("Reporte de Facturas").FontSize(20).Bold();
                            col.Item().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        });

                        pagina.Content().PaddingVertical(15).Table(tabla =>
                        {
                            tabla.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(1);  
                                c.RelativeColumn(2);   
                                c.RelativeColumn(3);   
                                c.RelativeColumn(3);  
                            });

                            tabla.Header(h =>
                            {
                                h.Cell().Background(Colors.Grey.Lighten2)
                                .Padding(5)
                                .Text("Cantidad")
                                .Bold();
                                h.Cell().Background(Colors.Grey
                                    .Lighten2).Padding(5)
                                    .Text("Total").Bold();

                                h.Cell().Background(Colors.Grey
                                    .Lighten2).Padding(5)
                                    .Text("Fecha").Bold();

                                h.Cell().Background(Colors.Grey
                                    .Lighten2).Padding(5)
                                    .Text("Empleado").Bold();
                            });

                            foreach (var f in datos)
                            {
                                tabla.Cell().BorderBottom(1)
                                .BorderColor(Colors.Grey.Lighten2)
                                .Padding(5).Text(f.Cantidad
                                .ToString());

                                tabla.Cell().BorderBottom(1)
                                .BorderColor(Colors.Grey
                                    .Lighten2).Padding(5).Text(f.Total
                                    .ToString("N0"));

                                tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey
                                    .Lighten2).Padding(5).Text(f.Fecha
                                    .ToString("dd/MM/yyyy"));

                                tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey
                                    .Lighten2).Padding(5)
                                    .Text(f._Empleado?.Nombre ?? "-");
                            }
                        });

                        pagina.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                    });
                }).GeneratePdf();

                return File(pdf, "application/pdf", "ReporteFacturas.pdf");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                OnPostBtBuscar();   
                return Page();
            }
        }

    }
}

