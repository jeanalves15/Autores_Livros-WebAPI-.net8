using Livro_Autores_WebAPI8.Context;
using Livro_Autores_WebAPI8.DTO;
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
            _context = context;   
        }
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensage = autores.Count == 0
                    ? "Sua lista de autores está vazia."
                    : "Todos os autores foram coletados!";  
            }
            catch 
            {
                
                resposta.Status = false;                                
            }
            return resposta;
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

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome=autorCriacaoDto.Sobrenome
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensage = "Autor criado com sucesso!!!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensage = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensage = "Nenhum autor localizado";
                    return resposta;
                }
                 _context.Remove(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensage = "Autor Removido com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensage = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> EdicaoAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autorEdicaoDTO.Id);
                if (autor == null)
                {
                    resposta.Mensage = "Nenhum autor localizado";
                    return resposta;
                }
                autor.Nome = autorEdicaoDTO.Nome;
                autor.Sobrenome = autorEdicaoDTO.Sobrenome;

                 _context.Update(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensage = "Autor editado com sucesso!!!";
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
