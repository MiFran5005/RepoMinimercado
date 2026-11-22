using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Lib_Minimercado.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Minimercado
{
    // Registra una auditoría cada vez que se ejecuta Insertar, Actualizar o Borrar
    // en cualquier controlador de la API. No hay que tocar los controladores.
    public class AuditoriaFilter : IActionFilter
    {
        private IAuditorias_Aplicacion auditorias;

        public AuditoriaFilter(IAuditorias_Aplicacion auditorias)
        {
            this.auditorias = auditorias;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var accion = descriptor?.ActionName;
                var controlador = descriptor?.ControllerName;

                if (accion != "Insertar" && accion != "Actualizar" && accion != "Borrar")
                    return;

                Console.WriteLine($"[AUDIT] {controlador}/{accion}");

                if (context.Exception != null)
                {
                    Console.WriteLine("[AUDIT] omitido: la accion fallo");
                    return;
                }

                if (controlador == null || controlador.StartsWith("Auditorias"))
                    return;

                var cabecera = context.HttpContext.Request.Headers["X-Usuario-Id"].ToString();
                if (!int.TryParse(cabecera, out var usuarioId))
                {
                    Console.WriteLine($"[AUDIT] omitido: encabezado X-Usuario-Id vacio ('{cabecera}')");
                    return;
                }

                var entidad = (context.Result as ObjectResult)?.Value;
                var id = entidad?.GetType().GetProperty("Id")?.GetValue(entidad);

                auditorias.Insertar(new Auditorias
                {
                    Usuario = usuarioId,
                    Accion = accion,
                    Entidad = controlador.TrimEnd('_'),
                    Detalle = $"Id={id}",
                    Fecha = DateTime.Now
                });

                Console.WriteLine("[AUDIT] registrado");
            }
            catch (Exception ex)
            {
                // un fallo al auditar no debe romper la operacion principal
                Console.WriteLine("[AUDIT] error: " + ex);
            }
        }
    }
}
