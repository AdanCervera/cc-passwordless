using CC.Passwordless.API.Models.Response;

namespace CC.Passwordless.API.Persistence.Abstractions
{
    public interface IAuthenticationRepository
    {
        Task<AuthenticationResponse<bool>> Login(string email);
    }
}
