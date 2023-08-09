using CC.Passwordless.API.Models;
using CC.Passwordless.API.Persistence.Abstractions;
using CC.Passwordless.Exceptions.Authentication;
using CC.Passwordless.Utils.Files;

namespace CC.Passwordless.API.Persistence.Implementation
{
    public class UserRepository : IUserRepository
    {
        private const string path = @"Dummy\data-dummy.json";
        public async Task<bool> isEmailExists(string email)
        {
           EmailData emails = await new JsonFiles().ReadFileToObject(path);
           return (bool)(email != null ? (emails?.Emails?.Contains(email)) : throw new NoEmailFoundException("This user is not registered.")); 
        }

    }
}
