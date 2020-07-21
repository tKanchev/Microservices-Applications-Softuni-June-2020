using Invoices.Shared.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Shared.Controllers
{
    [Log]
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";
    }
}
