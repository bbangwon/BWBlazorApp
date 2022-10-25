namespace VideoAppCore.Models
{
    public interface IVideoRepository
    {
        Video AddVideo(Video video);
        List<Video> GetAll();
        Video GetById(int id);
        Video UpdateVideo(Video video);
        void RemoveVideo(int id);
    }
}
