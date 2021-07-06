using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public interface ICommonServices
    {
        Tuple<int, int, int> Pagination(int take, int pageId, int count);

        Task<string> UploadImage(IFormFile image, string cat);

        string GetImageUrl(string imageName, string cat);

        void DeleteImage(string imageName, string cat);

        bool FilterImage(string format);
    }
}