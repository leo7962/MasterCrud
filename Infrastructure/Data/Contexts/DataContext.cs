using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .HasOne(x => x.City)
                .WithMany(y => y.Agents)
                .HasForeignKey(z => z.CityId);
        }
    }
}