namespace Manufacturer.Models
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> AddAsync(Manufacturer manufacturer);
        Task<List<Manufacturer>?> GetAllAsync();
        Task<Manufacturer?> GetByIdAsync(int id);
        Task<Manufacturer?> EditAsync(Manufacturer manufacturer);
        Task DeleteAsync(int id);
    }
}
