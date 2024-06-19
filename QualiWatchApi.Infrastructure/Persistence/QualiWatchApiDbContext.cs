using Microsoft.EntityFrameworkCore;
using QualiWatchApi.Domain.Model.Estatistica;
using QualiWatchApi.Domain.Model.Produtos;
using QualiWatchApi.Domain.Model.Validade;

namespace QualiWatchApi.Infrastructure.Persistence
{
    public class QualiWatchApiDbContext : DbContext
    {
        public QualiWatchApiDbContext(DbContextOptions<QualiWatchApiDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Validade> Validades { get; set; } = null!;
        public DbSet<ProdutoAdicionado> ProdutoAdicionados { get; set; } = null!;
        public DbSet<ProdutoMonitorado> ProdutoMonitorados { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QualiWatchApiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
