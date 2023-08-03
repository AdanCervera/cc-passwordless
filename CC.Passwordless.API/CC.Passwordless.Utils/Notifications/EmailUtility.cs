namespace CC.Passwordless.Utils.Notifications;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

public static class EmailUtility
{
   


    public static void SendEmail(string toEmail, string subject, string htmlBody, Dictionary<string, string> replacements = null)
    {
       string _fromEmail = "adancerveradevelopment@gmail.com";
       string _password = "Manriquez1819!.";
        try
        {
            if (replacements != null)
            {
                foreach (var replacement in replacements)
                {
                    htmlBody = htmlBody.Replace($"{{{{ {replacement.Key} }}}}", replacement.Value);
                }
            }

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_fromEmail, _password);

                using (MailMessage mailMessage = new MailMessage(_fromEmail, toEmail, subject, ""))
                {
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = htmlBody;

                    smtpClient.Send(mailMessage);
                }
            }
            Console.WriteLine("Correo enviado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar el correo: {ex.Message}");
        }
    }
}
