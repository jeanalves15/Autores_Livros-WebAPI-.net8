using Livro_Autores_WebAPI8.Models;

namespace Livro_Autores_WebAPI8.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorID(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorIdLivro(int idLivro); 
        Task<ResponseModel<AutorModel>> ExcluirAutor(int idAutor);
        Task<ResponseModel<AutorModel>> EditarAutor(int idLivro);  


    }
}
}
