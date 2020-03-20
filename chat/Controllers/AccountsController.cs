using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IDataBaseRepository dataBaseRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountsController( IDataBaseRepository dataBaseRepository, UserManager<ApplicationUser> userManager)
        {
            this.dataBaseRepository = dataBaseRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetConnections()
        {
           ///var u = appDbContext.UserConnections.Where(c => c.ApplicationUserID == id).Select(s => s.Connection).Select(s => s.Users.Where(s => s.ApplicationUserID != id));
            return Ok("\"Hej\":1");
        }



        //[HttpGet("{account}")]
        //public IActionResult GetAccount([FromRoute] int account)
        //{

        //    try
        //    {
        //        return Ok(JsonSerializer.Serialize(
        //            AccountsService.GetAccounts().First(a => a.Number == account)));
        //    }
        //    catch { }

        //    return NotFound($"Requested account number {account} does not exist");
        //}

        //[HttpPut("transfer")]
        //public IActionResult transferPut([FromBody] Transaction trans)
        //{
        //    string result = AccountsService.Transfer(trans);

        //    if (result.Length > 0)
        //        return Conflict(result);
        //    else
        //        return Ok();
        //}

        [HttpPost("connection")]
        public IActionResult TransferConnection([FromBody] string[] id)
        {
            List<string> idList = id.ToList<string>();
            idList.Add(userManager.GetUserId(this.User));
            dataBaseRepository.AddConnection(idList);

            return Ok();
        }
    }
}