using System.Collections.Generic;
using System.Threading.Tasks;
using Core.ViewModels;
using Data.Models;

namespace Core.Services
{
    public interface IUserServices
    {
        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByuserName(string userName);

        Task AddUser(User user);

        Task Update(User user);

        Task<bool> AnyEmail(string email);

        Task<AccountViewModel> GetUserAccount(int id);

        Task<List<GetCartViewModel>> GetCart(int userId);

        Task DeleteWish(int? id , int userId);
        Task DeleteCart(int? id , int userId);
        Task UpdateCart(UpdateCartViewModel model);

        Task AddCart(AddCartViewModel cart , int userId);
        
        Task AddWhishList(WhishList whishList );

        Task<List<GetWishListViewModel>> GetWishList(int userId);
    }
}