using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Infrastructure.Persistence.Configurations;

public class ProdutoMonitoradoConfigurations : IEntityTypeConfiguration<ProdutoMonitorado>
{
    public void Configure(EntityTypeBuilder<ProdutoMonitorado> builder)
    {
        builder.ToTable("ProdutosMonitorados");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Nome).HasMaxLength(255);
    }
}