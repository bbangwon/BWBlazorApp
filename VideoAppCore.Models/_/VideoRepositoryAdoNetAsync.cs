using Microsoft.Data.SqlClient;

namespace VideoAppCore.Models._
{
    public class VideoRepositoryAdoNetAsync : IVideoRepositoryAsync
    {
        private readonly string connectionString;

        public VideoRepositoryAdoNetAsync(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<Video> AddVideoAsync(Video video)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            const string query = "Insert Into Videos(Title, Url, Name, Company, CreatedBy) " +
                                            "Values (@Title, @Url, @Name, @Company, @CreatedBy);" +
                                            "Select Cast(SCOPE_IDENTITY() As Int);";

            SqlCommand cmd = new SqlCommand(query, con) { CommandType = System.Data.CommandType.Text };

            cmd.Parameters.AddWithValue("@Title", video.Title);
            cmd.Parameters.AddWithValue("@Url", video.Url);
            cmd.Parameters.AddWithValue("@Name", video.Name);
            cmd.Parameters.AddWithValue("@Company", video.Company);
            cmd.Parameters.AddWithValue("@CreatedBy", video.CreatedBy);

            con.Open();
            object? result = await cmd.ExecuteScalarAsync();
            if (int.TryParse(result?.ToString(), out int id))
            {
                video.Id = id;
            }
            con.Close();
            return video;
        }

        public async Task<Video?> GetByIdAsync(int id)
        {
            Video video = new Video();

            using SqlConnection con = new SqlConnection(connectionString);
            const string query = "Select * From Videos Where Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con) { CommandType = System.Data.CommandType.Text };
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            if (dr.Read())
            {
                video.Id = dr.GetInt32(0);
                video.Title = dr["Title"].ToString();
                video.Url = dr["Url"].ToString();
                video.Name = dr["Name"].ToString();
                video.Company = dr["Company"].ToString();
                video.CreatedBy = dr["CreatedBy"].ToString();
                video.Created = Convert.ToDateTime(dr["created"]);
            }
            con.Close();
            return video;
        }

        public async Task<List<Video>> GetAllAsync()
        {
            List<Video> videos = new List<Video>();

            using SqlConnection con = new SqlConnection(connectionString);
            const string query = "Select * From Videos;";
            SqlCommand cmd = new SqlCommand(query, con) { CommandType = System.Data.CommandType.Text };

            con.Open();
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            while (dr.Read())
            {
                Video video = new Video
                {
                    Id = dr.GetInt32(0),
                    Title = dr["Title"].ToString(),
                    Url = dr["Url"].ToString(),
                    Name = dr["Name"].ToString(),
                    Company = dr["Company"].ToString(),
                    CreatedBy = dr["CreatedBy"].ToString(),
                    Created = Convert.ToDateTime(dr["Created"])
                };
                videos.Add(video);
            }
            con.Close();

            return videos;
        }



        public async Task RemoveVideoAsync(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            const string query = "Delete From Videos Where Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con) { CommandType = System.Data.CommandType.Text };

            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            const string query = @"
                Update Videos Set
                    Title = @Title, Url = @Url,
                    Name = @Name, Company = @Company,
                    ModifiedBy = @ModifiedBy
                Where Id = @Id";

            SqlCommand cmd = new SqlCommand(query, con) { CommandType = System.Data.CommandType.Text };
            cmd.Parameters.AddWithValue("@Id", video.Id);

            cmd.Parameters.AddWithValue("@Title", video.Title);
            cmd.Parameters.AddWithValue("@Url", video.Url);
            cmd.Parameters.AddWithValue("@Name", video.Name);
            cmd.Parameters.AddWithValue("@Company", video.Company);
            cmd.Parameters.AddWithValue("@ModifiedBy", video.ModifiedBy);

            con.Open();
            await cmd.ExecuteNonQueryAsync();
            con.Close();

            return video;
        }

    }
}
