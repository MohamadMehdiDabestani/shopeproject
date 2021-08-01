using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ViewModels;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ShopeDbContext _db;
        private readonly ICommonServices _common;
        public AdminServices(ShopeDbContext db, ICommonServices common)
        {
            this._common = common;
            this._db = db;
        }

        public async Task AddOrUpdateGroup(Group group)
        {
            var check = await _db.Group.AnyAsync(g => g.GroupId == group.GroupId);
            if (check)
            {
                var egroup = await _db.Group.Include(g=> g.SubId).SingleOrDefaultAsync(g=> g.GroupId == group.GroupId);
                egroup.GroupTitle = group.GroupTitle; 
                _db.Update(egroup);
            }
            else
            {
                await _db.AddAsync(group);
            }
            await _db.SaveChangesAsync();
        }

        public async Task DeleteGroup(Group group)
        {
            _db.Group.Remove(group);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Group>> GetAllGroup()
        {
            return await _db.Group.Include(g => g.SubId).ToListAsync();
        }

        public async Task<List<GetAllOrdersViewModel>> GetAllOrders(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return await _db.Factor.Select(f => new GetAllOrdersViewModel()
                {
                    Count = f.Count,
                    CreateDate = f.CreateDate.ToShamsi(),
                    Price = f.Price,
                    Status = f.Status,
                    Id = f.Id
                }).ToListAsync();
            }
            return await _db.Factor.Where(f => f.Status == "DELIVERED").Select(f => new GetAllOrdersViewModel()
            {
                Status = f.Status,
                Count = f.Count,
                CreateDate = f.CreateDate.ToShamsi(),
                Price = f.Price,
                Id = f.Id
            }).ToListAsync();
        }

        public async Task<List<GetCarouselAdminViewModel>> GetCarousel()
        {
            return await _db.Carousel.Select(c => new GetCarouselAdminViewModel()
            {
                Id = c.Id,
                Image = _common.GetImageUrl(c.Image , "carousel"),
                Link = c.Link,
                Price = c.Price,
                Text = c.Text,
                Title = c.Title
            }).ToListAsync();
            
        }

        public async Task<Group> GetGroup(int id)
        {
            return await _db.Group.FindAsync(id);
        }

        public async Task AddCarousel(Carousel carousel)
        {
            await _db.Carousel.AddAsync(carousel);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateOrder(EditeOrderViewModel order)
        {
            var o = await _db.Factor.FindAsync(order.Id);
            if (o != null)
            {
                o.Status = order.Status;
                _db.Update(o);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteCarousel(int id)
        {
            var item = await _db.Carousel.FindAsync(id);
            if(item != null){
                _db.Remove(item);
                await _db.SaveChangesAsync();
            }
        }
    }
}