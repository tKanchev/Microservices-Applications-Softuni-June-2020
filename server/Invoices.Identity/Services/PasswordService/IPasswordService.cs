using Invoices.Identity.Models;

namespace Invoices.Identity.Services.PasswordService
{
    public interface IPasswordService
    {
        Password GenerateHashAndSalt(string password);

        bool CheckPassword(byte[] hash, byte[] salt, string password);
    }
}
