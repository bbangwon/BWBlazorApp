using MachineApp.Models.Common;
using Microsoft.EntityFrameworkCore;
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
        Task<Machine?> GetMachineByIdAsync(int id);
        Task<Machine> EditMachineAsync(Machine machine);
        Task DeleteMachineAsync(int id);        
    }

    public class MachineRepository : IMachineRepository
    {
        private readonly MachineDbContext context;

        public MachineRepository(MachineDbContext context)
        {
            this.context = context;
        }

        public async Task<Machine> AddMachineAsync(Machine machine)
        {
            this.context.Add(machine);
            await this.context.SaveChangesAsync();
            return machine;
        }

        public async Task DeleteMachineAsync(int id)
        {
            var machine = await GetMachineByIdAsync(id);
            if(machine != null)
            {
                this.context.Remove(machine);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Machine> EditMachineAsync(Machine machine)
        {
            context.Update(machine);
            await this.context.SaveChangesAsync();
            return machine;
        }

        public async Task<Machine?> GetMachineByIdAsync(int id)
        {
            var machine = await this.context.FindAsync<Machine>(id);
            return machine;
        }

        public async Task<List<Machine>> GetMachinesAsync()
        {
            return await context.Machines!.ToListAsync();
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
