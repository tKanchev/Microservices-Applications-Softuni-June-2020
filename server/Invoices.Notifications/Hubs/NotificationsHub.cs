﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Invoices.Notifications.Hubs
{
    public class NotificationsHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                await this.Groups.AddToGroupAsync(
                    this.Context.ConnectionId,
                    Constants.AuthenticatedUsersGroup);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                await this.Groups.RemoveFromGroupAsync(
                    this.Context.ConnectionId,
                    Constants.AuthenticatedUsersGroup);
            }
        }
    }
}
