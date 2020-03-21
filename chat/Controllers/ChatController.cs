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

        public ChatController(UserManager<ApplicationUser> userManager, IDataBaseRepository dataBaseRepository)
        {
            this.userManager = userManager;
            this.dataBaseRepository = dataBaseRepository;
        }
    // GET: Chat
    public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//Get ID
            List<ConnectionVM> connectionList = dataBaseRepository.GetAllConnections(userId);
            ChatVM cVM = new ChatVM();

            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
    }
}