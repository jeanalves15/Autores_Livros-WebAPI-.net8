using Livro_Autores_WebAPI8.DTO;
using Livro_Autores_WebAPI8.Models;
using Livro_Autores_WebAPI8.Services.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livro_Autores_WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivrosController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }
        [HttpGet("ListarLivros")]

        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorID/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorID(int idLivro)
        {
            var livro = await _livroInterface.ListarLivroPorId(idLivro);
            return Ok(livro);
        }
        [HttpGet("BuscarLivrosIdAutor/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivrosIdAutor(int idAutor)
        {
            var livros = await _livroInterface.ListarLivrosPorIdAutor(idAutor);
            return Ok(livros);
        }
        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(CriacaoLivro criacaoLivro)
        {
            var livros = await _livroInterface.CriarLivro(criacaoLivro);
            return Ok(livros);
        }
        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(EdicaoLivro edicaoLivro)
        {
            var livros = await _livroInterface.EditarLivro(edicaoLivro);
            return Ok(livros);
        }
        [HttpDelete("DeletarLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> DeletarLivro(int idLivro)
        {
            var livros = await _livroInterface.RemoverLivro(idLivro);
            return Ok(livros);
        }
    }
}
