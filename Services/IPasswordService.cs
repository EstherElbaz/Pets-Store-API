using Zxcvbn;
namespace Services
{
    public interface IPasswordService
    {
        Result checkPassword(string password);
    }
}