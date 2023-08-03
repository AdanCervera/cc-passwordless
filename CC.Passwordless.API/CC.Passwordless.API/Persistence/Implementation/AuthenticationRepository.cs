using CC.Passwordless.API.Models;
using CC.Passwordless.API.Models.Response;
using CC.Passwordless.API.Persistence.Abstractions;
using CC.Passwordless.Exceptions.Authentication;
using CC.Passwordless.Utils.Extensions;
using CC.Passwordless.Utils.Files;
using CC.Passwordless.Utils.General;
using CC.Passwordless.Utils.Notifications;

namespace CC.Passwordless.API.Persistence.Implementation
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private const string path = @"Dummy\data-dummy.json";
        private const string EmailMagicLinkpath = @"EmailTemplates\MagicLink.html";
        public async Task<AuthenticationResponse<bool>> Login(string email)
        {
            var authenticationResponse = new AuthenticationResponse<bool>();
            try
            {
                if (!StringExtensions.IsValidEmail(email))
                {
                    throw new EmailFotmatInvalidException("Email format invalid");
                }

                EmailData emails = await JsonFiles<EmailData>.ReadFileToObject(path);
                authenticationResponse.Token = AuthenticationTokenGenerator.GenerateJwtToken(email, email);
                EmailUtility.SendEmail(email, "Inicio de Session", HtmlFiles.LoadHtmlFromFile(EmailMagicLinkpath));
                authenticationResponse.Data = emails?.Emails?.Contains(email) ?? throw new NoEmailFoundException("This user cannot be found registered");
            }
            catch (EmailFotmatInvalidException ex)
            {

                authenticationResponse.Error = ex.Message;
            }
            catch (NoEmailFoundException ex)
            {

                authenticationResponse.Error = ex.Message;
            }
            catch (Exception ex)
            {
                authenticationResponse.Error = ex.Message;
            }
            return authenticationResponse;
        }

    }
}
