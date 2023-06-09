using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(long userID); 
        int ExtractUserId(string token);
    }
}