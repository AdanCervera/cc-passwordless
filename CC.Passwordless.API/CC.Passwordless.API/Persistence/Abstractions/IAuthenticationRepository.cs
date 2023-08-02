namespace CC.Passwordless.API.Persistence.Abstractions
{
    public interface IAuthenticationRepository
    {
        Task<bool> Login(string email);
    }
}
