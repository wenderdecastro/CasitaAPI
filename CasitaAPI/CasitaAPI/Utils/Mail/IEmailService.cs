namespace CasitaAPI.Utils.Mail
{
    public interface IEmailService
    {
        //Metodo assincrono que recebe o objeto da classe mailrequest como se fosse uma view model
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
