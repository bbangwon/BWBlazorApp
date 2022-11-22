using Microsoft.EntityFrameworkCore;

namespace MachineApp.Models.Tests
{
    [TestClass]
    public class MaediaRepositoryTest
    {
        [TestMethod]
        public async Task MediaRepositoryMethodAllTest()
        {
            //[0] DbContextOptions 개체 생성
            var options = new DbContextOptionsBuilder<MachineDbContext>()
                .UseInMemoryDatabase(databaseName: "MachineApp").Options;

            //[1] Add() Method Test
            //[1][1] DbContext 개체 생성 및 데이터 입력
            using (var context = new MachineDbContext(options))
            {
                //[?] Repository Object Creation
                var repository = new MediaRepository(context);
                var media = new Media
                {
                    Name = "[1] T7910",
                    Created = DateTime.Now,
                };

                await repository.AddMediaAsync(media);
                await context.SaveChangesAsync();
            }

            //[1][2] 제대로 입력되었는지 테스트

            using (var context = new MachineDbContext(options))
            {
                Assert.AreEqual(1, await context.Medias!.CountAsync());
                var media = await context.Medias!.Where(m => m.Id == 1).SingleOrDefaultAsync();
                Assert.AreEqual("[1] T7910", media!.Name);
            }

            //[2] GetAll() Method Test
            //[2][1] DbContext 개체 생성 및 추가 데이터 입력
            using (var context = new MachineDbContext(options))
            {
                await (new MediaRepository(context))
                    .AddMediaAsync(new Media
                {
                    Name = "[2] Rugged Extream",
                    Created = DateTime.Now,
                });

                await context.AddAsync(new Media
                {
                    Name = "[3] Alienware Aurora R8",
                    Created = DateTime.Now,
                });

                await context.SaveChangesAsync();
            }

            //[2][2] 제대로 출력되는지 테스트
            using (var context = new MachineDbContext(options))
            {
                var repository = new MediaRepository(context);
                var medias = await repository.GetMediasAsync(); //[?] 전체 레코드 가져오기

                Assert.AreEqual(3, medias.Count);
            }

            //[3] GetById() Method Test
            //[3][1] DbContext 개체 생성 및 추가 데이터 입력
            using (var context = new MachineDbContext(options))
            {
                await (new MediaRepository(context))
                    .AddMediaAsync(new Media
                    {
                        Name = "[4] Level 10 Limited Edition",
                        Created = DateTime.Now,
                    });

                await context.SaveChangesAsync();
            }

            //[3][2] 제대로 출력되는지 테스트
            using (var context = new MachineDbContext(options))
            {
                var repository = new MediaRepository(context);
                var alienware = await repository.GetMediaByIdAsync(3);

                Assert.IsTrue(alienware!.Name!.Contains("Alienware"));
                Assert.AreEqual("[3] Alienware Aurora R8", alienware!.Name!);
            }


            //[4] Edit() Method Test
            //[4][1] DbContext 개체 생성 및 추가 데이터 입력
            using (var context = new MachineDbContext(options))
            {
                await (new MediaRepository(context))
                    .AddMediaAsync(new Media
                    {
                        Name = "[5] Surface Pro",
                        Created = DateTime.Now,
                    });

                await context.SaveChangesAsync();
            }

            //[4][2] 제대로 수정되는지 테스트
            using (var context = new MachineDbContext(options))
            {
                var repository = new MediaRepository(context);
                var surface = await repository.GetMediaByIdAsync(5); 
                surface!.Name = "[5] 서피스 프로";
                await repository.EditMediaAsync(surface);
                await context.SaveChangesAsync();

                var newSurface = await repository.GetMediaByIdAsync(5);
                Assert.AreEqual("[5] 서피스 프로", newSurface!.Name);                
            }

            //[5] Delete() Method Test
            //[5][1] DbContext 개체 생성 및 추가 데이터 입력
            using (var context = new MachineDbContext(options))
            {
                
            }

            //[5][2] 제대로 삭제되는지 테스트
            using (var context = new MachineDbContext(options))
            {
                var repository = new MediaRepository(context);
                await repository.DeleteMediaAsync(5);
                await context.SaveChangesAsync();

                Assert.AreEqual(4, await context.Medias!.CountAsync());
                Assert.IsNull(await repository.GetMediaByIdAsync(5));
            }

            //[6] GetPaging() Method Test
            //[6][1] DbContext 개체 생성 및 추가 데이터 입력
            using (var context = new MachineDbContext(options))
            {

            }

            //[6][2] 제대로 페이징 가져오는지 테스트
            using (var context = new MachineDbContext(options))
            {
                var repository = new MediaRepository(context);
                var medias = await repository.GetMediasPageAsync(1, 2);

                Assert.AreEqual("[2] Rugged Extream", medias.Records.FirstOrDefault()!.Name);
                Assert.AreEqual(4, medias.TotalRecords);                
            }
        }
    }
}
