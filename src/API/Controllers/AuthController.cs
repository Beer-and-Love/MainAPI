using API.Token;
using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTO;
namespace API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator, IMapper mapper, IUserService uservice)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
            _userService = uservice;
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
           var userdto = new UserDto();
            try
            {
                if (loginViewModel.Login == userdto.Email && loginViewModel.Password == userdto.Password )
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com Sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
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