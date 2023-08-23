using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Adbeer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Roles ="Administrator")]
    public class AdminBaseController : Controller
    {
        
    }
}
