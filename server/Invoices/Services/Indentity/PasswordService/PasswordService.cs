using Invoices.Identity.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Invoices.Services.Indentity.PasswordService
{
    public class PasswordService : IPasswordService
    {
        public Password CreateHashAndSalt(string password)
        {
            using var hmac = new HMACSHA512();
            
            return new Password
            {
                Salt = hmac.Key,
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
            };
        }

        public bool CheckPassword(byte[] hash, byte[] salt, string password)
        {
            using var hmac = new HMACSHA512(salt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            return computedHash.SequenceEqual(hash);
        }
    }
}
