using MachineApp.Models.Common;

namespace MachineApp.Models.MachinesMedias
{
    public interface IMachineMediaRepository
    {
        Task AddMachineMediaAsync(int machineId, int mediaId);
        Task<List<Media>> GetMediasByMachineIdAsync(int machineId);
        Task<List<Machine>> GetMachinesByMediaIdAsync(int mediaId);
        Task DeleteMachineMediaAsync(int machineId, int mediaId);
    }
}
