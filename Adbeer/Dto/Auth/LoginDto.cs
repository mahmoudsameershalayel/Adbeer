using System.ComponentModel.DataAnnotations;

namespace Adbeer.Dto.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Please enter your username")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
