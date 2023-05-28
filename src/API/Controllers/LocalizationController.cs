using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using API.Token;

namespace API.Controllers
{
    public class LocalizationController : ControllerBase
    {
        private readonly ILocalizationService _localizationService;
        private readonly ITokenGenerator _tokenGenerator;
        
        [HttpPost("/api/updateLocalization")]
        public IActionResult UpdateUserLocalization([FromBody] LocalizationDto localizationDto)
        {
            // Obter o token de autenticação do cabeçalho da requisição
            string token = Request.Headers["Authorization"].ToString();

            // Obter o ID do usuário atual com base no token de autenticação
            int currentUserId = _tokenGenerator.ExtractUserId(token);

            if (currentUserId == 0)
            {
                return Unauthorized();
            }
            
            _localizationService.UpdateUserLocalization(currentUserId, localizationDto);

            return Ok();
        }


        [HttpPost("/api/distances")]
        public IActionResult CalculateDistance([FromBody] string city)
        {
            string token = Request.Headers["Authorization"].ToString();
            int currentUserId = _tokenGenerator.ExtractUserId(token);

            if (currentUserId == 0)
            {
                return Unauthorized();
            }
            _localizationService.CalculateDistance(city, currentUserId);
            return (IActionResult)_localizationService.CalculateDistance(city, currentUserId);;
        }
    }
}