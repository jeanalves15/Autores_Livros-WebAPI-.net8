namespace Livro_Autores_WebAPI8.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string? Título { get; set; }
        public AutorModel? Autor { get; set; }

    }
}
