using CallScheduler.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CallScheduler.Models
{
    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;

        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return result;
        }
    }
}
