using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.Dto.VehicleDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Dto.RegisterDto;
using Adbeer.Models;
using AutoMapper;

namespace Adbeer.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Register
            CreateMap<School, RegisterDto>().ReverseMap();

            //Driver
            CreateMap<Driver, CreateDriverDto>().ReverseMap();
            CreateMap<Driver, UpdateDriverDto>().ReverseMap();
            CreateMap<Driver, DriverViewModel>().ReverseMap();

            //Vehicle
            CreateMap<Bus , CreateVehicleDto>().ReverseMap();
            CreateMap<Bus, VehicleViewModel>().ReverseMap();
    

        }
    }
}
