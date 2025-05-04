using Livro_Autores_WebAPI8.Models;
using Livro_Autores_WebAPI8.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livro_Autores_WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _IautorInterface;

        public AutorController(IAutorInterface iautorInterface)
        {
            _IautorInterface = iautorInterface;
        }
        [HttpGet("ListarAutores")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _IautorInterface.ListarAutores();
            return Ok(autores);
        }
        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _IautorInterface.BuscarAutorID(idAutor);    
            return Ok(autor);
        }
        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _IautorInterface.BuscarAutorIdLivro(idLivro);
            return Ok(autor);
        }
    }
}
