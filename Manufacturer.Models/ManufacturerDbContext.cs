using Microsoft.EntityFrameworkCore;

namespace Manufacturer.Models
{
    public class ManufacturerDbContext : DbContext
    {
        public ManufacturerDbContext()
        {

        }

        public ManufacturerDbContext(DbContextOptions<ManufacturerDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Manufacturer>? Manufacturers { get; set; }
    }
}
