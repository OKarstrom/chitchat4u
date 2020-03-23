using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace chat.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDataBaseRepository dataBaseRepository;
        private readonly ILogger<ChatController> logger;

        public ChatController(UserManager<ApplicationUser> userManager, IDataBaseRepository dataBaseRepository, ILogger<ChatController> logger)
        {
            this.userManager = userManager;
            this.dataBaseRepository = dataBaseRepository;
            this.logger = logger;
        }
        // GET: Chat
        public ActionResult Index()
        {

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//Get ID
            //ChatVM chatVM = new ChatVM();
            //chatVM.Connections = dataBaseRepository.GetAllConnections(userId);
            ChatVM chatVM = GetChatVM();

            return View(chatVM);
        }

        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost("chat/{connectionId}")]
        public ActionResult Index([FromRoute] int connectionId)
        {

            //logger.LogInformation("Cinnection id" + connectionId);
            ChatVM chatVM = GetChatVM(connectionId);
            return View();

        }

        private ChatVM GetChatVM(int connectionId = -1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ChatVM chatVM = new ChatVM();
            chatVM.Connections = dataBaseRepository.GetAllConnections(userId);
            ConnectionVM tmpCvm = new ConnectionVM();
            //Find selected connection
            foreach (ConnectionVM cvm in chatVM.Connections)
            {
                if (cvm.Id == connectionId)
                {
                    connectionId = cvm.Id;
                    tmpCvm = cvm;
                }
            }

            //If not found assign first connection
            if (connectionId == -1 && chatVM.Connections.Count > 0)
            {
                connectionId = chatVM.Connections[0].Id;
                tmpCvm = chatVM.Connections[0];
            }

            //Get friend id
            foreach(UserDetails ud in tmpCvm.UserList)
            {
                if (ud.Id != userId)
                    chatVM.CurrentFriendId = ud.Id;
            }
            chatVM.SelectedConnection = connectionId;
            chatVM.Messages = dataBaseRepository.GetMessages(connectionId);
            chatVM.CurrentUserId = userId;

            return chatVM;
        }
    }
    
}