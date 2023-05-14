
using System.Text.Json;
//using WebApplication1;
//using Entites;
using Services;
using Repository;
using Entites;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DTO;

namespace pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _UserService;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        public UsersController(IUserService UserService, ILogger<UsersController> ILogger, IMapper mapper)
        {
            _mapper = mapper;
            _UserService = UserService;
            _logger = ILogger;
        }

        [HttpGet]
        public async Task<ActionResult<UserSavedDTO>> Get([FromQuery] string password, string userName)
        {
            _logger.LogInformation($"{userName} logged in");
            User? user = await _UserService.getUser(password, userName);
            UserSavedDTO userSaveDto = _mapper.Map<User, UserSavedDTO>(user);
            if (userSaveDto == null)
            {
                return NoContent();
            }

            return Ok(userSaveDto);

        }

        [HttpPost]
        public async Task<ActionResult<UserSavedDTO>> Post([FromBody] User user)
        {
            User newUser = await _UserService.addUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await _UserService.updateUser(id, userToUpdate);

        }



    }
}
