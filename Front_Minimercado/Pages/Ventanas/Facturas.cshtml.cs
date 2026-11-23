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

        public FacturasModel(IFacturas_Presentacion IFacturas_Presentacion,
            IEmpleados_Presentacion IEmpleados_Presentacion)
        {
            this.IFacturas_Presentacion = IFacturas_Presentacion;
            this.IEmpleados_Presentacion = IEmpleados_Presentacion;
            this.Filtro = new Facturas();
        }
        [BindProperty] public List<Empleados> Empleados { get; set; }
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
                
                Lista = this.IFacturas_Presentacion.Buscar(this.Filtro!);
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
                this.Actual = new Facturas();
                this.Empleados = this.IEmpleados_Presentacion!.Consultar();
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
                    this.Actual = this.IFacturas_Presentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IFacturas_Presentacion.Actualizar(this.Actual!);
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
                this.Empleados = this.IEmpleados_Presentacion!.Consultar();
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
                this.Actual = this.IFacturas_Presentacion.Borrar(this.Actual!);
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

