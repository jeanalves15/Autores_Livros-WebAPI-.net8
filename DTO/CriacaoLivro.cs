using Livro_Autores_WebAPI8.Models;

namespace Livro_Autores_WebAPI8.DTO
{
    public class CriacaoLivro
    {
        
        public string? Título { get; set; }
        public AutorModel Autor { get; set; }
    }
}
