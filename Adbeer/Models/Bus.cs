using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adbeer.Models
{
    public class Bus : BaseEntity
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        [Required]
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
        public int DriverId { get; set; }
        public int SchoolId { get; set; }
        public School _School { get; set; }
        public List<BusStudents> _BusStudents { get; set; }
    }
}
