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

            List<string> tmplist = user.ToList();
            int.TryParse(tmplist[tmplist.Count - 1], out int connectionID);
            tmplist.RemoveAt(tmplist.Count - 1);
            IReadOnlyList<string> list = tmplist;

            await Clients.Users(list).SendAsync("ReceiveMessage", user[0], message);
            await dataBaseRepository.SaveMessage(message, user[0], connectionID);
            return;
           
        }

    }
}