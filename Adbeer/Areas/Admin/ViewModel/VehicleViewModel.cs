using Adbeer.Models;

namespace Adbeer.Areas.Admin.ViewModel
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
        public int SchoolId { get; set; }
        public School _School { get; set; }
        public DateTime Created_At { get; set; }
        public bool IsActive { get; set; }
    }
}
