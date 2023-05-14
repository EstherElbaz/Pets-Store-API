using Entites;
using System.Text.Json;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository: IUserRepository
    {
        storeWebsiteContext _storeWebsiteContext;
        public UserRepository(storeWebsiteContext storeWebsiteContext)
        {
            _storeWebsiteContext = storeWebsiteContext;
        }

        public async Task<User> getUser(string password, string userName)
        {

            var list = (from user in _storeWebsiteContext.Users
                        where user.Password == password && user.Email == userName
                        select user).ToArray<User>();
            return list.FirstOrDefault();

        }

        public async Task<User> addUser(User user)
        {

            await _storeWebsiteContext.Users.AddAsync(user);
            await _storeWebsiteContext.SaveChangesAsync();
            return user;

        }

        public async Task updateUser(int id, User user)
        {
            _storeWebsiteContext.Users.Update(user);
            await _storeWebsiteContext.SaveChangesAsync();
        }


    }
}