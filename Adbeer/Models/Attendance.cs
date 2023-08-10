using System.ComponentModel.DataAnnotations.Schema;

namespace Adbeer.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime ArrivalTime { get; set; } = DateTime.Now;
        public DateTime DepartureTime { get; set; }
        public string? StudentId { get; set; }
        public ApplicationUser _Student { get; set; }
        public int? BusId { get; set; }
        public Bus _Bus { get; set; }

    }
}
