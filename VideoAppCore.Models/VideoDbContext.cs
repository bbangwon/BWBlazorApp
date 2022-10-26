using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace VideoAppCore.Models
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext()
        {

        }

        public VideoDbContext(DbContextOptions<VideoDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Video>? Videos { get; set; }

    }
}
