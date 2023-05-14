using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
namespace pets.Controllers
{
    public class PasswordController1 : Controller
    {
        private readonly IPasswordService _passwordService;

        public PasswordController1(IPasswordService PasswordService)
        {
            _passwordService = PasswordService;

        }

        // POST api/<Password>
        [HttpPost]
        public int Post([FromBody] string password)
        {
            var result = _passwordService.checkPassword(password);
            return result.Score;
        }

        
    }
}
