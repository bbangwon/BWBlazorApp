using Microsoft.EntityFrameworkCore;

namespace VideoAppCore.Models
{
    public class VideoRepositoryEfCoreAsync : IVideoRepositoryAsync
    {
        private readonly VideoDbContext context;

        public VideoRepositoryEfCoreAsync(VideoDbContext context)
        {
            this.context = context;
        }

        public async Task<Video> AddVideoAsync(Video video)
        {
            this.context.Videos!.Add(video);
            await this.context.SaveChangesAsync();

            return video;
        }

        public async Task<Video?> GetByIdAsync(int id)
        {
            return await this.context.Videos!.FindAsync(id);
        }

        public async Task<List<Video>> GetAllAsync()
        {
            return await this.context.Videos!.ToListAsync();
        }

        public async Task RemoveVideoAsync(int id)
        {
            var video = await GetByIdAsync(id);

            if (video == null)
                return;

            this.context.Videos!.Remove(video);
            await this.context.SaveChangesAsync();
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            this.context.Videos!.Update(video);
            await this.context.SaveChangesAsync();
            return video;
        }
    }
}
