using Livro_Autores_WebAPI8.Models;
using Microsoft.EntityFrameworkCore;

namespace Livro_Autores_WebAPI8.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }



    }
}
