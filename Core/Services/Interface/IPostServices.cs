using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.ViewModels;
using Data.Models;

namespace Core.Services
{
    public interface IPostServices
    {
        Task<Tuple<List<Post>,int>> GetAllPost(int pageId , int take , string? title , bool relation);
        
        Task<Post> GetPost(int id , bool relation);

        Task AddPost(Post post);

        Task Update(Post post);

        Task DeletePost(Post post);

        Task AddComment(Comment comment);
        
        Task<List<string>> GetSearchTitle(string title);
    }
}