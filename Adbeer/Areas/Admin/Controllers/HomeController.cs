using Microsoft.AspNetCore.Mvc;

namespace Adbeer.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
