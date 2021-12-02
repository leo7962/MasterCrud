using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
    }
}
