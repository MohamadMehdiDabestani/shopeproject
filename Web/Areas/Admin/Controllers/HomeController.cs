using System.Collections.Generic;
using System.Security.Claims;
using System;

using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Core.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Role(1)]
    public class HomeController : Controller
    {
        private readonly IAdminServices _admin;
        private readonly IPostServices _post;
        private readonly ICommonServices _common;
        public HomeController(IAdminServices admin, IPostServices post, ICommonServices common)
        {
            this._common = common;
            this._post = post;
            this._admin = admin;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Group
        [Route("/Admin/Group")]
        public async Task<ActionResult> Group()
        {
            var model = await _admin.GetAllGroup();
            return View(model);
        }
        [Route("/Admin/AddOrUpdateGroup")]
        [HttpPost]
        public async Task<ActionResult> Group(AddOrUpdateGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var group = new Group
                {
                    GroupId = model.GroupId,
                    GroupTitle = model.GroupTitle,
                    ParentId = model.ParentId
                };
                await _admin.AddOrUpdateGroup(group);
                return Redirect("/Admin/Group");
            }
            return NotFound();
        }
        [Route("/Admin/Group/Delte/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await _admin.GetGroup(id);
            if (group == null)
                return NotFound();
            await _admin.DeleteGroup(group);
            return Redirect("/Admin/Group");
        }

        #endregion

        #region Post
        [Route("/Admin/Post")]
        public async Task<ActionResult> Posts(int take, string title, int pageId = 1)
        {
            var res = await _post.GetAllPost(take, pageId, title, false);
            var model = res.Item1.Select(p => new GetAllPostAdminViewModel()
            {
                ImageName = _common.GetImageUrl(p.ImageName, "post"),
                PostId = p.Id,
                PostTitle = p.PostTitle,
                AltImage = p.AltImage
            }).ToList();
            ViewBag.pageId = pageId;
            ViewBag.take = take;
            return View(Tuple.Create(model, res.Item2));
        }
        [Route("/Admin/AddPost")]
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/AddPost")]
        public async Task<IActionResult> AddPost(AddPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_common.FilterImage(Path.GetExtension(model.Image.FileName)))
                {
                    ViewBag.Error = "فایل وارد شده معتبر نیست";
                    return View(model);
                }
                var post = new Post
                {
                    AltImage = model.AltImage,
                    BrowserDescription = model.BrowserDescription,
                    BrowserTitle = model.BrowserTitle,
                    CreateDate = DateTime.Now,
                    PostDescription = model.PostDescription,
                    PostTitle = model.PostTitle,
                    Tags = model.Tags,
                    Text = model.Text,
                    UserId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value)
                };
                post.ImageName = await _common.UploadImage(model.Image, "post");
                await _post.AddPost(post);
                return Redirect("/Admin/Post");
            }
            return View(model);
        }
        [Route("/Admin/EditePost/{id}")]
        public async Task<IActionResult> GetEditePost(int id)
        {
            var post = await _post.GetPost(id, false);
            var model = new EditePostViewModel
            {
                AltImage = post.AltImage,
                BrowserDescription = post.BrowserDescription,
                BrowserTitle = post.BrowserTitle,

                PostDescription = post.PostDescription,
                PostId = post.Id,
                PostTitle = post.PostTitle,
                Tags = post.Tags,
                Text = post.Text,
            };
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/EditePost")]
        public async Task<IActionResult> EditePost(EditePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = await _post.GetPost(model.PostId, false);
                if (post == null)
                    return NotFound();
                post.PostTitle = model.PostTitle;
                post.PostDescription = model.PostDescription;
                post.BrowserDescription = model.BrowserDescription;
                post.AltImage = model.AltImage;
                post.Text = model.Text;
                post.Tags = model.Tags;
                if (model.Image != null)
                {
                    _common.DeleteImage(post.ImageName, "post");
                    post.ImageName = await _common.UploadImage(model.Image, "post");
                }
                await _post.Update(post);
                return Redirect("/Admin/Post");
            }
            return View(model);
        }
        [Route("/Admin/DeletePost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _post.GetPost(id, false);
            if (post == null)
                return NotFound();
            await _post.DeletePost(post);
            return Redirect("/admin/post");
        }
        #endregion
        [Route("/Admin/Order")]
        public async Task<IActionResult> GetAllOrders(string completed)
        {
            var model = await _admin.GetAllOrders(completed);
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/UpdateStatusOrder")]
        public async Task<IActionResult> EditeOrder(EditeOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _admin.UpdateOrder(model);
                return Redirect("/Admin/Order");
            }
            return BadRequest();
        }
        [Route("/Admin/Carousel")]
        public async Task<IActionResult> GetCarousel()
        {
            var model = await _admin.GetCarousel();
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/AddCarousel")]
        public async Task<IActionResult> AddCarousel(AddCarouselViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_common.FilterImage(Path.GetExtension(model.Image.FileName)))
                    return Redirect("/Admin/Carousel?error=true");
                var carousel = new Carousel()
                {
                    Image = await _common.UploadImage(model.Image, "carousel"),
                    Link = model.Link,
                    Price = model.Price,
                    Text = model.Text,
                    Title = model.Title,
                };
                await _admin.AddCarousel(carousel);
                return Redirect("/Admin/Carousel");
            }
            return Redirect("/Admin/Carousel?error=true");
        }
        [Route("/Admin/DeleteCarousel/{id}")]
        public async Task<IActionResult> DeleteCarousel(int id)
        {
            await _admin.DeleteCarousel(id);
            return Redirect("/Admin/Carousel");
        }
    }
}
