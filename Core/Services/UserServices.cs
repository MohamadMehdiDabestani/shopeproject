using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ViewModels;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly ShopeDbContext _db;
        private readonly ICommonServices _common;
        public UserServices(ShopeDbContext db, ICommonServices common)
        {
            this._common = common;
            this._db = db;
        }

        public async Task AddCart(AddCartViewModel cart , int userId)
        {
            if(await _db.Product.AnyAsync(p=> p.Id == cart.ProductId))
            {
                await _db.Cart.AddAsync(new Cart{
                    Count = cart.Count,
                    ProductId = cart.ProductId,
                    UserId = userId
                });
                await _db.SaveChangesAsync();
            }
        }

        public async Task AddUser(User user)
        {
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> AnyEmail(string email)
        {
            return await _db.User.AnyAsync(u => u.Email == email);
        }

        public async Task<List<GetCartViewModel>> GetCart(int UserId)
        {
            return await _db.Cart.Where(c => c.UserId == UserId)
            .Select(c => new GetCartViewModel()
            {
                Count = c.Count,
                Id = c.Id,
                ProductId = c.ProductId,
                ImageName = _common.GetImageUrl(c.Product.ProductImageName, "products"),
                Price = c.Product.Price,
                Title = c.Product.ProductName,
                AltImage = c.Product.AltImage
            }).ToListAsync();
        }

        public async Task<AccountViewModel> GetUserAccount(int id)
        {
            return await _db.User.Where(u => u.Id == id)
            .Select(u => new AccountViewModel
            {
                Email = u.Email,
                Id = u.Id,
                UserName = u.UserName
            }).SingleOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.User.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _db.User.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByuserName(string userName)
        {
            return await _db.User.SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task Update(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}