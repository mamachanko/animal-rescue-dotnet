using Microsoft.EntityFrameworkCore;

namespace AnimalRescueApi.Data
{
    public class AnimalRescueContext : DbContext
    {
        public AnimalRescueContext(DbContextOptions<AnimalRescueContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().ToTable("Animal");
        }
    }
}
