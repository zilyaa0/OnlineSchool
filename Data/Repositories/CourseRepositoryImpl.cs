using Microsoft.EntityFrameworkCore;
using OnlineSchool.Data.interfaces;
using OnlineSchool.Data.Models;
using System.Data.Entity;

namespace OnlineSchool.Data.Repositories
{
    public class CourseRepositoryImpl : CourseRepository
    {
        private readonly AppDbContext appDbContext;

        public CourseRepositoryImpl(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Course> GetCourses()
        {
            return appDbContext.Course.ToList();
        }

        public Course getObjectCourse(long courseid) => appDbContext.Course.FirstOrDefault(p => p.id == courseid);
    }
}
