namespace CoreService.Authentication
{
    public struct AuthDetail
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}