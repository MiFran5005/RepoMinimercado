namespace Presentacion_Minimercado.interfaces
{
    public interface IComunicaciones
    {
        string? UsuarioId { get; set; }
        Task<T> Ejecutar<T>(string url, object entidad);
    }
}
