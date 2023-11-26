using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Infrastructure.Persistence.Configurations
{
    public class ProdutoConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            //Id
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedNever();

           builder.Property(p => p.Nome).HasMaxLength(255);
           builder.Property(p => p.Lote).HasMaxLength(255);
        }
    }
}
