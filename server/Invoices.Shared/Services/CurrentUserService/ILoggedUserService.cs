namespace Invoices.Shared.Services.CurrentUserService
{
    public interface ILoggedUserService
    {
        string UserId { get; }

        bool IsAdmin { get; }
    }
}
