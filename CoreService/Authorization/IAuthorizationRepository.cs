namespace CoreService.Authorization
{
    public interface IAuthorizationRepository
    {
        Task<List<string>> GetPermissions(string token);
    }
}
