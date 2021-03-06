﻿using Invoices.Logger.Database;
using Invoices.Logger.Database.Entities;
using Invoices.Logger.Models.Output;
using Invoices.Shared.Models.MessageModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Logger.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly InvoicesLoggerDbContext context;

        public LoggerService(InvoicesLoggerDbContext context)
        {
            this.context = context;
        }

        public async Task<LogOutput[]> AllAsync()
            => await this.context.Logs.Select(l => new LogOutput
            {
                User = l.User,
                IpAddress = l.IpAddress,
                Controller = l.Controller,
                Action = l.Action,
                Arguments = l.Arguments,
                ExceptionMessage = l.ExceptionMessage,
                ExceptionType = l.ExceptionType,
                StackTrace = l.StackTrace,
                Date = l.Date
            })
            .ToArrayAsync();

        public async Task LogAsync(LogMessage message)
        {
            await this.context.AddAsync(new Log 
            {
                User = message.User,
                IpAddress = message.IpAddress,
                Controller = message.Controller,
                Action = message.Action,
                Arguments = message.Arguments,
                ExceptionMessage = message.ExceptionMessage,
                ExceptionType = message.ExceptionType,
                StackTrace = message.StackTrace
            });
            await this.context.SaveChangesAsync();
        }
    }
}
