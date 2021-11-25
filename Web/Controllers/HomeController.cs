using System.Threading;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Core.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _post;
        private readonly ICommonServices _common;
        private readonly IProductServices _product;
        public HomeController(IPostServices post, ICommonServices common, IProductServices product)
        {
            this._product = product;
            this._common = common;
            this._post = post;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _product.GetHome();
            return View(model);
        }
         
        [Route("/Post")]
        public async Task<IActionResult> GetAll(int pageId = 1, string title = "")
        {
            var post = await _post.GetAllPost(1, pageId, title, true);
            var model = post.Item1.Select(p => new GetAllPostViewModel
            {
                AltImage = p.AltImage,
                Description = p.PostDescription,
                ImageName = _common.GetImageUrl(p.ImageName, "post"),
                PostTitle = p.PostTitle,
                PostId = p.Id,
                CreateDate = p.CreateDate.ToShamsi(),
                CommentCount = p.comment.Count,
            }).ToList();
            ViewBag.title = title;
            ViewBag.pageId = pageId;
            return View(Tuple.Create(model, post.Item2));
        }
        [Route("/Post/{id}")]

        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _post.GetPost(id, true);
            if (post == null)
                return NotFound();
            var model = new GetPostViewModel
            {
                CreateDate = post.CreateDate.ToShamsi(),
                ImageName = _common.GetImageUrl(post.ImageName, "post"),
                Tags = post.Tags,
                Text = post.Text,
                Title = post.PostTitle,
                AltImage = post.AltImage,
                PostId = post.Id,
                CommentCount = post.comment.Count,
                Comments = post.comment.Select(c => new GetCommentViewModel
                {
                    Avatar = _common.GetImageUrl(c.user.UserAvatar, "user"),
                    CommentId = c.Id,
                    CreateDate = c.CreateDate.ToShamsi(),
                    ParentId = c.ParentId,
                    Text = c.Text,
                    UserName = c.user.UserName
                }).ToList(),

            };
            return View(model);
        }
        [HttpPost]
        [Route("/Post/AddComment")]
        [Authorize]
        public async Task<IActionResult> AddComment(AddCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    ParentId = model.ParentId == 0 ? null : model.ParentId,
                    CreateDate = DateTime.Now,
                    PostId = model.PostId,
                    Text = model.Text,
                    UserId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value),
                };
                await _post.AddComment(comment);
                return Redirect($"/post/{model.PostId}?succes=true");
            }
            return Redirect($"/post/{model.PostId}?error=true");
        }

    }

}
