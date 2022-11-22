using MachineApp.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace MachineApp.Models
{
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

        public async Task<PagingResult<Machine>> GetMachinesPageAsync(int pageIndex, int pageSize)
        {
            var totalRecord = await context.Machines!.CountAsync();
            var machines = await context.Machines!
                    .OrderByDescending(m => m.Id)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return new(machines, totalRecord);
        }
    }
}
