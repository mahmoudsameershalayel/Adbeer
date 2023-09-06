using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adbeer.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; } 
        public int? SchoolId { get; set; }
        public School _School { get; set; } 
        public List<BusStudents> _BusStudents { get; set; } 

    }
}
