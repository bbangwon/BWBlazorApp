using MachineApp.Models.Common;

namespace MachineApp.Models
{
    public interface IMediaRepository
    {
        Task<Media> AddMediaAsync(Media machine); 
        Task<List<Media>> GetMediasAsync();
        Task<Media?> GetMediaByIdAsync(int id);
        Task<Media> EditMediaAsync(Media machine);
        Task DeleteMediaAsync(int id);

        Task<PagingResult<Media>> GetMediasPageAsync(int pageIndex, int pageSize);
    }
}
