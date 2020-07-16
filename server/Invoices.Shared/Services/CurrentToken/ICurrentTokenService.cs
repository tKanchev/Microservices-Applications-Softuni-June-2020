namespace Invoices.Shared.Services.CurrentToken
{
    public interface ICurrentTokenService
    {
        string Get();

        void Set(string token);
    }
}
