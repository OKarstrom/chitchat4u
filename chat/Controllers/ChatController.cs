using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace chat.Controllers
{
    public class ChatController : Controller
    {
    // GET: Chat
    public ActionResult Index()
        {
                return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
    }
}