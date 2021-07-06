
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Services
{
    public interface IAdminServices
    {
        Task<List<Group>> GetAllGroup();

        Task<Group> GetGroup(int id);

        Task DeleteGroup(Group group);

        Task AddOrUpdateGroup(Group group);
    }
}