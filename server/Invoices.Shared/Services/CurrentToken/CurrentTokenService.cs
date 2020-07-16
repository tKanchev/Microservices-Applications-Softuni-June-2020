namespace Invoices.Shared.Services.CurrentToken
{
    public class CurrentTokenService : ICurrentTokenService
    {
        private string currentToken;

        public string Get() => this.currentToken;

        public void Set(string token) => this.currentToken = token;
    }
}
