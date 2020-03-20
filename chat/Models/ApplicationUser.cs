﻿using Microsoft.AspNetCore.Identity;
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
        }
        public virtual List<ApplicationUserConnection> Connections { get; set; }
        [PersonalData]
        public string DisplayName { get; set; }
        
    }
}
