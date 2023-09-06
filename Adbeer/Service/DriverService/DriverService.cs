using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Data;
using Adbeer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Adbeer.Service.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public DriverService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<DriverViewModel>> GetAll(string? key)
        {
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var school = await _context.Schools.Where(x => x.Administrator.ApplicationUserId.Equals(_UserId)).FirstOrDefaultAsync();
            var items = await _context.Drivers.Where(x => x.ApplicationUser.IsDeleted == false && x.ApplicationUser.IsActive == true && (string.IsNullOrEmpty(key) || x.ApplicationUser.FullName.Contains(key)) && x.SchoolId == school.Id).Include(x => x.ApplicationUser).ToListAsync();

            var itemsVM = _mapper.Map<List<DriverViewModel>>(items);
            return itemsVM;
        }
        public async Task<List<DriverViewModel>> GetAll()
        {
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var school = await _context.Schools.Where(x => x.Administrator.ApplicationUserId.Equals(_UserId)).FirstOrDefaultAsync();
            var items = await _context.Drivers.Where(x => x.ApplicationUser.IsDeleted == false && x.SchoolId == school.Id).Include(x => x.ApplicationUser).ToListAsync();
            var itemsVM = _mapper.Map<List<DriverViewModel>>(items);
            return itemsVM;
        }

        public async Task<CreateDriverDto> GetById(string id)
        {
            var item = await _context.Drivers.Where(x => x.ApplicationUser.Id == id).Include(x => x.ApplicationUser).FirstOrDefaultAsync();
            var itemVM = _mapper.Map<CreateDriverDto>(item);
            return itemVM;
        }

        public async Task<UpdateDriverDto> GetByIdForEdit(string id)
        {
            var item = await _context.Drivers.Include(x => x.ApplicationUser).Where(x => x.ApplicationUser.Id == id).FirstOrDefaultAsync();
            var itemVM = _mapper.Map<UpdateDriverDto>(item);
            return itemVM;
        }

        public async Task<Driver> GetUserById(string id)
        {
            var item = await _context.Drivers.Where(x => x.ApplicationUser.Id == id).Include(x => x.ApplicationUser).FirstOrDefaultAsync();
            return item;
        }
        public async Task<ApplicationUser> Create(CreateDriverDto dto)
        {
            /* var item = await _context.Drivers.Where(x => x.ApplicationUser.Email.Equals(dto.Email) && x.ApplicationUser.IsDeleted == false).FirstOrDefaultAsync();
             var item2 = await _userManager.Users.Where(x => x.Email.Equals(dto.Email) && x.IsDeleted == false).FirstOrDefaultAsync();
             if (item != null || item2 != null)
             {
                 return 0;
             }*/
            ApplicationUser _User = new ApplicationUser();
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var school = await _context.Schools.Where(x => x.Administrator.ApplicationUserId.Equals(_UserId)).FirstOrDefaultAsync();
            _User.Created_At = DateTime.Now;
            _User.Created_By = _UserId;
            _User.IsActive = dto.IsActive;
            _User.IsDeleted = false;
            _User.Email = dto.Email;
            _User.UserName = dto.FullName;
            _User.FullName = dto.FullName;
            _User.Phone = dto.Phone;
            _User.BirthDate = dto.BirthDate;
            _User.UserType = Data.Enums.UserType.Driver;
            await _userManager.CreateAsync(_User, dto.Password);
            await _userManager.AddToRoleAsync(_User, "Driver");
            return _User;
        }
        public async Task<int> CreateDriver(string userId)
        {
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var school = await _context.Schools.Where(x => x.Administrator.ApplicationUserId.Equals(_UserId)).FirstOrDefaultAsync();
            if (school == null)
                return 0;
            var driver = new Driver
            {
                ApplicationUserId = userId,
                SchoolId = school.Id,
            };
            await _context.AddAsync(driver);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var item = await _context.Drivers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item == null) return 0;
            _context.Drivers.Remove(item);
            await _context.SaveChangesAsync();
            var item1 = await _userManager.FindByIdAsync(item.ApplicationUserId);
            if (item1 == null) return 0;
            await _userManager.DeleteAsync(item1);
            return 1;
        }



        public Task<UpdateDriverDto> Update(UpdateDriverDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
