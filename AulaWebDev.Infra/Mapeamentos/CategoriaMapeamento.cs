using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaWebDev.Infra.Mapeamentos
{
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.CodCategoria)
                .HasColumnName("CodeCategory")
                .IsRequired();

            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId);

            //builder.HasData(
            //    new Categoria(Guid.NewGuid(), "Categoria teste")
            //);
        }
    }
}
