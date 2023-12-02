using CoreService.Authentication;
using CoreService.Authorization;

namespace CoreService
{
    public partial class AuthService
    {
        private readonly IAuthenticationRepository _repository;
        private readonly IAuthorizationRepository _authorizationRepository;

        public AuthService(
            IAuthenticationRepository repository,
            IAuthorizationRepository authorizationRepository)
        {
            _repository = repository;
            _authorizationRepository = authorizationRepository;
        }

        public async Task<AuthenticationDetails> Authenticate(string username, string password)
        {
            var auth = await _repository.Authenticate(username, password);
            var permissions = await _authorizationRepository.GetPermissions(auth.Token);

            return new AuthenticationDetails() { Expiration = auth.Expiration, Token = auth.Token, Permissions = permissions};
        }

        //public string GenerateJwtToken(string userName)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes(builder.Configuratin);
        //}
    }
}
