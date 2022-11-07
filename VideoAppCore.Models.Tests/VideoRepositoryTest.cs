using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoAppCore.Models.Tests
{
    [TestClass]
    public class VideoRepositoryTest
    {
        [TestMethod]
        public async Task AddVideoAsyncMethodTest()
        {
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>()
                .UseInMemoryDatabase(databaseName: "AddVideo").Options;

            //컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                //인메모리 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);

                var video = new Video { 
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "빵원"
                };
                await repository.AddVideoAsync(video);
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                Assert.AreEqual(1, context.Videos.Count());
                Assert.AreEqual("URL", context.Videos.Single().Url);
            }
        }

        [TestMethod]
        public async Task GetVideosAsyncMethodTest()
        {
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>()
                .UseInMemoryDatabase(databaseName: "GetVideos").Options;

            //컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                //인메모리 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);

                var video1 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "빵원"
                };
                var video2 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "영일"
                };
                var video3 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "헤헤"
                };
                context.Videos.Add(video1);
                context.Videos.Add(video2);
                context.Videos.Add(video3);

                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var videos = await repository.GetAllAsync();

                Assert.AreEqual(3, videos.Count);
                Assert.AreEqual("영일", videos.Where(v => v.Id == 2).FirstOrDefault()?.Name);
            }
        }

        [TestMethod]
        public async Task GetVideoByIdAsyncMethodTest()
        {
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>()
                .UseInMemoryDatabase(databaseName: "GetVideoById").Options;

            //컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                //인메모리 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);

                var video1 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "빵원"
                };
                var video2 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "영일"
                };
                var video3 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "헤헤"
                };

                context.Videos.Add(video1);
                context.Videos.Add(video2);
                context.Videos.Add(video3);

                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var video = await repository.GetByIdAsync(3);

                Assert.AreEqual("강좌1", video.Title);
                Assert.AreEqual("헤헤", video.Name);
            }
        }

        [TestMethod]
        public async Task UpdateVideoAsyncMethodTest()
        {
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateVideo").Options;

            //컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                //인메모리 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);

                var video1 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "빵원"
                };
                var video2 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "영일"
                };
                var video3 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "헤헤"
                };

                context.Videos.Add(video1);
                context.Videos.Add(video2);
                context.Videos.Add(video3);

                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var updateVideo = await repository.GetByIdAsync(3);

                updateVideo.Title = "넥슨개발자";
                await repository.UpdateVideoAsync(updateVideo);
                context.SaveChanges();

                var video = await repository.GetByIdAsync(3);


                Assert.AreEqual("넥슨개발자", video.Title);
            }
        }

        [TestMethod]
        public async Task DeleteVideoAsyncMethodTest()
        {
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteVideo").Options;

            //컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                //인메모리 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);

                var video1 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "빵원"
                };
                var video2 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "영일"
                };
                var video3 = new Video
                {
                    Title = "강좌1",
                    Url = "URL",
                    Company = "BreadOne",
                    Name = "헤헤"
                };

                context.Videos.Add(video1);
                context.Videos.Add(video2);
                context.Videos.Add(video3);

                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                await repository.RemoveVideoAsync(1);
                context.SaveChanges();

                var videos = await repository.GetAllAsync();

                Assert.AreEqual(2, videos.Count);
                Assert.IsNull(videos.SingleOrDefault(video => video.Id == 1));
            }
        }
    }
}
