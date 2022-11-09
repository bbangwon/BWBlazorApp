using ManufacturerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ManufacturerApp.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ManufacturerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Manufacturer> Add(Manufacturer manufacturer)
        {
            this.dbContext.Add(manufacturer);
            await this.dbContext.SaveChangesAsync();
            return manufacturer;
        }
        public async Task<List<Manufacturer>?> GetAll()       
        {
            if (this.dbContext.Manufacturers == null)
                return null;

            return await this.dbContext.Manufacturers.OrderBy(m => m.Id).ToListAsync();
        }

        public async Task<Manufacturer?> GetById(int id)
        {
            if (this.dbContext.Manufacturers == null)
                return null;

            return await this.dbContext.Manufacturers.FindAsync(id);
        }
        public async Task<Manufacturer?> Edit(Manufacturer manufacturer)
        {
            if (this.dbContext.Manufacturers == null)
                return null;

            this.dbContext.Manufacturers.Update(manufacturer);
            await this.dbContext.SaveChangesAsync();

            return manufacturer;
        }

        public async Task Delete(int id)
        {
            var manufacturer = await GetById(id);

            if (manufacturer == null)
                return;

            this.dbContext.Manufacturers?.Remove(manufacturer);
            await this.dbContext.SaveChangesAsync();
        }


    }
}
