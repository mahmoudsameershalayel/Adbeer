using Adbeer.Service.VehicleService;

namespace Adbeer.Models
{
    public class School : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AdministratorName { get; set; }
        public int AdministratorId { get; set; }
        public Administrator Administrator { get; set; }
        public string Address { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Driver> _Drivers { get; set; } = new List<Driver>();
        public List<Student> _Students { get; set; } = new List<Student>();
        public List<Bus> _Vehicles { get; set; } = new List<Bus>();
    }
}
