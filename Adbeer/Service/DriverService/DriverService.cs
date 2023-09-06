using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Data;
using Adbeer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Adbeer.Service.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public DriverService(ApplicationDbContext context , UserManager<ApplicationUser> userManager , IMapper mapper , IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<DriverViewModel>> GetAll(string? key)
        {
            var items = await _userManager.Users.Where(x => x.IsDeleted == false && x.IsActive == true && (string.IsNullOrEmpty(key) || x.FullName.Contains(key)) && x.UserType == Data.Enums.UserType.Driver ).ToListAsync();
            var itemsVM = _mapper.Map<List<DriverViewModel>>(items);
            return itemsVM;
        }
        public async Task<List<DriverViewModel>> GetAll()
        {

            var items = await _userManager.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.UserType == Data.Enums.UserType.Driver).ToListAsync();
            var itemsVM = _mapper.Map<List<DriverViewModel>>(items);
            return itemsVM;
        }

        public async Task<CreateDriverDto> GetById(string id)
        {
            var item = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            var itemVM = _mapper.Map<CreateDriverDto>(item);
            return itemVM;
        }

        public async Task<UpdateDriverDto> GetByIdForEdit(string id)
        {
            var item = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            var itemVM = _mapper.Map<UpdateDriverDto>(item);
            return itemVM;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var item = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }
        public async Task<int> Create(CreateDriverDto dto)
        {
            ApplicationUser _User = new ApplicationUser();
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
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
            var result = await _userManager.CreateAsync(_User, dto.Password);
            await _userManager.AddToRoleAsync(_User, "Driver");
            if (result.Succeeded)
            {
                return 1;
            }
            return 0;
        }

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        

        public Task<UpdateDriverDto> Update(UpdateDriverDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
