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

        Task<List<GetCartViewModel>> GetCart(int UserId);

        Task AddCart(AddCartViewModel cart , int userId);
    }
}