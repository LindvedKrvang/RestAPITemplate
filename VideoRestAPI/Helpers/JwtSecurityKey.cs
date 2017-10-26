using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace VideoRestAPI.Helpers
{
    public static class JwtSecurityKey
    {
        private static byte[] secureBytes = Encoding.UTF8.GetBytes("A secret for HmacSha256");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(secureBytes); }
        }

        public static void SetSecret(string secret)
        {
            secureBytes = Encoding.UTF8.GetBytes(secret);
        }
    }
}
