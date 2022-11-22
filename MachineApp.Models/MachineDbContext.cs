using Microsoft.EntityFrameworkCore;

namespace MachineApp.Models
{
    public class MachineDbContext : DbContext
    {
        private readonly string? connectionString;

        public MachineDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MachineDbContext(DbContextOptions<MachineDbContext> options) 
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);  
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Machine>()
                .Property(m => m.Created)
                .HasDefaultValueSql("GetDate()");
        }

        public DbSet<Machine>? Machines { get; set; }
    }
}
