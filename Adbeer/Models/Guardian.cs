namespace Adbeer.Models
{
    public class Guardian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Student> Students { get; set; }
    }
}
