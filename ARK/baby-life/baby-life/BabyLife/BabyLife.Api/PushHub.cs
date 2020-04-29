using BabyLife.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api
{
    public class PushHub : Hub
    {
        public async Task Send(Sleeping sleeping, User user)
        {
            var message = "Let your baby to sleep";

            await Clients.Caller.SendAsync("Receive", user, message);
        }
    }
}
