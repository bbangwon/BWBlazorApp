using Dapper;
using Microsoft.Data.SqlClient;

namespace VideoAppCore.Models
{
    public class VideoRepositoryDapperAsync : IVideoRepositoryAsync
    {
        private readonly SqlConnection db;

        public VideoRepositoryDapperAsync(string connectionString)
        {            
            db = new SqlConnection(connectionString);
        }

        public async Task<Video> AddVideoAsync(Video video)
        {
            const string query = "Insert Into Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);" +
                            "Select Cast(SCOPE_IDENTITY() As Int);";
            int id = await db.ExecuteScalarAsync<int>(query, video);
            video.Id = id;

            return video;
        }

        public async Task<Video?> GetByIdAsync(int id)
        {
            const string query = "Select * From Videos Where Id = @Id;";

            var video = await db.QueryFirstOrDefaultAsync<Video>(query, new { id }, commandType: System.Data.CommandType.Text);
            return video;
        }

        public async Task<List<Video>> GetAllAsync()
        {
            const string query = "Select * From Videos";
            var videos = await db.QueryAsync<Video>(query, commandType: System.Data.CommandType.Text);

            return videos.ToList();
        }

        public async Task RemoveVideoAsync(int id)
        {
            const string query = "Delete From Videos Where Id=@Id;";

            await db.ExecuteAsync(query, new { id }, commandType: System.Data.CommandType.Text);
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            const string query = @"
                Update Videos Set
                        Title = @Title, Url = @Url,
                        Name = @Name, Company = @Company,
                        ModifiedBy = @ModifiedBy
                Where Id = @Id;";

            await db.ExecuteAsync(query, video);
            return video;
        }
    }
}
