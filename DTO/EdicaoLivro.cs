using Livro_Autores_WebAPI8.Models;

namespace Livro_Autores_WebAPI8.DTO
{
    public class EdicaoLivro
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public AutorModel Autor { get; set; }
    }
}
