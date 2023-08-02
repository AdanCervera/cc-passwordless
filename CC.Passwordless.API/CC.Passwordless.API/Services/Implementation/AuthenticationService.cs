using CC.Passwordless.API.Persistence.Abstractions;
using CC.Passwordless.API.Services.Abstractions;

namespace CC.Passwordless.API.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repository;
        public AuthenticationService(IAuthenticationRepository repository) {
        _repository = repository;
        }
        public async Task<bool> Login(string email)
        {
            return await _repository.Login(email);
        }
    }
}
