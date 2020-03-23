using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ConnectionVM
    {
        public ConnectionVM()
        {
            this.UserList = new List<UserDetails>();
        }
        public int Id { get; set; }
        public List<UserDetails> UserList { get; set; }

    }
    public class UserDetails
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
