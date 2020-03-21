using System;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDataBaseRepository dataBaseRepository;

        public AccountController(
            ILogger<HomeController> logger, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IDataBaseRepository dataBaseRepository)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataBaseRepository = dataBaseRepository;
        }

        public IActionResult Register()
        {
            List<ApplicationUser> u = dataBaseRepository.GetAllUsers();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            logger.LogInformation("AccountController index called (Post)");

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = register.Username, Email = register.Email};
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
        public IActionResult ChangePassword()
        {
            logger.LogInformation("AccountController Changepassword called (Get)");
            return View();
        }

        public IActionResult ChangeUsername()
        {
            logger.LogInformation("AccountController Changeusername called (Get)");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword changepassword)
        {
            logger.LogInformation("AccountController ChangePassword called (Post)");

            if(ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(this.User);
                var result = await userManager.ChangePasswordAsync(user, changepassword.OldPassword, changepassword.NewPassword);

                if (result.Succeeded)
                {
                    Console.WriteLine("Success");
                    return RedirectToAction("index", "chat");
                    
                }
                foreach (var error in result.Errors)
                {
                    //Show in register view
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(changepassword);
        }

/*        [HttpPost]
        public async Task<IActionResult> ChangeUsername(ChangeUsername changeUsername)
        {
            logger.LogInformation("AccountController ChangePassword called (Post)");

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(this.User);
                var result = userManager.
                

                if (result.Succeeded)
                {
                    Console.WriteLine("Success");
                    return RedirectToAction("index", "chat");

                }
                foreach (var error in result.Errors)
                {
                    //Show in register view
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(changeUsername);
        }*/

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
                var user = await userManager.GetUserAsync(this.User);
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("index", "home");
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

        [HttpGet]
        public IActionResult DeleteAccount()
        {
            logger.LogInformation("AccountController DeleteAccount called (Get)");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(DeleteAccount delete)
        {
            logger.LogInformation("AccountController DeleteAccount called (Post)");

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(this.User);
                var result = await signInManager.PasswordSignInAsync(user.Email, delete.Password, false, false);
                if (result.Succeeded)
                {
                    var result2 = await userManager.DeleteAsync(user);
                    if (result2.Succeeded)
                    {
                        await Logout();
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        foreach (var error in result2.Errors)
                        {
                            //Show in register view
                            ModelState.AddModelError("", error.Description);
                        }
                    }                
                }                             
            }
            return View(delete);
        }
    }
}
