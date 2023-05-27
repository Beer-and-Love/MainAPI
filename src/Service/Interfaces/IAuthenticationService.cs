using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> VerifyPassword(string email, string enteredPassword);
        Task<long> IdForToken(string email);
    }

}