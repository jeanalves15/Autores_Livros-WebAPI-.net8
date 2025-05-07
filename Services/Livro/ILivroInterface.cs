using Livro_Autores_WebAPI8.DTO;
using Livro_Autores_WebAPI8.Models;

namespace Livro_Autores_WebAPI8.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> ListarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> ListarLivrosPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(CriacaoLivro criacaoLivro);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(EdicaoLivro edicaoLivro);
        Task<ResponseModel<List<LivroModel>>> RemoverLivro(int  idLivro);
    }
}
