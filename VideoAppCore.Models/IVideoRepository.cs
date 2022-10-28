namespace VideoAppCore.Models
{
    /// <summary>
    /// 동기방식
    /// </summary>
    public interface IVideoRepository
    {
        Video AddVideo(Video video);
        List<Video> GetAll();
        Video GetById(int id);
        Video UpdateVideo(Video video);
        void RemoveVideo(int id);
    }
}
