using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Linq;
using System.Globalization;
using System.Security.Claims;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Core
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IRoleService _role;
        private int roleId = 0;
        public RoleAttribute(int id)
        {
            roleId = id;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _role = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = int.Parse(context.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                if (!(_role.CheckRole(userId, roleId)))
                {
                    context.Result = new RedirectResult("/login");
                }
            }
            else
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}
