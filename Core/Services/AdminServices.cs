using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ShopeDbContext _db;
        public AdminServices(ShopeDbContext db)
        {
            this._db = db;
        }

        public async Task AddOrUpdateGroup(Group group)
        {
            var check = await _db.Group.AnyAsync(g => g.GroupId == group.GroupId);
            if (check)
            {
                _db.Update(group);
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

        public async Task<Group> GetGroup(int id)
        {
            return await _db.Group.FindAsync(id);
        }
    }
}