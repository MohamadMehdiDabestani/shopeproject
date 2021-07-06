using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ViewModels;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class PostServices : IPostServices
    {
        private readonly ShopeDbContext _db;
        private readonly ICommonServices _common;
        public PostServices(ShopeDbContext db, ICommonServices common)
        {
            this._common = common;
            this._db = db;
        }

        public async Task AddComment(Comment comment)
        {
            await _db.Comment.AddAsync(comment);
            await _db.SaveChangesAsync();
        }

        public async Task AddPost(Post post)
        {
            await _db.AddAsync(post);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePost(Post post)
        {
            _db.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<Tuple<List<Post>, int>> GetAllPost(int take, int pageId, string? title, bool relation)
        {
            IQueryable<Post> p = _db.Post;
            if (!string.IsNullOrEmpty(title))
            {
                p = p.Where(p => p.PostTitle.Contains(title));
            }
            var pCount = await p.CountAsync();
            var paging = _common.Pagination(take, pageId, pCount);
            var list = relation ? await p.Include(p=> p.comment).OrderBy(c => c.CreateDate).Skip(paging.Item2).Take(paging.Item1).ToListAsync()
            : await p.OrderBy(c => c.CreateDate).Skip(paging.Item2).Take(paging.Item1).ToListAsync();
            return Tuple.Create(list, paging.Item3);
        }

        public async Task<Post> GetPost(int id, bool relation)
        {
            return relation ? await _db.Post.Include(p => p.comment)
            .ThenInclude(p => p.user)
            .SingleOrDefaultAsync(p => p.Id == id) : await _db.Post.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<string>> GetSearchTitle(string title)
        {
            return await _db.Post.Where(p=> p.PostTitle.Contains(title))
            .Select(p=> p.PostTitle)
            .ToListAsync();
        }

        public async Task Update(Post post)
        {
            _db.Update(post);
            await _db.SaveChangesAsync();
        }
    }
}