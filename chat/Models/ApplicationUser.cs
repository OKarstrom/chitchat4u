using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Connections = new List<ApplicationUserConnection>();
            this.Messages = new List<Message>();
        }
        public virtual List<ApplicationUserConnection> Connections { get; set; }
        public virtual List<Message> Messages { get; set; }
        [PersonalData]
        public string DisplayName { get; set; }
        
    }
}
