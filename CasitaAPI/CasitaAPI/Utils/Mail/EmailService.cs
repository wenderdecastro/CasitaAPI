
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CasitaAPI.Utils.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {

            emailSettings = options.Value;

        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                //Define o objeto inteiro do email
                var email = new MimeMessage();

                //define o remetente do email

                email.Sender = MailboxAddress.Parse(emailSettings.Email);

                //adiciona o destinario do email

                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));


                //Define o assunto do email
                email.Subject = mailRequest.Subject;

                //Cria o corpo do email
                var builder = new BodyBuilder();


                //Define o corpo do email como html
                builder.HtmlBody = mailRequest.Body;

                //Define o corpo do email no obj MimeMessage
                email.Body = builder.ToMessageBody();

                //INSTANCIAR O SMTPCLIENT DO MAILKIT NAO DO SYSTEM
                //cria
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);


                    smtp.Authenticate(emailSettings.Email, emailSettings.Password);

                    await smtp.SendAsync(email);

                }
            }
            catch (Exception) { throw; }
        }
    
}
}
