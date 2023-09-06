using Adbeer.Areas.Admin.Dto.DriverDto;
using Adbeer.Areas.Admin.Dto.VehicleDto;
using Adbeer.Service.DriverService;
using Adbeer.Service.VehicleService;
using Microsoft.AspNetCore.Mvc;

namespace Adbeer.Areas.Admin.Controllers
{
    public class VehicleController : AdminBaseController
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key)
        {
            var items = await _vehicleService.GetAll(key);
            return View(items);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var dto = await _vehicleService.InjectDrivers();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateVehicleDto dto)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _vehicleService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }

    }
}
