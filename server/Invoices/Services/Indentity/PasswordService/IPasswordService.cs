using Invoices.Identity.Models;

namespace Invoices.Services.Indentity.PasswordService
{
    public interface IPasswordService
    {
        Password CreateHashAndSalt(string password);

        bool CheckPassword(byte[] hash, byte[] salt, string password);
    }
}
