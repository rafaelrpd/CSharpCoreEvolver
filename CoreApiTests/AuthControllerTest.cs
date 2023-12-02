using CoreApi.Controllers;
using CoreApi.Models.Auth;
using CoreService;
using CoreService.Authentication;
using CoreService.Authorization;

namespace CoreApiTests
{
    [TestClass]
    public class AuthControllerTest
    {
        private AuthController authController;
        private AuthenticationRepositoryMock authenticationRepositoryMock = new AuthenticationRepositoryMock();
        private AuthorizationRepositoryMock authorizationRepositoryMock = new AuthorizationRepositoryMock();

        public AuthControllerTest()
        {
            var authService = new AuthService(authenticationRepositoryMock, authorizationRepositoryMock);
            authController = new AuthController(authService);
        }

        [TestInitialize]
        public void Init()
        {
            authenticationRepositoryMock.Add("arroz", "feijao", "123");
            authenticationRepositoryMock.Add("xibiu", "ximboca", "456");
        }

        [TestCleanup]
        public void Cleanup()
        {
            authenticationRepositoryMock.Clear();
            authorizationRepositoryMock.permissions.Clear();
        }

        [TestMethod]
        public async Task TestUserArrozAuthenticationSuccess()
        {
            // Given
            authorizationRepositoryMock.permissions.Add("CriarOrdemDeServiços");

            // When
            var result = await authController.Login(new LoginModel
            {
                UserName = "arroz",
                Password = "feijao"
            });

            // Then
            Assert.IsNotNull(result);
            Assert.AreEqual("123", result.Token);
            Assert.AreEqual("CriarOrdemDeServiços", result.Permissions.FirstOrDefault());
        }

        [TestMethod]
        public async Task TestUnexistentUserAuthenticationFail()
        {
            try
            {
                var result = await authController.Login(new LoginModel
                {
                    UserName = "passarinho",
                    Password = "gaiola"
                });

                Assert.Fail("Usuário foi autenticado com credenciais inválidas.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public async Task TestLoginXibiuAuthenticationSuccessWithoutPermission()
        {
            var result = await authController.Login(new LoginModel
            {
                UserName = "xibiu",
                Password = "ximboca"
            });

            Assert.AreEqual(0, result.Permissions.Count());
            Assert.AreEqual("456", result.Token);
        }

        private class AuthenticationRepositoryMock : IAuthenticationRepository
        {
            private Dictionary<string, string> ValidCredentials { get; set; } = new Dictionary<string, string>();

            public Task<AuthDetail> Authenticate(string username, string password)
            {
                var credential = username + ":" + password;
                if (ValidCredentials.TryGetValue(credential, out string token))
                {
                    return Task.FromResult(new AuthDetail() { Token = token, Expiration = DateTime.Now.AddMinutes(30) });
                }

                return Task.FromException<AuthDetail>(new UnauthorizedAccessException("Credenciais inválidas"));
            }

            public void Add(string username, string password, string token)
            {
                var credential = username + ":" + password;
                ValidCredentials.Add(credential, token);
            }

            public void Clear()
            {
                ValidCredentials.Clear();
            }
        }

        private class AuthorizationRepositoryMock : IAuthorizationRepository
        {
            public List<string> permissions = new List<string>()
            {
            };

            public Task<List<string>> GetPermissions(string token)
            {
                return Task.FromResult(permissions);
            }
        }
    }
}