using Adbeer.Data.Enums;
using Adbeer.Models;

namespace Adbeer.Areas.Admin.ViewModel
{
    public class DriverViewModel
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
