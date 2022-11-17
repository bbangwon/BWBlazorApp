using MachineApp.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.ComponentModel.DataAnnotations;

namespace MachineApp.Models
{
    public class Machine : AuditableBase
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }

    public interface IMachineRepository
    {
        Task<Machine> AddMachineAsync(Machine machine); 
        Task<List<Machine>> GetMachinesAsync();
        Task<Machine> GetMachineByIdAsync(int id);
        Task<Machine> EditMachineAsync(Machine machine);
        Task DeleteMachineAsync(int id);        
    }

    public class MachineRepository : IMachineRepository
    {
        public Task<Machine> AddMachineAsync(Machine machine)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMachineAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Machine> EditMachineAsync(Machine machine)
        {
            throw new NotImplementedException();
        }

        public Task<Machine> GetMachineByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Machine>> GetMachinesAsync()
        {
            throw new NotImplementedException();
        }
    }

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
