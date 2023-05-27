using Infra.Interfaces;
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

        public async Task<long> IdForToken(string email)
        {
            var userId = await _userRepository.GetByEmail(email);
            return userId.Id;

        }

    }
}