using Adbeer.Areas.Admin.Dto.DriverDto;
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
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateDriverDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _driverService.Create(dto);
                await _driverService.CreateDriver(user.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _driverService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }
    }
}
