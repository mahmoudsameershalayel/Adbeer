using Adbeer.Models;

namespace Adbeer.Dto.RegisterDto
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AdministratorName { get; set; }
        public string Address { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
