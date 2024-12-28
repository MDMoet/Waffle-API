using Azure;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Waffle_API.Classes;
using Waffle_API.Models;

namespace Waffle_API.Controllers
{
    [Route("[controller]/auth")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var result = await _authService.Login(user);
            // Set refresh token in cookie or return tokens in response
            Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions { HttpOnly = true, Secure = true });
            return Ok(new { AccessToken = result.AccessToken });
        }
    }
    public class AuthService
    {
        private readonly IUser _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> LoginAsync(LoginModel loginModel)
        {
            // Validate credentials, generate tokens, etc.
            var user = await _userRepository.ValidateUserCredentials(loginModel.Username, loginModel.Password);

            if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken(user);

            return new LoginResponse { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }

}
