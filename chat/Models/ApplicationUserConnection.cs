using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ApplicationUserConnection
    {
        public string ApplicationUserID { get; set; }
        public ApplicationUser AppUser { get; set; }

        public int ConnectionID { get; set; }
        public Connection Connection { get; set; }
    }
}
