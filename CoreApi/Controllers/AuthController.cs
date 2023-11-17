using CoreApi.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            throw new NotImplementedException();
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