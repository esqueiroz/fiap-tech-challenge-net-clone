using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Infrastructure.Configuration
{
    public class RegionalConfiguration : IEntityTypeConfiguration<Regional>
    {
        public void Configure(EntityTypeBuilder<Regional> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasColumnType("UUID");
            builder.Property(e => e.CriadoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.AlteradoEm).HasColumnType("DATETIME");
            builder.Property(e => e.Ddd).HasColumnType("INT").IsRequired();
            builder.Property(e => e.Estado).HasColumnType("VARCHAR(2)").HasMaxLength(2).IsRequired();
            builder.Property(e => e.Nome).HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired();
        }
    }
}
