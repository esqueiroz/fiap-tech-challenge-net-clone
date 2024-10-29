using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Infrastructure.Configuration
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasColumnType("UUID");
            builder.Property(e => e.CriadoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.AlteradoEm).HasColumnType("DATETIME");
            builder.Property(e => e.Nome).HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Telefone).HasColumnType("VARCHAR(9)").HasMaxLength(9).IsRequired();
            builder.Property(e => e.Email).HasColumnType("VARCHAR(150)").HasMaxLength(150).IsRequired();

            builder.HasOne(c => c.Regional)
                .WithMany(r => r.Contatos)
                .HasPrincipalKey(r => r.Id);
        }
    }
}
