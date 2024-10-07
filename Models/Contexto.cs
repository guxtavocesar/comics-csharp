using Microsoft.EntityFrameworkCore;

namespace ComicShop.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Quadrinho> Quadrinho { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
    }
}
