using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {//json weptokenlarının oluşturulabilmesi sistemi kullanabilmek için elimizde olanlar burası .netcore için
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);//hangi anahtar ve hangi algoritmayo kullanacağını veriyoruz
        }
    }
}
