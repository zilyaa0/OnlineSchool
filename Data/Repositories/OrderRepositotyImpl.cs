using OnlineSchool.Data.Models;
using System.Web.Helpers;

namespace OnlineSchool.Data.Repositories
{
    public class OrderRepositoryImpl : OrderRepository
    {
        private readonly AppDbContext appDbContext;

        public OrderRepositoryImpl(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AddToOrder(Client client, Course course)
        {
            Client c = appDbContext.Clients.First(x => x.Id == client.Id);
            foreach (var order in appDbContext.Orders.Where(x => x.ClientId == client.Id))
            {
                if (appDbContext.Course.First(x => x.id == order.CourseId).id == course.id)
                    return;
            }

            Order o = new Order
            {
                ClientId = client.Id,
                CourseId = course.id

            };
            appDbContext.Orders.Add(o);
            appDbContext.SaveChanges();
        }

        public List<Course> GetAllCoursesByClientID(long id)
        {
            Client client = appDbContext.Clients.First(x => x.Id == id);
            List<Course> courses = new List<Course>() { };
            foreach (var course in appDbContext.Orders.Where(x => x.ClientId == client.Id))
            {
                courses.Add(appDbContext.Course.First(x => x.id == course.CourseId));
            }
            return courses;

        }

        public void DeleteCourse(int courseid, Client client)
        {
            var dord = appDbContext.Orders.First(x => x.CourseId == courseid && x.ClientId == client.Id);
            appDbContext.Orders.Remove(dord);
            appDbContext.SaveChanges();
        }

        public bool AnyOrder(Client client){
            bool i = appDbContext.Orders.Any(x => x.ClientId == client.Id);
            if (i == true) return true;
            else return false;
        }
    }
}
