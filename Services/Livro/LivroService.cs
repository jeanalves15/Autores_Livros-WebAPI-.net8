using Livro_Autores_WebAPI8.Context;
using Livro_Autores_WebAPI8.DTO;
using Livro_Autores_WebAPI8.Models;
using Microsoft.EntityFrameworkCore;

namespace Livro_Autores_WebAPI8.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();
                response.Dados = livros;
                response.Mensage = livros.Any()
                    ? "Seus livros foram retornados com sucesso"
                    : "Sua lista de livros esta vazia";
            }
            catch 
            {
                
                response.Status = false;
                response.Mensage = "Erro ao buscar  lista de livros";

            }
            return response;
        }
        public async Task<ResponseModel<LivroModel>> ListarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.Include(a=>a.Autor).FirstOrDefaultAsync(x => x.Id == idLivro);
                response.Dados=livro;
                response.Mensage = livro != null
                ? "Seu livro foi retornado com sucesso"
                : "Seu livro não foi encontrado pelo ID";
            }
            catch
            {
                response.Status = false;
                response.Mensage = "Erro ao buscar o livro";

            }
            return response;
        }
        public async Task<ResponseModel<List<LivroModel>>> ListarLivrosPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(a => a.Autor)
                                           .Where(x => x.Id == idAutor).ToListAsync();
                response.Dados = livros;
                response.Mensage = livros != null
                ? "Seus livros foram retornado com sucesso"
                : "Seuz livroz não foi encontrados pelo ID do autor";
            }
            catch 
            {
                response.Status = false;
                response.Mensage = "Erro ao buscar os livros do autor";
            }
            return response;

        }
        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(CriacaoLivro criacaoLivro)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == criacaoLivro.Autor.Id);
                if(autor is null)
                {
                    response.Mensage = "Nenhum registro de autor localizado!!";
                }

                var livro = new LivroModel()
                {
                    Título = criacaoLivro.Título,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();
                response.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Mensage = ex.Message;
                response.Status = false;
               
            }
            return response;

        }
        
        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(EdicaoLivro edicaoLivro)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == edicaoLivro.Id);
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == edicaoLivro.Autor.Id);

                if (autor is null)
                {
                    response.Mensage = "Nenhum registro de autor localizado!!";
                    return response;
                }
                if (livro is null)
                {
                    response.Mensage = "Nenhum registro de livro localizado!!";
                    return response;
                }

                livro.Título = edicaoLivro.Título;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();
                response.Dados = await _context.Livros.ToListAsync();
                response.Mensage = "Livro atualizado com sucesso!";

            }
            catch (Exception ex)
            {
                response.Mensage = ex.Message;
                response.Status = false;
                
            }
            return response;
        }
        public async Task<ResponseModel<List<LivroModel>>> RemoverLivro(int idlivro)
        {
            var response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include(a=>a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idlivro);

                if (livro is null)
                {
                    response.Mensage = "Nenhum registro de livro localizado!!";
                    return response;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.ToListAsync();
                response.Mensage = "Livro Removido com sucesso!!!";
            }
            catch (Exception ex)
            {
                response.Mensage = ex.Message;
                response.Status = false;
            }
            return response;

        }












    }
}
