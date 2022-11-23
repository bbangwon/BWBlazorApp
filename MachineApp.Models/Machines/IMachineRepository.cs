using MachineApp.Models.Common;

namespace MachineApp.Models.Machines
{
    public interface IMachineRepository
    {
        Task<Machine> AddMachineAsync(Machine machine);
        Task<List<Machine>> GetMachinesAsync();
        Task<Machine?> GetMachineByIdAsync(int id);
        Task<Machine> EditMachineAsync(Machine machine);
        Task DeleteMachineAsync(int id);

        Task<List<Machine>> GetMachinesPageAsync(int pageIndex, int pageSize);
        Task<int> GetTotalRecordsCountAsync();
    }
}
