using System.IO;
using System;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class CommonServices : ICommonServices
    {
        private readonly IConfiguration _config;
        public CommonServices(IConfiguration config)
        {
            this._config = config;
        }

        public void DeleteImage(string imageName, string cat)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", cat, imageName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
        }

        public bool FilterImage(string format)
        {
            if (format == ".jpg" || format == ".svg" || format == ".png")
                return true;
            return false;
        }

        public string GetImageUrl(string imageName, string cat)
        {
            var url = _config["Url"];
            return $"{url}images/{cat}/{imageName}";
        }

        public Tuple<int, int , int> Pagination(int take, int pageId, int count)
        {

            if (take <= 0)
                take = 5;
            int skip = (pageId - 1) * take;
            if (pageId > (count / take))
            {
                if ((count % take) > 0)
                {
                    pageId = (count / take) + 1;
                }
                else
                {
                    pageId = count / take;
                }
            }
            var pageCount = count / take;
            if ((count % take) > 0)
                pageCount += 1;
            return Tuple.Create(take, skip , pageCount);
        }

        public async Task<string> UploadImage(IFormFile image, string cat)
        {
            var imageName = RandowString.GetString(140) + Path.GetExtension(image.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", cat, imageName);
            using (var s = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(s);
            }
            var le = imageName.Length;
            return imageName;
        }
    }
}