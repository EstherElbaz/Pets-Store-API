using Entites;
using Repository;



namespace Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _UserRepository = IUserRepository;
        }
         

        public async Task<User> getUser(string password, string userName)
        {
           return await _UserRepository.getUser(password, userName);
            
          
        }

        public async Task<User> addUser(User user)
        {
            User res = await _UserRepository.addUser(user);
                return res;
        }

        public async Task updateUser(int id,User user)
        {
            await _UserRepository.updateUser(id, user);
        }
    }
}