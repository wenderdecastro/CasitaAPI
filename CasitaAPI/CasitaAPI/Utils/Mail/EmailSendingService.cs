using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace CasitaAPI.Utils.Mail
{
    public class EmailSendingService
    {
        private readonly IEmailService emailService;
        public EmailSendingService(IEmailService service)
        {

            emailService = service;
        }

        public async Task SendWelcomeEmail(string email, string userName)
        {

            MailRequest request = new MailRequest
            {
                ToEmail = email,
                Subject = "Bem vindo a Casita",
                Body = GetHtmlContent(userName),


            };
            await emailService.SendEmailAsync(request);
        }

        public async Task SendRecoveryPassword(string userName, string email, int codigo)
        {

            MailRequest request = new MailRequest
            {
                ToEmail = email,
                Subject = "Bem vindo a Casita",
                Body = GetHtmlContentRecovery(userName, codigo),


            };
            await emailService.SendEmailAsync(request);
        }

        public async Task SendRecoveryEmail(string userName, string email, int codigo)
        {
            try
            {
                MailRequest request = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Recuperação de senha",
                    Body = GetHtmlContentRecovery(userName, codigo)
                };

                await emailService.SendEmailAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string GetHtmlContent(string userName)
        {

            string Response = @"
<div style=""width:100%; background-color:rgba(96, 191, 197, 1); padding: 20px;"">
    <div style=""max-width: 600px; margin: 0 auto; background-color:#FFFFFF; border-radius: 10px; padding: 20px;"">
        <img src=""https://fhycnon.stripocdn.email/content/guids/CABINET_5c5b43ff9c9e36ad763d8f1007dd446fc521ff17031d6e5aca36dbca4db7e01d/images/iphone_13_14_9_1.png"" alt="" Logotipo da Aplicação"" style="" display: block; margin: 0 auto; max-width: 200px;"" />
        <h1 style=""color: #333333; text-align: center;"">Bem-vindo ao VitalHub!</h1>
        <p style=""color: #666666; text-align: center;"">Olá <strong>" + userName + @"</strong>,</p>
        <p style=""color: #666666;text-align: center"">Estamos muito felizes por você ter se inscrito na plataforma Casita.</p>
        <p style=""color: #666666;text-align: center"">Explore todas as funcionalidades que oferecemos para facilitar o seu dia a dia.</p>
        <p style=""color: #666666;text-align: center"">Se tiver alguma dúvida ou precisar de assistência, nossa equipe de suporte está sempre pronta para ajudar.</p>
        <p style=""color: #666666;text-align: center"">Aproveite sua experiência conosco!</p>
        <p style=""color: #666666;text-align: center"">Atenciosamente,<br>Equipe Casita</p>
    </div>
</div>";

            // Retorna o conteúdo HTML do e-mail
            return Response;
        }

        private string GetHtmlContentRecovery(string userName, int codigo)
        {
            string Response = @"<!DOCTYPE html>
<html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office'>
<head>
<meta charset='UTF-8'>
<meta content='width=device-width, initial-scale=1' name='viewport'>
<meta name='x-apple-disable-message-reformatting'>
<meta http-equiv='X-UA-Compatible' content='IE=edge'>
<meta content='telephone=no' name='format-detection'>
<title></title>
<!--[if (mso 16)]>
<style type='text/css'>
a {text-decoration: none;}
</style>
<![endif]-->
<!--[if gte mso 9]>
<style>
sup { font-size: 100%!important; }
</style>
<![endif]-->
<!--[if gte mso 9]>
<xml>
<o:OfficeDocumentSettings>
<o:AllowPNG></o:AllowPNG>
<o:PixelsPerInch>96</o:PixelsPerInch>
</o:OfficeDocumentSettings>
</xml>
<![endif]-->
<!--[if!mso]><!-- -->
<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,400i,700,700i' rel='stylesheet'>
<link href='https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i' rel='stylesheet'>
<!--<![endif]-->
</head>

<body class='body'>
<div dir='ltr' class='es-wrapper-color'>
<!--[if gte mso 9]>
<v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'>
<v:fill type='tile' color='#f6f6f6'></v:fill>
</v:background>
<![endif]-->
<table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr>
<td class='esd-email-paddings' valign='top'>
<table class='esd-header-popover es-header' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr>
<td class='esd-stripe' align='center'>
<table class='es-header-body' width='600' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'>
<tbody>
<tr>
<td class='esd-structure es-p20t es-p20r es-p20l' align='left'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td width='560' class='esd-container-frame' align='center' valign='top'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='center' class='esd-block-image' style='font-size: 0px;'><a target='_blank'><img class='adapt-img' src='https://fhycnon.stripocdn.email/content/guids/CABINET_5c5b43ff9c9e36ad763d8f1007dd446fc521ff17031d6e5aca36dbca4db7e01d/images/iphone_13_14_9_1.png' alt style='display: block;' width='560'></a></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table class='es-content' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr>
<td class='esd-stripe' align='center'>
<table class='es-content-body' width='600' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'>
<tbody>
<tr>
<td class='es-p20t es-p20r es-p20l esd-structure' align='left'>
<table width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr>
<td class='esd-container-frame' width='560' valign='top' align='center'>
<table width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr>
<td align='center' class='esd-block-text'>
<p style='font-size: 18px; font-family: roboto, 'helvetica neue', helvetica, arial, sans-serif;'><strong>Recuperar Senha</strong></p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table class='esd-footer-popover es-footer' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr>
<td class='esd-stripe' align='center'>
<table class='es-footer-body' width='600' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'>
<tbody>
<tr>
<td class='esd-structure es-p20t es-p20r es-p20l' align='left'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td width='560' class='esd-container-frame' align='center' valign='top'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='center' class='esd-block-text'>
<p style='font-family: roboto, 'helvetica neue', helvetica, arial, sans-serif;'>Olá, "+userName+@"!</p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr>
<td class='esd-structure es-p20t es-p20r es-p20l' align='left'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td width='560' class='esd-container-frame' align='center' valign='top'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='center' class='esd-block-text es-m-txt-c'>
<p style='font-family: roboto, 'helvetica neue', helvetica, arial, sans-serif;'>Que dó, vamos precisamos recuperar sua senha Se foi você mesmo que solicitou a mudança, aqui está seu código de recuperação:</p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr>
<td class='esd-structure es-p20t es-p20r es-p20l' align='left'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td width='560' class='esd-container-frame' align='center' valign='top'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='center' class='esd-block-text'>
<p style='font-size: 36px; font-family: roboto, 'helvetica neue', helvetica, arial, sans-serif;'><strong>"+codigo+@"</strong></p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr>
<td class='esd-structure es-p20t es-p20r es-p20l' align='left'>
<!--[if mso]><table width='560' cellpadding='0' cellspacing='0'><tr><td width='265' valign='top'><![endif]-->
<table cellpadding='0' cellspacing='0' class='es-left' align='left'>
<tbody>
<tr>
<td width='245' class='es-m-p0r es-m-p20b esd-container-frame' align='center'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='left' class='esd-block-text'>
<p>Se não foi você que solicitou essa mudança de senha, <a target='_blank' href='https://screenmessage.com/casita-proteja-sua-conta'>proteja sua conta</a>.</p>
</td>
</tr>
</tbody>
</table>
</td>
<td class='es-hidden' width='20'></td>
</tr>
</tbody>
</table>
<!--[if mso]></td><td width='173' valign='top'><![endif]-->
<table cellpadding='0' cellspacing='0' class='es-left' align='left'>
<tbody>
<tr>
<td width='173' align='left' class='esd-container-frame es-m-p20b'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='right' class='esd-block-text es-p25'>
<p style='line-height: 200%; font-family: roboto, 'helvetica neue', helvetica, arial, sans-serif;'>Casita da Silva,<br>o aplicativo.</p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!--[if mso]></td><td width='20'></td><td width='102' valign='top'><![endif]-->
<table cellpadding='0' cellspacing='0' class='es-right' align='right'>
<tbody>
<tr>
<td width='102' align='left' class='esd-container-frame'>
<table cellpadding='0' cellspacing='0' width='100%'>
<tbody>
<tr>
<td align='center' class='esd-block-image' style='font-size: 0px;'><a target='_blank'><img class='adapt-img' src='https://fhycnon.stripocdn.email/content/guids/CABINET_5c5b43ff9c9e36ad763d8f1007dd446fc521ff17031d6e5aca36dbca4db7e01d/images/frame_10.png' alt style='display: block;' width='102'></a></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!--[if mso]></td></tr></table><![endif]-->
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</div>
</body>
</html>";

            return Response;
        }
    }
}

