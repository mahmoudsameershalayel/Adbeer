namespace Adbeer.Models
{
    public class BusStudents
    {
        public int Id { get; set; }
        public string? StudentId { get; set; }
        public ApplicationUser _Stuednt { get; set; }
        public int? BusId { get; set; }
        public Bus _Bus { get; set; }
    }
}
