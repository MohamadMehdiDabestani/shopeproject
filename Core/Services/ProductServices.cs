using System.Reflection.Metadata;
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
    public class ProductServices : IProductServices
    {
        private readonly ShopeDbContext _db;
        private readonly ICommonServices _common;
        public ProductServices(ShopeDbContext db, ICommonServices common)
        {
            this._common = common;
            this._db = db;
        }

        public async Task AddOrEditePropertiy(ProductProperty model)
        {
            if (await _db.ProductPropertiy.AnyAsync(p => p.Id == model.Id))
            {
                _db.ProductPropertiy.Update(model);
            }
            else
            {
                await _db.ProductPropertiy.AddAsync(model);
            }
            await _db.SaveChangesAsync();
        }

        public async Task AddProduct(Product product)
        {
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductProperty> GetProp(int id)
        {
            return await _db.ProductPropertiy.FindAsync(id);
        }

        public async Task<Tuple<List<Product>, int>> GetAll(int take, int pageId, bool relation = false, string? title = "", int? groupId = 0, int? maxPrice = 0, int? minPrice = 0)
        {
            IQueryable<Product> p = _db.Product.Where(p => p.Quantity > 0);

            if (!string.IsNullOrEmpty(title))
                p = p.Where(p => p.ProductName.Contains(title));
            if (groupId > 0)
                p = p.Where(p => p.GroupId == groupId || p.SubGroupId == groupId);
            if (maxPrice > 0)
                p = p.Where(p => p.Price <= maxPrice);
            if (minPrice > 0)
                p = p.Where(p => p.Price >= minPrice);
            var pagination = _common.Pagination(take, pageId, await p.CountAsync());
            var res = relation ?
            await p.Include(p => p.GroupProduct).Skip(pagination.Item2).Take(pagination.Item1).ToListAsync()
            : await p.Skip(pagination.Item2).Take(pagination.Item1).ToListAsync();
            return Tuple.Create(res, pagination.Item3);
        }

        public async Task<Product> GetProduct(int id, bool isRelation)
        {
            return isRelation ? await _db.Product
            .Where(p => p.Quantity > 0).Include(p => p.GroupProduct)
            .Include(p => p.Gallery)
            .Include(p => p.SubGroupProduct)
            .Include(p => p.Review)
            .ThenInclude(p => p.user)
            .Include(p => p.ProductPropertyRelation).ThenInclude(p => p.ProductProperty).SingleOrDefaultAsync(p => p.Id == id) :
            await _db.Product.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProductProperty>> GetProperty()
        {
            return await _db.ProductPropertiy.ToListAsync();
        }

        public async Task<List<Group>> GetSubGroup(int id)
        {
            return await _db.Group.Where(g => g.ParentId == id).ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProp(ProductProperty model)
        {
            _db.Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ProductPropertiyViewModel>> GetPropertiyProduct(int id)
        {
            return await _db.ProductPropertyRelations.Include(p => p.ProductProperty)
            .Where(p => p.ProductId == id)
            .Select(p => new ProductPropertiyViewModel
            {
                ProductId = p.ProductId,
                PropertiyId = p.ProductPropertId,
                Title = p.ProductProperty.ProductPropertyTitle,
                Value = p.Value,
                PP_ID = p.PP_ID
            }).ToListAsync();
        }

        public async Task AddPropertiyToProduct(AddPropertiyToProductViewModel model)
        {
            await _db.ProductPropertyRelations.AddAsync(new ProductPropertyRelation
            {
                ProductId = model.ProducId,
                ProductPropertId = model.PropertiyId,
                Value = model.PropertiyValue
            });
            await _db.SaveChangesAsync();
        }

        public async Task DeletePropertiyProduct(ProductPropertyRelation model)
        {
            _db.Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductPropertyRelation> GetSinglePropProduct(int id)
        {
            return await _db.ProductPropertyRelations.FindAsync(id);
        }

        public async Task<List<GetGalleryViewModel>> GetGallery(int id)
        {
            return await _db.Gallery.Where(g => g.ProductId == id)
            .Select(g => new GetGalleryViewModel
            {
                AltImage = g.AltImage,
                GalleryId = g.Id,
                ImageName = _common.GetImageUrl(g.ImageName, "products/gallery"),
                ProductId = g.ProductId
            }).ToListAsync();
        }

        public async Task AddGallery(Gallery gallery)
        {
            await _db.Gallery.AddAsync(gallery);
            await _db.SaveChangesAsync();
        }

        public async Task<Gallery> GetSingleGallery(int galleryId, int productId)
        {
            return await _db.Gallery.SingleOrDefaultAsync(g => g.Id == galleryId && g.ProductId == productId);
        }

        public async Task DeleteGallery(Gallery gallery)
        {
            _db.Gallery.Remove(gallery);
            await _db.SaveChangesAsync();
        }

        public async Task AddReview(AddReviewViewModel model, int userId)
        {
            _db.Reviews.Add(new Reviews()
            {
                CreateDate = DateTime.Now,
                ProductId = model.ProductId,
                ReviewText = model.Text,
                UserId = userId
            });
            await _db.SaveChangesAsync();
        }

        public async Task<bool> CheckProductInCart(int userId, int productId)
        {
            return !(await _db.Cart.AnyAsync(c => c.ProductId == productId && c.UserId == userId));
        }

        public async Task<bool> CheckProductInWhishList(int productId, int userId)
        {
            return !(await _db.WhishList.AnyAsync(w => w.UserId == userId && productId == w.ProductId));
        }

        public async Task<HomeViewModel> GetHome()
        {
            IQueryable<Product> p = _db.Product;
            var res = new HomeViewModel();
            res.Random = await p.OrderBy(r => Guid.NewGuid()).Take(2)
            .Include(r => r.GroupProduct)
            .Select(r => new GetAllProductViewModel()
            {
                AltImage = r.AltImage,
                GroupTitle = r.GroupProduct.GroupTitle,
                Id = r.Id,
                ImageName = _common.GetImageUrl(r.ProductImageName, "products"),
                Name = r.ProductName,
                Price = r.Price.ToString("#,0"),
            }).ToListAsync();
            res.LastProduct = await p.OrderBy(r => r.CreateDate)
            .Include(r => r.GroupProduct)
            .Select(r => new GetAllProductViewModel()
            {
                AltImage = r.AltImage,
                GroupTitle = r.GroupProduct.GroupTitle,
                Id = r.Id,
                ImageName = _common.GetImageUrl(r.ProductImageName, "products"),
                Name = r.ProductName,
                Price = r.Price.ToString("#,0"),
                Text = r.ProductText,
            }).ToListAsync();
            return res;
        }

        public async Task<List<CarouselItemViewModel>> GetCarousel()
        {
            return await _db.Carousel.Select(c => new CarouselItemViewModel()
            {
                ImageName = _common.GetImageUrl(c.Image, "carousel"),
                Link = c.Link,
                Price = c.Price,
                Text = c.Text,
                Title = c.Title,
            }).ToListAsync();
        }
    }
}