using Adbeer.Areas.Admin.Dto.VehicleDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Data;
using Adbeer.Models;
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Adbeer.Service.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public VehicleService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<VehicleViewModel>> GetAll()
        {
            var items = await _context.Buses.Where(x => x.IsDelete == false && x.IsActive == true).Include(x => x.Driver).ToListAsync();
            var itemsVM = _mapper.Map<List<VehicleViewModel>>(items);
            return itemsVM;
        }

        public async Task<List<VehicleViewModel>> GetAll(string? key)
        {
            var items = await _context.Buses.Where(x => x.IsDelete == false && x.IsActive == true).Include(x => x.Driver).ThenInclude(x => x.ApplicationUser).ToListAsync();
             var itemsVM = _mapper.Map<List<VehicleViewModel>>(items);
             return itemsVM;
        }

        public async Task<CreateVehicleDto> GetById(int id)
        {
            var item = await _context.Buses.Where(x => x.Id == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<CreateVehicleDto>(item);
            return dto;
        }

        public async Task<UpdateVehicleDto> GetByIdForEdit(int id)
        {
            var item = await _context.Buses.Where(x => x.Id == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<UpdateVehicleDto>(item);
            return dto;
        }

        public async Task<int> Create(CreateVehicleDto dto)
        {
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var school = await _context.Schools.Where(x => x.Administrator.ApplicationUserId.Equals(_UserId)).FirstOrDefaultAsync();
            dto.SchoolId = school.Id;
            var item = _mapper.Map<Bus>(dto);
            item.IsDelete = false;
            item.Created_At = DateTime.Now;
            item.Created_By = _UserId;
            item.SchoolId = school.Id;
            item.DriverId = dto.DriverId;
            await _context.Buses.AddAsync(item);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(UpdateVehicleDto dto)
        {
            var item = await _context.Buses.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (item != null)
            {
                var updateItem = _mapper.Map(dto, item);
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                updateItem.Updated_At = DateTime.Now;
                updateItem.Updated_By = _UserId;
                _context.Buses.Update(updateItem);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            var item = await _context.Buses.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                item.IsDelete = true;
                item.IsActive = false;
                _context.Buses.Update(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CreateVehicleDto> InjectDrivers()
        {
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var school = await _context.Schools.Where(x => x.Administrator.ApplicationUserId.Equals(_UserId)).FirstOrDefaultAsync();
            var drivers = await _context.Drivers.Where(x => x.ApplicationUser.IsDeleted == false && x.ApplicationUser.IsActive == true && x.SchoolId == school.Id).Include(x => x.ApplicationUser).ToListAsync();
            var dto = new AddVehicleWithDriver();
            dto.InjectDrivers(drivers);
            return dto;
        }
    }
}
