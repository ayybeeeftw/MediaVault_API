using Microsoft.EntityFrameworkCore;
using MediaVault.Models.Entities;

namespace MediaVault.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tables (DbSets)
        public DbSet<Show> Shows { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ShowActor> ShowActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Show>()
                .HasQueryFilter(s => !s.IsDeleted);

            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Show)
                .WithMany(s => s.Episodes)
                .HasForeignKey(e => e.ShowId);

            modelBuilder.Entity<ShowActor>()
                .HasKey(sa => new { sa.ShowId, sa.ActorId });

            modelBuilder.Entity<ShowActor>()
                .HasOne(sa => sa.Show)
                .WithMany(s => s.ShowActors)
                .HasForeignKey(sa => sa.ShowId);

            modelBuilder.Entity<ShowActor>()
                .HasOne(sa => sa.Actor)
                .WithMany(a => a.ShowActors)
                .HasForeignKey(sa => sa.ActorId);

        }

    }
}
