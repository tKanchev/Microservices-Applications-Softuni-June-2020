using Invoices.Data.Entities;

namespace Invoices.Services.Indentity.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
