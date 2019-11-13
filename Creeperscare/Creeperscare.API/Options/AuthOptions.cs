using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creeperscare.API.Options
{
    public class AuthOptions
    {
        public const string Issuer = "TokenIssuer";
        public const string Audience = "http://localhost:5000/";
        public const string Key = "fdkjfhkerjwoewkddkvbdfkw";
        public const int Lifetime = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
