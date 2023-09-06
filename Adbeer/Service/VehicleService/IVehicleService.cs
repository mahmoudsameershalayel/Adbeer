using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.Dto.VehicleDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Models;

namespace Adbeer.Service.VehicleService
{
    public interface IVehicleService
    {
        public Task<List<VehicleViewModel>> GetAll();
        public Task<List<VehicleViewModel>> GetAll(string? key);
        public Task<CreateVehicleDto> GetById(int id);
        public Task<UpdateVehicleDto> GetByIdForEdit(int id);
        public Task<int> Create(CreateVehicleDto dto);
        public Task<int> Update(UpdateVehicleDto dto);
        public Task<int> Delete(int id);
        public Task<CreateVehicleDto> InjectDrivers();
    }
}
