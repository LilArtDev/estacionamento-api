using EstacionamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Movimentation> Movimentation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}