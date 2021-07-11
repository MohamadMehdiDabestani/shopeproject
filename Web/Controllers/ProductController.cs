using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _product;
        private readonly ICommonServices _common;
        public ProductController(IProductServices product, ICommonServices common)
        {
            this._common = common;
            this._product = product;
        }
        [Route("/product")]
        public async Task<IActionResult> GetAll(int pageId = 1, string title = "", int groupId = 0, int maxPrice = 0, int minPrice = 0)
        {
            var list = await _product.GetAll(12, pageId, true, title, groupId, maxPrice, minPrice);
            var model = list.Item1.Select(p => new GetAllProductViewModel()
            {
                Id = p.Id,
                AltImage = p.AltImage,
                GroupTitle = p.GroupProduct.GroupTitle,
                ImageName = _common.GetImageUrl(p.ProductImageName, "products"),
                Name = p.ProductName,
                Price = p.Price.ToString("#,0"),
                Text = p.ProductText
            }).ToList();
            ViewBag.groupId = groupId;
            ViewBag.maxPrice = maxPrice;
            ViewBag.minPrice = minPrice;
            ViewBag.pageId = pageId;
            return View(Tuple.Create(model, list.Item2));
        }
        [Route("/product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _product.GetProduct(id, true);
            if (product == null)
                return NotFound();
            ViewBag.Product = new GetProductViewModel
            {
                AltImage = product.AltImage,
                Gallery = product.Gallery.Select(g => new GetGalleryProductViewModel()
                {
                    AltImage = g.AltImage,
                    ImageName = _common.GetImageUrl(g.ImageName, "products/gallery"),
                }).ToList(),
                GroupTitle = product.GroupProduct.GroupTitle,
                Id = product.Id,
                ImageName = _common.GetImageUrl(product.ProductImageName, "products"),
                Name = product.ProductName,
                Price = product.Price.ToString("#,0"),
                Propertiy = product.ProductPropertyRelation.Select(r => new GetPropertiyProductViewModel
                {
                    Title = r.ProductProperty.ProductPropertyTitle,
                    Value = r.Value
                }).ToList(),
                Text = product.ProductText,
                SubGroupTitle = product.SubGroupProduct != null ? product.SubGroupProduct.GroupTitle : null,
                GroupId = product.GroupId,
                SunGroupId = product.SubGroupId != null ? product.SubGroupId : 0,
                BTitle = product.ProductBrowserTitle,
                BDescription = product.ProductBrowserDescription,
                Review = product.Review != null ? product.Review.Where(p=> p.ProductId == product.Id)
                .Select(p=> new GetReview{
                    CreateDate = p.CreateDate.ToShamsi(),
                    Text = p.ReviewText,
                    UserName = p.user.UserName
                }).ToList() : null,
                Count = product.Quantity,
                IsInCart = User.Identity.IsAuthenticated ? await _product.CheckProductInCart(int.Parse(User.Claims.First(u=> u.Type == ClaimTypes.NameIdentifier).Value) , product.Id) : false,
                IsInWhishList = User.Identity.IsAuthenticated ? await _product.CheckProductInWhishList(product.Id , int.Parse(User.Claims.First(u=> u.Type == ClaimTypes.NameIdentifier).Value)) : false
            };
            return View();
        }
        [Route("/product/{id}")]
        [HttpPost]
        public async Task<IActionResult> GetProduct(AddReviewViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _product.AddReview(model , int.Parse(User.Claims.First(u=> u.Type == ClaimTypes.NameIdentifier).Value));
                return Redirect($"/product/{model.ProductId}?succes=true");
            }
            return Redirect($"/product/{model.ProductId}?error=true");
        }
    }
}
