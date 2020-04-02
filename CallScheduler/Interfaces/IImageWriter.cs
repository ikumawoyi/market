using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CallScheduler.Interfaces
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
    }
}
