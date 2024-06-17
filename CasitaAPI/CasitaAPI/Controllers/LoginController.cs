using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using CasitaAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                //busca usuário por email e senha 
                var usuarioBuscado = _userRepository.GetByEmailAndPwd(user.Email!, user.Password!);

                //caso não encontre
                if (usuarioBuscado == null)
                {
                    //retorna 401 - sem autorização
                    return StatusCode(401, "Email ou senha inválidos!");
                }


                //caso encontre, prossegue para a criação do token

                //informações que serão fornecidas no token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Name!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim("MonthlyIncome", usuarioBuscado.IdNavigation.MonthlyIncome.Value.ToString()),
                    new Claim("Necessities", (usuarioBuscado.IdNavigation.NecessitiesPercentage * 100).ToString()),
                    new Claim("Wants", (usuarioBuscado.IdNavigation.WantsPercentage * 100).ToString()),
                    new Claim("Savings", (usuarioBuscado.IdNavigation.SavingsPercentage * 100).ToString()),
                    new Claim("Balance", usuarioBuscado.IdNavigation.Balance.ToString()),

                };

                //chave de segurança
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("CasitaAPI-chave-symmetricsecuritykey"));

                //credenciais
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //token
                var meuToken = new JwtSecurityToken(
                        issuer: "CasitaAPI",
                        audience: "CasitaAPI",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }



        }


    }
}
