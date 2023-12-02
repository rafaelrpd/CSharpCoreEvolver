namespace CoreService.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<AuthDetail> Authenticate(string username, string password);
    }
}