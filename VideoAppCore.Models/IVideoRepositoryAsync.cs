namespace VideoAppCore.Models
{
    /// <summary>
    /// 비동기방식
    /// </summary>
    public interface IVideoRepositoryAsync
    {
        Task<Video> AddVideoAsync(Video video);
        Task<List<Video>> GetAllAsync();
        Task<Video?> GetByIdAsync(int id);
        Task<Video> UpdateVideoAsync(Video video);
        Task RemoveVideoAsync(int id);
    }
}
