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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Videos 테이블의 Created 열은 자동으로 GetDate() 제약 조건을 부여하기
            modelBuilder.Entity<Video>().Property(v => v.Created).HasDefaultValueSql("GetDate()");
        }

    }
}
