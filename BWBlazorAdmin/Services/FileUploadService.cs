using Microsoft.AspNetCore.Components.Forms;

namespace BWBlazorAdmin.Services
{
    public interface IFileUploadService
    {
        Task UploadAsync(IReadOnlyList<IBrowserFile> files);
    }

    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment env;

        public FileUploadService(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public async Task UploadAsync(IReadOnlyList<IBrowserFile> files)
        {           
            foreach (var file in files)
            {
                try
                {
                    var trustedFileNameForFileStorage = Path.GetRandomFileName();
                    var path = Path.Combine(this.env.ContentRootPath, "Upload", trustedFileNameForFileStorage);

                    await using FileStream fs = new(path, FileMode.Create);
                    await file.OpenReadStream().CopyToAsync(fs);

                    Console.WriteLine($"파일 업로드 성공 {path}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }            
        }
    }
}
