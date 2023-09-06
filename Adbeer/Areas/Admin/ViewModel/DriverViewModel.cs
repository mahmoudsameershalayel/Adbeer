using Adbeer.Data.Enums;

namespace Adbeer.Areas.Admin.ViewModel
{
    public class DriverViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

    }
}
