using AluraChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Infra.Persistence.Map
{
    public class MapVideo : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Video");

            builder.Property(p => p.Id).HasMaxLength(450).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Url).HasMaxLength(150).IsRequired();

            builder.HasOne(p => p.Category).WithMany(p => p.Videos).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
