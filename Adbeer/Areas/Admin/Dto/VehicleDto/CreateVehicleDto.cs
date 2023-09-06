using Adbeer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Adbeer.Areas.Admin.Dto.VehicleDto
{
    public class CreateVehicleDto
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int DriverId { get; set; }
        public int SchoolId { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class AddVehicleWithDriver : CreateVehicleDto {
        public IEnumerable<SelectListItem> _Drivers { get; set; }
        public void InjectDrivers(List<Driver> drivers)
        {
            List<SelectListItem> ListOfDrivers = new List<SelectListItem>();
            ListOfDrivers.Add(
               new SelectListItem { Text = "Select Driver", Value = null }
               );
            foreach (var driver in drivers)
            {
                ListOfDrivers.Add(
                new SelectListItem { Text = driver.ApplicationUser.UserName, Value = driver.Id.ToString() }
                );
            }
            _Drivers = ListOfDrivers;
        }

    }
}
