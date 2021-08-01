using System.Runtime.CompilerServices;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Core.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Core;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Role(1)]
    public class ProductController : Controller
    {
        private readonly IProductServices _product;
        private readonly ICommonServices _common;
        private readonly IAdminServices _admin;
        public ProductController(IProductServices product, ICommonServices common, IAdminServices admin)
        {
            this._admin = admin;
            this._common = common;
            this._product = product;
        }
        [Route("/Admin/GetSubGroup/{id}")]
        public async Task<IActionResult> GetSubGroup(int id)
        {
            var list = new List<SelectListItem>() {
                new SelectListItem(){Value = "" ,Text="Choose"}
            };
            var group = await _product.GetSubGroup(id);
            var res = group.Select(g => new SelectListItem
            {
                Text = g.GroupTitle,
                Value = g.GroupId.ToString()
            });
            list.AddRange(res);
            return Json(new SelectList(list, "Value", "Text"));
        }
        [Route("/Admin/Productlist")]
        public async Task<IActionResult> Get(int take, int pageId = 1)
        {
            var product = await _product.GetAll(take, pageId, false, "" , 0 , 0 ,0);
            var model = product.Item1.Select(p => new GetAllAdminProductViewModel
            {
                AltImage = p.AltImage,
                ImageName = _common.GetImageUrl(p.ProductImageName, "products"),
                ProductId = p.Id,
                ProductName = p.ProductName,
            }).ToList();
            return View(model);
        }

        [Route("/Admin/AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }
        [Route("/Admin/AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_common.FilterImage(Path.GetExtension(model.Image.FileName)))
                {
                    ViewBag.Error = "Please Enter a valid file";
                    return View(model);
                }
                var product = new Product
                {
                    GroupId = model.GroupId,
                    Price = model.Price,
                    ProductBrowserDescription = model.ProductBrowserDescription,
                    ProductBrowserTitle = model.ProductBrowserTitle,
                    ProductImageName = await _common.UploadImage(model.Image, "products"),
                    ProductName = model.ProductName,
                    ProductText = model.ProductText,
                    Quantity = model.Quantity,
                    SubGroupId = model.SubGroupId,
                    Tags = model.Tags,
                    CreateDate = DateTime.Now,
                    AltImage = model.AltImage
                };
                await _product.AddProduct(product);
                return Redirect("/Admin/productlist");
            }
            return View(model);
        }
        [Route("/Admin/EditeProduct/{id}")]
        public async Task<IActionResult> Edite(int id)
        {
            var product = await _product.GetProduct(id, false);
            if (product == null)
                return NotFound();
            var model = new EditeProductViewModel
            {
                AltImage = product.AltImage,
                Price = product.Price,
                ProductBrowserDescription = product.ProductBrowserDescription,
                ProductBrowserTitle = product.ProductBrowserTitle,
                ProductId = product.Id,
                ProductName = product.ProductName,
                ProductText = product.ProductText,
                Quantity = product.Quantity,
                Tags = product.Tags,
                GroupId = product.GroupId,
                SubGroupId = product.SubGroupId
            };
            return View(model);
        }
        [Route("/Admin/EditeProduct")]
        [HttpPost]
        public async Task<IActionResult> Edite(EditeProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _product.GetProduct(model.ProductId, false);
                if (product == null)
                    return null;
                if (model.Image != null)
                {
                    if (!_common.FilterImage(Path.GetExtension(model.Image.FileName)))
                    {
                        ViewBag.Error = "Please enter a valid file";
                        return View(model);
                    }
                    _common.DeleteImage(product.ProductImageName, "products");
                }
                product.AltImage = model.AltImage;
                product.Price = model.Price;
                product.ProductBrowserDescription = model.ProductBrowserDescription;
                product.ProductBrowserTitle = model.ProductBrowserTitle;
                product.ProductName = model.ProductName;
                product.ProductText = model.ProductText;
                product.Quantity = model.Quantity;
                product.Tags = model.Tags;
                product.GroupId = model.GroupId;
                product.SubGroupId = model.SubGroupId;
                await _product.UpdateProduct(product);
                return Redirect("/Admin/productlist");
            }
            return View(model);
        }
        [Route("/Admin/Propertiy")]
        public async Task<IActionResult> Propertiy()
        {
            var model = await _product.GetProperty();
            return View(model);
        }
        [Route("/Admin/AddOrUpdatePropertiy")]
        public async Task<IActionResult> AddOrEdite(PropertiyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var propertiy = new ProductProperty
                {
                    Id = model.Id,
                    ProductPropertyTitle = model.ProductPropertyTitle
                };
                await _product.AddOrEditePropertiy(propertiy);
                return Redirect("/admin/Propertiy");
            }
            return Redirect("/admin/Propertiy");
        }
        [Route("/Admin/Propertiy/Delete/{id}")]
        public async Task<IActionResult> DeletePropertiy(int id)
        {
            var prop = await _product.GetProp(id);
            if (prop != null)
            {
                await _product.DeleteProp(prop);
                return Redirect("/Admin/Propertiy");
            }
            return NotFound();
        }
        [Route("/Admin/DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _product.GetProduct(id, false);
            if (product == null)
                return NotFound();
            _common.DeleteImage(product.ProductImageName, "products");
            await _product.DeleteProduct(product);
            return Redirect("/admin/productlist");
        }
        [Route("/Admin/Product/PropertiyList/{id}")]
        public async Task<IActionResult> PropertiyProduct(int id)
        {
            ViewBag.ID = id;
            var model = await _product.GetPropertiyProduct(id);
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/AddOrUpdatePropertiyProduct")]
        public async Task<IActionResult> AddPropertiyToProduct(AddPropertiyToProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _product.AddPropertiyToProduct(model);
                return Redirect($"/Admin/Product/PropertiyList/{model.ProducId}");
            }
            return BadRequest();
        }
        [Route("/Admin/PropertiyProduct/Delete/{PP_ID}/{ProductId}")]
        public async Task<IActionResult> DeletePropertiyProduct(int PP_ID, int ProductId)
        {
            var propertiy = await _product.GetSinglePropProduct(PP_ID);
            if (propertiy == null)
                return NotFound();
            await _product.DeletePropertiyProduct(propertiy);
            return Redirect($"/Admin/Product/PropertiyList/{ProductId}");
        }
        [Route("/Admin/product/Gallery/{id}")]
        public async Task<IActionResult> Gallery(int id)
        {
            ViewBag.List = await _product.GetGallery(id);
            ViewBag.ID = id;
            var model = new AddGalleryViewModel
            {
                ProductId = id
            };
            return View(model);
        }
        [Route("/Admin/AddGalleryProduct")]
        [HttpPost]
        public async Task<IActionResult> AddGallery(AddGalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var gallery = new Gallery
                {
                    AltImage = model.AltImage,
                    ImageName = await _common.UploadImage(model.Image, "products/gallery"),
                    ProductId = model.ProductId
                };
                await _product.AddGallery(gallery);
                return Redirect($"/Admin/product/Gallery/{model.ProductId}");
            }
            return BadRequest();
        }
        [Route("/Admin/Product/DeleteGallery/{gId}/{pId}")]
        public async Task<IActionResult> DeleteGallery(int gId, int pId)
        {
            var gallery = await _product.GetSingleGallery(gId, pId);
            if (gallery == null)
                return NotFound();
            await _product.DeleteGallery(gallery);
            _common.DeleteImage(gallery.ImageName, "products/gallery");
            return Redirect($"/Admin/product/Gallery/{pId}");
        }
    }
}
