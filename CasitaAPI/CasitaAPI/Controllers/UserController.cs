using CasitaAPI.Interfaces;
using CasitaAPI.Repository;
using CasitaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }
        [HttpPut("AlterarSenha")]
        public IActionResult UpdatePassword(string email, ChangePasswordViewModel senha)
        {
            try
            {
                userRepository.ChangePassword(email, senha.SenhaNova!);

                return Ok("Senha alterada com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
