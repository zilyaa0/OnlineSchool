using OnlineSchool.Data.Models;

namespace OnlineSchool.Data.Repositories
{
    public class ClientRepositoryImpl : ClientRepository
    {
        private readonly AppDbContext appDbContext;

        public ClientRepositoryImpl(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void DeleteUser(Client client)
        {
            appDbContext.Clients.Remove(client);
            appDbContext.SaveChanges();
        }

        public Client GetUserByEmail(string email)
        {
            Client c = appDbContext.Clients.FirstOrDefault(u => u.Email == email);
            return c;
        }

        public void SaveUser(Client client)
        {
            Client us = appDbContext.Clients.FirstOrDefault(x => x.Email == client.Email);

            if (us != null)
            {
                appDbContext.Clients.Update(client);
            }
            else
            {
                appDbContext.Clients.Add(client);
            }
            appDbContext.SaveChanges();
        }
    }
}
