using Adbeer.Service.DriverService;
using Microsoft.AspNetCore.Mvc;

namespace Adbeer.Areas.Admin.Controllers
{
    public class DriverController : AdminBaseController
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
                _driverService = driverService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _driverService.GetAll();
            return View(items);
        }
    }
}
