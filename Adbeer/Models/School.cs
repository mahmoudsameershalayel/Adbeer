namespace Adbeer.Models
{
    public class School : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<ApplicationUser> _Students { get; set; } = new List<ApplicationUser>();
    }
}
