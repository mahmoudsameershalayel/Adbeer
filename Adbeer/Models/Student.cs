namespace Adbeer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int GuardianId { get; set; }
        public Guardian Guardian { get; set; }
        public int SchoolId { get; set; }
        public School _School { get; set; }
        public List<BusStudents> _BusStudents { get; set; }
    }
}
