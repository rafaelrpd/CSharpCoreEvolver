using CoreApi.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using CoreService;
using CoreService.Authentication;

namespace CoreApi.Controllers
{
    public class AuthController : Controller
    {
        protected readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<AuthenticationDetails> Login(LoginModel loginModel)
        {
            return await _authService.Authenticate(loginModel.UserName, loginModel.Password);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            throw new NotImplementedException();
        }
    }
}