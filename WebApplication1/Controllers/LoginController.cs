using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Route("/Login/Login")]
        [HttpPost]
        public async Task<IActionResult> Validate(string username, string password, bool isRemembered, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            User user = _context.Users.FirstOrDefault(user => user.UserName == username && user.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Role, user.Permission)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var properties = new AuthenticationProperties() {
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                    IsPersistent = isRemembered
                };
                TempData["Permission"] = user.Permission;
                await HttpContext.SignInAsync(claimsPrincipal, properties);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Records");
                }
                return Redirect(returnUrl);
            }
            TempData["Error"] = "Неправильно введен логин или пароль";
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            TempData["Permission"] = "Anonymous";
            return RedirectToAction("Index", "Records");
        }

        public IActionResult Denied()
        {
            return View();
        }
    }
}
