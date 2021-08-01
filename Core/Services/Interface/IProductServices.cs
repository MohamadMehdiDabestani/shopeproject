using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Models;
using Core.ViewModels;
using System;

namespace Core.Services
{
    public interface IProductServices
    {
        Task AddProduct(Product product);
        
        Task<Tuple<List<Product> , int>> GetAll(int take , int pageId , bool relation , string? title , int? groupId , int? maxPrice , int? minPrice);

        Task<List<Group>> GetSubGroup(int id);
        
        Task<Product> GetProduct(int id , bool isRelation);

        Task UpdateProduct(Product product);

        Task<List<ProductProperty>> GetProperty();

        Task AddOrEditePropertiy(ProductProperty model);

        Task<ProductProperty> GetProp(int id);

        Task DeleteProp(ProductProperty model);

        Task DeleteProduct(Product product);

        Task<List<ProductPropertiyViewModel>> GetPropertiyProduct(int id);

        Task AddPropertiyToProduct(AddPropertiyToProductViewModel model);
        
        Task DeletePropertiyProduct(ProductPropertyRelation model);

        Task<ProductPropertyRelation> GetSinglePropProduct(int id);

        Task<List<GetGalleryViewModel>> GetGallery(int id);

        Task AddGallery(Gallery gallery);

        Task<Gallery> GetSingleGallery(int galleryId , int productId);

        Task DeleteGallery(Gallery gallery);

        Task AddReview(AddReviewViewModel model , int userId);

        Task<bool> CheckProductInCart(int userId , int productId);

        Task<bool> CheckProductInWhishList(int productId , int userId);

        Task<HomeViewModel> GetHome();
        
        Task<List<CarouselItemViewModel>> GetCarousel();
    }
}