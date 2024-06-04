using OnlineSchool.Data.Models;

namespace OnlineSchool.Data.Repositories
{
    public interface ClientRepository
    {
        Client GetUserByEmail(string email);
        void SaveUser(Client client);
        void DeleteUser(Client client);
    }
}
