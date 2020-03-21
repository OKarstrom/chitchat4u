using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using chat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDataBaseRepository dataBaseRepository;

        public ChatHub(IDataBaseRepository dataBaseRepository)
        {
            this.dataBaseRepository = dataBaseRepository;
        }

        public async Task SendMessage(string[] user, string message)
        {
            //Sender id => this.Context.UserIdentifier);
            IReadOnlyList<string> list = user.ToList();
            await Clients.Users(list).SendAsync("ReceiveMessage", user, message);
           
        }

    }
}