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



        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userRepository.GetUser(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.Create(user);
            return Ok(user);
        }

        [HttpPatch]
        public IActionResult Patch(Guid userId, Financial userFinancial)
        {
            _userRepository.Update(userId, userFinancial);

            return Ok(userFinancial);
        }

        [HttpPatch("ChangePassword")]
        public IActionResult UpdatePassword(string email, string senha)
        {
            try
            {

                _userRepository.ChangePassword(email, senha);

                return Ok("Senha alterada com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
