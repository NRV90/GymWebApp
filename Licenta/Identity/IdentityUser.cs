using Licenta.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Licenta.Identity
{
    public class IdentityUser:Controller
    {
        public static async Task CreateClaimsAsync(UserModel user, HttpContext httpContext) {
            
            var claims = new List<Claim>();
            claims.Add(new Claim("username", user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
            claims.Add(new Claim(ClaimTypes.Role,user.Role));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(claimsPrincipal);

            return;




        }



    }
}
