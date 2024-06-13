using CasitaAPI.Data;
using CasitaAPI.Utils.Mail;
using CasitaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasitaAPI.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class RecuperarSenhaController : ControllerBase
        {
            private readonly CasitaDbContext ctx;
            private readonly EmailSendingService _emailSendingService;

            public RecuperarSenhaController(CasitaDbContext context, EmailSendingService emailSendingService)
            {
                ctx = context;
                _emailSendingService = emailSendingService;
            }

            [HttpPost]
            public async Task<IActionResult> SendRecoveryCodePassword(string email)
            {
                try
                {
                    //Busca o usuário pelo email
                    var user = await ctx.Users.FirstOrDefaultAsync(u => u.Email == email);

                    if (user == null)
                    {
                        return NotFound("Usuário não encontrado!");
                    }

                    //Gera um código aleatório com 4 algarismos
                    Random random = new Random();
                    int recoveryCode = random.Next(10000, 99999);

                    user.RecoveryCode = recoveryCode.ToString();

                    await ctx.SaveChangesAsync();

                    //Envia código de4 confirmação por email
                    await _emailSendingService.SendRecoveryEmail(user.Name,user.Email!, recoveryCode);

                    return Ok("Código de recuperação enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException);
                }
            }

            [HttpPost("ValidarCodigoRecuperacaoSenha")]
            public async Task<IActionResult> ValidatePasswordRecoveryCode(string email, int codigo)
            {
                try
                {
                    var user = await ctx.Users.FirstOrDefaultAsync(u => u.Email == email);

                    if (user == null)
                    {
                        return NotFound("Usuário não encontrado!");
                    }

                    if (user.RecoveryCode != codigo.ToString())
                    {
                        return BadRequest("Código de recuperação é inválido!");
                    }

                    user.RecoveryCode = null;

                    await ctx.SaveChangesAsync();

                    return Ok("Código de recuperação está correto!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        
    }
    }
