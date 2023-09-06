namespace Adbeer.Models
{
    public class BusStudents
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Student _Stuednt { get; set; }
        public int? BusId { get; set; }
        public Bus _Bus { get; set; }
    }
}
