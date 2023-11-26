using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using QualiWatchApi.Domain.Model.Validade;

namespace QualiWatchApi.Infrastructure.Persistence.Configurations;

    public class ValidadeConfigurations : IEntityTypeConfiguration<Validade>
    {
        public void Configure(EntityTypeBuilder<Validade> builder)
        {
            builder.ToTable("Validades");

            //Id
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .ValueGeneratedNever();

            builder.Property(v => v.ProdutoId)
                .ValueGeneratedNever();
        }
    }

