namespace OnlineSchool.Data.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }

    }
}
