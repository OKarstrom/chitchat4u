﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chat.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            logger.LogInformation("AccountController index called (Post)");

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = register.Email, Email = register.Email};
                var result = await userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    //Goto chat
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "chat");
                }

                foreach (var error in result.Errors)
                {
                    //Show in register view
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            logger.LogInformation("AccountController Login called (Get)");
        

                return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            logger.LogInformation("AccountController Login called (Post)");
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("index", "chat");
                ModelState.AddModelError("", "Login failed");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            logger.LogInformation("AccountController Logout called (Post)");
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}