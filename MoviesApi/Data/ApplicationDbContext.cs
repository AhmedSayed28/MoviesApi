using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre>Genres { get; set; }
        public DbSet<Movie>Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                        .ToTable("Genres")
                        .HasKey(e => e.Id);
            
            modelBuilder.Entity<Movie>()
                        .ToTable("Movies")
                        .HasKey(e => e.Id);
                        
                
        }

    }
}
