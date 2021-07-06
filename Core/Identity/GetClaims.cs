using System.Globalization;
using System.Security.Claims;

namespace Core
{
    public static class GetClaims
    {
        public static string GetUserId(this ClaimsPrincipal identity)
        {
            Claim claim = identity?.FindFirst(ClaimTypes.NameIdentifier);

            return claim.Value != null ? claim.Value : null;
        }

        public static string GetName(this ClaimsPrincipal identity)
        {
            Claim claim = identity?.FindFirst(ClaimTypes.Name);

            return claim.Value != null ? claim.Value : null;
        }
        public static string GetEmail(this ClaimsPrincipal identity)
        {
            Claim claim = identity?.FindFirst(ClaimTypes.Email);

            return claim.Value != null ? claim.Value : null;
        }
    }
}