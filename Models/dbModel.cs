using Microsoft.EntityFrameworkCore;

namespace aspnet.Models
{
    public sealed class dbModel : DbContext
    {
        private readonly string _connectionString = "Server=localhost; Username=postgres; Password=1q2w3e$; Database=FilmFlow;";
        public DbSet<Review> reviews { get; set; }
        public dbModel()
        {
            Database.EnsureCreated();
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
