using AluraChallenge.Domain.Entities;
using AluraChallenge.Infra.Persistence.Map;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Infra
{
    public class AluraChallengeContext : DbContext
    {
        public AluraChallengeContext(DbContextOptions<AluraChallengeContext> options)
       : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<prmToolkit.NotificationPattern.Notification>();

            #region Adiciona entidades mapeadas 
            modelBuilder.ApplyConfiguration(new MapCategory());
            modelBuilder.ApplyConfiguration(new MapVideo());
            
            #endregion
        }
    }
}
