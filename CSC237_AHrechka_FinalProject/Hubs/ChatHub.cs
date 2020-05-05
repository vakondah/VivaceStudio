using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Hubs
{
    public class ChatHub: Hub
    {
        // This hub will get a message and transmit it to all clients:
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
