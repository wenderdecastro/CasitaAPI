using CasitaAPI.Interfaces;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController() {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult Get(Guid id) {

            return Ok();
        }
    }
}
