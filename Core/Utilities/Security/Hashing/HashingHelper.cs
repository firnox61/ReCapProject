using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {//password vericez karşılığında out byte[] passwordHash, out byte[] passwordSalt alıcaz
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }//verdiğimiz passworda karşılık salt olarak bu metodun keyini ve hash olarak bytesını variyoruz
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {//benim verdiğim paswordu hashlayıp saltlayıp veritabanındaki hash ve saltla kıyaslayarak doğrulunu kanıtlayacak
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                 
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//i UTF-8 kodlamasına dönüştürerek, password değişkeninin içeriğini bir byte dizisine dönüştürüyor.
                for (int i = 0; i < computedHash.Length; i++)//hashleri burada karşılaştırıyoruz
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}

