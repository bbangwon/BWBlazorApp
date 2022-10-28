namespace VideoAppCore.Models
{
    public class VideoRepositoryAdoNetAsync : IVideoRepositoryAsync
    {
        public Task<Video> AddVideoAsync(Video video)
        {
            throw new NotImplementedException();
        }

        public Task<List<Video>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveVideoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Video> UpdateVideoAsync(Video video)
        {
            throw new NotImplementedException();
        }
    }
}
