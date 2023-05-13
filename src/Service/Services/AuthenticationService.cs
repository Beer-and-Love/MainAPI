using Infra.Interfaces;
using Domain.Entities;
using BCrypt.Net;
using Service.Interfaces;
namespace Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository; // Repositório de usuários

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> VerifyPassword(string email, string enteredPassword)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
                return false;

           
            var hashedPassword = user.Password; 
            if (hashedPassword == enteredPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}