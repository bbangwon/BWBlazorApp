using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Manufacturer.Models.Tests
{
    [TestClass]
    public class ManufacturerRepositoryTest
    {
        [TestMethod]
        public async Task ManufacturerRepositoryAllMethod()
        {
            var options = new DbContextOptionsBuilder<ManufacturerDbContext>()
                .UseInMemoryDatabase(databaseName: "ManufacturerAdd").Options;

            //AddAsync() Method Test
            using var context = new ManufacturerDbContext(options);

            var repository = new ManufacturerRepository(context);
            await repository.AddAsync(new Manufacturer { Name = "SAMSUNG", ManufacturerCode = "SM", Comment = "삼성" });            

            Assert.AreEqual(1, await context.Manufacturers!.CountAsync());
            var manufacturer = await context.Manufacturers!.Where(m => m.Id == 1).SingleOrDefaultAsync();
            Assert.AreEqual("SM", manufacturer!.ManufacturerCode);

            //GetAllAsync() Method Test
            await context.Manufacturers!.AddAsync(new Manufacturer { Name = "LG", ManufacturerCode = "LG", Comment = "LG" });
            await context.SaveChangesAsync();

            var manufacturers = await repository.GetAllAsync();

            Assert.AreEqual(2, manufacturers!.Count);

            //GetByIdAsync() Method Test
            await context.Manufacturers!.AddAsync(new Manufacturer { Name = "SK", ManufacturerCode = "SK", Comment = "SK" });
            await context.SaveChangesAsync();

            var sk = await repository.GetByIdAsync(3);
            Assert.AreEqual("SK", sk!.Comment);

            //EditAsync() Method Test
            await context.Manufacturers!.AddAsync(new Manufacturer { Name = "MS", ManufacturerCode = "MS", Comment = "MS" });
            await context.SaveChangesAsync();

            var ms = await repository.GetByIdAsync(4);
            ms!.Name = "Microsoft";
            await repository.EditAsync(ms);
            var microsoft = await repository.GetByIdAsync(4);
            Assert.AreEqual("Microsoft", microsoft!.Name);

            //DeleteAsync() Method Test
            await repository.DeleteAsync(1);
            await repository.DeleteAsync(2);
            await repository.DeleteAsync(3);

            Assert.AreEqual(1, await context.Manufacturers.CountAsync());

            int pageIndex = 0;
            int pageSize = 2;

            int count = await repository.CountAsync();
            Assert.AreEqual(1, count);

            manufacturers = await repository.GetAllAsync(pageIndex, pageSize);
            Assert.AreEqual(1, manufacturers!.ToList().Count);



        } 
    }
}
