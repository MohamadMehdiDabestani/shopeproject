using System.Threading.Tasks;
namespace Core.Services
{
    public interface IRoleService
    {
        bool CheckRole(int userId, int roleId);
    }
}