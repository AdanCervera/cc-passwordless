namespace CC.Passwordless.API.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<bool> Login(string email);
    }
}
