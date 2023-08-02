using CC.Passwordless.API.Models;
using CC.Passwordless.API.Persistence.Abstractions;
using CC.Passwordless.Utils.Extensions;
using CC.Passwordless.Utils.Files;

namespace CC.Passwordless.API.Persistence.Implementation
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private const string path = @"Dummy\data-dummy.json";
        public async Task<bool> Login(string email)
        {
            if (!StringExtensions.IsValidEmail(email))
            {
                return false;
            }

            EmailData emails = await JsonFiles<EmailData>.ReadFileToObject(path);

            return emails?.Emails?.Contains(email) ?? false;
        }

    }
}
