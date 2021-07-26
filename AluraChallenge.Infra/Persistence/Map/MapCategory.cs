using AluraChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Infra.Persistence.Map
{
    public class MapCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.Property(p => p.Id).HasMaxLength(450).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(50).IsRequired();
        }
    }
}
