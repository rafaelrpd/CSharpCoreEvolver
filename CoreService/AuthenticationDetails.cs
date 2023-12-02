namespace CoreService
{
    public class AuthenticationDetails
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public List<string> Permissions { get; set; }
    }
}