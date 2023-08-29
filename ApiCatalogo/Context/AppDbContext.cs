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
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>().Property(c => c.Nome).HasMaxLength(100)
                                                        .IsRequired();
            
            mb.Entity<Categoria>().Property(c => c.Descricao).HasMaxLength(100)
                                                             .IsRequired();
            //produto
            mb.Entity<Produto>().HasKey(c => c.ProdutoId);
            mb.Entity<Produto>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
            mb.Entity<Produto>().Property(c => c.Descricao).HasMaxLength(150);
            mb.Entity<Produto>().Property(c => c.Imagem).HasMaxLength(100);
            mb.Entity<Produto>().Property(c => c.Preco).HasPrecision(14,2);

            //relacionamento
            //Produto tem uma relação com 1 categoria e vários produtos.
            mb.Entity<Produto>()
                .HasOne<Categoria>(c => c.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.CategoriaId);


        }

    }
}
