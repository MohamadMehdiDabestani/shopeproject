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

        public async Task AddCart(AddCartViewModel cart, int userId)
        {
            if (await _db.Product.AnyAsync(p => p.Id == cart.ProductId && p.Quantity >= cart.Count))
            {
                await _db.Cart.AddAsync(new Cart
                {
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
        public async Task AddWhishList(WhishList whishList)
        {
            if (await _db.Product.AnyAsync(w => w.Id == whishList.ProductId))
            {
                await _db.WhishList.AddAsync(whishList);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> AnyEmail(string email)
        {
            return await _db.User.AnyAsync(u => u.Email == email);
        }

        public async Task DeleteCart(int? id, int userId)
        {
            if (id > 0)
            {
                var item = await _db.Cart.SingleOrDefaultAsync(c => c.Id == id && c.UserId == userId);
                if (item != null)
                    _db.Remove(item);
            }
            else
            {
                var items = await _db.Cart.Where(c => c.UserId == userId).ToListAsync();
                _db.RemoveRange(items);
            }
            await _db.SaveChangesAsync();
        }

        public async Task DeleteWish(int? id, int userId)
        {
            if (id > 0)
            {
                var item = await _db.WhishList.SingleOrDefaultAsync(s => s.Id == id && s.UserId == userId);
                if (item != null)
                    _db.WhishList.Remove(item);
            }
            else
            {
                var items = await _db.WhishList.Where(w => w.UserId == userId).ToListAsync();
                _db.RemoveRange(items);
            }
            await _db.SaveChangesAsync();
        }

        public async Task<List<GetCartViewModel>> GetCart(int userId)
        {
            return await _db.Cart.Where(c => c.UserId == userId)
            .Include(p => p.Product)
            .Select(c => new GetCartViewModel()
            {
                Count = c.Count,
                Id = c.Id,
                ProductId = c.ProductId,
                ImageName = _common.GetImageUrl(c.Product.ProductImageName, "products"),
                Price = c.Product.Price,
                Title = c.Product.ProductName,
                AltImage = c.Product.AltImage,
                Quentity = c.Product.Quantity
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

        public async Task<List<GetWishListViewModel>> GetWishList(int userId)
        {
            return await _db.WhishList
            .Include(p => p.Product).ThenInclude(w => w.GroupProduct)
            .Include(p=> p.Product).ThenInclude(p=> p.Cart)
            .Where(w => w.UserId == userId)
            .Select(w => new GetWishListViewModel()
            {
                GroupId = w.Product.GroupId,
                GroupTitle = w.Product.GroupProduct.GroupTitle,
                ImageName = _common.GetImageUrl(w.Product.ProductImageName, "products"),
                AltImage = w.Product.AltImage,
                Price = w.Product.Price,
                ProductId = w.ProductId,
                Title = w.Product.ProductName,
                Id = w.Id,
                InCart = w.Product.Cart.Any(c=> c.ProductId == w.ProductId && c.UserId == userId)
            }).ToListAsync();
        }

        public async Task Update(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCart(UpdateCartViewModel model)
        {
            var cart = await _db.Cart.FindAsync(model.Id);
            if (cart != null)
            {
                cart.Count = model.Count;
                _db.Cart.UpdateRange(cart);
                await _db.SaveChangesAsync();
            }
        }
    }
}