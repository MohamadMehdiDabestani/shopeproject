using System.Linq;
using Data;

namespace Core.Services
{
    public class RoleServices : IRoleService
    {
        private readonly ShopeDbContext _db;
        public RoleServices(ShopeDbContext db)
        {
            this._db = db;
        }
        public bool CheckRole(int userId, int roleId)
        {
            return _db.User.Any(r=> r.RoleId == roleId && r.Id == userId);
        }
    }
}