using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Controllers
{
    [EnableCors]
    public class AccountController : APIBase
    {
        public AccountController(Database.AspirantDBContext ctx) : base(ctx) { }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginInfo info)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => (u.Username == info.Login || 
                u.Email == info.Login) && u.Password == info.Password);
            if (user == null)
                return NotFound();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("ID", user.UserId.ToString()),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegistrationForm info)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => (u.Username == info.PhoneNumber ||
                u.Email == info.Email) && u.Password == info.Password);

            if (user != null)
                return BadRequest();
            await _ctx.Users.AddAsync(new Database.Entities.User
            {

            });
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("ID", user.UserId.ToString()),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
