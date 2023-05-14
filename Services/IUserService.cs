using Entites;
using Repository;


namespace Services
{
    public interface IUserService
    {
        public Task<User> getUser(string password, string userName);
        public Task<User> addUser(User user);
        public Task updateUser(int id, User user);


    }
}