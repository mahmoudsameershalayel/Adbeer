using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.ViewModel;
using Adbeer.Models;
using AutoMapper;

namespace Adbeer.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Driver
            CreateMap<ApplicationUser, CreateDriverDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateDriverDto>().ReverseMap();
            CreateMap<ApplicationUser, DriverViewModel>().ReverseMap();

        }
    }
}
