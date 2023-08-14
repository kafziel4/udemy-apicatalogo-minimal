using CatalogoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasKey(c => c.CategoriaId);
            modelBuilder.Entity<Categoria>().Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Categoria>().Property(c => c.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Produto>().HasKey(p => p.ProdutoId);
            modelBuilder.Entity<Produto>().Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Descricao)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Imagem)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Preco)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Produto>().HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
