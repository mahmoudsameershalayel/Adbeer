using Adbeer.Data;
using Adbeer.Dto.Auth;
using Adbeer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Adbeer.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManager.FindByEmailAsync(dto.Email);
                var result = await _signInManager.PasswordSignInAsync(_user, dto.Password, false, false);
                if (result.Succeeded)
                {
                    bool isAdmin = await _userManager.IsInRoleAsync(_user, "Administrator");
                    if (isAdmin)
                    {
                        return LocalRedirect("/Admin/Home/Index");
                    }
                }
            }
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/Home");
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();

        }


    }
}
