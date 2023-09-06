using Adbeer.Data;
using Adbeer.Dto.Auth;
using Adbeer.Dto.RegisterDto;
using Adbeer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adbeer.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, IHttpContextAccessor contextAccessor , ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _context = context; 
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
                var _user = await _userManager.Users.Where(x => x.Email.Equals(dto.Email)).FirstOrDefaultAsync();
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
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto dto)
        {
            ApplicationUser _User = new ApplicationUser();
            _User.Created_At = DateTime.Now;
            _User.IsActive = true;
            _User.IsDeleted = false;
            _User.Email = dto.Email;
            _User.UserName = dto.AdministratorName;
            _User.FullName = dto.AdministratorName;
            _User.Phone = dto.MobileNumber;
            _User.UserType = Data.Enums.UserType.Administrator;
            var result = await _userManager.CreateAsync(_User, dto.Password);
            await _userManager.AddToRoleAsync(_User, "Administrator");
            var Administrator = new Administrator();
            Administrator.ApplicationUserId = _User.Id;
            await _context.Administrators.AddAsync(Administrator);
            await _context.SaveChangesAsync();
            var item = _mapper.Map<School>(dto);
            item.IsActive = true;
            item.IsDelete = false;
            item.Created_At = DateTime.Now;
            item.AdministratorId = Administrator.Id;
            await _context.Schools.AddAsync(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
