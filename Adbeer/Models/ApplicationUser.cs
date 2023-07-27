using Adbeer.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace Adbeer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public UserType UserType { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public int Section { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public string? Created_By { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now;
        public string? Updated_by { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<BusStudents> _BusStudents { get; set; }
    }
}
