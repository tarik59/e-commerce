using System;
using System.Security.Claims;

namespace EC_Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
