using Refit;
using System;
using System.Threading.Tasks;

namespace Invoices.Management.HttpServices
{
    public interface IHttpUserService
    {
        [Get("/users/getUserIdByIdNumber")]
        Task<Guid> GetUserIdByIdNumber(string idNumber);
    }
}
