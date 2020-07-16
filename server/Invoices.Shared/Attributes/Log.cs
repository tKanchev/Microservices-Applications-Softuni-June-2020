using Invoices.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Shared.Attributes
{
    public class Log : TypeFilterAttribute
    {
        public Log()
            : base(typeof(LogFilter))
        {
        }
    }
}
