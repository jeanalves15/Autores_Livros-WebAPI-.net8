namespace Livro_Autores_WebAPI8.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string? Mensage { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}
