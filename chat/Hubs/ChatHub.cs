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

        public async Task SendMessage(string user, string message)
        {
           
            List<Connection> s = dataBaseRepository.GetAllConnections(Context.UserIdentifier);
            Connection c = new Connection();
            var d = dataBaseRepository.GetAllConnections(Context.UserIdentifier);

            var u = Context.User;
            var ui = Context.UserIdentifier;
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.User("53a3c311-044a-4bca-90d9-5fc3c9e188f3").SendAsync("ReceiveMessage", user, message);
           
        }

    }
}