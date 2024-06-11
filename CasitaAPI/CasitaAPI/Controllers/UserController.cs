using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using CasitaAPI.Utils;
using CasitaAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userList = _userRepository.GetAll();
            return Ok(userList);
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.Create(user);
            return Ok(user);
        }

        [HttpPatch]
        public IActionResult Patch(User user)
        {
            _userRepository.Update(user);
            return Ok(user);
        }

        
        

    }
}
