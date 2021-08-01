
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.ViewModels;
using Data.Models;

namespace Core.Services
{
    public interface IAdminServices
    {
        Task<List<Group>> GetAllGroup();

        Task<Group> GetGroup(int id);

        Task DeleteGroup(Group group);

        Task AddOrUpdateGroup(Group group);
        
        #nullable enable
        Task<List<GetAllOrdersViewModel>> GetAllOrders(string? filter);

        Task UpdateOrder(EditeOrderViewModel order);

        Task<List<GetCarouselAdminViewModel>> GetCarousel();
        
        Task AddCarousel(Carousel carousel);
        Task DeleteCarousel(int id);
    }
}