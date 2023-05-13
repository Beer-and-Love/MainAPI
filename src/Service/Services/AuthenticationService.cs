using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Interfaces;
using Domain.Entities;
using BCrypt.Net;

namespace Service.Services
{
    public class AuthenticationService
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

            // Lógica de verificação da senha com bcrypt
            var hashedPassword = user.Password; // Obtém o hash da senha armazenada
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

    }
}