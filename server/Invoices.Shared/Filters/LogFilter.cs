using Invoices.Shared.Extensions;
using Invoices.Shared.Models;
using Invoices.Shared.Models.MessageModels;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Invoices.Shared.Filters
{
    public class LogFilter : IActionFilter
    {
        private readonly IBus publisher;

        public LogFilter(IBus publisher)
        {
            this.publisher = publisher;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                Exception baseException = context.Exception.GetBaseException();

                publisher.Publish(new LogMessage
                {
                    User = context.HttpContext.User.Identity.Name,
                    IpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Controller = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName,
                    Action = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName,
                    ExceptionMessage = baseException.Message,
                    ExceptionType = context.Exception.GetType().ToString(),
                    StackTrace = context.Exception.StackTrace
                });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StringBuilder arguments = new StringBuilder();

            context.ActionArguments
                .ForEach(arg =>
                {
                    arguments.Append(JsonConvert.SerializeObject(arg));
                });

            publisher.Publish(new LogMessage
            {
                Date = DateTime.Now,
                User = context.HttpContext.User.Identity.Name,
                IpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                Controller = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName,
                Action = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName,
                Arguments = arguments.ToString()
            });
        }
    }
}
