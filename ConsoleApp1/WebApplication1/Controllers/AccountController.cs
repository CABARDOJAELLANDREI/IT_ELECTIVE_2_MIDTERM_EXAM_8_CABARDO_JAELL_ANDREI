using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ConferenceSystem.Models;
using ConferenceSystem.Repositories;

namespace ConferenceSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepo = new();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user != null && user.Password == password)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Attendee");
            }
            ModelState.AddModelError("", "Invalid username or password, or the account has not been registered.");
            return View();
        }
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}