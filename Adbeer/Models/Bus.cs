namespace Adbeer.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string DriverId { get; set; }
        public ApplicationUser _Driver { get; set; }
        public int SchoolId { get; set; }
        public School _School { get; set; }
        public List<BusStudents> _BusStudents { get; set; }
    }
}
