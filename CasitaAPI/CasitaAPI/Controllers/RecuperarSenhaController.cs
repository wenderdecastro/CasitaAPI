using CasitaAPI.Data;
using CasitaAPI.Utils.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasitaAPI.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class RecuperarSenhaController : ControllerBase
        {
            private readonly CasitaContext _context;
            private readonly EmailSendingService _emailSendingService;

            public RecuperarSenhaController(CasitaContext context, EmailSendingService emailSendingService)
            {
                _context = context;
                _emailSendingService = emailSendingService;
            }

            [HttpPost]
            public async Task<IActionResult> SendRecoveryCodePassword(string email)
            {
                try
                {
                    //Busca o usuário pelo email
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                    if (user == null)
                    {
                        return NotFound("Usuário não encontrado!");
                    }

                    //Gera um código aleatório com 4 algarismos
                    Random random = new Random();
                    int recoveryCode = random.Next(1000, 9999);

                    user.RecoveryCode = recoveryCode.ToString();

                    await _context.SaveChangesAsync();

                    //Envia código de4 confirmação por email
                    await _emailSendingService.SendRecoveryEmail(user.Email!, recoveryCode);

                    return Ok("Código de recuperação enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost("ValidarCodigoRecuperacaoSenha")]
            public async Task<IActionResult> ValidatePasswordRecoveryCode(string email, int codigo)
            {
                try
                {
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                    if (user == null)
                    {
                        return NotFound("Usuário não encontrado!");
                    }

                    if (user.RecoveryCode != codigo.ToString())
                    {
                        return BadRequest("Código de recuperação é inválido!");
                    }

                    user.RecoveryCode = null;

                    await _context.SaveChangesAsync();

                    return Ok("Código de recuperação está correto!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
