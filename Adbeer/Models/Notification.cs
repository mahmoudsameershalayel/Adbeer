using System.ComponentModel.DataAnnotations.Schema;

namespace Adbeer.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public ApplicationUser _Sender { get; set; }
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        public School _School { get; set; }
        public string Message { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
