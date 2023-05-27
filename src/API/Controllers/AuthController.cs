using API.Token;
using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using BCrypt.Net;
using Service.Services;
namespace API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public AuthController(IAuthenticationService authenticationService, IConfiguration configuration,
        ITokenGenerator tokenGenerator, IUserService userService)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var isPasswordValid = await _authenticationService.VerifyPassword(loginViewModel.Email, loginViewModel.Password);

                if (isPasswordValid)
                {
                    var userId = await _authenticationService.IdForToken(loginViewModel.Email);
                    var token = _tokenGenerator.GenerateToken(userId); 


                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = token,
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}