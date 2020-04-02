using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CallScheduler.Interfaces
{
    public interface IImageHandler
    {
        Task<string> UploadImage(IFormFile file);
    }
}
