using MachineApp.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace MachineApp.Models
{
    public class MediaRepository : IMediaRepository
    {
        private readonly MachineDbContext context;

        public MediaRepository(MachineDbContext context)
        {
            this.context = context;
        }

        public async Task<Media> AddMediaAsync(Media media)
        {
            this.context.Add(media);
            await this.context.SaveChangesAsync();
            return media;
        }

        public async Task DeleteMediaAsync(int id)
        {
            var media = await GetMediaByIdAsync(id);
            if(media != null)
            {
                this.context.Remove(media);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Media> EditMediaAsync(Media media)
        {
            context.Update(media);
            await this.context.SaveChangesAsync();
            return media;
        }

        public async Task<Media?> GetMediaByIdAsync(int id)
        {
            var media = await this.context.FindAsync<Media>(id);
            return media;
        }

        public async Task<List<Media>> GetMediasAsync()
        {
            return await context.Medias!.ToListAsync();
        }

        public async Task<PagingResult<Media>> GetMediasPageAsync(int pageIndex, int pageSize)
        {
            var totalRecord = await context.Medias!.CountAsync();
            var madias = await context.Medias!
                    .OrderByDescending(m => m.Id)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return new(madias, totalRecord);
        }
    }
}
