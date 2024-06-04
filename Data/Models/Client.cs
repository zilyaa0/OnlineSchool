using System.Data;

namespace OnlineSchool.Data.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
    public enum Role
    {
        ADMIN, NOT_ADMIN
    }
}
