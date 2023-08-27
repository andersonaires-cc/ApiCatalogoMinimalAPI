using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    //Uma ponte entre as classes de dominio e o banco de dados
    //responsável pela interação com o banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //DbSet representa um conjunto de entidades sobre os quais será possível fazer operações
        //Consultas links no DbSet serão convertidas emc onsultas no Banco de dados.
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            
        }

    }
}
