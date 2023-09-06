namespace Adbeer.Models
{
    public class School : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public string AdministratorName { get; set; } = string.Empty;

		public string Address { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

		public List<ApplicationUser> _Students { get; set; } = new List<ApplicationUser>();
    }
}
