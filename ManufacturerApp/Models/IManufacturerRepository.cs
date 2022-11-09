namespace ManufacturerApp.Models
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> Add(Manufacturer manufacturer);
        Task<List<Manufacturer>?> GetAll();
        Task<Manufacturer?> GetById(int id);
        Task<Manufacturer?> Edit(Manufacturer manufacturer);
        Task Delete(int id);
    }
}
