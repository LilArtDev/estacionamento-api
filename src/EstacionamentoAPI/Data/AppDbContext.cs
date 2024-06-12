using EstacionamentoAPI.Models;
using Microsoft.EntityFrameworkCore;
using EstacionamentoAPI.Data.Extensions;

namespace EstacionamentoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Movimentations> Movimentations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilderNamingExtension.UseCustomNamingConvention(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}