using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Models;

namespace Adbeer.Service.DriverService
{
    public interface IDriverService
    {
        public Task<List<DriverViewModel>> GetAll();
        public Task<List<DriverViewModel>> GetAll(string? key);
        public Task<CreateDriverDto> GetById(string id);
        public Task<Driver> GetUserById(string id);
        public Task<UpdateDriverDto> GetByIdForEdit(string id);
        public Task<ApplicationUser> Create(CreateDriverDto dto);
        public Task<int> CreateDriver(string userId);
        public Task<UpdateDriverDto> Update(UpdateDriverDto dto);
        public Task<int> Delete(int id);
    }
}
