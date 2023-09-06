using System.ComponentModel.DataAnnotations;

namespace Adbeer.Areas.Admin.Dto.DriverDto
{
    public class UpdateDriverDto
    {
        [Required(ErrorMessage = "*Full name is Required")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Email is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Phone is Required")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Birth date is Required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "*Password is Required")]
        public string Password { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
