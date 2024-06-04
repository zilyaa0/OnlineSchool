namespace OnlineSchool.Data.Models
{
    public class Course
    {
        public long id {  get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public int duration {  get; set; }
        public float price {  get; set; }
        public string path { get; set; }
    }
}
