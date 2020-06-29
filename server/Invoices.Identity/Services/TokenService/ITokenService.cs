using Invoices.Identity.Database.Entities;

namespace Invoices.Identity.Services.TokenService
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
