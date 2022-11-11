using Microsoft.EntityFrameworkCore;

namespace Manufacturer.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ManufacturerDbContext dbContext;

        public ManufacturerRepository(ManufacturerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Manufacturer> AddAsync(Manufacturer manufacturer)
        {
            this.dbContext.Add(manufacturer);
            await this.dbContext.SaveChangesAsync();
            return manufacturer;
        }
        public async Task<List<Manufacturer>?> GetAllAsync()       
        {
            return await this.dbContext.Manufacturers!.OrderBy(m => m.Id).ToListAsync();
        }

        public async Task<Manufacturer?> GetByIdAsync(int id)
        {
            return await this.dbContext.Manufacturers!.FindAsync(id);
        }
        public async Task<Manufacturer?> EditAsync(Manufacturer manufacturer)
        {
            this.dbContext.Manufacturers!.Update(manufacturer);
            await this.dbContext.SaveChangesAsync();

            return manufacturer;
        }

        public async Task DeleteAsync(int id)
        {
            var manufacturer = await GetByIdAsync(id);

            if (manufacturer == null)
                return;

            this.dbContext.Manufacturers?.Remove(manufacturer);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<Manufacturer>?> GetAllAsync(int pageIndex, int pageSize = 10)
        {
            return await this.dbContext.Manufacturers!
                .OrderBy(m => m.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await this.dbContext.Manufacturers!.CountAsync();
        }
    }
}
