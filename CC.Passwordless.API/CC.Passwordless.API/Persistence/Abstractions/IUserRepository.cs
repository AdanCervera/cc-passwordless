namespace CC.Passwordless.API.Persistence.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> isEmailExists(string email);
    }
}
