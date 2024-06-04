using OnlineSchool.Data.Models;

namespace OnlineSchool.Data.interfaces
{
    public interface CourseRepository
    {
        public List<Course> GetCourses();
        Course getObjectCourse(long courseid);
    }
}
