using Livro_Autores_WebAPI8.Context;
using Livro_Autores_WebAPI8.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livro_Autores_WebAPI8.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            context = _context;   
        }
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensage = "Todos os autores foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensage = ex.Message;
                resposta.Status = false;
                return resposta;
                
            }
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorID(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensage = "Nenhum registro localizado!";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensage = "Autor localizado!!!";
                return resposta;
            }

            catch (Exception ex)
            {
                resposta.Mensage = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        } 
            

        public async Task<ResponseModel<AutorModel>> BuscarAutorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros
                     .Include(a => a.Autor)
                     .FirstOrDefaultAsync(x => x.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensage = "Livro não encontrado!!!";
                    return resposta;
                }
                  

                resposta.Dados =livro.Autor;
                resposta.Mensage = "Autor Localizado";
                return resposta;
            }

            catch (Exception ex)
            {
                resposta.Mensage = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        
    }
}
