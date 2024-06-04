using OnlineSchool.Data.Models;

namespace OnlineSchool.Data.Repositories
{
    public interface OrderRepository
    {
        void AddToOrder(Client client, Course course);
        public List<Course> GetAllCoursesByClientID(long id);
        bool AnyOrder(Client client);
        public void DeleteCourse(int courseid, Client client);
    }
}
