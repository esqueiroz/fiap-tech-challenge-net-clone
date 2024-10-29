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
            builder.Property(e => e.Id);
            builder.Property(e => e.CriadoEm).HasColumnType("timestamp without time zone").IsRequired();
            builder.Property(e => e.AlteradoEm).HasColumnType("timestamp without time zone");
            builder.Property(e => e.Nome).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Telefone).HasMaxLength(9).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(150).IsRequired();

            /*builder.HasOne(c => c.Regional)
                .WithMany(r => r.Contatos)
                .HasPrincipalKey(r => r.Id);*/
        }
    }
}
