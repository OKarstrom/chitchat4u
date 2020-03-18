using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            this.Connections = new HashSet<ApplicationUserConnection>();
        }
        public virtual ICollection<ApplicationUserConnection> Connections { get; set; }
    }
}
