using Entites;
namespace  Repository
{
    public interface IUserRepository
    {
        public Task<User> getUser(string password, string userName);
        public Task<User> addUser(User user);
        public Task updateUser(int id, User user);
    }
}