using Microsoft.EntityFrameworkCore;


namespace beerpong_api.Models
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }


        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<Pool> Pool { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .Property(t => t.Points)
                .HasDefaultValue(0);
            modelBuilder.Entity<Team>()
                .Property(t => t.BeerFor)
                .HasDefaultValue(0);
            modelBuilder.Entity<Team>()
                .Property(t => t.BeerAgainst)
                .HasDefaultValue(0);

            modelBuilder.Entity<Match>()
                .Property(m => m.BeerFor1)
                .HasDefaultValue(0);
            modelBuilder.Entity<Match>()
                .Property(m => m.BeerFor2)
                .HasDefaultValue(0);
        }
    }
}