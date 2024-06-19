using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Infrastructure.Persistence.Configurations;

public class ProdutoAdicionadoConfigurations : IEntityTypeConfiguration<ProdutoAdicionado>
{
    public void Configure(EntityTypeBuilder<ProdutoAdicionado> builder)
    {
        builder.ToTable("ProdutosAdicionados");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Nome).HasMaxLength(255);
    }
}
